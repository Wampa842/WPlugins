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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using PEPlugin;

namespace WPlugins.Common
{
	//What's my purpose?
	public static class Info
	{
		//You pass the version.
		public static string Version { get; } = "0.2.0";
	}

	public class About : IPEPlugin
	{
		public void Run(IPERunArgs args)
		{
			AboutForm form = new AboutForm();
			form.ShowDialog();
		}

		public string Name => "About && Update";
		public string Version => Info.Version;
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
