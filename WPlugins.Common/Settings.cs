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
		public enum CreateBoneMode { None, Origin, Average };
		public bool MetricUnits { get; set; } = false;
		public bool FlipFaces { get; set; } = false;
		public bool SwapYZ { get; set; } = false;
		public bool UniformScale { get; set; } = true;
		public float ScaleX { get; set; } = 1.0f;
		public float ScaleY { get; set; } = 1.0f;
		public float ScaleZ { get; set; } = 1.0f;
		public float ScaleU { get; set; } = 1.0f;
		public float ScaleV { get; set; } = 1.0f;
		public CreateBoneMode CreateBone { get; set; } = CreateBoneMode.None;

		private void ReadSettings()
		{
			XmlDocument doc = new XmlDocument();
			try
			{
				doc.Load(Settings.SettingsFileUrl);
			}
			catch(System.IO.FileNotFoundException ex)
			{
				MessageBox.Show("Settings.xml not found.\n" + ex.Message + '\n' + ex.FileName + "\nDefault values will be used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

			}
			XmlNodeList nodes = doc.DocumentElement["ObjImport"].ChildNodes;
			foreach (XmlNode n in nodes)
			{
				switch (n.LocalName)
				{
					case "MetricUnits":
						try
						{
							this.MetricUnits = bool.Parse(n.InnerText.Trim());
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
					case "UniformScale":
						try
						{
							this.UniformScale = bool.Parse(n.InnerText.Trim());
						}
						catch { }
						break;
					case "XScale":
						try
						{
							this.ScaleX = float.Parse(n.InnerText.Trim());
							if (n.Attributes["mirror"].InnerText.Trim().ToLowerInvariant() == "true")
								this.ScaleX *= -1;
						}
						catch { }
						break;
					case "YScale":
						try
						{
							this.ScaleY = float.Parse(n.InnerText.Trim());
							if (n.Attributes["mirror"].InnerText.Trim().ToLowerInvariant() == "true")
								this.ScaleY *= -1;
						}
						catch { }
						break;
					case "ZScale":
						try
						{
							this.ScaleZ = float.Parse(n.InnerText.Trim());
							if (n.Attributes["mirror"].InnerText.Trim().ToLowerInvariant() == "true")
								this.ScaleZ *= -1;
						}
						catch { }
						break;
					case "UScale":
						try
						{
							this.ScaleU = float.Parse(n.InnerText.Trim());
							if (n.Attributes["mirror"].InnerText.Trim().ToLowerInvariant() == "true")
								this.ScaleU *= -1;
						}
						catch { }
						break;
					case "VScale":
						try
						{
							this.ScaleV = float.Parse(n.InnerText.Trim());
							if (n.Attributes["mirror"].InnerText.Trim().ToLowerInvariant() == "true")
								this.ScaleV *= -1;
						}
						catch { }
						break;
					case "WithBone":
						if (n.InnerText.Trim() == "2")
							this.CreateBone = CreateBoneMode.Average;
						else if (n.InnerText.Trim() == "1")
							this.CreateBone = CreateBoneMode.Origin;
						else
							this.CreateBone = CreateBoneMode.None;
						break;
				}
			}
		}
		
		public ObjImportSettings()
		{
			ReadSettings();
		}
	}

	public static class Settings
	{
		public static readonly string SettingsFileUrl = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\settings.xml";

		private static ObjImportSettings _objImportSettings;
		public static ObjImportSettings ObjImportSettings
		{
			get
			{
				if (_objImportSettings == null)
				{
					_objImportSettings = new ObjImportSettings();
				}
				return _objImportSettings;
			}
		}
	}
}
