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
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace WPlugins.Common
{
    public static class Settings
    {
        private static SettingsData _current;
        private static FileStream _stream;
        public static string SettingsFilePath { get { return Path.Combine(Info.PluginDirectory, "settings.xml"); } }
        public static SettingsData Current
        {
            get
            {
                if (_current == null)
                {
                    Load();
                }

                return _current;
            }
            set
            {
                _current = value;
            }
        }

        private static XmlSerializer _serializer;

        public static SettingsData Import(string path)
        {
            SettingsData settings = new SettingsData();
            XmlReader reader = null;

            try
            {
                if (_serializer == null)
                    _serializer = new XmlSerializer(typeof(SettingsData));
                //stream = File.Open(path, FileMode.Append, FileAccess.ReadWrite);
                if (_stream == null)
                    _stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                reader = XmlReader.Create(_stream);

                settings = (SettingsData)_serializer.Deserialize(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            if (reader != null)
            {
                reader.Close();
            }

            return settings;
        }

        public static void Export(string path, SettingsData settings)
        {
            XmlWriter writer = null;

            try
            {
                if (_serializer == null)
                    _serializer = new XmlSerializer(typeof(SettingsData));
                if (_stream == null)
                    _stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                writer = XmlWriter.Create(_stream);

                _serializer.Serialize(writer, settings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            {
                if (writer != null)
                {
                    writer.Flush();
                    writer.Close();
                }
            }

            if (writer != null)
            {
                writer.Close();
            }
        }

        public static void Load()
        {
            if (File.Exists(SettingsFilePath))
            {
                _current = Import(SettingsFilePath);
            }
            else
            {
                _current = new SettingsData();
                Save();
            }
        }

        public static void Save()
        {
            Export(SettingsFilePath, _current);
        }
    }
}
