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
using PEPlugin.SDX;
using PEPlugin.View;

namespace WPlugins.ViewSettingsStorage
{
    public partial class MainForm : Form
    {
        private IPERunArgs _args;
        public MainForm(IPERunArgs args)
        {
            InitializeComponent();
            _args = args;
        }

        private ViewSettings GetCurrentView()
        {
            IPXPmxViewConnector connector = _args.Host.Connector.View.PmxView;
            IPXPmxViewHelper helper = _args.Host.Connector.View.PmxViewHelper;
            IPEViewSettingConnector settings = _args.Host.Connector.View.PmxViewSetting;

            ViewSettings view = new ViewSettings();

            view.Camera.Position = new Vector3(connector.CameraPosition);
            view.Camera.Target = new Vector3(connector.CameraTarget);
            view.Camera.Up = new Vector3(connector.CameraUpVector);

            view.RotationCenter = new Vector3(connector.CameraRotateCenter);

            view.AmbientColor = settings.AmbientColor;
            view.LightColor = settings.LightColor;
            view.LightDirection = new Vector3(settings.LightDirection);

            view.BackgroundColor = settings.BackColor;

            return new ViewSettings();
        }

        private void getCurrentButton_Click(object sender, EventArgs e)
        {
            // Get the current view settings and put it into the UI
            IPXPmxViewConnector connector = _args.Host.Connector.View.PmxView;
            IPXPmxViewHelper helper = _args.Host.Connector.View.PmxViewHelper;
            IPEViewSettingConnector settings = _args.Host.Connector.View.PmxViewSetting;

            cameraPosition.Value = new Vector3(connector.CameraPosition);
            cameraTarget.Value = new Vector3(connector.CameraTarget);
            cameraUp.Value = new Vector3(connector.CameraUpVector);

            orbitCenter.Value = new Vector3(connector.CameraRotateCenter);

            ambientColor.Color = settings.AmbientColor;
            lightColor.Color = settings.LightColor;
            lightDirection.Value = new Vector3(settings.LightDirection);
            backgroundColor.Color = settings.BackColor;
        }

        private void applyCurrentButton_Click(object sender, EventArgs e)
        {
            // Apply the UI values to the current view
            IPXPmxViewConnector connector = _args.Host.Connector.View.PmxView;
            IPXPmxViewHelper helper = _args.Host.Connector.View.PmxViewHelper;
            IPEViewSettingConnector settings = _args.Host.Connector.View.PmxViewSetting;

            if (cameraEnable.Checked)
            {
                connector.CameraPosition = cameraPosition.Value;
                connector.CameraTarget = cameraTarget.Value;
                connector.CameraUpVector = cameraUp.Value;
            }
            if (orbitEnable.Checked)
            {
                connector.CameraRotateCenter = orbitCenter.Value;
            }
            if (lightEnable.Checked)
            {
                settings.AmbientColor = ambientColor.Color;
                settings.LightColor = lightColor.Color;
                settings.LightDirection = lightDirection.Value;
            }
            if (backgroundEnable.Checked)
            {
                settings.BackColor = backgroundColor.Color;
            }

            connector.UpdateView();
        }

        private void restoreButton_Click(object sender, EventArgs e)
        {
            // Get stored view settings and put them into the UI
        }

        private void storeButton_Click(object sender, EventArgs e)
        {
            // Store current UI values in the list
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_args.Host.Connector.View.PmxViewSetting.Perspective.ToString());
        }
    }
}
