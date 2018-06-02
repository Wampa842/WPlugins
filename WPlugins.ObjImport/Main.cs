/*
Copyright (C) 2018 Wampa842

This file is part of WPlugins.

WPlugins is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

WPlugins is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Foobar.  If not, see <http://www.gnu.org/licenses/>.
*/
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
	class ObjFileImporter
	{
		public string ObjFileName { get; private set; }
		public int ErrorNum { get; private set; } = 0;
		public int ErrorNumMtl { get; private set; } = 0;
		public string LogFileUrl { get; } = System.Reflection.Assembly.GetExecutingAssembly().Location + ".log";
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
		private StreamWriter logger;

		private Dictionary<string, IPXMaterial> ReadMaterialLibrary(string path)
		{
			Dictionary<string, IPXMaterial> output = new Dictionary<string, IPXMaterial>();
			string mtlPath = path;
			IPXMaterial mat = null;

			if (!File.Exists(mtlPath))
			{
				logger.WriteLine("(MTL) File not found: " + mtlPath);
				if (MessageBox.Show("Material library not found:\n" + path + "\n\nWould you like to select the MTL file manually?", "MTL file not found", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
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
					loadWithoutMaterials = true;
				}
			}

			using (StreamReader reader = new StreamReader(mtlPath))
			{
				string line;
				string[] tok;
				int lineNum = 0;

				while (!reader.EndOfStream)
				{
					line = reader.ReadLine().Trim();
					++lineNum;
					if (string.IsNullOrWhiteSpace(line) || line[0] == '#')
						continue;
					tok = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


					switch (tok[0])
					{
						case "Kd":
							if (mat != null)
							{
								try
								{
									mat.Diffuse = new V4(float.Parse(tok[1]), float.Parse(tok[2]), float.Parse(tok[3]), 1.0f);
								}
								catch (FormatException)
								{
									logger.WriteLine($"ERROR (MTL) FormatException on line {lineNum}: {line}");
									this.ErrorNumMtl++;
								}
							}
							break;
						case "Ks":
							if (mat != null)
							{
								try
								{
									mat.Specular = new V3(float.Parse(tok[1]), float.Parse(tok[2]), float.Parse(tok[3]));
								}
								catch (FormatException)
								{
									logger.WriteLine($"ERROR (MTL) FormatException on line {lineNum}: {line}");
									this.ErrorNumMtl++;
								}
							}
							break;
						case "Ns":
							if (mat != null)
							{
								try
								{
									mat.Power = float.Parse(tok[1]);
								}
								catch (FormatException)
								{
									logger.WriteLine($"ERROR (MTL) FormatException on line {lineNum}: {line}");
									this.ErrorNumMtl++;
								}
							}
							break;
						case "Ka":
							if (mat != null)
							{
								try
								{
									mat.Ambient = new V3(float.Parse(tok[1]), float.Parse(tok[2]), 1.0f);
								}
								catch (FormatException)
								{
									logger.WriteLine($"ERROR (MTL) FormatException on line {lineNum}: {line}");
									this.ErrorNumMtl++;
								}
							}
							break;
						case "d":
							if (mat != null)
							{
								try
								{
									mat.Diffuse.A = float.Parse(tok[1]);
								}
								catch (FormatException)
								{
									logger.WriteLine($"ERROR (MTL) FormatException on line {lineNum}: {line}");
									this.ErrorNumMtl++;
								}
							}
							break;
						case "Ke":
							if (mat != null)
							{
								try
								{
									mat.Ambient = new V3(float.Parse(tok[1]), float.Parse(tok[2]), 1.0f);
								}
								catch (FormatException)
								{
									logger.WriteLine($"ERROR (MTL) FormatException on line {lineNum}: {line}");
									this.ErrorNumMtl++;
								}
							}
							break;
						case "map_Kd":
							if (mat != null)
							{
								mat.Tex = line.Trim().Substring(7, line.Length - 7);
								mat.Ambient = new V3(0.5f, 0.5f, 0.5f);
								mat.Diffuse = new V4(1.0f, 1.0f, 1.0f, mat.Diffuse.A);
							}
							else
							{
								logger.WriteLine($"ERROR (MTL) Missing newmtl for line {lineNum}");
								this.ErrorNumMtl++;
							}
							break;
						case "newmtl":
							string name;
							if (tok.Length <= 1)
							{
								logger.WriteLine($"ERROR (MTL) Invalid material declaration on line {lineNum}");
								this.ErrorNumMtl++;
								name = "material_" + lineNum.ToString();
							}
							else
								name = line.Trim().Substring(7, line.Length - 7);
							if (!output.ContainsKey(name))
							{
								mat = builder.Material();
								mat.Name = mat.NameE = name;
								output.Add(name, mat);
							}
							break;
					}
				}
				logger.WriteLine($"LOG (MTL) Finished ({this.ErrorNumMtl} errors)");
				logger.WriteLine($"LOG (MTL) Created {output.Count} materials");
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
				if (v >= 0 && v < vList.Count)
					vert.Position = vList[v];
				if (vt >= 0 && vt < vtList.Count)
					vert.UV = vtList[vt];
				if (vn >= 0 && vn < vnList.Count)
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

			using (logger = new StreamWriter(this.LogFileUrl))
			using (StreamReader reader = new StreamReader(path))
			{
				string line;
				string[] tok;

				int lineNum = 0;
				int vNum = 0;
				int vtNum = 0;
				int vnNum = 0;
				int fNum = 0;
				int triNum = 0;
				int quadNum = 0;
				int triOutNum = 0;
				int gNum = 0;
				string groupName;

				while (!reader.EndOfStream)
				{
					line = reader.ReadLine().Trim();
					++lineNum;
					if (string.IsNullOrWhiteSpace(line) || line[0] == '#')
						continue;
					tok = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

					int v, vt, vn, v1, v2, v3, v4;

					switch (tok[0])
					{
						case "v":
							try
							{
								vList.Add(new V3(float.Parse(tok[1]), float.Parse(tok[2]), -float.Parse(tok[3])));
							}
							catch (FormatException)
							{
								logger.WriteLine($"ERROR (OBJ) FormatException on line {lineNum}: {line}");
								this.ErrorNum++;
							}
							++vNum;
							break;
						case "vt":
							try
							{
								vtList.Add(new V2(float.Parse(tok[1]), -float.Parse(tok[2])));
							}
							catch (FormatException)
							{
								logger.WriteLine($"ERROR (OBJ) FormatException on line {lineNum}: {line}");
								this.ErrorNum++;
							}
							++vtNum;
							break;
						case "vn":
							try
							{
								vnList.Add(new V3(float.Parse(tok[1]), float.Parse(tok[2]), -float.Parse(tok[3])));
							}
							catch (FormatException)
							{
								logger.WriteLine($"ERROR (OBJ) FormatException on line {lineNum}: {line}");
								this.ErrorNum++;
							}
							++vnNum;
							break;
						case "f":
							++fNum;
							//Construct triangle
							if (tok.Length == 4)
							{
								++triNum;
								++triOutNum;
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
											face.Vertex3 = vertices[v1];
											face.Vertex2 = vertices[v2];
											face.Vertex1 = vertices[v3];
											material.Faces.Add(face);
										}
									}
								}
							}
							else if (tok.Length == 5)
							{
								++quadNum;
								++triOutNum;
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
												face.Vertex3 = vertices[v1];
												face.Vertex2 = vertices[v2];
												face.Vertex1 = vertices[settings.TurnQuads ? v3 : v4];
												material.Faces.Add(face);

												face = builder.Face();
												face.Vertex3 = vertices[settings.TurnQuads ? v1 : v2];
												face.Vertex2 = vertices[v3];
												face.Vertex1 = vertices[v4];
												material.Faces.Add(face);
											}
										}
									}
								}
							}
							else
							{
								logger.WriteLine($"ERROR (OBJ) Unsupported polygon ({tok.Length - 1} points) on line {lineNum}: {line}");
								this.ErrorNum++;
							}
							break;
						case "g":
							if (tok.Length >= 2)
							{
								groupName = line.Trim().Substring(2, line.Length - 2);
								material = builder.Material();
								material.Name = material.NameE = groupName;
								materials.Add(material.Name, material);
							}
							else
							{
								logger.WriteLine($"ERROR (OBJ) Invalid group definition on line {lineNum}: {line}");
								this.ErrorNum++;
							}
							++gNum;
							break;
						case "usemtl":
							string name = line.Trim().Substring(7, line.Length - 7);
							if (loadWithoutMaterials)
							{
								material.Diffuse = new V4(1.0f, 1.0f, 1.0f, 1.0f);
								material.Ambient = new V3(0.5f, 0.5f, 0.5f);
								material.Specular = new V3();
								material.Tex = "";
								material.Power = 10.0f;
								material.Edge = false;
								material.SelfShadow = true;
								material.SelfShadowMap = true;
								material.Shadow = true;
							}
							else
							{
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
								else
								{
									logger.WriteLine($"WARNING (OBJ) Material not found ({name}) on line {lineNum}");
									this.ErrorNum++;
								}
							}
							break;
						case "mtllib":
							uniqueMaterials = ReadMaterialLibrary(Path.Combine(Path.GetDirectoryName(path), line.Trim().Substring(7, line.Length - 7).Trim()));
							break;
					}
				}
				logger.WriteLine($"LOG (OBJ) Finished ({ErrorNum} errors)");
				logger.WriteLine($"LOG (OBJ) {vNum} vertices, {vtNum} texture coordinates, {vnNum} normal vectors, {fNum} face records ({triNum} triangles, {quadNum} quads), {triOutNum} total triangles, {gNum} groups");
			}
		}

		public IPXPmx ToPmx()
		{
			IPXPmx pmx = builder.Pmx();
			pmx.Clear();

			pmx.ModelInfo.ModelName = pmx.ModelInfo.ModelNameE = ObjFileName;

			//Set up bone
			IPXBone bone = builder.Bone();
			bone.Name = bone.NameE = ObjFileName;
			bone.Position = new V3();

			//Register vertices
			foreach (IPXVertex v in vertices)
			{
				v.Position *= new V3(settings.ScaleX, settings.ScaleY, settings.ScaleZ) / 10.0f;
				if (settings.UseMetricUnits)
					v.Position *= 2.54f;

				if (settings.SwapYZ)
				{
					float temp = v.Position.Y;
					v.Position.Y = v.Position.Z;
					v.Position.Z = temp;
					temp = v.Normal.Y;
					v.Normal.Y = v.Normal.Z;
					v.Normal.Z = temp;
				}

				if (settings.FlipFaces)
				{
					v.Normal *= -1;
				}

				v.UV *= new V2(settings.ScaleU, settings.ScaleV);

				if (settings.CreateBone == ObjImportSettings.CreateBoneMode.Average)
					bone.Position += v.Position;
				if (settings.CreateBone != ObjImportSettings.CreateBoneMode.None)
					v.Bone1 = bone;
				else
					v.Bone1 = pmx.Bone[0];
				v.Weight1 = 1.0f;
				pmx.Vertex.Add(v);
			}

			//Register the bone
			if (settings.CreateBone == ObjImportSettings.CreateBoneMode.Average)
				bone.Position /= pmx.Vertex.Count;
			if (settings.CreateBone != ObjImportSettings.CreateBoneMode.None)
				pmx.Bone.Add(bone);

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
				if (settings.MaterialNaming == ObjImportSettings.MaterialNamingMode.BitmapName)
					m.Value.Name = m.Value.NameE = m.Value.Tex;
				if (settings.MaterialNaming == ObjImportSettings.MaterialNamingMode.Numbered)
					m.Value.Name = m.Value.NameE = pmx.Material.Count.ToString();
				pmx.Material.Add(m.Value);
			}

			//end
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
					if (importer.ErrorNum + importer.ErrorNumMtl > 0)
					{
						if (MessageBox.Show($"There have been errors during import:\n{importer.ErrorNum} while processing OBJ\n{importer.ErrorNumMtl} while processing MTL\n\nWould you like to open the log file to find out what happened?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
						{
							System.Diagnostics.Process.Start(importer.LogFileUrl);
						}
					}
					return importer.ToPmx();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"{ex}");
			}
			pmx = builder.Pmx();
			return pmx;
		}

		public string Ext => ".obj";

		public string Caption => "WPlugins Obj Importer (version " + Common.Info.Version + ")";
	}
}
