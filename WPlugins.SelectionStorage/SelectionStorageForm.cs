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

namespace WPlugins.SelectionStorage
{
    public partial class SelectionStorageForm : Form
    {
        private IPERunArgs _args;
        private List<Selection> _storage;
        public SelectionStorageForm(IPERunArgs args)
        {
            InitializeComponent();
            _args = args;
            _storage = new List<Selection>();
        }

        public void PopulateList()
        {
            storedList.Items.Clear();
            for(int i = 0; i < _storage.Count; ++i)
            {
                Selection sel = _storage[i];
                ListViewItem item = new ListViewItem(new string[] { i.ToString(), sel.Name, sel.Vertex.Length.ToString(), sel.Triangle.Length.ToString(), sel.Bone.Length.ToString(), sel.Rigidbody.Length.ToString(), sel.Joint.Length.ToString() });
                item.Tag = sel;
                storedList.Items.Add(item);
            }
        }

        public void AddCurrentSelection()
        {
            Selection sel = new Selection(_args.Host.Connector.View.PmxView, nameText.Text);
            _storage.Add(sel);
            ListViewItem item = new ListViewItem(new string[] { (_storage.Count - 1).ToString(), sel.Name, sel.Vertex.Length.ToString(), sel.Triangle.Length.ToString(), sel.Bone.Length.ToString(), sel.Rigidbody.Length.ToString(), sel.Joint.Length.ToString() });
            item.Tag = sel;
            storedList.Items.Add(item);
        }

        public void RestoreSelection(Selection sel)
        {
            PEPlugin.View.IPXPmxViewConnector view = _args.Host.Connector.View.PmxView;

            view.SetSelectedVertexIndices(sel.Vertex);
            view.SetSelectedFaceIndices(sel.Triangle);
            view.SetSelectedBoneIndices(sel.Bone);
            view.SetSelectedBodyIndices(sel.Rigidbody);
            view.SetSelectedJointIndices(sel.Joint);
            view.UpdateView();
        }

        private void storeCurrentButton_Click(object sender, EventArgs e)
        {
            AddCurrentSelection();
            nameText.Text = "";
        }

        private void keepOnTopToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = ((ToolStripMenuItem)sender).Checked;
        }

        private void restoreButton_Click(object sender, EventArgs e)
        {
            if (storedList.SelectedItems.Count <= 0)
                return;
            RestoreSelection((Selection)storedList.SelectedItems[0].Tag);
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            if (storedList.SelectedItems.Count <= 0)
                return;
            Selection sel = (Selection)storedList.SelectedItems[0].Tag;
            sel.Name = nameText.Text;
            PopulateList();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (storedList.SelectedItems.Count <= 0)
                return;
            Selection sel = (Selection)storedList.SelectedItems[0].Tag;
            _storage.Remove(sel);
            PopulateList();
        }

        private void exportToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
