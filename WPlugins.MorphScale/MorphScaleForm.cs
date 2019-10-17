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

using WPlugins.Common;
using PEPlugin;
using PEPlugin.Form;
using PEPlugin.Pmx;
using PEPlugin.SDX;

namespace WPlugins.MorphScale
{
    public partial class MorphScaleForm : Form
    {
        public enum MorphKind { None, Vertex, UV, BoneRotation, BoneTranslation }

        private IPERunArgs _args;
        private IPXPmx _pmx;

        public MorphScaleForm(IPERunArgs args)
        {
            InitializeComponent();

            _args = args;
            _pmx = args.Host.Connector.Pmx.GetCurrentState();
        }

        private MorphKind SelectedMorphKind
        {
            get
            {
                if (typeVertexCheck.Checked)
                    return MorphKind.Vertex;
                else if (typeUVCheck.Checked)
                    return MorphKind.UV;
                else if (typeBoneRCheck.Checked)
                    return MorphKind.BoneRotation;
                else if (typeBoneTCheck.Checked)
                    return MorphKind.BoneTranslation;
                else
                    return MorphKind.None;
            }
        }

        private bool MorphIsOfKind(IPXMorph morph, MorphKind kind)
        {
            switch (kind)
            {
                case MorphKind.Vertex:
                    return morph.Kind == PEPlugin.Pmx.MorphKind.Vertex;
                case MorphKind.UV:
                    return morph.Kind == PEPlugin.Pmx.MorphKind.UV || morph.Kind == PEPlugin.Pmx.MorphKind.UVA1 || morph.Kind == PEPlugin.Pmx.MorphKind.UVA2 || morph.Kind == PEPlugin.Pmx.MorphKind.UVA3 || morph.Kind == PEPlugin.Pmx.MorphKind.UVA4;
                case MorphKind.BoneRotation:
                case MorphKind.BoneTranslation:
                    return morph.Kind == PEPlugin.Pmx.MorphKind.Bone;
                default:
                    return false;
            }
        }

        private void PopulateList(MorphKind kind)
        {
            morphList.Items.Clear();
            for(int i = 0; i < _pmx.Morph.Count; ++i)
            {
                IPXMorph morph = _pmx.Morph[i];
                if(MorphIsOfKind(morph, kind))
                {
                    ListViewItem item = new ListViewItem(new string[] { morph.Name, morph.NameE });
                    item.Tag = i;
                    morphList.Items.Add(item);
                }
            }
        }

        private void MorphScaleForm_Load(object sender, EventArgs e)
        {
            PopulateList(SelectedMorphKind);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            PopulateList(SelectedMorphKind);
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in morphList.SelectedItems)
            {
                int index = (int)item.Tag;

                // Create a working copy to make sure the original remains unaffected
                IPXMorph workingCopy = (IPXMorph)_pmx.Morph[index].Clone();

                // Scale offsets
                switch (SelectedMorphKind)
                {
                    case MorphKind.Vertex:
                        foreach (IPXVertexMorphOffset offset in workingCopy.Offsets)
                        {
                            offset.Offset = new V3(offset.Offset.X * (float)scaleX.Value, offset.Offset.Y * (float)scaleY.Value, offset.Offset.Z * (float)scaleZ.Value);
                        }
                        break;
                    case MorphKind.UV:
                        // TBI
                        break;
                    default:
                        break;
                }

                // Apply morph to the scene
                foreach(IPXVertexMorphOffset offset in workingCopy.Offsets)
                {
                    offset.Vertex.Position += offset.Offset;
                }
            }

            // Update the scene and PMXView
            _args.Host.Connector.Pmx.Update(_pmx);
            _args.Host.Connector.View.PmxView.UpdateModel_Vertex();
            _args.Host.Connector.View.PmxView.UpdateModel_Bone();
        }

        private void scaleButton_Click(object sender, EventArgs e)
        {
            // Only a quaternion's magnitude can be scaled - notify the user
            if (SelectedMorphKind == MorphKind.BoneRotation && !uniformCheck.Checked && MessageBox.Show("For bone rotation morphs, only the magnitude can be scaled, and only uniformly. If you proceed, the rotation magnitude will be scaled by the factor in the X field.\n\nWould you like to proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            // If new morphs are added, update the list automatically
            bool updateList = false;
            foreach (ListViewItem item in morphList.SelectedItems)
            {
                int index = (int)item.Tag;

                // Create a working copy to make sure the original remains unaffected
                IPXMorph workingCopy = (IPXMorph)_pmx.Morph[index].Clone();

                switch (SelectedMorphKind)
                {
                    case MorphKind.Vertex:
                        foreach (IPXVertexMorphOffset offset in workingCopy.Offsets)
                        {
                            offset.Offset = new V3(offset.Offset.X * (float)scaleX.Value, offset.Offset.Y * (float)scaleY.Value, offset.Offset.Z * (float)scaleZ.Value);
                        }
                        break;
                    case MorphKind.UV:
                        // TBI
                        break;
                    case MorphKind.BoneRotation:
                        foreach (IPXBoneMorphOffset offset in workingCopy.Offsets)
                        {
                            // Scale the rotation's magnitude
                            Q q = offset.Rotation;
                            float theta = 2 * (float)Math.Acos(q.W);
                            offset.Rotation.W = (float)Math.Cos((theta * (float)scaleX.Value) / 2);

                            //float s = (float)Math.Sin(theta / 2);
                            //V3 axis = new V3();
                            //axis.X = q.X / s;
                            //axis.Y = q.Y / s;
                            //axis.Z = q.Z / s;
                        }
                        break;
                    case MorphKind.BoneTranslation:
                        foreach (IPXBoneMorphOffset offset in workingCopy.Offsets)
                        {
                            offset.Translation = new V3(offset.Translation.X * (float)scaleX.Value, offset.Translation.Y * (float)scaleY.Value, offset.Translation.Z * (float)scaleZ.Value);
                        }
                        break;
                    default:
                        break;
                }

                if (createNewCheck.Checked)
                {
                    // Add a new morph
                    workingCopy.Name += " scaled";
                    workingCopy.NameE += " scaled";
                    _pmx.Morph.Add(workingCopy);
                    updateList = true;
                }
                else
                {
                    // Replace the old morph with the clone
                    _pmx.Morph[index] = workingCopy;
                }
            }

            if (updateList)
                PopulateList(SelectedMorphKind);

            // Commit the changes to the PMX scene
            _args.Host.Connector.Pmx.Update(_pmx);
            _args.Host.Connector.Form.UpdateList(PEPlugin.Pmd.UpdateObject.Morph);
        }

        private void scaleValue_ValueChanged(object sender, EventArgs e)
        {
            if(uniformCheck.Checked)
            {
                if (sender is NumericUpDown)
                {
                    scaleY.Value = scaleZ.Value = scaleX.Value = ((NumericUpDown)sender).Value;
                }
                else
                {
                    scaleY.Value = scaleZ.Value = scaleX.Value;
                }
            }
        }
        
        private void invertButton_Click(object sender, EventArgs e)
        {
            // Invert values - possible data loss
            scaleX.Value = 1 / scaleX.Value;
            scaleY.Value = 1 / scaleY.Value;
            scaleZ.Value = 1 / scaleZ.Value;
        }

        private void negativeButton_Click(object sender, EventArgs e)
        {
            scaleX.Value *= -1;
            scaleY.Value *= -1;
            scaleZ.Value *= -1;
        }

        private void morphList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedNumberLabel.Text = "Selected: " + morphList.SelectedItems.Count;
        }

        private void typeCheck_CheckedChanged(object sender, EventArgs e)
        {
            applyButton.Enabled = sender == typeVertexCheck || sender == typeUVCheck;
        }
    }
}
