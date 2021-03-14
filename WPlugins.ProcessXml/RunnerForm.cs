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
        private RunnerProgress _progress;
        private IPERunArgs _args;

        public RunnerForm(IPERunArgs args)
        {
            InitializeComponent();
            _progress = new RunnerProgress(validateOutput, executionProgress);
            _args = args;
        }

        private void UpdatePmx(IPXPmx pmx)
        {
            Application.DoEvents();
            // TODO: This method blocks the UI thread and there's no way around it. Consider starting the UI on a new thread.
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

        private async void executeButton_Click(object sender, EventArgs e)
        {
            cancelButton.Enabled = true;
            IPXPmx pmx = _args.Host.Connector.Pmx.GetCurrentState();
            IPXPmxBuilder builder = _args.Host.Builder.Pmx;
            XmlDocument doc = new XmlDocument();
            doc.Load(pathText.Text);

            RunnerResult result = await Task.Run(() => { return Runner.Execute(doc, pmx, builder, _progress); });
            if(result == RunnerResult.Success)
            {
                UpdatePmx(pmx);
            }
            cancelButton.Enabled = false;
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
            
        }
    }
}
