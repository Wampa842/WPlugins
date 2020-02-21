using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;

namespace WPlugins.QuickIK
{
    public partial class PhysicsSettingsForm : Form
    {
        private PhysicsSettings _settings;
        public PhysicsSettings PhysicsSettings
        {
            get
            {
                return _settings;
            }
            set
            {
                _settings = value;
                switch (_settings.Shape)
                {
                    case PEPlugin.Pmd.BodyBoxKind.Box:
                        shapeSelect.SelectedIndex = 1;
                        break;
                    case PEPlugin.Pmd.BodyBoxKind.Capsule:
                        shapeSelect.SelectedIndex = 2;
                        break;
                    default:
                        shapeSelect.SelectedIndex = 0;
                        break;
                }
                switch (_settings.BodyMode)
                {
                    case PEPlugin.Pmd.BodyMode.Dynamic:
                        modeSelect.SelectedIndex = 1;
                        break;
                    case PEPlugin.Pmd.BodyMode.DynamicWithBone:
                        modeSelect.SelectedIndex = 2;
                        break;
                    default:
                        modeSelect.SelectedIndex = 0;
                        break;
                }
                switch (_settings.LengthCalculation)
                {
                    case PhysicsSettings.LengthCalculationMode.Absolute:
                        lengthCalcSelect.SelectedIndex = 0;
                        break;
                    case PhysicsSettings.LengthCalculationMode.DistanceFromEnds:
                        lengthCalcSelect.SelectedIndex = 2;
                        break;
                    default:
                        lengthCalcSelect.SelectedIndex = 1;
                        break;
                }
                widthText.Text = _settings.Width.ToString("f4", CultureInfo.InvariantCulture);
                heightText.Text = _settings.Height.ToString("f4", CultureInfo.InvariantCulture);
                lengthText.Text = _settings.Length.ToString("f4", CultureInfo.InvariantCulture);
                attachParentCheck.Checked = _settings.AttachToParent;
            }
        }
        public PhysicsSettingsForm()
        {
            InitializeComponent();
        }

        private void PhysicsSettingsForm_Load(object sender, EventArgs e)
        {
            shapeSelect.SelectedIndex = 0;
            modeSelect.SelectedIndex = 0;
            lengthCalcSelect.SelectedIndex = 1;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            _settings = new PhysicsSettings();
            try
            {
                _settings.Length = float.Parse(lengthText.Text, CultureInfo.InvariantCulture);
                _settings.Width = float.Parse(widthText.Text, CultureInfo.InvariantCulture);
                _settings.Height = float.Parse(heightText.Text, CultureInfo.InvariantCulture);
            }
            catch(FormatException)
            {
                MessageBox.Show("Make sure the number values are formatted correctly!");
                return;
            }
            switch (lengthCalcSelect.SelectedIndex)
            {
                case 1:
                    _settings.LengthCalculation = PhysicsSettings.LengthCalculationMode.Relative;
                    break;
                case 2:
                    _settings.LengthCalculation = PhysicsSettings.LengthCalculationMode.DistanceFromEnds;
                    break;
                default:
                    _settings.LengthCalculation = PhysicsSettings.LengthCalculationMode.Absolute;
                    break;
            }
            switch (shapeSelect.SelectedIndex)
            {
                case 0:
                    _settings.Shape = PEPlugin.Pmd.BodyBoxKind.Sphere;
                    break;
                case 2:
                    _settings.Shape = PEPlugin.Pmd.BodyBoxKind.Capsule;
                    break;
                default:
                    _settings.Shape = PEPlugin.Pmd.BodyBoxKind.Box;
                    break;
            }
            switch (modeSelect.SelectedIndex)
            {
                case 1:
                    _settings.BodyMode = PEPlugin.Pmd.BodyMode.Dynamic;
                    break;
                case 2:
                    _settings.BodyMode = PEPlugin.Pmd.BodyMode.DynamicWithBone;
                    break;
                default:
                    _settings.BodyMode = PEPlugin.Pmd.BodyMode.Static;
                    break;
            }
            _settings.AttachToParent = attachParentCheck.Checked;

            DialogResult = DialogResult.OK;
            Hide();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void shapeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (shapeSelect.SelectedIndex)
            {
                case 0: // sphere
                    lengthText.Enabled = true;
                    heightText.Enabled = false;
                    widthText.Enabled = false;

                    lengthLabel.Text = "Radius";
                    heightLabel.Text = "Height";
                    widthLabel.Text = "Width";
                    break;
                case 2: // Capsule
                    lengthText.Enabled = true;
                    heightText.Enabled = false;
                    widthText.Enabled = true;

                    lengthLabel.Text = "Length";
                    heightLabel.Text = "Height";
                    widthLabel.Text = "Radius";
                    break;
                default:    // Box
                    lengthText.Enabled = true;
                    heightText.Enabled = true;
                    widthText.Enabled = true;

                    lengthLabel.Text = "Length";
                    heightLabel.Text = "Height";
                    widthLabel.Text = "Width";
                    break;
            }
        }

        private void lengthCalcSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lengthCalcSelect.SelectedIndex == 1)
            {
                lengthText.Text = "1.0";
            }
        }
    }
}
