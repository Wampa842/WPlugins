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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;

namespace WPlugins.Common
{
    public static class VersionCheck
    {
        public const string RELEASE_URL = "https://api.github.com/repos/wampa842/wplugins/releases/latest";

        // Extract the semver string from the JSON file from GitHub's web API. The return value indicates whether the operation was successful.
        private static bool GetVersionString(string content, out string version)
        {
            if(string.IsNullOrEmpty(content))
            {
                version = null;
                return false;
            }

            Match regex = Regex.Match(content, "\"tag_name\"[\\s:]*\"([\\d.]*)\"");
            if(regex.Success)
            {
                version = regex.Groups[1].ToString();
                return true;
            }

            version = null;
            return false;
        }

        // Return the semantic version of the plugin's latest release on GitHub.
        public static SemanticVersion GetLatestVersion()
        {
            SemanticVersion ver = null;
            using (WebClient client = new WebClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;  //GitHub API uses TLS 1.2 exclusively
                client.Headers.Add(HttpRequestHeader.UserAgent, "WPlugins.Common.About");

                string str = "";
                if (!GetVersionString(client.DownloadString(RELEASE_URL), out str))
                    throw new FormatException("The downloaded JSON document doesn't contain the \"tag_name\" key.");

                ver = SemanticVersion.Parse(str);
            }
            return ver;
        }

        // Return the semantic version of the plugin's latest release on GitHub asynchronously.
        public static async Task<SemanticVersion> GetLatestVersionAsync()
        {
            SemanticVersion ver = null;
            using (WebClient client = new WebClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;  //GitHub API uses TLS 1.2 exclusively
                client.Headers.Add(HttpRequestHeader.UserAgent, "WPlugins.Common.About");

                string str = "";
                if (!GetVersionString(await client.DownloadStringTaskAsync(new Uri(RELEASE_URL)), out str))
                    throw new FormatException("The downloaded JSON document doesn't contain the \"tag_name\" key.");

                ver = SemanticVersion.Parse(str);
            }
            return ver;
        }
    }
}
