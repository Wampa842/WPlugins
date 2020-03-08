using System;
using System.Collections.Generic;
using System.Text;
using PEPlugin;
using PEPlugin.Pmx;

namespace WPlugins.ProcessXml
{
    public class ProcessXml : IPEPlugin
    {
        private RunnerForm _form;
        public void Run(IPERunArgs args)
        {
            _form = new RunnerForm(args);
            _form.Show();
        }
        public string Name => "Batch Process";
        public string Version => "1.0.0";
        public string Description => "Execute a batch file on the model";
        class PluginOptions : IPEPluginOption
        {
            public bool Bootup => true;

            public bool RegisterMenu => true;

            public string RegisterMenuText => "Batch Process";
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
