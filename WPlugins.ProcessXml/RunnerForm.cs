using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using PEPlugin;
using PEPlugin.Pmx;

namespace WPlugins.ProcessXml
{
    public partial class RunnerForm : Form
    {
        private IPERunArgs _args;
        public RunnerForm(IPERunArgs args)
        {
            InitializeComponent();
            _args = args;
        }

        // Add a new line to the log and update the progress bar. If the percent parameter is negative, the progress bar is not affected.
        private void ReportProgress(string line, int percent)
        {
            //if (!verbose || verboseLogging.Checked)
            if (!string.IsNullOrEmpty(line))
            {
                validateOutput.AppendText(line + Environment.NewLine);
            }

            if (percent >= 0)
                executionProgress.Value = percent;
        }

        private void UpdatePmx(IPXPmx pmx)
        {
            Application.DoEvents();
            // TODO: this method seems to block the main UI thread.
            _args.Host.Connector.Pmx.Update(pmx);
            _args.Host.Connector.View.PmxView.UpdateModel();
            _args.Host.Connector.View.PmxView.UpdateView();
            _args.Host.Connector.Form.UpdateList(PEPlugin.Pmd.UpdateObject.All);
            cancelButton.Enabled = false;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "XML Files|*.xml|All files|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pathText.Text = dialog.FileName;
            }
        }

        private void validateButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(pathText.Text))
            {
                validateOutput.Text = string.Format("File not found: {0}", pathText.Text);
                executeButton.Enabled = false;
                return;
            }
            try
            {
                validateOutput.Text = "Begin validation..." + Environment.NewLine;
                XmlDocument document = new XmlDocument();
                document.Load(pathText.Text);
                //bool valid = Runner.ValidateXml(document, AppendLog);
                bool valid = true;
                ReportProgress(valid ? "Validation successful." : "Validation failed.", -1);
                executeButton.Enabled = valid;
            }
            catch (XmlException ex)
            {
                validateOutput.Text = string.Format("Not a valid XML file: {0}\n{1}", pathText.Text, ex.Message);
                executeButton.Enabled = false;
            }
            catch (Exception ex)
            {
                validateOutput.Text = string.Format("Failed to load file: {0}\n{1}", pathText.Text, ex.Message);
                executeButton.Enabled = false;
            }
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            ReportProgress("Start execution...", 0);
            cancelButton.Enabled = true;
            IPXPmx pmx = _args.Host.Connector.Pmx.GetCurrentState();
            XmlDocument doc = new XmlDocument();
            doc.Load(pathText.Text);
            Runner.ExecuteAsync(doc, pmx, _args.Host.Builder.Pmx, ReportProgress, UpdatePmx);
        }

        private void RunnerForm_DragDrop(object sender, DragEventArgs e)
        {
            pathText.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
        }

        private void RunnerForm_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            cancelButton.Enabled = false;
            ReportProgress("> Cancel pending...", -1);
            Runner.CancelWorker();
        }
    }
}
