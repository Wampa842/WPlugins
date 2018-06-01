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

		private int compareSemvers(string a, string b)
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

		public AboutForm()
		{
			currentVersion = Regex.Match(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(), "^(\\d+\\.\\d+\\.\\d+).*").Groups[1].ToString();
			InitializeComponent();
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
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				client.Headers.Add(HttpRequestHeader.UserAgent, "WPlugins.Common.About");
				client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(delegate(object s, DownloadStringCompletedEventArgs args)
				{
					latestVersionLabel.Font = new Font(latestVersionLabel.Font, FontStyle.Regular);
					latestVersionLabel.Text = "connection error";
					if(args.Error == null)
					{
						latestVersionLabel.Text = "undefined";
						Match m = Regex.Match(args.Result, "\"tag_name\"[\\s:]*\"([\\d.]*)\"");
						if (m.Success)
						{
							latestVersionLabel.Text = m.Groups[1].ToString();
							latestVersionLabel.Font = new Font(latestVersionLabel.Font, FontStyle.Bold);

							this.Height = 220;
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
				});
				client.DownloadStringAsync(uri);
			}
		}

		private void updateHintLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/wampa842/wplugins/releases/latest");
		}
	}
}
