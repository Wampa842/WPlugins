using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PEPlugin;
using PEPlugin.Pmx;

namespace WPlugins.ObjImport
{
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
				pmx = builder.Pmx();
				pmx.Clear();
				form.ShowDialog();
			}
			catch(Exception ex)
			{
				MessageBox.Show($"{ex.Message}\n{ex.StackTrace}\n\n{ex.Data}", "Error");
			}
			return pmx;
		}

		public string Ext { get { return ".obj"; } }

		public string Caption { get { return "OBJ Import (WPlugins)"; } }
	}
}
