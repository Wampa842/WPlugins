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
		private string currentVersion;
		private Form licenseForm = null;

		//Compare semantic version strings with the Major.Minor.Hotfix schema
		private int compareSemvers(string a, string b)
		{
			try
			{
				string[] splitA = a.Split('.');
				string[] splitB = b.Split('.');
				int result;
				if ((result = string.Compare(splitA[0], splitB[0])) != 0)
					return result;
				if ((result = string.Compare(splitA[1], splitB[1])) != 0)
					return result;
				if ((result = string.Compare(splitA[2], splitB[2])) != 0)
					return result;
				return 0;
			}
			catch
			{
				return -1;
			}
		}

		public AboutForm()
		{
			InitializeComponent();
			//currentVersion = Regex.Match(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(), "^(\\d+\\.\\d+\\.\\d+).*").Groups[1].ToString();
			currentVersionLabel.Text = currentVersion = Info.Version;
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
			Uri uri = new Uri("https://api.github.com/repos/wampa842/wplugins/releases/latest");
			latestVersionLabel.Text = "please wait...";

			using (WebClient client = new WebClient())
			{
				//GitHub API uses TLS 1.2 exclusively
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				client.Headers.Add(HttpRequestHeader.UserAgent, "WPlugins.Common.About");

				//Event handler for the completion of the async operation
				client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(delegate (object s, DownloadStringCompletedEventArgs args)
				{
					latestVersionLabel.Font = new Font(latestVersionLabel.Font, FontStyle.Regular);
					if (args.Error == null)
					{
						latestVersionLabel.Text = "undefined";
						//The result string is a JSON object with a single tag_name property - quick and dirty, but it works.
						Match m = Regex.Match(args.Result, "\"tag_name\"[\\s:]*\"([\\d.]*)\"");
						if (m.Success)
						{
							latestVersionLabel.Text = m.Groups[1].ToString();
							latestVersionLabel.Font = new Font(latestVersionLabel.Font, FontStyle.Bold);

							this.Height += 20;
							updateHintLabel.Show();

							int cmp = compareSemvers(currentVersion, latestVersionLabel.Text);
							if (cmp < 0)        //local is behind
							{
								latestVersionLabel.ForeColor = Color.Red;
								updateHintLabel.Text = "Update available, download here.";
								updateHintLabel.LinkArea = new LinkArea(18, 13);
							}
							else if (cmp > 0)   //local is ahead
							{
								latestVersionLabel.ForeColor = Color.Orange;
								updateHintLabel.Text = "Up-to-date (pre-release).";
							}
							else                //local is up-to-date
							{
								latestVersionLabel.ForeColor = Color.Green;
								updateHintLabel.Text = "Up-to-date.";
							}
						}
					}
					else
					{
						latestVersionLabel.Text = "connection error";
					}
				});
				client.DownloadStringAsync(uri);
			}
		}

		private void updateHintLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://github.com/wampa842/wplugins/releases/latest");
		}

		private void showLicenseButton_Click(object sender, EventArgs e)
		{
			if (licenseForm == null)
			{
				Form p = this;
				//Create a new form with a Label showing the copyright notice, and a LinkLabel to GNU's licenses
				licenseForm = new Form()
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
					MaximumSize = new Size(licenseForm.ClientSize.Width, 0),
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
				licenseForm.Controls.Add(noticeLabel);
				licenseForm.Controls.Add(gplLink);
			}
			if (licenseForm != null)
				licenseForm.ShowDialog();
		}
	}
}
