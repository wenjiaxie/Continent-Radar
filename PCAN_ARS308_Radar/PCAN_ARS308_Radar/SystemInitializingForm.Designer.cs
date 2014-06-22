namespace PCAN_ARS308_Radar
{
    partial class SystemInitializingForm
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
            this.Baudrate = new System.Windows.Forms.Label();
            this.BaudComboBox = new System.Windows.Forms.ComboBox();
            this.InitButton = new System.Windows.Forms.Button();
            this.IOComboBox = new System.Windows.Forms.ComboBox();
            this.IO = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.INTComboBox = new System.Windows.Forms.ComboBox();
            this.ReleaseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.HardwareComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.HWTypeComboBox = new System.Windows.Forms.ComboBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Baudrate
            // 
            this.Baudrate.AutoSize = true;
            this.Baudrate.Location = new System.Drawing.Point(12, 88);
            this.Baudrate.Name = "Baudrate";
            this.Baudrate.Size = new System.Drawing.Size(53, 12);
            this.Baudrate.TabIndex = 0;
            this.Baudrate.Text = "Baudrate";
            // 
            // BaudComboBox
            // 
            this.BaudComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BaudComboBox.FormattingEnabled = true;
            this.BaudComboBox.Items.AddRange(new object[] {
            "1 MBit/sec",
            "800 kBit/s",
            "500 kBit/sec",
            "250 kBit/sec",
            "125 kBit/sec",
            "100 kBit/sec",
            "95,238 kBit/s",
            "83,333 kBit/s",
            "50 kBit/sec",
            "47,619 kBit/s",
            "33,333 kBit/s",
            "20 kBit/sec",
            "10 kBit/sec",
            "5 kBit/sec"});
            this.BaudComboBox.Location = new System.Drawing.Point(71, 85);
            this.BaudComboBox.Name = "BaudComboBox";
            this.BaudComboBox.Size = new System.Drawing.Size(121, 20);
            this.BaudComboBox.TabIndex = 1;
            this.BaudComboBox.SelectedIndexChanged += new System.EventHandler(this.BaudComboBox_SelectedIndexChanged);
            // 
            // InitButton
            // 
            this.InitButton.Location = new System.Drawing.Point(36, 203);
            this.InitButton.Name = "InitButton";
            this.InitButton.Size = new System.Drawing.Size(75, 23);
            this.InitButton.TabIndex = 2;
            this.InitButton.Text = "Initialize";
            this.InitButton.UseVisualStyleBackColor = true;
            this.InitButton.Click += new System.EventHandler(this.InitButton_Click);
            // 
            // IOComboBox
            // 
            this.IOComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IOComboBox.Enabled = false;
            this.IOComboBox.FormattingEnabled = true;
            this.IOComboBox.Items.AddRange(new object[] {
            "0100",
            "0120",
            "0140",
            "0200",
            "0220",
            "0240",
            "0260",
            "0278",
            "0280",
            "02A0",
            "02C0",
            "02E0",
            "02E8",
            "02F8",
            "0300",
            "0320",
            "0340",
            "0360",
            "0378",
            "0380",
            "03BC",
            "03E0",
            "03E8",
            "03F8"});
            this.IOComboBox.Location = new System.Drawing.Point(71, 111);
            this.IOComboBox.Name = "IOComboBox";
            this.IOComboBox.Size = new System.Drawing.Size(121, 20);
            this.IOComboBox.TabIndex = 3;
            // 
            // IO
            // 
            this.IO.AutoSize = true;
            this.IO.Location = new System.Drawing.Point(12, 114);
            this.IO.Name = "IO";
            this.IO.Size = new System.Drawing.Size(23, 12);
            this.IO.TabIndex = 4;
            this.IO.Text = "I/O";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Interrupt";
            // 
            // INTComboBox
            // 
            this.INTComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.INTComboBox.Enabled = false;
            this.INTComboBox.FormattingEnabled = true;
            this.INTComboBox.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "7",
            "9",
            "10",
            "11",
            "12",
            "15"});
            this.INTComboBox.Location = new System.Drawing.Point(71, 164);
            this.INTComboBox.Name = "INTComboBox";
            this.INTComboBox.Size = new System.Drawing.Size(121, 20);
            this.INTComboBox.TabIndex = 6;
            // 
            // ReleaseButton
            // 
            this.ReleaseButton.Enabled = false;
            this.ReleaseButton.Location = new System.Drawing.Point(117, 203);
            this.ReleaseButton.Name = "ReleaseButton";
            this.ReleaseButton.Size = new System.Drawing.Size(75, 23);
            this.ReleaseButton.TabIndex = 7;
            this.ReleaseButton.Text = "Release";
            this.ReleaseButton.UseVisualStyleBackColor = true;
            this.ReleaseButton.Click += new System.EventHandler(this.ReleaseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Hardware";
            // 
            // HardwareComboBox
            // 
            this.HardwareComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HardwareComboBox.FormattingEnabled = true;
            this.HardwareComboBox.Items.AddRange(new object[] {
            "None",
            "DNG-Channel 1",
            "ISA-Channel 1",
            "ISA-Channel 2",
            "ISA-Channel 3",
            "ISA-Channel 4",
            "ISA-Channel 5",
            "ISA-Channel 6",
            "ISA-Channel 7",
            "ISA-Channel 8",
            "PCC-Channel 1",
            "PCC-Channel 2",
            "PCI-Channel 1",
            "PCI-Channel 2"});
            this.HardwareComboBox.Location = new System.Drawing.Point(71, 30);
            this.HardwareComboBox.Name = "HardwareComboBox";
            this.HardwareComboBox.Size = new System.Drawing.Size(121, 20);
            this.HardwareComboBox.TabIndex = 10;
            this.HardwareComboBox.SelectedIndexChanged += new System.EventHandler(this.HardwareComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Hardware \r\nType";
            // 
            // HWTypeComboBox
            // 
            this.HWTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HWTypeComboBox.Enabled = false;
            this.HWTypeComboBox.FormattingEnabled = true;
            this.HWTypeComboBox.Items.AddRange(new object[] {
            "ISA-82C200",
            "ISA-SJA1000",
            "ISA-PHYTEC",
            "DNG-82C200",
            "DNG-82C200 EPP",
            "DNG-SJA1000",
            "DNG-SJA1000 EPP"});
            this.HWTypeComboBox.Location = new System.Drawing.Point(71, 138);
            this.HWTypeComboBox.Name = "HWTypeComboBox";
            this.HWTypeComboBox.Size = new System.Drawing.Size(121, 20);
            this.HWTypeComboBox.TabIndex = 12;
            this.HWTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.HWTypeComboBox_SelectedIndexChanged);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(71, 56);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(121, 23);
            this.RefreshButton.TabIndex = 13;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // SystemInitializingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 269);
            this.ControlBox = false;
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.HWTypeComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HardwareComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ReleaseButton);
            this.Controls.Add(this.INTComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IO);
            this.Controls.Add(this.IOComboBox);
            this.Controls.Add(this.InitButton);
            this.Controls.Add(this.BaudComboBox);
            this.Controls.Add(this.Baudrate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SystemInitializingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "System Initialize";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Baudrate;
        private System.Windows.Forms.ComboBox BaudComboBox;
        private System.Windows.Forms.Button InitButton;
        private System.Windows.Forms.ComboBox IOComboBox;
        private System.Windows.Forms.Label IO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox INTComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox HardwareComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox HWTypeComboBox;
        private System.Windows.Forms.Button RefreshButton;
        public System.Windows.Forms.Button ReleaseButton;
    }
}