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
	# Copyright notice
	mtllib mtlfile.mtl

	(flat lists with 1-base indexing)
	v <x> <y> <z>
	vt <x> <y>
	vn <x> <y> <z>

	g name
	usemtl materialname (always follows g)
	s <smoothing group> (should be constant or numbered?)
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
					//TODO: export implementation
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"{ex}");
			}
		}

		public string Ext => ".obj";

		public string Caption => "WPlugins Obj Exporter (version " + Common.Info.Version + ")";
	}
}
