using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PEPlugin;

namespace WPlugins.ViewSettingsStorage
{
    public class ViewSettingsStorage : IPEPlugin
    {
        private MainForm _form;
        public void Run(IPERunArgs args)
        {
            try
            {
                if (_form == null)
                {
                    _form = new MainForm(args);
                }
                _form.Show();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        public string Name => "View settings storage";
        public string Version => Common.Info.Version.ToString();
        public string Description => "Save camera and view setting between sessions";
        class PluginOptions : IPEPluginOption
        {
            public bool Bootup => false;

            public bool RegisterMenu => true;

            public string RegisterMenuText => "View settings storage";
        }
        public IPEPluginOption Option => new PluginOptions();
        public void Dispose() { }
    }
}