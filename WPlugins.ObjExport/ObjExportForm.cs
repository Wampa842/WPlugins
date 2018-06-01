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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PEPlugin;
using PEPlugin.Pmx;

namespace WPlugins.ObjExport
{
	public partial class ObjExportForm : Form
	{
		private Common.Settings settingsDoc;
		private IPERunArgs args;
		private string path;
		private string jobPath;
		public Common.ObjExportSettings Settings;

		public ObjExportForm(string path, IPERunArgs args)
		{
			InitializeComponent();
			this.args = args;
			this.path = path;
			this.jobPath = path + ".wp_export.xml";

			settingsDoc = new Common.Settings();
			this.Settings = settingsDoc.ObjExport;
		}

		private void bitmapActionHelpLink_Click(object sender, EventArgs e)
		{
			MessageBox.Show("The bitmap action determines what should happen to texture image files.\n\nIgnore: don't do anything. The exported material library will not retain the textures.\nCopy: bitmap files will be copied to the export location and linked by the material library.\nLink: bitmap files will be referenced by the material library, but the files themselves will not be copied.\nAbsolute link: the material library will link to the original files by their absolute location. The files will not be copied.\n\nPath: location relative to the export directory where bitmap files should be linked and/or copied in Copy and Link mode.", "Help: bitmap actions", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
