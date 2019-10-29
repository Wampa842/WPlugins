using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WPlugins.SelectionStorage
{
    /// <summary>
    /// Having a bit in the 1st to 5th place set means that the type should be removed.
    /// </summary>
    [Flags]
    public enum TrimOptions { None = 0, Vertex = 1, Triangle = 2, Bone = 4, Rigidbody = 8, Joint = 16, Clone = 32, Cancel = 64 }
    
    public partial class TrimForm : Form
    {
        private TrimOptions _options = TrimOptions.None;

        public TrimForm()
        {
            InitializeComponent();
        }

        // Pass the options, then call ShowDialog
        public TrimOptions Display(TrimOptions options)
        {
            _options = options;
            keepVertices.Checked = !(removeVertices.Checked = _options.HasFlag(TrimOptions.Vertex));
            keepTriangles.Checked = !(removeTriangles.Checked = _options.HasFlag(TrimOptions.Triangle));
            keepBones.Checked = !(removeBones.Checked = _options.HasFlag(TrimOptions.Bone));
            keepRigidbodies.Checked = !(removeRigidbodies.Checked = _options.HasFlag(TrimOptions.Rigidbody));
            keepJoints.Checked = !(removeJoints.Checked = _options.HasFlag(TrimOptions.Joint));

            ShowDialog();
            // This thread should be blocked at this point.
            // Control returns here when the form is closed.
            return _options;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _options = TrimOptions.Cancel;
            Close();
        }

        private void trimButton_Click(object sender, EventArgs e)
        {
            _options = TrimOptions.None;

            if (removeVertices.Checked) _options |= TrimOptions.Vertex;
            if (removeTriangles.Checked) _options |= TrimOptions.Triangle;
            if (removeBones.Checked) _options |= TrimOptions.Bone;
            if (removeRigidbodies.Checked) _options |= TrimOptions.Rigidbody;
            if (removeJoints.Checked) _options |= TrimOptions.Joint;
            Close();
        }

        private void trimCloneButton_Click(object sender, EventArgs e)
        {
            _options = TrimOptions.Clone;

            if (removeVertices.Checked) _options |= TrimOptions.Vertex;
            if (removeTriangles.Checked) _options |= TrimOptions.Triangle;
            if (removeBones.Checked) _options |= TrimOptions.Bone;
            if (removeRigidbodies.Checked) _options |= TrimOptions.Rigidbody;
            if (removeJoints.Checked) _options |= TrimOptions.Joint;
            Close();
        }

        private void TrimForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _options = TrimOptions.Cancel;
        }
    }
}
