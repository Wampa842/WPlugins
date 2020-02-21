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
    public partial class Vector3Numeric : UserControl, INotifyPropertyChanged
    {
        private Vector3 _value;
        private bool _allowNumberChange = true;
        public Vector3Numeric()
        {
            InitializeComponent();
            _value = new Vector3();
            PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == "Value")
                {
                    _allowNumberChange = false;
                    xNumber.Value = (decimal)_value.X;
                    yNumber.Value = (decimal)_value.Y;
                    zNumber.Value = (decimal)_value.Z;
                    _allowNumberChange = true;
                }
            };
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Vector3 Value
        {
            get
            {
                return _value;
            }
            set
            {
                this.X = value.X;
                this.Y = value.Y;
                this.Z = value.Z;
            }
        }

        [Category("Value")]
        public float X
        {
            get
            {
                return _value.X;
            }
            set
            {
                _value.X = value;
                OnPropertyChanged("Value");
            }
        }

        [Category("Value")]
        public float Y
        {
            get
            {
                return _value.Y;
            }
            set
            {
                _value.Y = value;
                OnPropertyChanged("Value");
            }
        }

        [Category("Value")]
        public float Z
        {
            get
            {
                return _value.Z;
            }
            set
            {
                _value.Z = value;
                OnPropertyChanged("Value");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void number_ValueChanged(object sender, EventArgs e)
        {
            if(_allowNumberChange)
            {
                _value = new Vector3((float)xNumber.Value, (float)yNumber.Value, (float)zNumber.Value);
            }
        }

        private void Vector3Numeric_EnabledChanged(object sender, EventArgs e)
        {
            xNumber.Enabled = yNumber.Enabled = zNumber.Enabled = this.Enabled;
            Invalidate();
            xNumber.Invalidate();
            yNumber.Invalidate();
            zNumber.Invalidate();
        }
    }
}
