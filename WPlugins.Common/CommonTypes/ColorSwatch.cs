using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WPlugins.Common.UI
{
    public partial class ColorSwatch : UserControl, INotifyPropertyChanged
    {
        private ColorDialog _colorDialog;
        private Color _selectedColor;

        public event PropertyChangedEventHandler PropertyChanged;

        [Description("The color represented by the selector.")]
        public Color Color
        {
            get
            {
                return _selectedColor;
            }
            set
            {
                _selectedColor = value;
                OnPropertyChanged("Color");
            }
        }

        // Set the color without invoking the PropertyChanged event
        public void SetColor(Color color)
        {
            _selectedColor = BackColor = color;
        }

        protected void OnPropertyChanged(string name)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public ColorSwatch()
        {
            InitializeComponent();
            _colorDialog = new ColorDialog();
            Color = Color.White;
            PropertyChanged += (o, e) =>
            {
                if(e.PropertyName == "Color")
                {
                    BackColor = this.Color;
                }
            };
        }

        private void ColorSwatch_Click(object sender, EventArgs e)
        {
            _colorDialog.Color = _selectedColor;
            _colorDialog.FullOpen = true;
            if(_colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color = _colorDialog.Color;
            }
        }

        private void ColorSwatch_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ColorSwatch_Click(sender, e);
            }
            else if(e.Button == MouseButtons.Right)
            {
                swatchContextMenu.Show(Cursor.Position);
            }
        }

        private void copyCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float r = Color.R / 255.0f;
            float g = Color.G / 255.0f;
            float b = Color.B / 255.0f;
            Clipboard.SetText(string.Format(System.Globalization.CultureInfo.InvariantCulture, "1.0,{0},{1},{2}", r, g, b), TextDataFormat.CommaSeparatedValue);
        }

        private void pastePToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFormatProvider culture = System.Globalization.CultureInfo.InvariantCulture;
            string[] values = Clipboard.GetText(TextDataFormat.CommaSeparatedValue).Trim().Split(',');
            int r = 0;
            int g = 0;
            int b = 0;
            try
            {
                r = (int)Math.Round(float.Parse(values[1]) * 255);
                g = (int)Math.Round(float.Parse(values[2]) * 255);
                b = (int)Math.Round(float.Parse(values[3]) * 255);
            }
            catch { }
            Color = Color.FromArgb(255, r, g, b);
        }
    }
}
