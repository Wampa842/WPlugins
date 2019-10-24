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
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace WPlugins.Common
{
    [Serializable]
    public class ObjExportSettings
	{
		public enum BitmapActionType { None, Copy, Link, Absolute };

		public bool UseMetricUnits { get; set; } = false;
		public bool FlipFaces { get; set; } = false;
		public bool SwapYZ { get; set; } = false;
		public bool SeparateSmoothingGroups { get; set; } = false;
		public bool UniformScale { get; set; } = true;
		public bool UniformUVScale { get; set; } = true;
		public float ScaleX { get; set; } = 1.0f;
		public float ScaleY { get; set; } = 1.0f;
		public float ScaleZ { get; set; } = 1.0f;
		public float ScaleU { get; set; } = 1.0f;
		public float ScaleV { get; set; } = 1.0f;
		public BitmapActionType BitmapAction { get; set; } = BitmapActionType.Link;
		public string BitmapPath { get; set; } = "";

        public static ObjExportSettings Import(string path)
        {
            ObjExportSettings settings = new ObjExportSettings();
            StreamReader stream = null;
            XmlReader reader = null;
            XmlSerializer _serializer = null;

            try
            {
                if (_serializer == null)
                    _serializer = new XmlSerializer(typeof(ObjExportSettings));
                stream = new StreamReader(path);
                reader = XmlReader.Create(stream);

                settings = (ObjExportSettings)_serializer.Deserialize(reader);
            }
            catch { throw; }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader = null;
                    stream = null;
                }
            }

            return settings;
        }

        public void Export(string path)
        {
            XmlSerializer serializer = null;
            StreamWriter stream = null;
            XmlWriter writer = null;

            try
            {
                serializer = new XmlSerializer(typeof(ObjExportSettings));
                stream = new StreamWriter(path);
                writer = XmlWriter.Create(stream);

                serializer.Serialize(writer, this);
            }
            catch { throw; }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    writer = null;
                    stream = null;
                }
            }
        }
    }
}
