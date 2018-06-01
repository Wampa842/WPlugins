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

/*  OBJ:
	mtllib mtlfile.mtl

	v <x> <y> <z>
	vt <x> <y>
	vn <x> <y> <z>

	g name
	usemtl materialname
	s <smoothing group>
	f <v>/<vt>/<vn> <v>/<vt>/<vn> <v>/<vt>/<vn>

	MTL:
	newmtl materialname
		Ka <ambient RGB>
		Kd <diffuse RGB>
		Ks <specular RGB>
		Ns <specular exponent>
		d  <opacity>
		Tr <1 - opacity>
		illum 2
		map_Kd <diffuse bitmap>
*/

namespace WPlugins.ObjExport
{
	public class Main : IPEExportPlugin
	{
		class ObjFileExporter
		{
			List<string> v = new List<string>();
			List<string> vt = new List<string>();
			List<string> vn = new List<string>();
			List<string> f = new List<string>();
			List<string> mat = new List<string>();

			public ObjFileExporter(string path, IPXPmx pmx, Common.ObjExportSettings settings, DoWorkEventArgs e = null)
			{
				foreach(IPXMaterial m in pmx.Material)
				{
					foreach(IPXFace f in m.Faces)
					{
						//mat.Add()
					}
				}
			}
			public void SaveMtl(string path)
			{
				StreamWriter writer = null;
				try
				{
					writer = new StreamWriter(path);
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
			public void SaveObj(string path)
			{
				StreamWriter writer = null;
				try
				{
					writer = new StreamWriter(path);
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

		BackgroundWorker worker;
		IPXPmx pmx;
		ObjExportForm form;
		ExportProgressForm progressForm;
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
					worker = new BackgroundWorker
					{
						WorkerReportsProgress = true,
						WorkerSupportsCancellation = true
					};
					worker.DoWork += this.Worker_DoWork;
					worker.ProgressChanged += this.Worker_ProgressChanged;
					worker.RunWorkerCompleted += this.Worker_RunWorkerCompleted;

					progressForm = new ExportProgressForm();
					progressForm.Show();

					worker.RunWorkerAsync();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"{ex}");
			}
		}

		private void Worker_DoWork(object sender, DoWorkEventArgs e)
		{
			ObjFileExporter exporter = new ObjFileExporter(this.path, pmx, form.Settings, e);
			
		}

		private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			throw new NotImplementedException();
		}

		public string Ext => ".obj";

		public string Caption => "WPlugins Obj Exporter (version " + Common.Info.Version + ")";
	}
}
