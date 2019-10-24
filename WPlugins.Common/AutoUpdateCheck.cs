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
along with Foobar.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using PEPlugin;

namespace WPlugins.Common
{
    public class AutoUpdateCheck : IPEPlugin
    {
        private AutoUpdateForm _form;

        private async void CheckUpdate()
        {
            SemanticVersion latest = await VersionCheck.GetLatestVersionAsync();
            if (latest == null)
            {
                return;
            }
            if (Settings.Current.Update.Cancel == UpdateSettings.CancelAction.SkipVersion && latest.Equals(Settings.Current.Update.SkipVersion))
            {
                return;
            }
            if (latest.CompareTo(Info.Version) > 0)
            {
                if (_form == null || _form.IsDisposed)
                {
                    _form = new AutoUpdateForm(latest, Info.Version);
                    _form.Show();
                }
            }
        }

        public void Run(IPERunArgs args)
        {
            CheckUpdate();
        }

        public string Name => "WPlugins Update Checker";

        public string Version => Info.Version.ToString();

        public string Description => "Automatic update checker for WPlugins";

        public class PluginOptions : IPEPluginOption
        {
            public bool Bootup => Settings.Current.Update.Cancel != UpdateSettings.CancelAction.NeverCheck; // Don't even run the plugin if the user doesn't want to check for updates

            public bool RegisterMenu => false;

            public string RegisterMenuText => "WPlugins Update Checker";
        }

        public IPEPluginOption Option => new PluginOptions();

        public void Dispose()
        {
        }
    }
}
