using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PEPlugin;

namespace WPlugins.PluginLauncher
{
    public class PluginLauncher : IPEPlugin
    {
        LauncherForm _form;
        public void Run(IPERunArgs args)
        {
            if (_form == null)
                _form = new LauncherForm(args);
            _form.Show();
        }

        public string Name => "Plugin Launcher";
        public string Version => Common.Info.Version.ToString();
        public string Description => "Quick launcher for WPlugins";
        class PluginOptions : IPEPluginOption
        {
            public bool Bootup => true;

            public bool RegisterMenu => true;

            public string RegisterMenuText => "Plugin Launcher";
        }
        public IPEPluginOption Option => new PluginOptions();
        public void Dispose()
        {
            if (_form != null)
                _form.Dispose();
        }
    }
}
