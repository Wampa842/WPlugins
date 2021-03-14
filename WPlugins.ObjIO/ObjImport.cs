using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using PEPlugin;
using PEPlugin.Pmx;

namespace WPlugins.ObjIO
{
    public partial class ObjImport : IPEImportPlugin
    {
        public static void WriteLogFile(string path, string message)
        {
            try
            {
                File.AppendAllText(path, message + Environment.NewLine);
            }
            catch { }
        }

        public IPXPmx Import(string path, IPERunArgs args)
        {
            try
            {
                if (File.Exists(path + ".log"))
                    File.Delete(path + ".log");
            }
            catch { }

            IPXPmxBuilder builder = PEStaticBuilder.Pmx;

            ImportForm form = new ImportForm(path, args);

            // This call blocks the thread until the dialog is closed.
            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                // DialogResult.OK does not mean a successful outcome, only that the user has initiated the process and then the form was closed for whatever reason.
                // The outcome of the actual import operation is indicated by ImportForm.ImportResult.
                switch (form.ImportResult.Result)
                {
                    case ImportResult.ResultType.Success:
                        WriteLogFile(path + ".log", string.Format("Import operation was completed successfully with {0} errors and {1} warnings.", form.ImportResult.ErrorCount, form.ImportResult.WarningCount));
                        return (IPXPmx)form.ImportResult.Pmx;
                    case ImportResult.ResultType.Fail:
                        MessageBox.Show(string.Format("The import operation has failed.\n\n{0}", form.ImportResult.Pmx as Exception));
                        WriteLogFile(path + ".log", string.Format("Import operation has failed with {0} errors and {1} warnings.", form.ImportResult.ErrorCount, form.ImportResult.WarningCount));
                        break;
                    case ImportResult.ResultType.Cancel:
                        MessageBox.Show("The operation was cancelled by the user.");
                        WriteLogFile(path + ".log", "The operation was cancelled by the user.");
                        break;
                    default:
                        MessageBox.Show("The import operation was halted before a valid result was obtained.");
                        WriteLogFile(path + ".log", "The import operation was halted for an unknown reason before a valid result was obtained.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Test");
            }

            // If control reaches this point, then the import operation was not completed successfully and there is no valid data to return to the application.
            return null;
        }

        public string Ext => ".obj";

        public string Caption => string.Format("Wavefront Object 2 (WPlugins {0})", Common.Info.Version);
    }
}
