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
using System.Xml;

using PEPlugin;
using PEPlugin.Pmx;

namespace WPlugins.ObjImport
{
	public partial class ObjImportForm : Form
	{
		private IPERunArgs _args;
		private string _path;
		private string _jobPath;
        internal Settings Settings { get; private set; }

		public ObjImportForm(string path, IPERunArgs args)
		{
			InitializeComponent();
			_args = args;
			_path = path;
			_jobPath = path + ".wp_import.xml";
            Settings = Settings.Load();

			if (System.IO.File.Exists(_jobPath))
			{
				switch (MessageBox.Show("This file has an associated job file. Would you like to load it?\n(Press Cancel to delete it)", "Job file found", MessageBoxButtons.YesNoCancel))
				{
					case DialogResult.Yes:
						try
						{
							saveDefaultCheck.Checked = false;
							saveDefaultCheck.Enabled = false;
                            Settings = Settings.Import(_jobPath);
						}
						catch (XmlException ex)
						{
							MessageBox.Show($"Could not load job file:\n{ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						break;
					case DialogResult.Cancel:
						try
						{
							System.IO.File.Delete(_jobPath);
						}
						catch(System.IO.IOException ex)
						{
							MessageBox.Show($"Could not delete file:\n{ex.Message}\n{ex.StackTrace}", "Error");
						}
						break;
					default:
						break;
				}
			}
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

			this.Settings.MaterialNaming = (Settings.MaterialNamingMode)materialNamingSelect.SelectedIndex;
			this.Settings.CreateBone = (Settings.CreateBoneMode)boneActionSelect.SelectedIndex;

			this.DialogResult = DialogResult.OK;
			if (saveDefaultCheck.Checked)
			{
                Settings.Save(Settings);
			}
			if (saveJobCheck.Checked)
			{
                Settings.Export(_jobPath, Settings);
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
			MessageBox.Show("Job files help streamline the import process of frequently imported models by storing the settings in an XML file specific to a single OBJ file, without overwriting the default settings.\nIf a job file is detected, you will be prompted whether to load, ignore or delete it.\nThe job file will have the name of the OBJ file, followed by .wp_import.xml (for example: Something.obj.wp_import.xml).\n\nDue to a programming error, if you load a job file, you can't save those settings as default.", "Help: job files", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
