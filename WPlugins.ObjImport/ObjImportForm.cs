using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

using PEPlugin;
using PEPlugin.Pmx;

namespace WPlugins.ObjImport
{
	public partial class ObjImportForm : Form
	{
		private Common.Settings settingsDoc;
		private IPERunArgs args;
		private string path;
		private string jobPath;
		public Common.ObjImportSettings Settings;

		public ObjImportForm(string path, IPERunArgs args)
		{
			InitializeComponent();
			this.args = args;
			this.path = path;
			this.jobPath = path + ".wp_import.xml";

			if (System.IO.File.Exists(jobPath))
			{
				switch (MessageBox.Show("This file has an associated job file. Would you like to load it?\n(Press Cancel to delete it)", "Job file found", MessageBoxButtons.YesNoCancel))
				{
					case DialogResult.Yes:
						try
						{
							settingsDoc = new Common.Settings(jobPath);
						}
						catch (XmlException ex)
						{
							MessageBox.Show($"Could not load job file:\n{ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							settingsDoc = new Common.Settings();
						}
						break;
					case DialogResult.Cancel:
						try
						{
							System.IO.File.Delete(jobPath);
						}
						catch(System.IO.IOException ex)
						{
							MessageBox.Show($"Could not delete file:\n{ex.Message}\n{ex.StackTrace}", "Error");
						}
						finally
						{
							settingsDoc = new Common.Settings();
						}
						break;
					default:
						settingsDoc = new Common.Settings();
						break;
				}
			}
			else
			{
				settingsDoc = new Common.Settings();
			}
			Settings = settingsDoc.ObjImport;
		}

		private void ObjImportForm_Load(object sender, EventArgs e)
		{
			flipFacesCheck.Checked = Settings.FlipFaces;
			swapAxesCheck.Checked = Settings.SwapYZ;
			turnQuadsCheck.Checked = Settings.TurnQuads;
			imperialRadio.Checked = !Settings.UseMetricUnits;
			metricRadio.Checked = Settings.UseMetricUnits;

			uniformModelScaleCheck.Checked = Settings.UniformScale;
			uniformTextureScaleCheck.Checked = Settings.UniformUVScale;

			mirrorXCheck.Checked = Settings.ScaleX < 0;
			scaleXNumber.Value = Math.Abs((decimal)Settings.ScaleX);
			mirrorYCheck.Checked = Settings.ScaleY < 0;
			scaleYNumber.Value = Math.Abs((decimal)Settings.ScaleY);
			mirrorZCheck.Checked = Settings.ScaleZ < 0;
			scaleZNumber.Value = Math.Abs((decimal)Settings.ScaleZ);
			mirrorUCheck.Checked = Settings.ScaleU < 0;
			scaleUNumber.Value = Math.Abs((decimal)Settings.ScaleU);
			mirrorVCheck.Checked = Settings.ScaleV < 0;
			scaleVNumber.Value = Math.Abs((decimal)Settings.ScaleV);

			materialNamingSelect.SelectedIndex = (int)Settings.MaterialNaming;
			boneActionSelect.SelectedIndex = (int)Settings.CreateBone;
		}

		private void uniformModelScaleCheck_CheckedChanged(object sender, EventArgs e)
		{
			scaleZNumber.Value = scaleYNumber.Value = scaleXNumber.Value;
			scaleZNumber.Enabled = scaleYNumber.Enabled = !((CheckBox)sender).Checked;
		}

		private void uniformTextureScaleCheck_CheckedChanged(object sender, EventArgs e)
		{
			scaleVNumber.Value = scaleUNumber.Value;
			scaleVNumber.Enabled = !((CheckBox)sender).Checked;
		}

		private void importButton_Click(object sender, EventArgs e)
		{
			this.Settings.ScaleX = (float)scaleXNumber.Value * (mirrorXCheck.Checked ? -1 : 1);
			this.Settings.ScaleY = (float)scaleYNumber.Value * (mirrorYCheck.Checked ? -1 : 1);
			this.Settings.ScaleZ = (float)scaleZNumber.Value * (mirrorZCheck.Checked ? -1 : 1);
			this.Settings.ScaleU = (float)scaleUNumber.Value * (mirrorUCheck.Checked ? -1 : 1);
			this.Settings.ScaleV = (float)scaleVNumber.Value * (mirrorVCheck.Checked ? -1 : 1);
			this.Settings.UniformScale = uniformModelScaleCheck.Checked;
			this.Settings.UniformUVScale = uniformTextureScaleCheck.Checked;

			this.Settings.SwapYZ = swapAxesCheck.Checked;
			this.Settings.TurnQuads = turnQuadsCheck.Checked;
			this.Settings.UseMetricUnits = metricRadio.Checked;
			this.Settings.FlipFaces = flipFacesCheck.Checked;

			this.Settings.MaterialNaming = (Common.ObjImportSettings.MaterialNamingMode)materialNamingSelect.SelectedIndex;
			this.Settings.CreateBone = (Common.ObjImportSettings.CreateBoneMode)boneActionSelect.SelectedIndex;

			this.DialogResult = DialogResult.OK;
			if (saveDefaultCheck.Checked)
			{
				settingsDoc.Save();
			}
			if (saveJobCheck.Checked)
			{
				XmlDocument doc = new XmlDocument();
				doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", "no"));
				XmlElement root = doc.CreateElement("WPluginsSettings");
				this.Settings.UpdateNode();
				XmlNode node = doc.ImportNode(this.Settings.Node, true);
				root.AppendChild(node);
				doc.AppendChild(root);
				try
				{
					doc.Save(this.jobPath);
				}
				catch (XmlException ex)
				{
					MessageBox.Show($"Could not save job file:\n{ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			this.Close();
		}

		private void scaleXNumber_ValueChanged(object sender, EventArgs e)
		{
			if (uniformModelScaleCheck.Checked)
			{
				scaleYNumber.Value = scaleZNumber.Value = ((NumericUpDown)sender).Value;
			}
		}

		private void scaleUNumber_ValueChanged(object sender, EventArgs e)
		{
			if (uniformTextureScaleCheck.Checked)
			{
				scaleVNumber.Value = ((NumericUpDown)sender).Value;
			}
		}

		private void saveJobHelpLink_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Job files help streamline the import process of frequently imported models by storing the settings in an XML file specific to a single OBJ file, without overwriting the default settings.\nIf a job file is detected, you will be prompted whether to load, ignore or delete it.\nThe job file will have the name of the OBJ file, followed by .wp_import.xml (for example: Something.obj.wp_import.xml).", "Help: job files", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
