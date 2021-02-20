using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PEPlugin;

namespace WPlugins.QuickIK
{
    public class QuickIK : IPEPlugin
    {
        private MainForm _form;
        public void Run(IPERunArgs args)
        {
            if (_form == null || _form.IsDisposed)
                _form = new MainForm(args);
            _form.Show();
        }

        public string Name => "Quick IK";
        public string Version => Common.Info.Version.ToString();
        public string Description => "Create bone and IK chains quickly.";
        class PluginOptions : IPEPluginOption
        {
            public bool Bootup => false;

            public bool RegisterMenu => true;

            public string RegisterMenuText => "Quick IK";
        }
        public IPEPluginOption Option => new PluginOptions();
        public void Dispose()
        {
            if (_form != null)
            {
                _form.Dispose();
            }
        }
    }
}
