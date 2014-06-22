namespace PCAN_ARS308_Radar
{
    partial class WriteMsgForm
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
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ExtendedFrameCheckBox_WM = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LengthUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.D7 = new System.Windows.Forms.TextBox();
            this.D2 = new System.Windows.Forms.TextBox();
            this.D1 = new System.Windows.Forms.TextBox();
            this.D0 = new System.Windows.Forms.TextBox();
            this.D4 = new System.Windows.Forms.TextBox();
            this.D6 = new System.Windows.Forms.TextBox();
            this.D5 = new System.Windows.Forms.TextBox();
            this.D3 = new System.Windows.Forms.TextBox();
            this.WriteButton = new System.Windows.Forms.Button();
            this.RTRCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.LengthUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(69, 12);
            this.IdTextBox.MaxLength = 3;
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(100, 21);
            this.IdTextBox.TabIndex = 0;
            this.IdTextBox.Text = "0";
            this.IdTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdTextBox_KeyPress);
            this.IdTextBox.Leave += new System.EventHandler(this.IdTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID (Hex)";
            // 
            // ExtendedFrameCheckBox_WM
            // 
            this.ExtendedFrameCheckBox_WM.AutoSize = true;
            this.ExtendedFrameCheckBox_WM.Location = new System.Drawing.Point(184, 14);
            this.ExtendedFrameCheckBox_WM.Name = "ExtendedFrameCheckBox_WM";
            this.ExtendedFrameCheckBox_WM.Size = new System.Drawing.Size(78, 28);
            this.ExtendedFrameCheckBox_WM.TabIndex = 2;
            this.ExtendedFrameCheckBox_WM.Text = "Extended \r\nFrame";
            this.ExtendedFrameCheckBox_WM.UseVisualStyleBackColor = true;
            this.ExtendedFrameCheckBox_WM.CheckedChanged += new System.EventHandler(this.ExtendedFrameCheckBox_WM_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Length";
            // 
            // LengthUpDown
            // 
            this.LengthUpDown.Location = new System.Drawing.Point(69, 59);
            this.LengthUpDown.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.LengthUpDown.Name = "LengthUpDown";
            this.LengthUpDown.Size = new System.Drawing.Size(100, 21);
            this.LengthUpDown.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data(0...7)";
            // 
            // D7
            // 
            this.D7.Location = new System.Drawing.Point(233, 124);
            this.D7.MaxLength = 2;
            this.D7.Name = "D7";
            this.D7.Size = new System.Drawing.Size(25, 21);
            this.D7.TabIndex = 107;
            this.D7.Text = "00";
            this.D7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.D7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdTextBox_KeyPress);
            this.D7.Leave += new System.EventHandler(this.D0_Leave);
            // 
            // D2
            // 
            this.D2.Location = new System.Drawing.Point(78, 124);
            this.D2.MaxLength = 2;
            this.D2.Name = "D2";
            this.D2.Size = new System.Drawing.Size(25, 21);
            this.D2.TabIndex = 102;
            this.D2.Text = "00";
            this.D2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.D2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdTextBox_KeyPress);
            this.D2.Leave += new System.EventHandler(this.D0_Leave);
            // 
            // D1
            // 
            this.D1.Location = new System.Drawing.Point(47, 124);
            this.D1.MaxLength = 2;
            this.D1.Name = "D1";
            this.D1.Size = new System.Drawing.Size(25, 21);
            this.D1.TabIndex = 101;
            this.D1.Text = "00";
            this.D1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.D1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdTextBox_KeyPress);
            this.D1.Leave += new System.EventHandler(this.D0_Leave);
            // 
            // D0
            // 
            this.D0.Location = new System.Drawing.Point(16, 124);
            this.D0.MaxLength = 2;
            this.D0.Name = "D0";
            this.D0.Size = new System.Drawing.Size(25, 21);
            this.D0.TabIndex = 100;
            this.D0.Text = "00";
            this.D0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.D0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdTextBox_KeyPress);
            this.D0.Leave += new System.EventHandler(this.D0_Leave);
            // 
            // D4
            // 
            this.D4.Location = new System.Drawing.Point(140, 124);
            this.D4.MaxLength = 2;
            this.D4.Name = "D4";
            this.D4.Size = new System.Drawing.Size(25, 21);
            this.D4.TabIndex = 104;
            this.D4.Text = "00";
            this.D4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.D4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdTextBox_KeyPress);
            this.D4.Leave += new System.EventHandler(this.D0_Leave);
            // 
            // D6
            // 
            this.D6.Location = new System.Drawing.Point(202, 124);
            this.D6.MaxLength = 2;
            this.D6.Name = "D6";
            this.D6.Size = new System.Drawing.Size(25, 21);
            this.D6.TabIndex = 106;
            this.D6.Text = "00";
            this.D6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.D6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdTextBox_KeyPress);
            this.D6.Leave += new System.EventHandler(this.D0_Leave);
            // 
            // D5
            // 
            this.D5.Location = new System.Drawing.Point(171, 124);
            this.D5.MaxLength = 2;
            this.D5.Name = "D5";
            this.D5.Size = new System.Drawing.Size(25, 21);
            this.D5.TabIndex = 105;
            this.D5.Text = "00";
            this.D5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.D5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdTextBox_KeyPress);
            this.D5.Leave += new System.EventHandler(this.D0_Leave);
            // 
            // D3
            // 
            this.D3.Location = new System.Drawing.Point(109, 124);
            this.D3.MaxLength = 2;
            this.D3.Name = "D3";
            this.D3.Size = new System.Drawing.Size(25, 21);
            this.D3.TabIndex = 103;
            this.D3.Text = "00";
            this.D3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.D3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdTextBox_KeyPress);
            this.D3.Leave += new System.EventHandler(this.D0_Leave);
            // 
            // WriteButton
            // 
            this.WriteButton.Location = new System.Drawing.Point(184, 163);
            this.WriteButton.Name = "WriteButton";
            this.WriteButton.Size = new System.Drawing.Size(75, 23);
            this.WriteButton.TabIndex = 14;
            this.WriteButton.Text = "Write";
            this.WriteButton.UseVisualStyleBackColor = true;
            this.WriteButton.Click += new System.EventHandler(this.WriteButton_Click);
            // 
            // RTRCheckBox
            // 
            this.RTRCheckBox.AutoSize = true;
            this.RTRCheckBox.Location = new System.Drawing.Point(184, 98);
            this.RTRCheckBox.Name = "RTRCheckBox";
            this.RTRCheckBox.Size = new System.Drawing.Size(42, 16);
            this.RTRCheckBox.TabIndex = 15;
            this.RTRCheckBox.Text = "RTR";
            this.RTRCheckBox.UseVisualStyleBackColor = true;
            this.RTRCheckBox.CheckedChanged += new System.EventHandler(this.RTRCheckBox_CheckedChanged);
            // 
            // WriteMsgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 219);
            this.ControlBox = false;
            this.Controls.Add(this.RTRCheckBox);
            this.Controls.Add(this.WriteButton);
            this.Controls.Add(this.D3);
            this.Controls.Add(this.D5);
            this.Controls.Add(this.D6);
            this.Controls.Add(this.D4);
            this.Controls.Add(this.D0);
            this.Controls.Add(this.D1);
            this.Controls.Add(this.D2);
            this.Controls.Add(this.D7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LengthUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ExtendedFrameCheckBox_WM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IdTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "WriteMsgForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Write Message";
            ((System.ComponentModel.ISupportInitialize)(this.LengthUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IdTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ExtendedFrameCheckBox_WM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown LengthUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox D7;
        private System.Windows.Forms.TextBox D2;
        private System.Windows.Forms.TextBox D1;
        private System.Windows.Forms.TextBox D0;
        private System.Windows.Forms.TextBox D4;
        private System.Windows.Forms.TextBox D6;
        private System.Windows.Forms.TextBox D5;
        private System.Windows.Forms.TextBox D3;
        private System.Windows.Forms.Button WriteButton;
        private System.Windows.Forms.CheckBox RTRCheckBox;
    }
}