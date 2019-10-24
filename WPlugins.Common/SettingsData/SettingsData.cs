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

namespace WPlugins.Common
{
    [Serializable]
    public class SettingsData
    {
        public UpdateSettings Update { get; set; }
        public ObjImportSettings ObjImport { get; set; }
        public ObjExportSettings ObjExport { get; set; }

        public SettingsData()
        {
            Update = new UpdateSettings();
            ObjImport = new ObjImportSettings();
            ObjExport = new ObjExportSettings();
        }
    }
}
