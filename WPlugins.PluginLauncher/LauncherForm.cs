using System;
using System.IO;
using System.Windows.Forms;
using PEPlugin;

namespace WPlugins.PluginLauncher
{
    public partial class LauncherForm : Form
    {
        IPERunArgs _args;
        public LauncherForm(IPERunArgs args)
        {
            InitializeComponent();
            _args = args;
        }

        private void PopulatePluginList()
        {
            int pluginPathLength = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location).Length;
            pluginList.Items.Clear();
            for (int i = 0; i < _args.Host.Connector.System.RegisteredPluginCount; ++i)
            {
                IPERegisteredPluginInfo info = _args.Host.Connector.System.GetPluginInfo(i);
                if (System.Text.RegularExpressions.Regex.IsMatch(System.IO.Path.GetFileName(info.AssemblyPath), @"WPlugins\..*$") && info.ClassName != "WPlugins.PluginLauncher.PluginLauncher")
                {
                    ListViewItem item = new ListViewItem(System.Text.RegularExpressions.Regex.Replace(info.Name, "&[^ &]", "").Replace("&&", "&"));
                    item.Tag = i;
                    string path = info.AssemblyPath.Remove(0, pluginPathLength + 1);
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, path));
                    pluginList.Items.Add(item);
                }
            }
        }

        private void LaunchSelected()
        {
            foreach (ListViewItem item in pluginList.SelectedItems)
            {
                _args.Host.Connector.System.RunPlugin((int)item.Tag);
            }
        }

        private void LauncherForm_Load(object sender, EventArgs e)
        {
            PopulatePluginList();
        }

        private void launchSelectedButton_Click(object sender, EventArgs e)
        {
            LaunchSelected();
        }

        private void pluginList_DoubleClick(object sender, EventArgs e)
        {
            LaunchSelected();
        }

        private void pluginList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                LaunchSelected();
            }
        }
    }
}
