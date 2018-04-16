using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PEPlugin;
using PEPlugin.Pmx;

namespace WPlugins.ObjImport
{
	public partial class ObjImportForm : Form
	{
		private Common.Settings settingsDoc;
		private IPERunArgs args;
		public Common.ObjImportSettings Settings;

		public ObjImportForm(string path, IPERunArgs args)
		{
			InitializeComponent();
			this.args = args;
			settingsDoc = new Common.Settings();
			Settings = settingsDoc.ObjImport;
			MessageBox.Show(Settings.ToString());
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
			if (storeSettingsCheck.Checked)
			{
				settingsDoc.Save();
			}
			this.Close();
		}

		private void scaleXNumber_ValueChanged(object sender, EventArgs e)
		{
			if(uniformModelScaleCheck.Checked)
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
	}
}
