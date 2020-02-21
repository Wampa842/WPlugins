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
along with WPlugins.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

using PEPlugin;
using PEPlugin.Pmx;
using PEPlugin.SDX;

using WPlugins.Common;

namespace WPlugins.ObjImport
{
    public class ObjFileImporter
	{
		public string ObjFileName { get; private set; }
		public int ErrorNum { get; private set; } = 0;
		public int ErrorNumMtl { get; private set; } = 0;
		public string LogFileUrl { get; } = System.Reflection.Assembly.GetExecutingAssembly().Location + ".log";
		private IPXPmxBuilder builder;
		private readonly ObjImportSettings settings;
		private List<IPXVertex> vertices;
        //private Dictionary<string, IPXMaterial> materials;          //Sub-objects in the PMX scene
        private List<IPXMaterial> materials;
		private Dictionary<string, IPXMaterial> uniqueMaterials;    //Unique materials in the MTL file
		private List<V3> vList;
		private List<V2> vtList;
		private List<V3> vnList;
		private Dictionary<string, int> vertexDict;					//Assigns indices to v/vt/vn hashes
		private bool loadWithoutMaterials = false;
		private StreamWriter logger;

		//Read and parse the MTL file that belongs to the OBJ
		private Dictionary<string, IPXMaterial> ReadMaterialLibrary(string path)
		{
			Dictionary<string, IPXMaterial> output = new Dictionary<string, IPXMaterial>();
			string mtlPath = path;
			IPXMaterial mat = null;

			//Process missing file
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
					//Skip empty and comment lines
					if (string.IsNullOrWhiteSpace(line) || line[0] == '#')
						continue;
					tok = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


					switch (tok[0])
					{
						//Diffuse color
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
						//Specular color
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
						//Specular exponent
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
						//Ambient color - used only in case there's no emissive color
						case "Ka":
							if (mat != null)
							{
								try
								{
									mat.Ambient = new V3(float.Parse(tok[1]), float.Parse(tok[2]), float.Parse(tok[3]));
								}
								catch (FormatException)
								{
									logger.WriteLine($"ERROR (MTL) FormatException on line {lineNum}: {line}");
									this.ErrorNumMtl++;
								}
							}
							break;
						//Opacity
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
						//Emissive - overwrites ambient color
						case "Ke":
							if (mat != null)
							{
								try
								{
									mat.Ambient = new V3(float.Parse(tok[1]), float.Parse(tok[2]), float.Parse(tok[3]));
								}
								catch (FormatException)
								{
									logger.WriteLine($"ERROR (MTL) FormatException on line {lineNum}: {line}");
									this.ErrorNumMtl++;
								}
							}
							break;
						//Diffuse texture
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
						//New material declaration
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
							//Check if the same material exists
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

		//Deconstruct the face record and output individual indices
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

		//Generates a v/vt/vn hash and returns the index of the matching vertex, or creates a new one
		private int CreateVertex(int v, int vt, int vn)
		{
			//Generate hash
			string key = v.ToString() + '/' + vt.ToString() + '/' + vn.ToString();
			//Return existing vertex's index
			if (vertexDict.ContainsKey(key))
			{
				return vertexDict[key];
			}
			//Create new vertex and return its index
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

		//Read the OBJ file at <path> and parse the data into IPX* types
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
            //materials = new Dictionary<string, IPXMaterial>();
            materials = new List<IPXMaterial>();

			IPXMaterial material = builder.Material();
			IPXMaterial template = null;

			using (logger = new StreamWriter(this.LogFileUrl))
			using (StreamReader reader = new StreamReader(path))
			{
				string line;
				string[] tok;
				string groupName = "";

				//Counters for the sake of verbosity
				int lineNum = 0;
				int vNum = 0;
				int vtNum = 0;
				int vnNum = 0;
				int fNum = 0;
				int triNum = 0;
				int quadNum = 0;
				int triOutNum = 0;
				int gNum = 0;

				while (!reader.EndOfStream)
				{
					line = reader.ReadLine().Trim();
					++lineNum;
					
					//Skip empty and comment lines
					if (string.IsNullOrWhiteSpace(line) || line[0] == '#')
						continue;
					tok = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

					int v, vt, vn, v1, v2, v3, v4;
                    bool groupWithoutMaterial = false;  // Indicates if a group has been created but no material was assigned to it.

					switch (tok[0])
					{
						//Vertex position
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
						//Texture coordinate
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
						//Vertex normal vector
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
						//Face
						case "f":
							++fNum;
							//Construct triangle
                            if(groupWithoutMaterial)
                            {
                                material = builder.Material();
                                material.Name = material.NameE = groupName;
                                materials.Add(material);
                            }
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
							//Construct two triangles from quad
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
							//Handle polygons - currently not supported
							else
							{
								logger.WriteLine($"ERROR (OBJ) Unsupported polygon ({tok.Length - 1} points) on line {lineNum}: {line}");
								this.ErrorNum++;
							}
							break;
						//Group - create new material instance
                        /*
                         * A group definition is always followed by:
                         * - Material assignment
                         * - Smoothing group assignment (ignored)
                         * - Face definition
                         * 
                         * If a group definition is followed by a face definition with no assigned material, assign the default material to it.
                         * */
						case "g":
							if (tok.Length >= 2)
							{
								groupName = line.Trim().Substring(2, line.Length - 2);
							}
							else
							{
								logger.WriteLine($"ERROR (OBJ) Invalid group definition on line {lineNum}: {line}");
								this.ErrorNum++;
							}
							++gNum;
							break;
						//Material - assign the template's properties to the instance created by g
						case "usemtl":
							string name = line.Trim().Substring(7, line.Length - 7);
                            material = builder.Material();
                            material.Name = material.NameE = groupName;
                            materials.Add(material);
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
						//Material template library - process MTL
						case "mtllib":
							uniqueMaterials = ReadMaterialLibrary(Path.Combine(Path.GetDirectoryName(path), line.Trim().Substring(7, line.Length - 7).Trim()));
							break;
					}
				}
				logger.WriteLine($"LOG (OBJ) Finished ({ErrorNum} errors)");
				logger.WriteLine($"LOG (OBJ) {vNum} vertices, {vtNum} texture coordinates, {vnNum} normal vectors, {fNum} face records ({triNum} triangles, {quadNum} quads), {triOutNum} total triangles, {gNum} groups");
			}
		}

		//Organize the parsed data into a PMX object
		public IPXPmx ToPmx()
		{
			//Initialize new PMX scene
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
				//Transform vertex
				v.Position *= new V3(settings.ScaleX, settings.ScaleY, settings.ScaleZ) / 10.0f;
				if (settings.UseMetricUnits)
					v.Position *= 2.54f;

				//Swap axes
				if (settings.SwapYZ)
				{
					float temp = v.Position.Y;
					v.Position.Y = v.Position.Z;
					v.Position.Z = temp;
					temp = v.Normal.Y;
					v.Normal.Y = v.Normal.Z;
					v.Normal.Z = temp;
				}

				//Flip normal vectors if faces are flipped
				if (settings.FlipFaces)
				{
					v.Normal *= -1;
				}

				//Transform texture coordinates
				v.UV *= new V2(settings.ScaleU, settings.ScaleV);

				//Calculate average vertex position if needed
				if (settings.CreateBone == ObjImportSettings.CreateBoneMode.Average)
					bone.Position += v.Position;
				//Weight vertices to the new bone if needed
				if (settings.CreateBone != ObjImportSettings.CreateBoneMode.None)
					v.Bone1 = bone;
				else
					v.Bone1 = pmx.Bone[0];
				v.Weight1 = 1.0f;

				//Register the vertex in the PMX object
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
					foreach (IPXFace f in m.Faces)
					{
						IPXVertex temp = f.Vertex1;
						f.Vertex1 = f.Vertex3;
						f.Vertex3 = temp;
					}
				}
				if (settings.MaterialNaming == ObjImportSettings.MaterialNamingMode.BitmapName)
					m.Name = m.NameE = m.Tex;
				if (settings.MaterialNaming == ObjImportSettings.MaterialNamingMode.Numbered)
					m.Name = m.NameE = pmx.Material.Count.ToString();
				pmx.Material.Add(m);
			}

			//end
			return pmx;
		}
	}
}
