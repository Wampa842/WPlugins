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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

using PEPlugin;
using PEPlugin.Pmx;

namespace WPlugins.ObjIO
{
    public partial class ImportForm : Form
    {
        public enum ImportResultType { Undefined, Success, Fail, Cancel }

        private Task<ImportResult> _importTask;
        private CancellationTokenSource _ctSource;

        /// <summary>
        /// Contains the result of the import operation once it is completed, the form is closed, and control is handed back to the plugin entry point.
        /// </summary>
        public ImportResult ImportResult { get; private set; }

        private IPERunArgs _args;
        private string _path;
        private string _jobPath;

        /// <summary>
        /// Gather settings data from the form.
        /// </summary>
        private ImportSettings GetSettings()
        {
#pragma warning disable IDE0017
            ImportSettings o = new ImportSettings();

            o.ScaleX = (float)scaleXNumber.Value * (mirrorXCheck.Checked ? -1 : 1);
            o.ScaleY = (float)scaleYNumber.Value * (mirrorYCheck.Checked ? -1 : 1);
            o.ScaleZ = (float)scaleZNumber.Value * (mirrorZCheck.Checked ? -1 : 1);
            o.ScaleU = (float)scaleUNumber.Value * (mirrorUCheck.Checked ? -1 : 1);
            o.ScaleV = (float)scaleVNumber.Value * (mirrorVCheck.Checked ? -1 : 1);
            o.UniformScale = uniformModelScaleCheck.Checked;
            o.UniformUVScale = uniformTextureScaleCheck.Checked;

            o.SwapYZ = swapAxesCheck.Checked;
            o.TurnQuads = turnQuadsCheck.Checked;
            o.UseMetricUnits = metricRadio.Checked;
            o.FlipFaces = flipFacesCheck.Checked;
            o.SaveTrianglePairs = saveQuadPairsCheck.Checked;
            o.WhiteMaterialIfTextured = makeWhiteIfTexturedCheck.Checked;

            o.MaterialNaming = (ImportSettings.MaterialNamingMode)materialNamingSelect.SelectedIndex;
            o.CreateBone = (ImportSettings.CreateBoneMode)boneActionSelect.SelectedIndex;

            return o;
#pragma warning restore IDE0017
        }

        /// <summary>
        /// Put settings data on the form.
        /// </summary>
        private void PutSettings(ImportSettings o)
        {
            flipFacesCheck.Checked = o.FlipFaces;
            swapAxesCheck.Checked = o.SwapYZ;
            turnQuadsCheck.Checked = o.TurnQuads;
            imperialRadio.Checked = !o.UseMetricUnits;
            metricRadio.Checked = o.UseMetricUnits;
            makeWhiteIfTexturedCheck.Checked = o.WhiteMaterialIfTextured;
            saveQuadPairsCheck.Checked = o.SaveTrianglePairs;

            uniformModelScaleCheck.Checked = o.UniformScale;
            uniformTextureScaleCheck.Checked = o.UniformUVScale;

            mirrorXCheck.Checked = o.ScaleX < 0;
            scaleXNumber.Value = Math.Abs((decimal)o.ScaleX);
            mirrorYCheck.Checked = o.ScaleY < 0;
            scaleYNumber.Value = Math.Abs((decimal)o.ScaleY);
            mirrorZCheck.Checked = o.ScaleZ < 0;
            scaleZNumber.Value = Math.Abs((decimal)o.ScaleZ);
            mirrorUCheck.Checked = o.ScaleU < 0;
            scaleUNumber.Value = Math.Abs((decimal)o.ScaleU);
            mirrorVCheck.Checked = o.ScaleV < 0;
            scaleVNumber.Value = Math.Abs((decimal)o.ScaleV);

            materialNamingSelect.SelectedIndex = (int)o.MaterialNaming;
            boneActionSelect.SelectedIndex = (int)o.CreateBone;
        }

        public ImportForm(string path, IPERunArgs args)
        {
            InitializeComponent();
            _ctSource = new CancellationTokenSource();
            _args = args;
            _path = path;
            _jobPath = path + ".wpjob.xml";
            ImportSettings settings = ImportSettings.Load();

            if (System.IO.File.Exists(_jobPath))
            {
                switch (MessageBox.Show("This file has an associated job file. Would you like to load it?\n(Press Cancel to delete it)", "Job file found", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        try
                        {
                            saveDefaultCheck.Checked = false;
                            saveDefaultCheck.Enabled = false;
                            settings = ImportSettings.Import(_jobPath);
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
                        catch (System.IO.IOException ex)
                        {
                            MessageBox.Show($"Could not delete file:\n{ex.Message}\n{ex.StackTrace}", "Error");
                        }
                        break;
                    default:
                        break;
                }
            }

            PutSettings(settings);
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

        private async void importButton_Click(object sender, EventArgs e)
        {
            // Prevent the user from starting another import operation
            importButton.Enabled = false;
            ImportSettings settings = GetSettings();

            if (saveDefaultCheck.Checked)
            {
                ImportSettings.Save(settings);
            }
            if (saveJobCheck.Checked)
            {
                ImportSettings.Export(_jobPath, settings);
            }

            IOProgress progress = new IOProgress
            {
                ReportMessageCallback = message =>
                {
                    statusLabel.Text = message;
                },
                ReportPercentCallback = percent =>
                {
                    importProgress.Value = percent;
                },
                ReportWarningCallback = (message, line) =>
                {
                    statusLabel.Text = message;
                    ObjImport.WriteLogFile(_path + ".log", string.Format("[Warning][{0}]: {1}", line, message));
                },
                ReportErrorCallback = (message, line) =>
                {
                    statusLabel.Text = message;
                    ObjImport.WriteLogFile(_path + ".log", string.Format("[Error][{0}]: {1}", line, message));
                    return false;
                },
                CancellationToken = _ctSource.Token
            };

            try
            {
                _importTask = Task.Run(() => Importer.Import(_path, PEStaticBuilder.Pmx, settings, progress), _ctSource.Token);
                ImportResult = await _importTask;
            }
            catch(OperationCanceledException)
            {
                ImportResult = ImportResult.Cancel(progress.WarningCount, progress.ErrorCount);
            }

            DialogResult = DialogResult.OK; // This will cause the calling thread to resume executing, regardless of when the Close() method is called on the form.
            Close();
            _importTask = null;
            importButton.Enabled = true;
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
            MessageBox.Show("Job files help streamline the import process of frequently imported models by storing the settings in an XML file specific to a single OBJ file, without overwriting the default settings.\n" +
                "If a job file is detected, you will be prompted whether to load, ignore or delete it.\n" +
                "The job file will have the name of the OBJ file, followed by '.wp_import.xml'. For this file, the generated job file would be called '" + System.IO.Path.GetFileName(_jobPath) + "'.\n\n" +
                "Due to a programming error, if you load a job file, you can't save those settings as default.", "Help: job files", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ImportForm_Load(object sender, EventArgs e)
        {
            materialNamingSelect.SelectedIndex = 1;
            boneActionSelect.SelectedIndex = 0;
        }

        private void ImportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ctSource.Dispose();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _ctSource.Cancel();
        }
    }
}
