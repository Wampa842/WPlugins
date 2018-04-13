using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using PEPlugin;

namespace WPlugins.Common
{
    public class Main : IPEPlugin
    {
        public void Run(IPERunArgs args)
        {
            ;
        }

        public string Name
        {
            get
            {
                return "WPlugins: Common";
            }
        }

        public string Version
        {
            get
            {
                return "0.0.0";
            }
        }

        public string Description
        {
            get
            {
                return "Common methods for WPlugins";
            }
        }

        private class PluginOptions : IPEPluginOption
        {
            public bool Bootup { get { return false; } }

            public bool RegisterMenu { get { return false; } }

            public string RegisterMenuText { get { return "WPlugins Core"; } }
        }

        public IPEPluginOption Option
        {
            get
            {
                return new PluginOptions();
            }
        }

        public void Dispose()
        {
            ;
        }
    }
}
