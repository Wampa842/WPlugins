using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PEPlugin;
using PEPlugin.Pmx;

namespace WPlugins.ObjImport
{
	public class Main : IPEImportPlugin
	{
		public IPXPmx Import(string path, IPERunArgs args)
		{
			throw new NotImplementedException();
		}

		public string Ext { get { return "obj"; } }

		public string Caption { get { return "OBJ Import (WPlugins)"; } }
	}
}
