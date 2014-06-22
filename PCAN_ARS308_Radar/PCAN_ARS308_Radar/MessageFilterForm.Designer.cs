namespace PCAN_ARS308_Radar
{
    partial class MessageFilterForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ExtendedCheckBox = new System.Windows.Forms.CheckBox();
            this.OpenRadioButton = new System.Windows.Forms.RadioButton();
            this.CloseRadioButton = new System.Windows.Forms.RadioButton();
            this.CustomRadioButton = new System.Windows.Forms.RadioButton();
            this.FromUpDown = new System.Windows.Forms.NumericUpDown();
            this.ToUpDown = new System.Windows.Forms.NumericUpDown();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.QueryButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FromUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ExtendedCheckBox
            // 
            this.ExtendedCheckBox.AutoSize = true;
            this.ExtendedCheckBox.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExtendedCheckBox.Location = new System.Drawing.Point(12, 12);
            this.ExtendedCheckBox.Name = "ExtendedCheckBox";
            this.ExtendedCheckBox.Size = new System.Drawing.Size(108, 16);
            this.ExtendedCheckBox.TabIndex = 0;
            this.ExtendedCheckBox.Text = "Extended Frame";
            this.ExtendedCheckBox.UseVisualStyleBackColor = true;
            this.ExtendedCheckBox.CheckedChanged += new System.EventHandler(this.ExtendedCheckBox_CheckedChanged);
            // 
            // OpenRadioButton
            // 
            this.OpenRadioButton.Checked = true;
            this.OpenRadioButton.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OpenRadioButton.Location = new System.Drawing.Point(12, 47);
            this.OpenRadioButton.Name = "OpenRadioButton";
            this.OpenRadioButton.Size = new System.Drawing.Size(47, 16);
            this.OpenRadioButton.TabIndex = 1;
            this.OpenRadioButton.TabStop = true;
            this.OpenRadioButton.Text = "Open";
            this.OpenRadioButton.CheckedChanged += new System.EventHandler(this.OpenRadioButton_CheckedChanged);
            // 
            // CloseRadioButton
            // 
            this.CloseRadioButton.AutoSize = true;
            this.CloseRadioButton.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CloseRadioButton.Location = new System.Drawing.Point(93, 47);
            this.CloseRadioButton.Name = "CloseRadioButton";
            this.CloseRadioButton.Size = new System.Drawing.Size(53, 16);
            this.CloseRadioButton.TabIndex = 2;
            this.CloseRadioButton.Text = "Close";
            this.CloseRadioButton.UseVisualStyleBackColor = true;
            this.CloseRadioButton.CheckedChanged += new System.EventHandler(this.CloseRadioButton_CheckedChanged);
            // 
            // CustomRadioButton
            // 
            this.CustomRadioButton.AutoSize = true;
            this.CustomRadioButton.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CustomRadioButton.Location = new System.Drawing.Point(12, 78);
            this.CustomRadioButton.Name = "CustomRadioButton";
            this.CustomRadioButton.Size = new System.Drawing.Size(107, 16);
            this.CustomRadioButton.TabIndex = 3;
            this.CustomRadioButton.Text = "Custom(expand)";
            this.CustomRadioButton.UseVisualStyleBackColor = true;
            this.CustomRadioButton.CheckedChanged += new System.EventHandler(this.CustomRadioButton_CheckedChanged);
            // 
            // FromUpDown
            // 
            this.FromUpDown.Enabled = false;
            this.FromUpDown.Hexadecimal = true;
            this.FromUpDown.Location = new System.Drawing.Point(61, 110);
            this.FromUpDown.Maximum = new decimal(new int[] {
            2047,
            0,
            0,
            0});
            this.FromUpDown.Name = "FromUpDown";
            this.FromUpDown.Size = new System.Drawing.Size(105, 21);
            this.FromUpDown.TabIndex = 4;
            // 
            // ToUpDown
            // 
            this.ToUpDown.Enabled = false;
            this.ToUpDown.Hexadecimal = true;
            this.ToUpDown.Location = new System.Drawing.Point(61, 148);
            this.ToUpDown.Maximum = new decimal(new int[] {
            2047,
            0,
            0,
            0});
            this.ToUpDown.Name = "ToUpDown";
            this.ToUpDown.Size = new System.Drawing.Size(105, 21);
            this.ToUpDown.TabIndex = 5;
            this.ToUpDown.Value = new decimal(new int[] {
            2047,
            0,
            0,
            0});
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(12, 204);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 22);
            this.ApplyButton.TabIndex = 6;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // QueryButton
            // 
            this.QueryButton.Location = new System.Drawing.Point(93, 204);
            this.QueryButton.Name = "QueryButton";
            this.QueryButton.Size = new System.Drawing.Size(75, 22);
            this.QueryButton.TabIndex = 7;
            this.QueryButton.Text = "Query";
            this.QueryButton.UseVisualStyleBackColor = true;
            this.QueryButton.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "From：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(10, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "To  ：";
            // 
            // MessageFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(182, 273);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.QueryButton);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.ToUpDown);
            this.Controls.Add(this.FromUpDown);
            this.Controls.Add(this.CustomRadioButton);
            this.Controls.Add(this.CloseRadioButton);
            this.Controls.Add(this.OpenRadioButton);
            this.Controls.Add(this.ExtendedCheckBox);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MessageFilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Message Filter Setting";
            ((System.ComponentModel.ISupportInitialize)(this.FromUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button QueryButton;
        public System.Windows.Forms.CheckBox ExtendedCheckBox;
        public System.Windows.Forms.RadioButton OpenRadioButton;
        public System.Windows.Forms.RadioButton CloseRadioButton;
        public System.Windows.Forms.RadioButton CustomRadioButton;
        public System.Windows.Forms.NumericUpDown FromUpDown;
        public System.Windows.Forms.NumericUpDown ToUpDown;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
    }
}