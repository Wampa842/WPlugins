using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using PEPlugin;

namespace WPlugins.Common
{
	public class About : IPEPlugin
	{
		public void Run(IPERunArgs args)
		{
			AboutForm form = new AboutForm();
			form.ShowDialog();
		}

		public string Name => "About & Update";
		public string Version => "0.1.2";
		public string Description => "Information about and updates for WPlugins";
		class PluginOptions : IPEPluginOption
		{
			public bool Bootup => false;

			public bool RegisterMenu => true;

			public string RegisterMenuText => "About & Update";
		}
		public IPEPluginOption Option => new PluginOptions();
		public void Dispose() { }
	}
}
