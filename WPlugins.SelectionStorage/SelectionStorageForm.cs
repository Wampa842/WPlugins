using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using PEPlugin;

namespace WPlugins.SelectionStorage
{
    public partial class SelectionStorageForm : Form
    {
        private IPERunArgs _args;
        private TrimForm _trimForm;
        public SelectionStorageForm(IPERunArgs args)
        {
            InitializeComponent();
            _args = args;
        }

        public void AddSelection(Selection sel)
        {
            ListViewItem item = new ListViewItem(new string[] { storedList.Items.Count.ToString(), sel.Name, sel.Vertex.Length.ToString(), sel.Triangle.Length.ToString(), sel.Bone.Length.ToString(), sel.Rigidbody.Length.ToString(), sel.Joint.Length.ToString() });
            item.Tag = sel;
            storedList.Items.Add(item);
        }

        public Selection GetCurrentSelection()
        {
            PEPlugin.View.IPXPmxViewConnector view = _args.Host.Connector.View.PmxView;
            int[] v = selectiveVertexCheck.Checked ? view.GetSelectedVertexIndices() : new int[0];
            int[] f = selectiveTriangleCheck.Checked ? view.GetSelectedFaceIndices() : new int[0];
            int[] b = selectiveBoneCheck.Checked ? view.GetSelectedBoneIndices() : new int[0];
            int[] r = selectiveRigidbodyCheck.Checked ? view.GetSelectedBodyIndices() : new int[0];
            int[] j = selectiveJointCheck.Checked ? view.GetSelectedJointIndices() : new int[0];
            string name = string.IsNullOrEmpty(nameText.Text) ? "Selection " + storedList.Items.Count.ToString() : nameText.Text;

            return new Selection(name, v, f, b, r, j);
        }

        public void AddCurrentSelection()
        {
            AddSelection(GetCurrentSelection());
        }

        public void RestoreSelection(Selection sel)
        {
            PEPlugin.View.IPXPmxViewConnector view = _args.Host.Connector.View.PmxView;

            if (selectiveVertexCheck.Checked)
            {
                view.SetSelectedVertexIndices(sel.Vertex);
            }
            if (selectiveTriangleCheck.Checked)
            {
                view.SetSelectedFaceIndices(sel.Triangle);
            }
            if (selectiveBoneCheck.Checked)
            {
                view.SetSelectedBoneIndices(sel.Bone);
            }
            if (selectiveRigidbodyCheck.Checked)
            {
                view.SetSelectedBodyIndices(sel.Rigidbody);
            }
            if (selectiveJointCheck.Checked)
            {
                view.SetSelectedJointIndices(sel.Joint);
            }
            view.UpdateView();
        }

        private Selection[] GetSelectedFromList()
        {
            Selection[] output = new Selection[storedList.SelectedItems.Count];
            for(int i = 0; i < output.Length; ++i)
            {
                output[i] = (Selection)storedList.SelectedItems[i].Tag;
            }
            return output;
        }

        private void UpdateIndices()
        {
            foreach(ListViewItem item in storedList.Items)
            {
                item.Text = item.Index.ToString();
            }
        }

        #region Event handlers
        private void storedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            unionButton.Enabled = intersectButton.Enabled = differenceButton.Enabled = storedList.SelectedItems.Count > 1;
            deleteButton.Enabled = renameButton.Enabled = storedList.SelectedItems.Count > 0;
            nameText.Text = storedList.SelectedItems.Count > 0 ? ((Selection)storedList.SelectedItems[0].Tag).Name : "";
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
            foreach(ListViewItem item in storedList.SelectedItems)
            {
                item.SubItems[0].Text = ((Selection)item.Tag).Name = nameText.Text;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in storedList.SelectedItems)
            {
                storedList.Items.Remove(item);
            }
        }

        private void exportToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void unionButton_Click(object sender, EventArgs e)
        {
            Selection[] operands = GetSelectedFromList();
            if (operands.Length < 2) return;
            Selection union = Selection.Union(operands);
            union.Name = operands.Length > 2 ? string.Format("Union of {0} selections", operands.Length) : string.Format("Union of {0} and {1}", operands[0].Name, operands[1].Name);
            AddSelection(union);
        }

        private void intersectButton_Click(object sender, EventArgs e)
        {
            Selection[] operands = GetSelectedFromList();
            if (operands.Length < 2) return;
            Selection intersect = Selection.Intersect(operands);
            intersect.Name = operands.Length > 2 ? string.Format("Intersect of {0} selections", operands.Length) : string.Format("Intersect of {0} and {1}", operands[0].Name, operands[1].Name);
            AddSelection(intersect);
        }

        private void differenceButton_Click(object sender, EventArgs e)
        {
            Selection[] operands = GetSelectedFromList();
            if (operands.Length < 2) return;
            Selection difference = Selection.Except(operands);
            difference.Name = operands.Length > 2 ? string.Format("Difference of {0} and {1} others", operands[0].Name, operands.Length - 1) : string.Format("Difference of {0} and {1}", operands[0].Name, operands[1].Name);
            AddSelection(difference);
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in storedList.SelectedItems)
            {
                if(item.Index > 0)
                {
                    int index = item.Index - 1;
                    storedList.Items.RemoveAt(item.Index);
                    storedList.Items.Insert(index, item);
                }
            }
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            for(int i = storedList.SelectedItems.Count - 1; i >= 0; --i)
            {
                ListViewItem item = storedList.SelectedItems[i];
                if (item.Index < storedList.Items.Count - 1)
                {
                    int index = item.Index + 1;
                    storedList.Items.RemoveAt(item.Index);
                    storedList.Items.Insert(index, item);
                }
            }
        }

        private void complementButton_Click(object sender, EventArgs e)
        {
            // Given the sets A, B, C, U where U = selection of every item
            // produces the set O = U \ (A u B u C)

            PEPlugin.View.IPXPmxViewConnector view = _args.Host.Connector.View.PmxView;

            // Get U
            Selection universe = new Selection();

        }

        private void selectiveCheck_Click(object sender, EventArgs e)
        {
            if (selectiveVertexCheck.Checked && selectiveTriangleCheck.Checked && selectiveBoneCheck.Checked && selectiveRigidbodyCheck.Checked && selectiveJointCheck.Checked)
            {
                selectiveAllCheck.CheckState = CheckState.Checked;
            }
            else if (selectiveVertexCheck.Checked || selectiveTriangleCheck.Checked || selectiveBoneCheck.Checked || selectiveRigidbodyCheck.Checked || selectiveJointCheck.Checked)
            {
                selectiveAllCheck.CheckState = CheckState.Indeterminate;
            }
            else
            {
                selectiveAllCheck.CheckState = CheckState.Unchecked;
            }
        }

        private void selectiveAllCheck_Click(object sender, EventArgs e)
        {
            selectiveVertexCheck.Checked = selectiveTriangleCheck.Checked = selectiveBoneCheck.Checked = selectiveRigidbodyCheck.Checked = selectiveJointCheck.Checked = ((CheckBox)sender).CheckState == CheckState.Checked;
        }

        #endregion

        private void cloneButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in storedList.SelectedItems)
            {
                Selection clone = (Selection)((Selection)item.Tag).Clone();
                clone.Name += " copy";
                AddSelection(clone);
            }
        }

        private void trimButton_Click(object sender, EventArgs e)
        {
            if (_trimForm == null)
                _trimForm = new TrimForm();
            TrimOptions options = TrimOptions.None;
            if (!selectiveVertexCheck.Checked) options |= TrimOptions.Vertex;
            if (!selectiveTriangleCheck.Checked) options |= TrimOptions.Triangle;
            if (!selectiveBoneCheck.Checked) options |= TrimOptions.Bone;
            if (!selectiveRigidbodyCheck.Checked) options |= TrimOptions.Rigidbody;
            if (!selectiveJointCheck.Checked) options |= TrimOptions.Joint;

            TrimOptions result = _trimForm.Display(options);
            if (result.HasFlag(TrimOptions.Cancel))
                return;

            foreach(ListViewItem item in storedList.SelectedItems)
            {
                Selection sel;
                if (result.HasFlag(TrimOptions.Clone))
                {
                    sel = (Selection)((Selection)item.Tag).Clone();
                    sel.Name += " trim";
                }
                else
                {
                    sel = (Selection)item.Tag;
                }

                if (result.HasFlag(TrimOptions.Vertex))
                {
                    sel.Vertex = new int[0];
                    item.SubItems[2].Text = "0";
                }
                if (result.HasFlag(TrimOptions.Triangle))
                {
                    sel.Triangle = new int[0];
                    item.SubItems[3].Text = "0";
                }
                if (result.HasFlag(TrimOptions.Bone))
                {
                    sel.Bone = new int[0];
                    item.SubItems[4].Text = "0";
                }
                if (result.HasFlag(TrimOptions.Rigidbody))
                {
                    sel.Rigidbody = new int[0];
                    item.SubItems[5].Text = "0";
                }
                if (result.HasFlag(TrimOptions.Joint))
                {
                    sel.Joint = new int[0];
                    item.SubItems[6].Text = "0";
                }

                if(result.HasFlag(TrimOptions.Clone))
                {
                    AddSelection(sel);
                }
            }
        }
    }
}
