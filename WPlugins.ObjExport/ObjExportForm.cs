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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

using PEPlugin;
using PEPlugin.Pmx;

namespace WPlugins.ObjExport
{
	public partial class ObjExportForm : Form
	{
		private Common.Settings settingsDoc;
		private IPERunArgs args;
		private string path;
		private string jobPath;
		public Common.ObjExportSettings Settings { get; private set; }

		public ObjExportForm(string path, IPERunArgs args)
		{
			InitializeComponent();
			this.args = args;
			this.path = path;
			this.jobPath = path + ".wp_export.xml";

			if (File.Exists(jobPath))
			{
				switch (MessageBox.Show("This file has an associated job file. Would you like to load it?\n(Press Cancel to delete it)", "Job file found", MessageBoxButtons.YesNoCancel))
				{
					case DialogResult.Yes:
						try
						{
							settingsDoc = new Common.Settings(jobPath);
							saveDefaultCheck.Checked = false;
							saveDefaultCheck.Enabled = false;
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
							File.Delete(jobPath);
						}
						catch (IOException ex)
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
			Settings = settingsDoc.ObjExport;
		}

		private void ObjExportForm_Load(object sender, EventArgs e)
		{
			flipFacesCheck.Checked = Settings.FlipFaces;
			swapAxesCheck.Checked = Settings.SwapYZ;
			imperialRadio.Checked = !Settings.UseMetricUnits;
			metricRadio.Checked = Settings.UseMetricUnits;

			uniformModelScaleCheck.Checked = Settings.UniformScale;
			uniformTextureScaleCheck.Checked = Settings.UniformUVScale;
			separateSmoothingGroupCheck.Checked = Settings.SeparateSmoothingGroups;

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

			bitmapActionSelect.SelectedIndex = (int)Settings.BitmapAction;
			bitmapRelativePathText.Text = Uri.IsWellFormedUriString(Settings.BitmapPath, UriKind.Relative) ? Settings.BitmapPath : "";
		}

		private void bitmapActionHelpLink_Click(object sender, EventArgs e)
		{
			MessageBox.Show("The bitmap action determines what should happen to texture image files.\n\n- Ignore: don't do anything. The exported material library will not retain the textures.\n- Copy: bitmap files will be copied to the export location and linked by the material library. Subdirectory structure will not be retained.\n-Link: bitmap files will be referenced by the material library, but the files themselves will not be copied. Subdirectory structure is retained.\n- Absolute link: the material library will link to the original files by their absolute location. The files will not be copied.\n\nPath: location relative to the export directory where bitmap files should be linked and/or copied in Copy and Link mode.", "Help: bitmap actions", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void exportButton_Click(object sender, EventArgs e)
		{
			this.Settings.ScaleX = (float)scaleXNumber.Value * (mirrorXCheck.Checked ? -1 : 1);
			this.Settings.ScaleY = (float)scaleYNumber.Value * (mirrorYCheck.Checked ? -1 : 1);
			this.Settings.ScaleZ = (float)scaleZNumber.Value * (mirrorZCheck.Checked ? -1 : 1);
			this.Settings.ScaleU = (float)scaleUNumber.Value * (mirrorUCheck.Checked ? -1 : 1);
			this.Settings.ScaleV = (float)scaleVNumber.Value * (mirrorVCheck.Checked ? -1 : 1);
			this.Settings.UniformScale = uniformModelScaleCheck.Checked;
			this.Settings.UniformUVScale = uniformTextureScaleCheck.Checked;

			this.Settings.SwapYZ = swapAxesCheck.Checked;
			this.Settings.UseMetricUnits = metricRadio.Checked;
			this.Settings.FlipFaces = flipFacesCheck.Checked;
			this.Settings.SeparateSmoothingGroups = separateSmoothingGroupCheck.Checked;

			this.Settings.BitmapAction = (Common.ObjExportSettings.BitmapActionType)bitmapActionSelect.SelectedIndex;
			this.Settings.BitmapPath = Uri.IsWellFormedUriString(bitmapRelativePathText.Text, UriKind.Relative) ? bitmapRelativePathText.Text : "";

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

		private void saveJobHelpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MessageBox.Show("Job files help streamline the import process of frequently imported models by storing the settings in an XML file specific to a single OBJ file, without overwriting the default settings.\nIf a job file is detected, you will be prompted whether to load, ignore or delete it.\nThe job file will have the name of the OBJ file, followed by .wp_import.xml (for example: Something.obj.wp_import.xml).\n\nDue to a programming error, if you load a job file, you can't save those settings as default.", "Help: job files", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
