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
using System.Windows.Forms;
using System.Net;

namespace WPlugins.Common
{
    public partial class AutoUpdateForm : Form
    {
        private SemanticVersion _current, _latest;
        public AutoUpdateForm(SemanticVersion latest, SemanticVersion current)
        {
            InitializeComponent();
            _current = current;
            _latest = latest;
            thisVersionLabel.Text = current.ToString();
            newVersionLabel.Text = latest.ToString();
        }

        private async void RemoteLog(string action)
        {
            if (Settings.Current.Update.AllowRemoteLog)
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add(HttpRequestHeader.UserAgent, "WPlugins.Common.AutoUpdate");
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
                    //await client.UploadStringTaskAsync("http://localhost/wplugins/rlog.php", string.Format("version={0}&action={1}", _current.ToString(), action));
                    await client.UploadStringTaskAsync("http://users.atw.hu/wplugins/rlog.php", string.Format("version={0}&action={1}", _current.ToString(), action));
                }
            }
        }

        private void visitUpdateButton_Click(object sender, EventArgs e)
        {
            // Visit the latest release, then close the form.
            System.Diagnostics.Process.Start("https://github.com/wampa842/wplugins/releases/latest");
            Settings.Current.Update.Cancel = UpdateSettings.CancelAction.None;
            RemoteLog("update");
            Close();
        }

        private void ignoreButton_Click(object sender, EventArgs e)
        {
            // Close the form and don't do anything
            Settings.Current.Update.Cancel = UpdateSettings.CancelAction.None;
            RemoteLog("delay");
            Close();
        }

        private void disableButton_Click(object sender, EventArgs e)
        {
            // Log to never check for updates, then close the form.
            Settings.Current.Update.Cancel = UpdateSettings.CancelAction.NeverCheck;
            RemoteLog("never");
            Close();
        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            // Log the version to ignore, then close the form.
            Settings.Current.Update.Cancel = UpdateSettings.CancelAction.SkipVersion;
            Settings.Current.Update.SkipVersion = _latest;
            RemoteLog("skip");
            Close();
        }

        private void AutoUpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Save();
        }

        private void privacyLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string note =
                "The automatic updater does a minimal amount of on-line logging.\n" +
                "When a button is clicked, the application sends the nature of the action (update, delay, skip, or disable) and the version of the installed plugin to a remote web server that simply counts how many times the actions occured. The collected data is completely anonymous and cannot be traced back to anyone.\n\n" +
                "If you do not want to send this information, click on the \"No\" button below. The application will remember your choice and it'll never send this data.\n\n" +
                "Would you like to send anonymous data about your choice?";
            DialogResult result = MessageBox.Show(note, "Privacy statement & opt-out", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            Settings.Current.Update.AllowRemoteLog = result != DialogResult.No;
            Settings.Save();
        }
    }
}
