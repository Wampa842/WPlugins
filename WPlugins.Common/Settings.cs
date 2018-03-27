using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Windows.Forms;

namespace WPlugins.Common
{
	public class ObjImportSettings : IDisposable
	{
		public enum CreateBoneMode { None, Origin, Average };
		bool MetricUnits = false;
		bool FlipFaces = false;
		bool SwapYZ = false;
		bool UniformScale = true;
		float ScaleX = 1.0f;
		float ScaleY = 1.0f;
		float ScaleZ = 1.0f;
		float ScaleU = 1.0f;
		float ScaleV = 1.0f;
		CreateBoneMode CreateBone = CreateBoneMode.None;

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
						}
						catch { }
						break;
					case "YScale":
						try
						{
							this.ScaleY = float.Parse(n.InnerText.Trim());
						}
						catch { }
						break;
					case "ZScale":
						try
						{
							this.ScaleZ = float.Parse(n.InnerText.Trim());
						}
						catch { }
						break;
					case "MirrorX":
						try
						{
							if (bool.Parse(n.InnerText.Trim()))
								this.ScaleX *= -1;
						}
						catch { }
						break;
					case "MirrorY":
						try
						{
							if (bool.Parse(n.InnerText.Trim()))
								this.ScaleY *= -1;
						}
						catch { }
						break;
					case "MirrorZ":
						try
						{
							if (bool.Parse(n.InnerText.Trim()))
								this.ScaleZ *= -1;
						}
						catch { }
						break;
					case "MirrorU":
						try
						{
							if (bool.Parse(n.InnerText.Trim()))
								this.ScaleU *= -1;
						}
						catch { }
						break;
					case "MirrorV":
						try
						{
							if (bool.Parse(n.InnerText.Trim()))
								this.ScaleV*= -1;
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

		public void Dispose()
		{
			throw new NotImplementedException();
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
