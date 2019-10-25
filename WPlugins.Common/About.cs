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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using PEPlugin;

namespace WPlugins.Common
{
    //What's my purpose?
    public static class Info
    {
        //You pass the version.
        public static SemanticVersion Version { get; }
        public static string PluginDirectory { get; }

        static Info()
        {
            Version = new SemanticVersion(0, 4, 2);
            PluginDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }

    public class About : IPEPlugin
    {
        public void Run(IPERunArgs args)
        {
            AboutForm form = new AboutForm();
            form.Show();
        }

        public string Name => "About && Update";
        public string Version => Info.Version.ToString();
        public string Description => "Information about and updates for WPlugins";
        class PluginOptions : IPEPluginOption
        {
            public bool Bootup => false;

            public bool RegisterMenu => true;

            public string RegisterMenuText => "About && Update";
        }
        public IPEPluginOption Option => new PluginOptions();
        public void Dispose() { }
    }
}
