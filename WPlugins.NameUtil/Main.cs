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
using PEPlugin;

namespace WPlugins.NameUtil
{
	public class Main : IPEPlugin
	{
		public void Run(IPERunArgs args)
		{
			throw new NotImplementedException();
		}

		public string Name => "Name utility";
		public string Version => Common.Info.Version.ToString();
		public string Description => "A tool to set, replace and edit item names";
		class PluginOptions : IPEPluginOption
		{
			public bool Bootup => true;

			public bool RegisterMenu => true;

			public string RegisterMenuText => "Name utility";
		}
		public IPEPluginOption Option => new PluginOptions();
		public void Dispose(){}
	}
}
