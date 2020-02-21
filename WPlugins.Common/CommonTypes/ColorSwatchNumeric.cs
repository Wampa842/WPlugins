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
    public partial class ColorSwatchNumeric : UserControl
    {
        private bool _allowNumberChangeEvent = true;
        public ColorSwatchNumeric()
        {
            InitializeComponent();
            swatch_PropertyChanged(swatch, new PropertyChangedEventArgs("Color"));
        }

        public Color Color
        {
            get
            {
                return swatch.Color;
            }
            set
            {
                swatch.Color = value;
            }
        }

        private void swatch_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Color")
            {
                //decimal r = swatch.Color.R / 255.0m;
                //decimal g = swatch.Color.G / 255.0m;
                //decimal b = swatch.Color.B / 255.0m;
                _allowNumberChangeEvent = false;
                redNumber.Value = swatch.Color.R / 255.0m;
                greenNumber.Value = swatch.Color.G / 255.0m;
                blueNumber.Value = swatch.Color.B / 255.0m;
                _allowNumberChangeEvent = true;
            }
        }

        private void number_ValueChanged(object sender, EventArgs e)
        {
            if (_allowNumberChangeEvent)
            {
                int r = (int)Math.Round(redNumber.Value * 255);
                int g = (int)Math.Round(greenNumber.Value * 255);
                int b = (int)Math.Round(blueNumber.Value * 255);
                swatch.SetColor(Color.FromArgb(255, r, g, b));
            }
        }
    }
}
