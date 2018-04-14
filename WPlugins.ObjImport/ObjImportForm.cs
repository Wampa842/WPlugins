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
		private Common.ObjImportSettings settings;
		private IPERunArgs args;

		public ObjImportForm(string path, IPERunArgs args)
		{
			InitializeComponent();
			this.args = args;
			settings = new Common.ObjImportSettings();
		}

		private void ObjImportForm_Load(object sender, EventArgs e)
		{
			imperialRadio.Checked = !settings.UseMetricUnits;
			metricRadio.Checked = settings.UseMetricUnits;

			uniformModelScaleCheck.Checked = settings.UniformScale;
			uniformTextureScaleCheck.Checked = settings.UniformUVScale;

			mirrorXCheck.Checked = settings.ScaleX < 0;
			scaleXNumber.Value = Math.Abs((decimal)settings.ScaleX);
			mirrorYCheck.Checked = settings.ScaleY < 0;
			scaleYNumber.Value = Math.Abs((decimal)settings.ScaleY);
			mirrorZCheck.Checked = settings.ScaleZ < 0;
			scaleZNumber.Value = Math.Abs((decimal)settings.ScaleZ);
			mirrorUCheck.Checked = settings.ScaleU < 0;
			scaleUNumber.Value = Math.Abs((decimal)settings.ScaleU);
			mirrorVCheck.Checked = settings.ScaleV < 0;
			scaleVNumber.Value = Math.Abs((decimal)settings.ScaleV);

			materialNamingSelect.SelectedIndex = (int)settings.MaterialNaming;
			bitmapActionSelect.SelectedIndex = (int)settings.BitmapAction;
			boneActionSelect.SelectedIndex = (int)settings.CreateBone;
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

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void importButton_Click(object sender, EventArgs e)
		{

		}
	}
}
