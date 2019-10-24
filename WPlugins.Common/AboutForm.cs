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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace WPlugins.Common
{
    public partial class AboutForm : Form
    {
        private Form _licenseForm = null;

        private async void CheckUpdate()
        {
            SemanticVersion latest = await VersionCheck.GetLatestVersionAsync();

            if (latest == null)
            {
                // Connection error, parse error
                latestVersionLabel.Text = "(connection error)";
            }
            else
            {
                // Everything successful and a valid semver object is returned
                latestVersionLabel.Text = latest.ToString();
                latestVersionLabel.Font = new Font(latestVersionLabel.Font, FontStyle.Bold);
                this.Height = 260;
                updateHintLabel.Show();

                int cmp = Info.Version.CompareTo(latest);
                if (cmp > 0)        // Local is ahead (local > latest)
                {
                    latestVersionLabel.ForeColor = Color.Orange;
                    updateHintLabel.Text = "Up to date (pre-release)";
                }
                else if (cmp < 0)   // Local is behind
                {
                    latestVersionLabel.ForeColor = Color.Red;
                    updateHintLabel.Text = "Update available, download here";
                    updateHintLabel.LinkArea = new LinkArea(18, 13);
                }
                else                // Local is equal
                {
                    latestVersionLabel.ForeColor = Color.Green;
                    updateHintLabel.Text = "Up to date";
                }
            }
        }

        public AboutForm()
        {
            InitializeComponent();
            currentVersionLabel.Text = Info.Version.ToString();
        }

        private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/wampa842/wplugins");
        }

        private void releasesLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/wampa842/wplugins/releases");
        }

        private void issuesLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/wampa842/wplugins/issues");
        }

        private void websiteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://wampa842.github.io/wplugins");
        }

        private void fetchVersionButton_Click(object sender, EventArgs e)
        {
            latestVersionLabel.Text = "please wait...";
            CheckUpdate();
        }

        private void updateHintLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/wampa842/wplugins/releases/latest");
        }

        private void showLicenseButton_Click(object sender, EventArgs e)
        {
            if (_licenseForm == null)
            {
                Form p = this;
                //Create a new form with a Label showing the copyright notice, and a LinkLabel to GNU's licenses
                _licenseForm = new Form()
                {
                    FormBorderStyle = FormBorderStyle.SizableToolWindow,
                    Text = "Copyright notice",
                    StartPosition = FormStartPosition.Manual,
                    Location = new Point(p.Location.X + p.Width, p.Location.Y),
                    Size = new Size(400, 300),
                    ShowInTaskbar = false
                };
                Label noticeLabel = new Label()
                {
                    Text = "Copyright (C) 2018 Wampa842\n\nThis program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.\n\nWPlugins is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.\n\nYou should have received a copy of the GNU General Public License along with Foobar.  If not, see <http://www.gnu.org/licenses/>.",
                    AutoSize = true,
                    MaximumSize = new Size(_licenseForm.ClientSize.Width, 0),
                    Location = new Point(0, 0),
                };
                LinkLabel gplLink = new LinkLabel()
                {
                    Name = "gplLink",
                    Text = "http://www.gnu.org/licenses/",
                    TextAlign = ContentAlignment.TopCenter,
                    Dock = DockStyle.Bottom,
                    AutoSize = false,
                    Height = 20
                };
                gplLink.LinkClicked += (o, a) => { Process.Start("http://www.gnu.org/licenses/"); };
                _licenseForm.Controls.Add(noticeLabel);
                _licenseForm.Controls.Add(gplLink);
            }
            if (_licenseForm != null)
                _licenseForm.ShowDialog();
        }

        private void AboutForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Load();
        }
    }
}
