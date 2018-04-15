using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using PEPlugin;
using PEPlugin.Pmx;
using PEPlugin.SDX;

using WPlugins.Common;

namespace WPlugins.ObjImport
{
	[Serializable]
	public class PolygonException : Exception
	{
		public int Count { get; }
		public int LineNumber { get; }
		public PolygonException() { }
		public PolygonException(string message) : base(message) { }
		public PolygonException(string message, int count, int LineNumber) : base(message) { this.Count = count; this.LineNumber = LineNumber; }
		public PolygonException(string message, Exception inner) : base(message, inner) { }
		protected PolygonException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}

	class ObjFileImporter
	{
		public string ObjFileName;
		private IPXPmxBuilder builder;
		private readonly ObjImportSettings settings;
		private List<IPXVertex> vertices;
		private Dictionary<string, IPXMaterial> materials;          //Sub-objects in the PMX scene
		private Dictionary<string, IPXMaterial> uniqueMaterials;    //Unique materials in the MTL file
		private List<V3> vList;
		private List<V2> vtList;
		private List<V3> vnList;
		private Dictionary<string, int> vertexDict;
		private bool loadWithoutMaterials = false;

		private Dictionary<string, IPXMaterial> ReadMaterialLibrary(string path)
		{
			Dictionary<string, IPXMaterial> output = new Dictionary<string, IPXMaterial>();
			string mtlPath = path;
			IPXMaterial mat = null;

			if (!File.Exists(mtlPath))
			{
				if (MessageBox.Show("Material library not found:\n" + path + "\n\nWould you like to select the MTL file manually?", "Error: MTL file not found", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
				{
					OpenFileDialog dialog = new OpenFileDialog
					{
						Multiselect = false,
						InitialDirectory = Path.GetDirectoryName(path),
						Title = "Select the material library",
						Filter = "Wavefront material library|*.mtl|All files|*.*"
					};
					dialog.ShowDialog();
					mtlPath = dialog.FileName;
				}
				else
				{
					if (MessageBox.Show("Would you like to load the model without materials?", "Error: MTL file not found", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						loadWithoutMaterials = true;
					}
				}
			}

			using (StreamReader reader = new StreamReader(mtlPath))
			{
				string line;
				string[] tok;

				while (!reader.EndOfStream)
				{
					line = reader.ReadLine();
					if (string.IsNullOrWhiteSpace(line) || line[0] == '#')
						continue;
					tok = line.Split(' ');

					switch (tok[0])
					{
						case "Kd":
							if (mat != null)
							{
								try
								{
									mat.Diffuse = new V4(float.Parse(tok[1]), float.Parse(tok[2]), float.Parse(tok[3]), 1.0f);
								}
								catch (FormatException) { }
							}
							break;
						case "Ks":
							if (mat != null)
							{
								try
								{
									mat.Specular = new V3(float.Parse(tok[1]), float.Parse(tok[2]), 1.0f);
								}
								catch (FormatException) { }
							}
							break;
						case "Ns":
							if (mat != null)
							{
								try
								{
									mat.Power = float.Parse(tok[1]);
								}
								catch (FormatException) { }
							}
							break;
						case "Ka":
							if (mat != null)
							{
								try
								{
									mat.Ambient = new V3(float.Parse(tok[1]), float.Parse(tok[2]), 1.0f);
								}
								catch (FormatException) { }
							}
							break;
						case "d":
							if (mat != null)
							{
								try
								{
									mat.Diffuse.A = float.Parse(tok[1]);
								}
								catch (FormatException) { }
							}
							break;
						case "Ke":
							if (mat != null)
							{
								try
								{
									mat.Ambient = new V3(float.Parse(tok[1]), float.Parse(tok[2]), 1.0f);
								}
								catch (FormatException) { }
							}
							break;
						case "map_Kd":
							if (mat != null)
							{
								mat.Tex = line.Trim().Substring(7, line.Length - 7);
								mat.Ambient = new V3(0.5f, 0.5f, 0.5f);
								mat.Diffuse = new V4(1.0f, 1.0f, 1.0f, mat.Diffuse.A);
							}
							break;
						case "newmtl":
							string name = line.Trim().Substring(7, line.Length - 7);
							if (!output.ContainsKey(name))
							{
								mat = builder.Material();
								mat.Name = mat.NameE = name;
								output.Add(name, mat);
							}
							break;
					}
				}
			}

			return output;
		}

		private void VertexElements(string f, out int v, out int vt, out int vn)
		{
			v = -1;
			vt = -1;
			vn = -1;

			string[] str = f.Trim().Split(new char[] { '/' }, StringSplitOptions.None);
			
			int.TryParse(str[0], out v);
			--v;
			int.TryParse(str[1], out vt);
			--vt;
			int.TryParse(str[2], out vn);
			--vn;
		}

		private int CreateVertex(int v, int vt, int vn)
		{
			string key = v.ToString() + '/' + vt.ToString() + '/' + vn.ToString();
			if (vertexDict.ContainsKey(key))
			{
				return vertexDict[key];
			}
			else
			{
				IPXVertex vert = builder.Vertex();
				if (v >= 0 && v <= vList.Count)
					vert.Position = vList[v];
				if (vt >= 0 && vt <= vtList.Count)
					vert.UV = vtList[vt];
				if (vn >= 0 && vn <= vnList.Count)
					vert.Normal = vnList[vn];
				int index = vertices.Count;
				vertices.Add(vert);
				vertexDict.Add(key, index);
				return index;
			}
		}

		public ObjFileImporter(string path, IPXPmxBuilder builder, ObjImportSettings settings)
		{
			this.builder = builder;
			this.settings = settings;
			this.ObjFileName = Path.GetFileNameWithoutExtension(path);
			vList = new List<V3>();
			vtList = new List<V2>();
			vnList = new List<V3>();
			vertexDict = new Dictionary<string, int>();
			vertices = new List<IPXVertex>();
			materials = new Dictionary<string, IPXMaterial>();

			IPXMaterial material = builder.Material();
			IPXMaterial template = null;
			using (StreamReader reader = new StreamReader(path))
			{
				string line;
				string[] tok;

				int lineNum = 0;
				string groupName;

				while (!reader.EndOfStream)
				{
					line = reader.ReadLine().Trim();
					++lineNum;
					if (string.IsNullOrWhiteSpace(line) || line[0] == '#')
						continue;
					tok = line.Split(' ');

					int v, vt, vn, v1, v2, v3, v4;

					switch (tok[0])
					{
						case "v":
							try
							{
								vList.Add(new V3(float.Parse(tok[1]), float.Parse(tok[2]), float.Parse(tok[3])));
							}
							catch (FormatException) { }
							break;
						case "vt":
							try
							{
								vtList.Add(new V2(float.Parse(tok[1]), float.Parse(tok[2])));
							}
							catch (FormatException) { }
							break;
						case "vn":
							try
							{
								vnList.Add(new V3(float.Parse(tok[1]), float.Parse(tok[2]), float.Parse(tok[3])));
							}
							catch (FormatException) { }
							break;
						case "f":
							//Construct triangle
							if (tok.Length == 4)
							{
								VertexElements(tok[1], out v, out vt, out vn);
								v1 = CreateVertex(v, vt, vn);
								if (v1 >= 0)
								{
									VertexElements(tok[2], out v, out vt, out vn);
									v2 = CreateVertex(v, vt, vn);
									if (v2 >= 0)
									{
										VertexElements(tok[3], out v, out vt, out vn);
										v3 = CreateVertex(v, vt, vn);
										if (v3 >= 0)
										{
											IPXFace face = builder.Face();
											face.Vertex1 = vertices[v1];
											face.Vertex2 = vertices[v2];
											face.Vertex3 = vertices[v3];
											material.Faces.Add(face);
										}
									}
								}
							}
							else if (tok.Length == 5)
							{
								VertexElements(tok[1], out v, out vt, out vn);
								v1 = CreateVertex(v, vt, vn);
								if (v1 >= 0)
								{
									VertexElements(tok[2], out v, out vt, out vn);
									v2 = CreateVertex(v, vt, vn);
									if (v2 >= 0)
									{
										VertexElements(tok[3], out v, out vt, out vn);
										v3 = CreateVertex(v, vt, vn);
										if (v3 >= 0)
										{
											VertexElements(tok[4], out v, out vt, out vn);
											v4 = CreateVertex(v, vt, vn);
											if (v4 >= 0)
											{
												IPXFace face = builder.Face();
												face.Vertex1 = vertices[v1];
												face.Vertex2 = vertices[v2];
												face.Vertex3 = vertices[settings.TurnQuads ? v3 : v4];
												material.Faces.Add(face);

												face = builder.Face();
												face.Vertex1 = vertices[settings.TurnQuads ? v1 : v2];
												face.Vertex2 = vertices[v3];
												face.Vertex3 = vertices[v4];
												material.Faces.Add(face);
											}
										}
									}
								}
							}
							else
								throw new PolygonException(line, tok.Length, lineNum);
							break;
						case "g":
							if (tok.Length >= 2)
							{
								groupName = line.Trim().Substring(2, line.Length - 2);
								material = builder.Material();
								material.Name = material.NameE = groupName;
								materials.Add(material.Name, material);
							}
							break;
						case "usemtl":
							if (loadWithoutMaterials || uniqueMaterials.Count <= 0)
							{
								material.Diffuse = new V4(1.0f, 1.0f, 1.0f, 1.0f);
								material.Ambient = new V3(0.5f, 0.5f, 0.5f);
								material.Specular = new V3(0.0f, 0.0f, 0.0f);
								material.Power = 10;
								material.Edge = false;
								material.SelfShadow = true;
								material.SelfShadowMap = true;
								material.Shadow = true;
							}
							else
							{
								string name = line.Trim().Substring(7, line.Length - 7);
								if (uniqueMaterials.ContainsKey(name))
								{
									template = uniqueMaterials[name];
									material.Diffuse = template.Diffuse;
									material.Ambient = template.Ambient;
									material.Specular = template.Specular;
									material.Tex = template.Tex;
									material.Power = template.Power;
									material.Edge = false;
									material.SelfShadow = true;
									material.SelfShadowMap = true;
									material.Shadow = true;
								}
							}
							break;
						case "mtllib":
							uniqueMaterials = ReadMaterialLibrary(Path.Combine(Path.GetDirectoryName(path), line.Trim().Substring(7, line.Length - 7).Trim()));
							break;
					}
				}
			}
		}

		public IPXPmx ToPmx()
		{
			MessageBox.Show("ToPmx begin");
			IPXPmx pmx = builder.Pmx();
			pmx.Clear();

			pmx.ModelInfo.ModelName = pmx.ModelInfo.ModelNameE = ObjFileName;

			//Register bone
			IPXBone bone = builder.Bone();
			bone.Name = bone.NameE = ObjFileName;
			switch (settings.CreateBone)
			{
				case ObjImportSettings.CreateBoneMode.Origin:
					bone.Position = new V3();
					break;
				case ObjImportSettings.CreateBoneMode.Average:
					V3 sum = new V3();
					foreach (var v in vList)
						sum += v;
					bone.Position = sum / vList.Count;
					break;
			}
			if (settings.CreateBone != ObjImportSettings.CreateBoneMode.None)
				pmx.Bone.Add(bone);

			//Register vertices
			foreach (IPXVertex v in vertices)
			{
				v.Position *= 10 * new V3(settings.ScaleX, settings.ScaleY, settings.ScaleZ);
				v.UV *= new V2(settings.ScaleU, settings.ScaleV);
				if (settings.CreateBone != ObjImportSettings.CreateBoneMode.None)
					v.Bone1 = bone;
				else
					v.Bone1 = pmx.Bone[0];
				v.Weight1 = 1.0f;
				pmx.Vertex.Add(v);
			}

			//Register materials and faces
			foreach (var m in materials)
			{
				if (settings.FlipFaces)
				{
					foreach (IPXFace f in m.Value.Faces)
					{
						IPXVertex temp = f.Vertex1;
						f.Vertex1 = f.Vertex3;
						f.Vertex3 = temp;
					}
				}
				pmx.Material.Add(m.Value);
			}

			//end
			MessageBox.Show("ToPmx end");
			return pmx;
		}
	}

	public class Main : IPEImportPlugin
	{
		private IPXPmxBuilder builder = PEStaticBuilder.Pmx;
		private IPXPmx pmx;
		private ObjImportForm form;

		public IPXPmx Import(string path, IPERunArgs args)
		{
			try
			{
				form = new ObjImportForm(path, args);
				form.ShowDialog();
				if (form.DialogResult == DialogResult.OK)
				{
					ObjFileImporter importer = new ObjFileImporter(path, builder, form.Settings);
					return importer.ToPmx();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"{ex}");
			}
			pmx = builder.Pmx();
			pmx.ModelInfo.ModelName = "fuck";
			return pmx;
		}

		public string Ext { get { return ".obj"; } }

		public string Caption { get { return "OBJ Import (WPlugins)"; } }
	}
}
