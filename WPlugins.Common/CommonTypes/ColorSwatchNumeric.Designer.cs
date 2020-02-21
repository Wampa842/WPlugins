namespace WPlugins.Common.UI
{
    partial class ColorSwatchNumeric
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.swatch = new WPlugins.Common.UI.ColorSwatch();
            this.redNumber = new System.Windows.Forms.NumericUpDown();
            this.greenNumber = new System.Windows.Forms.NumericUpDown();
            this.blueNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.redNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // swatch
            // 
            this.swatch.BackColor = System.Drawing.Color.White;
            this.swatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.swatch.Color = System.Drawing.Color.White;
            this.swatch.Location = new System.Drawing.Point(3, 3);
            this.swatch.Name = "swatch";
            this.swatch.Size = new System.Drawing.Size(40, 20);
            this.swatch.TabIndex = 0;
            this.swatch.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.swatch_PropertyChanged);
            // 
            // redNumber
            // 
            this.redNumber.DecimalPlaces = 2;
            this.redNumber.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.redNumber.Location = new System.Drawing.Point(49, 3);
            this.redNumber.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.redNumber.Name = "redNumber";
            this.redNumber.Size = new System.Drawing.Size(50, 20);
            this.redNumber.TabIndex = 1;
            this.redNumber.ValueChanged += new System.EventHandler(this.number_ValueChanged);
            // 
            // greenNumber
            // 
            this.greenNumber.DecimalPlaces = 2;
            this.greenNumber.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.greenNumber.Location = new System.Drawing.Point(105, 3);
            this.greenNumber.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.greenNumber.Name = "greenNumber";
            this.greenNumber.Size = new System.Drawing.Size(50, 20);
            this.greenNumber.TabIndex = 2;
            this.greenNumber.ValueChanged += new System.EventHandler(this.number_ValueChanged);
            // 
            // blueNumber
            // 
            this.blueNumber.DecimalPlaces = 2;
            this.blueNumber.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.blueNumber.Location = new System.Drawing.Point(163, 3);
            this.blueNumber.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.blueNumber.Name = "blueNumber";
            this.blueNumber.Size = new System.Drawing.Size(50, 20);
            this.blueNumber.TabIndex = 3;
            this.blueNumber.ValueChanged += new System.EventHandler(this.number_ValueChanged);
            // 
            // ColorSwatchNumeric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.blueNumber);
            this.Controls.Add(this.greenNumber);
            this.Controls.Add(this.redNumber);
            this.Controls.Add(this.swatch);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ColorSwatchNumeric";
            this.Size = new System.Drawing.Size(216, 26);
            ((System.ComponentModel.ISupportInitialize)(this.redNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorSwatch swatch;
        private System.Windows.Forms.NumericUpDown redNumber;
        private System.Windows.Forms.NumericUpDown greenNumber;
        private System.Windows.Forms.NumericUpDown blueNumber;
    }
}
