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
along with Foobar.  If not, see <http://www.gnu.org/licenses/>.
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
using PEPlugin;
using PEPlugin.Pmx;
using PEPlugin.SDX;
using PEPlugin.Form;
using PEPlugin.View;

namespace WPlugins.SelectionUtil
{
	public partial class SelectionUtilForm : Form
	{
		private IPERunArgs args;
		private IPXPmx pmx;
		private IPXPmxViewConnector view;
		public SelectionUtilForm(IPERunArgs args)
		{
			this.args = args;
			pmx = args.Host.Connector.Pmx.GetCurrentState();
			view = args.Host.Connector.View.PmxView;
			InitializeComponent();
		}

		private void selectVertexButton_Click(object sender, EventArgs e)
		{
			HashSet<int> selected = new HashSet<int>(Enumerable.Range(0, pmx.Vertex.Count));
			IPXVertex v;
			bool remove;
			for(int i = 0; i < pmx.Vertex.Count; ++i)
			{
				v = pmx.Vertex[i];
				if(vertexByBoneAnyRadio.Checked)
				{
					//Remove if it doesn't belong to any selected bone
					remove = !(
						vertexByBoneList.SelectedIndices.Contains(pmx.Bone.IndexOf(v.Bone1)) ||
						vertexByBoneList.SelectedIndices.Contains(pmx.Bone.IndexOf(v.Bone2)) ||
						vertexByBoneList.SelectedIndices.Contains(pmx.Bone.IndexOf(v.Bone3)) ||
						vertexByBoneList.SelectedIndices.Contains(pmx.Bone.IndexOf(v.Bone4))
						);
				}
				else
				{
					//Remove if doesn't belong to all bones
					remove = !(
						vertexByBoneList.SelectedIndices.Contains(pmx.Bone.IndexOf(v.Bone1)) &&
						vertexByBoneList.SelectedIndices.Contains(pmx.Bone.IndexOf(v.Bone2)) &&
						vertexByBoneList.SelectedIndices.Contains(pmx.Bone.IndexOf(v.Bone3)) &&
						vertexByBoneList.SelectedIndices.Contains(pmx.Bone.IndexOf(v.Bone4))
						);
				}
			}
			view.SetSelectedVertexIndices(selected.ToArray());
		}

		private void SelectionUtilForm_Load(object sender, EventArgs e)
		{
			vertexByBoneList.Items.Clear();
			foreach(IPXBone b in pmx.Bone)
			{
				ListViewItem item = new ListViewItem(b.Name);
				item.SubItems.Add(new ListViewItem.ListViewSubItem(item, b.NameE));
				vertexByBoneList.Items.Add(item);
			}
		}

		private void vertexByBoneEnable_CheckedChanged(object sender, EventArgs e)
		{
			foreach (Control c in vertexByBoneGroup.Controls)
				c.Enabled = ((CheckBox)sender).Checked;
			((CheckBox)sender).Enabled = true;
		}
	}
}
