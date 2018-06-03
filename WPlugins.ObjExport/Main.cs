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
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

using PEPlugin;
using PEPlugin.Pmx;
using PEPlugin.SDX;
using WPlugins.Common;

namespace WPlugins.ObjExport
{
	public class ProgressReporter
	{
		public int TotalProgress { get; set; }
		public int FacesMax { get; set; }
		public int FacesProgress { get; set; }
		public int MaterialsProgress { get; set; }
	}
	public class ObjFileExporter
	{
		private Dictionary<string, int> vDict;		//List v entries as keys and indices as values
		private Dictionary<string, int> vtDict;		//List vt entries and indices
		private Dictionary<string, int> vnDict;		//List vn entries and indices
		private List<string> faces;					//List g, usemtl, s and f declarations
		private List<string> materials;				//List all material-related declarations

		private IPXPmx pmx;							 //The PMX scene to be processed
		private string path;						 //Path of the OBJ file to be exported
		private ObjExportSettings settings;
		private BackgroundWorker worker;			//Processes the PMX scene asynchronously
		private ExportProgressForm progressForm;    //UI to report progress and cancel the background process

		public ObjFileExporter(string path, IPXPmx pmx, ObjExportSettings settings)
		{
			//Initialize the lists
			vDict = new Dictionary<string, int>();
			vtDict = new Dictionary<string, int>();
			vnDict = new Dictionary<string, int>();
			faces = new List<string>();
			materials = new List<string>();

			//Pass the arguments
			this.pmx = pmx;
			this.path = path;
			this.settings = settings;

			//Initialize the worker
			worker = new BackgroundWorker{WorkerReportsProgress = true, WorkerSupportsCancellation = true};
			worker.ProgressChanged += this.Worker_ProgressChanged;
		}

		private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			progressForm.UpdateProgress(50, (ProgressReporter)e.UserState);
		}

		//Convert a PEPlugin.SDX.V* vector to an OBJ-compatible string representation
		private string vecToString(object v)
		{
			//Texture coordinates
			if (v is V2)
			{
				V2 cast = (V2)v;
				return $"{cast.X} {-cast.Y}";
			}
			else if (v is V3)
			{
				V3 cast = (V3)v;
				return $"{cast.X} {cast.Y} {cast.Z}";
			}
			else if (v is V4)
			{
				V4 cast = (V4)v;
				return $"{cast.X} {cast.Y} {cast.Z} {cast.W}";
			}
			else return "";
		}

		//Turn a vertex into its string representation and return the face record
		private string processVertex(IPXVertex vert)
		{
			string vStr, vtStr, vnStr;
			int vIndex, vtIndex, vnIndex;

			//float mult = settings.UseMetricUnits ? 1.0f : 2.54f;
			float multPos = settings.UseMetricUnits ? 1.0f : 0.3937007874f;
			int multNrm = settings.FlipFaces ? -1 : 1;

			//stringify vertices
			if (settings.SwapYZ)
			{

				vStr = $"{vert.Position.X * settings.ScaleX * multPos} {vert.Position.Z * settings.ScaleZ * multPos} {-vert.Position.Y * settings.ScaleY * multPos}";
				vnStr = $"{vert.Normal.X * multNrm} {vert.Normal.Z * multNrm} {-vert.Normal.Y * multNrm}";
			}
			else
			{
				vStr = $"{vert.Position.X * settings.ScaleX * multPos} {vert.Position.Y * settings.ScaleY * multPos} {-vert.Position.Z * settings.ScaleZ * multPos}";
				vnStr = $"{vert.Normal.X * multNrm} {vert.Normal.Y * multNrm} {-vert.Normal.Z * multNrm}";
			}
			vtStr = $"{vert.UV.U * settings.ScaleU} {-vert.UV.V * settings.ScaleV}";

			if (vDict.ContainsKey(vStr))
			{
				vIndex = vDict[vStr];
			}
			else
			{
				vDict.Add(vStr, vIndex = vDict.Count + 1);
			}
			if (vtDict.ContainsKey(vtStr))
			{
				vtIndex = vtDict[vtStr];
			}
			else
			{
				vtDict.Add(vtStr, vtIndex = vtDict.Count + 1);
			}
			if (vnDict.ContainsKey(vnStr))
			{
				vnIndex = vnDict[vnStr];
			}
			else
			{
				vnDict.Add(vnStr, vnIndex = vnDict.Count + 1);
			}
			return $"{vIndex}/{(vtIndex > 0 ? vtIndex.ToString() : "")}/{vnIndex} ";
		}

		//Worker event handler that decomposes the PMX scene and turns it into OBJ text lines
		private void Worker_ProcessPmx(object sender, DoWorkEventArgs e)
		{
			int faceCount = (int)e.Argument;
			int matNum = 0;
			int totalFaceNum = 0;

			ProgressReporter rep = new ProgressReporter();

			//Iterate through materials
			foreach (IPXMaterial m in pmx.Material)
			{
				if(worker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}

				//Process material properties
				string matName = string.IsNullOrWhiteSpace(m.NameE) ? m.Name : m.NameE;
				materials.Add($"newmtl {matName}");
				materials.Add($"    Kd {vecToString(m.Diffuse)}");
				materials.Add($"    Ka {vecToString(m.Ambient)}");
				materials.Add($"    Ks {vecToString(m.Specular)}");
				materials.Add($"    d {m.Diffuse.A}");
				materials.Add($"    Tr {1 - m.Diffuse.A}");
				materials.Add($"    Ns {m.Power}");
				materials.Add($"    illum 2");
				if (!string.IsNullOrWhiteSpace(m.Tex))
				{
					string textureNewPath = "";
					switch (settings.BitmapAction)
					{
						case ObjExportSettings.BitmapActionType.Copy:
							textureNewPath = Path.Combine(settings.BitmapPath, Path.GetFileName(m.Tex));

							string originalPath = Path.Combine(Path.GetDirectoryName(pmx.FilePath), m.Tex);
							string targetDir = Path.Combine(Path.GetDirectoryName(path), settings.BitmapPath);
							string targetPath = Path.Combine(targetDir, Path.GetFileName(m.Tex));
							Directory.CreateDirectory(targetDir);
							try
							{
								if(File.Exists(originalPath) && !File.Exists(targetPath))
									File.Copy(originalPath, targetPath, false);
							}
							catch(Exception ex)
							{
								MessageBox.Show($"{ex.GetType().ToString()} while copying \"{originalPath}\" to \"{targetPath}\"");
							}
							break;
						case ObjExportSettings.BitmapActionType.Link:
							textureNewPath = Path.Combine(settings.BitmapPath, m.Tex);
							break;
						case ObjExportSettings.BitmapActionType.Absolute:
							textureNewPath = Path.Combine(Path.GetDirectoryName(path), m.Tex);
							break;
						default:
							break;
					}
					materials.Add($"    map_Kd {textureNewPath}");
				}
				materials.Add("");

				//Create a new group and assign the material
				faces.Add($"g {matName}");
				faces.Add($"usemtl {matName}");
				faces.Add($"s {(settings.SeparateSmoothingGroups ? matNum : 1)}");

				//Iterate through face
				foreach(IPXFace f in m.Faces)
				{
					++totalFaceNum;
					if(worker.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					if (settings.FlipFaces)
					{
						this.faces.Add("f " +
							this.processVertex(f.Vertex1) +
							this.processVertex(f.Vertex2) +
							this.processVertex(f.Vertex3).TrimEnd());
					}
					else
					{
						this.faces.Add("f " +
							this.processVertex(f.Vertex3) +
							this.processVertex(f.Vertex2) +
							this.processVertex(f.Vertex1).TrimEnd());
					}

					rep.TotalProgress = totalFaceNum;

					worker.ReportProgress(0, rep);
				}

				faces.Add($"# {m.Faces.Count} faces");
				faces.Add("");
			}
		}

		//Initialize and start processing and reporting
		public void ProcessPmx()
		{
			//Count the faces and initialize the reporting window
			int matCount = pmx.Material.Count;
			int faceCount = 0;
			foreach (IPXMaterial m in pmx.Material)
				faceCount += m.Faces.Count;

			//Initialize worker
			worker.DoWork += Worker_ProcessPmx;

			//Result reporting event handler
			worker.RunWorkerCompleted += (o, e) =>
			{
				if (e.Cancelled)
				{
					MessageBox.Show("Process cancelled");
				}
				else
				{
					SaveFiles();
				}
				progressForm.Close();
			};
			progressForm = new ExportProgressForm(worker, faceCount);
			worker.RunWorkerAsync(faceCount);
			progressForm.ShowDialog();
		}

		//Write processed strings to files
		public void SaveFiles()
		{
			string objPath = this.path;
			string mtlPath = Path.Combine(Path.GetDirectoryName(this.path), Path.GetFileNameWithoutExtension(this.path)) + ".mtl";
			StreamWriter writer = null;

			//Write MTL file
			try
			{
				writer = new StreamWriter(mtlPath);
				//Write file info
				writer.WriteLine($"# WPlugins OBJ Exporter v{Info.Version} - copyright (C) 2018 Wampa842 (GNU GPL-3.0-or-later)");
				writer.WriteLine($"# File created on {DateTime.Now.ToString("yyyy-MM-dd HH\\:mm\\:ss")} from {Path.GetFileName(pmx.FilePath)}");
				writer.WriteLine();

				foreach(string line in materials)
				{
					writer.WriteLine(line);
				}
			}
			catch(IOException ex)
			{
				MessageBox.Show(ex.ToString());
			}
			finally
			{
				if(writer != null)
					writer.Dispose();
			}

			//Write OBJ file
			try
			{
				writer = new StreamWriter(objPath);
				writer.WriteLine($"# WPlugins OBJ Exporter v{Info.Version} - copyright (C) 2018 Wampa842 (GNU GPL-3.0-or-later)");
				writer.WriteLine($"# File created on {DateTime.Now.ToString("yyyy-MM-dd HH\\:mm\\:ss")} from {Path.GetFileName(pmx.FilePath)}");
				writer.WriteLine();

				writer.WriteLine($"mtllib {Path.GetFileName(mtlPath)}");
				writer.WriteLine();

				foreach (string line in vDict.Keys)
				{
					writer.WriteLine("v " + line);
				}
				writer.WriteLine($"# {vDict.Count} vertex positions");
				writer.WriteLine();

				foreach (string line in vtDict.Keys)
				{
					writer.WriteLine("vt " + line);
				}
				writer.WriteLine($"# {vtDict.Count} texture coordinates");
				writer.WriteLine();

				foreach (string line in vnDict.Keys)
				{
					writer.WriteLine("vn " + line);
				}
				writer.WriteLine($"# {vnDict.Count} vertex normals");
				writer.WriteLine();

				foreach (string line in faces)
				{
					writer.WriteLine(line);
				}
				writer.WriteLine($"# {faces.Count} face-related records records");
			}
			catch (IOException ex)
			{
				MessageBox.Show(ex.ToString());
			}
			finally
			{
				if (writer != null)
					writer.Dispose();
			}
		}
	}

	public class Main : IPEExportPlugin
	{
		ObjExportForm form;
		string path;

		public void Export(IPXPmx pmx, string path, IPERunArgs args)
		{
			this.path = path;
			try
			{
				form = new ObjExportForm(path, args);
				form.ShowDialog();
				if(form.DialogResult == DialogResult.OK)
				{
					ObjFileExporter exporter = new ObjFileExporter(path, pmx, form.Settings);
					exporter.ProcessPmx();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"{ex}");
			}
		}

		public string Ext => ".obj";

		public string Caption => "Wavefront OBJ (WPlugins ObjExport v" + Common.Info.Version + ")";
	}
}
