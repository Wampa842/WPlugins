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

using System.Xml;
using System.Windows.Forms;

namespace WPlugins.Common
{
	public class ObjImportSettings
	{
		public XmlDocument Document { get; set; }
		public XmlNode Node { get; set; }

		public enum CreateBoneMode { None, Origin, Average };
		public enum MaterialNamingMode { Numbered, GroupName, BitmapName }
		public bool UseMetricUnits { get; set; } = false;
		public bool FlipFaces { get; set; } = false;
		public bool SwapYZ { get; set; } = false;
		public bool TurnQuads { get; set; } = false;
		public bool UniformScale { get; set; } = true;
		public bool UniformUVScale { get; set; } = true;
		public float ScaleX { get; set; } = 1.0f;
		public float ScaleY { get; set; } = 1.0f;
		public float ScaleZ { get; set; } = 1.0f;
		public float ScaleU { get; set; } = 1.0f;
		public float ScaleV { get; set; } = 1.0f;
		public CreateBoneMode CreateBone { get; set; } = CreateBoneMode.None;
		public MaterialNamingMode MaterialNaming { get; set; } = MaterialNamingMode.GroupName;

		private void ReadSettingsFromNode(XmlNode node)
		{
			foreach (XmlNode n in node.ChildNodes)
			{
				switch (n.LocalName)
				{
					case "UseMetricUnits":
						try
						{
							this.UseMetricUnits = bool.Parse(n.InnerText.Trim());
						}
						catch { }
						break;
					case "FlipFaces":
						try
						{
							this.FlipFaces = bool.Parse(n.InnerText.Trim());
						}
						catch { }
						break;
					case "SwapYZ":
						try
						{
							this.SwapYZ = bool.Parse(n.InnerText.Trim());
						}
						catch { }
						break;
					case "TurnQuads":
						try
						{
							this.TurnQuads = bool.Parse(n.InnerText.Trim());
						}
						catch { }
						break;
					case "UniformScale":
						try
						{
							this.UniformScale = bool.Parse(n.InnerText.Trim());
						}
						catch { }
						break;
					case "UniformUVScale":
						try
						{
							this.UniformUVScale = bool.Parse(n.InnerText.Trim());
						}
						catch { }
						break;
					case "ScaleX":
						try
						{
							this.ScaleX = float.Parse(n.InnerText.Trim());
						}
						catch { }
						break;
					case "ScaleY":
						try
						{
							this.ScaleY = float.Parse(n.InnerText.Trim());
						}
						catch { }
						break;
					case "ScaleZ":
						try
						{
							this.ScaleZ = float.Parse(n.InnerText.Trim());
						}
						catch { }
						break;
					case "ScaleU":
						try
						{
							this.ScaleU = float.Parse(n.InnerText.Trim());
						}
						catch { }
						break;
					case "ScaleV":
						try
						{
							this.ScaleV = float.Parse(n.InnerText.Trim());
						}
						catch { }
						break;
					case "CreateBone":
						if (n.InnerText.Trim() == "2")
							this.CreateBone = CreateBoneMode.Average;
						else if (n.InnerText.Trim() == "1")
							this.CreateBone = CreateBoneMode.Origin;
						else
							this.CreateBone = CreateBoneMode.None;
						break;
					case "MaterialNaming":
						if (n.InnerText.Trim() == "2")
							this.MaterialNaming = MaterialNamingMode.BitmapName;
						else if (n.InnerText.Trim() == "1")
							this.MaterialNaming = MaterialNamingMode.GroupName;
						else
							this.MaterialNaming = MaterialNamingMode.Numbered;
						break;
				}
			}
		}

		public ObjImportSettings(XmlNode node, XmlDocument doc)
		{
			this.Node = node;
			this.Document = doc;
			ReadSettingsFromNode(node);
		}

		public ObjImportSettings()
		{

		}

		public void UpdateNode()
		{
			Dictionary<string, bool> NodesExist = new Dictionary<string, bool>()
			{
				{"UseMetricUnits", false},
				{"FlipFaces", false},
				{"SwapYZ", false},
				{"TurnQuads", false},
				{"UniformScale", false},
				{"UniformUVScale", false},
				{"ScaleX", false},
				{"ScaleY", false},
				{"ScaleZ", false},
				{"ScaleU", false},
				{"ScaleV", false},
				{"CreateBone", false},
				{"MaterialNaming", false}
			};
			foreach (XmlNode n in Node.ChildNodes)
			{
				NodesExist[n.Name] = true;
			}

			foreach (var kvp in NodesExist)
			{
				if (!kvp.Value)
				{
					Node.AppendChild(Document.CreateElement(kvp.Key));
				}
				XmlNode n = Node[kvp.Key];
				switch (kvp.Key)
				{
					case "UseMetricUnits":
						n.InnerText = this.UseMetricUnits.ToString().ToLowerInvariant();
						break;
					case "FlipFaces":
						n.InnerText = this.FlipFaces.ToString().ToLowerInvariant();
						break;
					case "SwapYZ":
						n.InnerText = this.SwapYZ.ToString().ToLowerInvariant();
						break;
					case "TurnQuads":
						n.InnerText = this.UniformUVScale.ToString().ToLowerInvariant();
						break;
					case "UniformScale":
						n.InnerText = this.UniformScale.ToString().ToLowerInvariant();
						break;
					case "UniformUVScale":
						n.InnerText = this.UniformUVScale.ToString().ToLowerInvariant();
						break;
					case "ScaleX":
						n.InnerText = this.ScaleX.ToString().ToLowerInvariant();
						break;
					case "ScaleY":
						n.InnerText = this.ScaleY.ToString().ToLowerInvariant();
						break;
					case "ScaleZ":
						n.InnerText = this.ScaleZ.ToString().ToLowerInvariant();
						break;
					case "ScaleU":
						n.InnerText = this.ScaleU.ToString().ToLowerInvariant();
						break;
					case "ScaleV":
						n.InnerText = this.ScaleV.ToString().ToLowerInvariant();
						break;
					case "CreateBone":
						n.InnerText = ((int)this.CreateBone).ToString().ToLowerInvariant();
						break;
					case "MaterialNaming":
						n.InnerText = ((int)this.MaterialNaming).ToString().ToLowerInvariant();
						break;
				}
			}
		}
	}

	public class ObjExportSettings
	{
		public enum BitmapActionMode { None, Copy, Absolute, Relative };
		public bool UseMetricUnits { get; set; } = false;
		public bool FlipFaces { get; set; } = false;
		public bool SwapYZ { get; set; } = false;
		public bool TurnQuads { get; set; } = false;
		public bool UniformScale { get; set; } = true;
		public bool UniformUVScale { get; set; } = true;
		public float ScaleX { get; set; } = 1.0f;
		public float ScaleY { get; set; } = 1.0f;
		public float ScaleZ { get; set; } = 1.0f;
		public float ScaleU { get; set; } = 1.0f;
		public float ScaleV { get; set; } = 1.0f;
		public BitmapActionMode BitmapAction { get; set; } = BitmapActionMode.Relative;
		public string BitmapPath { get; set; } = "";

		public XmlDocument Document { get; set; }
		public XmlNode Node { get; set; }

		private void ReadSettingsFromNode(XmlNode node)
		{ }

		public ObjExportSettings(XmlNode node, XmlDocument doc)
		{
			this.Node = node;
			this.Document = doc;
			ReadSettingsFromNode(node);
		}

		public ObjExportSettings() { }

		public void UpdateNode()
		{

		}
	}

	public class Settings
	{
		public static readonly string SettingsFileUrl = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\settings.xml";
		protected XmlDocument _xml = new XmlDocument();
		private ObjImportSettings _objImport;
		private ObjExportSettings _objExport;

		public ObjImportSettings ObjImport { get => _objImport; private set => _objImport = value; }
		public ObjExportSettings ObjExport { get => _objExport; private set => _objExport = value; }

		public Settings(string filePath)
		{
			try
			{
				_xml.Load(filePath);
				XmlNode root = _xml.DocumentElement;

				foreach (XmlNode node in root.ChildNodes)
				{
					switch (node.Name)
					{
						case "ObjImport":
							ObjImport = new ObjImportSettings(node, _xml);
							break;
						case "ObjExport":
							break;
					}
				}
			}
			catch (System.Exception ex) when (ex is System.IO.IOException || ex is System.Security.SecurityException)
			{
				MessageBox.Show($"The settings file at \"{SettingsFileUrl}\" couldn't be opened: \n{ex.Message}\nMake sure the file exists and that you have permission to open it.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
				ObjImport = new ObjImportSettings();
			}
		}

		public Settings() : this(SettingsFileUrl) { }

		public void Save()
		{
			ObjImport.UpdateNode();
			_xml.Save(SettingsFileUrl);
		}
	}
}
