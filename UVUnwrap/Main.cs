using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PEPlugin;

namespace UVUnwrap
{
	public class UVUnwrap : IPEPlugin
	{
		public string Name { get { return "UV unwrapper/editor"; } }

		public string Version { get { return "1.0.0"; } }

		public string Description { get { return "View, transform and edit UV coordinates";} }

		private class PluginOptions : IPEPluginOption
		{
			public bool Bootup { get { return false; } }

			public bool RegisterMenu { get { return false; } }

			public string RegisterMenuText { get { return "WPlugins Core"; } }
		}

		public IPEPluginOption Option { get { return new PluginOptions(); } }

		public void Dispose()
		{
			;
		}

		public void Run(IPERunArgs args)
		{
			throw new NotImplementedException();
		}
	}
}
