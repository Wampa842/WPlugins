using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PEPlugin;
using PEPlugin.Pmx;

namespace WPlugins.QuickIK
{
    public partial class MainForm : Form
    {
        private IPERunArgs _args;
        private Vector3[] _curvePoints;
        private string[] _curveBoneNames;
        private PhysicsSettingsForm _physicsForm;
        private PhysicsSettings _physicsSettings;
        public MainForm(IPERunArgs args)
        {
            InitializeComponent();
            _args = args;
            _curvePoints = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 0, 1), new Vector3(0, 0, 2), new Vector3(0, 0, 3) };
            _curveBoneNames = new string[4];
            _physicsForm = new PhysicsSettingsForm();
            _physicsSettings = PhysicsSettings.Default;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            IPXPmx pmx = _args.Host.Connector.Pmx.GetCurrentState();
            parentBoneSelect.Items.Clear();
            parentBoneSelect.Items.Add("-1: (empty)");
            parentBoneSelect.SelectedIndex = 0;
            for (int i = 0; i < pmx.Bone.Count; ++i)
            {
                parentBoneSelect.Items.Add(string.Format("{0}: {1} ({2})", i, pmx.Bone[i].Name, pmx.Bone[i].NameE));
            }
            positionSelect.SelectedIndex = 0;
            autoCalcDistance.Checked = true;
            autoCalc_CheckedChanged(null, new EventArgs());
        }

        private void positionSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (positionSelect.SelectedIndex)
            {
                case 0:
                    firstPointLabel.Text = "Start";
                    lastPointLabel.Text = "Target";
                    firstPointVector.Enabled = true;
                    lastPointVector.Enabled = true;
                    generateButton.Enabled = true;
                    generateButton.Text = "Generate";
                    editPoints.Enabled = false;

                    autoCalcCount.Enabled = true;
                    autoCalcDistance.Enabled = true;
                    autoCalcLength.Enabled = true;
                    linkNumber.Enabled = true;
                    distanceNumber.Enabled = true;
                    lengthNumber.Enabled = true;
                    break;
                case 1:
                case 2:
                case 3:
                    firstPointVector.Enabled = false;
                    lastPointVector.Enabled = false;
                    generateButton.Enabled = true;
                    generateButton.Text = "Generate";
                    editPoints.Enabled = true;

                    autoCalcCount.Enabled = false;
                    autoCalcDistance.Enabled = false;
                    autoCalcLength.Enabled = false;
                    linkNumber.Enabled = true;
                    distanceNumber.Enabled = false;
                    lengthNumber.Enabled = false;
                    break;
                default:
                    firstPointVector.Enabled = false;
                    lastPointVector.Enabled = false;
                    generateButton.Enabled = false;
                    generateButton.Text = "(the selected positioning method is not supported)";
                    editPoints.Enabled = false;

                    autoCalcCount.Enabled = false;
                    autoCalcDistance.Enabled = false;
                    autoCalcLength.Enabled = false;
                    linkNumber.Enabled = true;
                    distanceNumber.Enabled = false;
                    lengthNumber.Enabled = false;
                    break;
            }
            autoCalc_CheckedChanged(null, new EventArgs());
        }

        private void autoCalc_CheckedChanged(object sender, EventArgs e)
        {
            if (autoCalcLength.Checked)
            {
                lengthNumber.Enabled = false;
                linkNumber.Enabled = true;
                distanceNumber.Enabled = true;
            }
            else if (autoCalcCount.Checked)
            {
                lengthNumber.Enabled = true;
                linkNumber.Enabled = false;
                distanceNumber.Enabled = true;
            }
            else if (autoCalcDistance.Checked)
            {
                lengthNumber.Enabled = true;
                linkNumber.Enabled = true;
                distanceNumber.Enabled = false;
            }
        }

        private void lengthNumber_ValueChanged(object sender, EventArgs e)
        {
            if (autoCalcCount.Checked)
            {
                linkNumber.Value = (int)Math.Max(Math.Round(lengthNumber.Value / distanceNumber.Value), 1);
            }
            else if (autoCalcDistance.Checked)
            {
                distanceNumber.Value = lengthNumber.Value / linkNumber.Value;
            }
        }

        private void linkNumber_ValueChanged(object sender, EventArgs e)
        {
            if (autoCalcLength.Checked)
            {
                lengthNumber.Value = distanceNumber.Value * linkNumber.Value;
            }
            else if (autoCalcDistance.Checked)
            {
                distanceNumber.Value = lengthNumber.Value / linkNumber.Value;
            }
        }

        private void distanceNumber_ValueChanged(object sender, EventArgs e)
        {
            if (distanceNumber.Value <= 0)
            {
                MessageBox.Show("The distance between links must be greater than 0!");
                distanceNumber.Value = 0.01m;
            }

            if (autoCalcLength.Checked)
            {
                lengthNumber.Value = distanceNumber.Value * linkNumber.Value;
            }
            else if (autoCalcCount.Checked)
            {
                linkNumber.Value = (int)Math.Max(Math.Round(lengthNumber.Value / distanceNumber.Value), 1);
            }
        }

        private void getFullDistanceButton_Click(object sender, EventArgs e)
        {
            if (!autoCalcLength.Checked)
            {
                lengthNumber.Value = (decimal)firstPointVector.Value.Distance(lastPointVector.Value);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(namingText.Text))
            {
                MessageBox.Show("The name cannot be empty!");
                return;
            }
            switch (positionSelect.SelectedIndex)
            {
                case 0:
                    if (lastPointVector.Value.Magnitude <= 0)
                    {
                        MessageBox.Show("The target vector cannot be zero!");
                        return;
                    }
                    break;
                case 1:
                    if(linkNumber.Value < pointCount.Value)
                    {
                        MessageBox.Show("The number of links must not be less than the number of control points.");
                        return;
                    }
                    break;
                default:
                    break;
            }

            if (editPoints.Checked)
                editPoints.Checked = false;

            IPXPmx pmx = _args.Host.Connector.Pmx.GetCurrentState();
            IPXBone parent = null;
            if (parentBoneSelect.SelectedIndex > 0)
            {
                parent = pmx.Bone[parentBoneSelect.SelectedIndex - 1];
            }
            IPXBone[] chain = null;

            int count;
            Vector3 start;
            Vector3 delta;

            switch (positionSelect.SelectedIndex)
            {
                case 0: // From start through target

                    start = firstPointVector.Value;
                    delta = lastPointVector.Value.Normalized * (float)distanceNumber.Value;
                    count = (int)Math.Round(linkNumber.Value);
                    chain = Builder.GenerateChain(_args.Host.Builder.Pmx, Math.Max(count, 1), delta, start, namingText.Text, namingEnText.Text);
                    break;
                case 1: // Segmented path
                    count = (int)Math.Round(linkNumber.Value);
                    chain = Builder.GenerateSegmentedChain(_args.Host.Builder.Pmx, count, _curvePoints, namingText.Text, namingEnText.Text);
                    break;
                case 2: // Along a spline
                    count = (int)Math.Round(linkNumber.Value);
                    chain = Builder.GenerateSplineChain(_args.Host.Builder.Pmx, count, _curvePoints, namingText.Text, namingEnText.Text);
                    break;
                case 3: // Along a spline with even distribution
                    count = (int)Math.Round(linkNumber.Value);
                    chain = Builder.GenerateSplineChainEvenSpaced(_args.Host.Builder.Pmx, count, _curvePoints, namingText.Text, namingEnText.Text);
                    break;
                default:
                    break;
            }

            if (chainTypeIK.Checked)
            {
                IPXBone handle = _args.Host.Builder.Pmx.Bone();
                handle.Parent = parent;
                handle.Name = namingText.Text.Replace("#", "IK").Replace("&", "IK");
                handle.NameE = namingEnText.Text.Replace("#", "IK").Replace("&", "IK");
                handle.IsTranslation = true;
                handle.IsIK = true;
                IPXIK ik = handle.IK;

                for (int i = chain.Length - 2; i >= 0; --i)
                {
                    ik.Links.Add(_args.Host.Builder.Pmx.IKLink(chain[i]));
                }

                ik.Target = chain[chain.Length - 1];
                ik.Angle = (float)((20.0 / 180.0) * Math.PI);
                ik.LoopCount = 10;
                handle.Position = ik.Target.Position;

                pmx.Bone.Add(handle);
            }

            if (createPhysics.Checked)
            {
                IPXJoint pj = null;
                if (_physicsSettings.AttachToParent)
                {
                    IPXBody pb = pmx.Body.Where(b => b.Bone == parent).FirstOrDefault();
                    if (pb == null)
                    {
                        MessageBox.Show("Could not attach physics chain to the parent bone because it doesn't have a rigidbody.", "Warning");
                    }
                    else
                    {
                        pj = _args.Host.Builder.Pmx.Joint();
                        pj.Name = namingText.Text.Replace("#", "P").Replace("&", "P");
                        pj.NameE = namingEnText.Text.Replace("#", "P").Replace("&", "P");
                        pj.Position = pb.Bone.Position;
                        pj.BodyA = pb;
                        pmx.Joint.Add(pj);
                    }
                }
                Builder.GeneratePhysics(_args.Host.Builder.Pmx, chain, _physicsSettings, out IPXBody[] rigidbodies, out IPXJoint[] joints);
                if (pj != null)
                {
                    pj.BodyB = rigidbodies[0];
                }
                foreach (IPXBody body in rigidbodies)
                {
                    pmx.Body.Add(body);
                }
                foreach (IPXJoint joint in joints)
                {
                    pmx.Joint.Add(joint);
                }
            }

            chain[0].Parent = parent;
            chain.Last().Visible = !lastBoneInvisible.Checked;
            foreach (IPXBone b in chain)
            {
                pmx.Bone.Add(b);
            }

            DialogResult = DialogResult.OK;
            _args.Host.Connector.Pmx.Update(pmx);
            _args.Host.Connector.View.PmxView.UpdateModel();
            _args.Host.Connector.View.PmxView.UpdateView();
            _args.Host.Connector.Form.UpdateList(PEPlugin.Pmd.UpdateObject.All);
            Close();
        }

        private void namingHelpLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("The naming format string can be used to name all of the bones that will be created using their number in the chain.\n" +
                "All characters will be copied verbatim with the following exceptions:\n" +
                " - # is replaced by the bone's 0-base number (0, 1, 2...)\n" +
                " - & is replaced by the bone's 1-base number (1, 2, 3...)\n" +
                " - If an IK handle is generated, both # and & are replaced by \"IK\"." +
                "For example, the format string \"bone_#\" would produce the following names: bone_0, bone_1, bone_2, and so on.", "Naming format string", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkNumberHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This number indicates how many segments the chain will have.\n\nIt includes the last bone at the tip of the chain.\nA chain with a link number of 1 will have only a single bone at the start position regardless of other parameters.");
        }

        private void editPoints_CheckedChanged(object sender, EventArgs e)
        {
            positionSelect.Enabled = pointCount.Enabled = !editPoints.Checked;

            if (editPoints.Checked)
            {
                if (MessageBox.Show("You are about to enable curve editing.\n" +
                    "While editing is active, four additional bones will be added to the scene. When you finish editing, these bones will be removed.\n\n" +
                    "WHILE EDITING IS ACTIVE:\n" +
                    "- DO NOT close the plugin window,\n" +
                    "- DO NOT edit your model,\n" +
                    "- DO NOT save your model,\n" +
                    "- Click on the \"FINISH EDITING\" button when you're done.\n" +
                    "Ignoring these instructions might corrupt your model and/or crash PMX Editor.\n\n" +
                    "Do you want to enable curve editing?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _args.Host.Connector.Pmx.LockUndo();
                    editPoints.BackColor = Color.OrangeRed;
                    editPoints.ForeColor = Color.Yellow;
                    editPoints.Text = "FINISH EDITING";
                    IPXPmx pmx = _args.Host.Connector.Pmx.GetCurrentState();
                    _curveBoneNames = new string[_curvePoints.Length];
                    IPXBone prevBone = null;
                    for (int i = 0; i < _curvePoints.Length; ++i)
                    {
                        IPXBone bone = _args.Host.Builder.Pmx.Bone();
                        _curveBoneNames[i] = bone.Name = bone.GetHashCode().ToString();
                        bone.Position = _curvePoints[i];
                        pmx.Bone.Add(bone);
                        if (prevBone != null)
                            prevBone.ToBone = bone;
                        prevBone = bone;
                    }
                    _args.Host.Connector.Pmx.Update(pmx);
                    _args.Host.Connector.View.PmxView.UpdateModel();
                    _args.Host.Connector.View.PmxView.UpdateView();
                    _args.Host.Connector.Form.UpdateList(PEPlugin.Pmd.UpdateObject.All);
                }
                else
                {
                    editPoints.Checked = false;
                }
            }
            else
            {
                IPXPmx pmx = _args.Host.Connector.Pmx.GetCurrentState();
                for (int i = 0; i < _curvePoints.Length; ++i)
                {
                    IPXBone bone = pmx.Bone.Where(b => b.Name == _curveBoneNames[i]).LastOrDefault();
                    if (bone == null)
                        continue;
                    _curvePoints[i] = (Vector3)bone.Position;
                    pmx.Bone.Remove(bone);
                }
                _args.Host.Connector.Pmx.Update(pmx);
                _args.Host.Connector.View.PmxView.UpdateModel();
                _args.Host.Connector.View.PmxView.UpdateView();
                _args.Host.Connector.Form.UpdateList(PEPlugin.Pmd.UpdateObject.All);
                _args.Host.Connector.Pmx.UnlockUndo();
                editPoints.BackColor = DefaultBackColor;
                editPoints.ForeColor = DefaultForeColor;
                editPoints.Text = "Edit points";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (editPoints.Checked)
            {
                MessageBox.Show("The instructions clearly stated that you MUST NOT close the plugin window while editing the curve points. Now you have to close PMX Editor WITHOUT SAVING and reopen the model.\n\nAny damage to your model is your own fault for not listening.", "Congratulations! You Are An Idiot!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void physicsSettingsButton_Click(object sender, EventArgs e)
        {
            _physicsForm.PhysicsSettings = _physicsSettings;
            if (_physicsForm.ShowDialog() == DialogResult.OK)
            {
                _physicsSettings = _physicsForm.PhysicsSettings;
            }
        }

        private void pointCount_ValueChanged(object sender, EventArgs e)
        {
            int count = (int)pointCount.Value;
            _curvePoints = new Vector3[count];
            for (int i = 0; i < count; ++i)
            {
                _curvePoints[i] = new Vector3(0, 0, i);
            }
        }

        private void positionHelpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PositionHelpForm form = new PositionHelpForm();
            form.Location = new Point(Location.X + Width, Location.Y);
            form.Show();
        }
    }
}
