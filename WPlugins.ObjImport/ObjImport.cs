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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PEPlugin;
using PEPlugin.Pmx;

namespace WPlugins.ObjImport
{
    public class ObjImport : IPEImportPlugin
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
					//New importer parses OBJ/MTL files into IPX*-types
					ObjFileImporter importer = new ObjFileImporter(path, builder, form.Settings);
					//If there are errors, notify the user
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
                MessageBox.Show(ex.ToString());
			}
			//If execution reaches this point, either an error has occured or the user pressed Cancel.
			pmx = builder.Pmx();
			return pmx;
		}

		public string Ext => ".obj";

        //public string Caption => "Wavefront OBJ (WPlugins ObjImport v" + Common.Info.Version + ")";
        public string Caption => "Wavefront OBJ (WPlugins Importer)";
	}
}
