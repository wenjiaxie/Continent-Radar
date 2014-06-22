namespace PCAN_ARS308_Radar
{
    partial class UserInitForm
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
            this.components = new System.ComponentModel.Container();
            this.SSGroupBox = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.OpTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SetStatusButton = new System.Windows.Forms.Button();
            this.RangeUpDown = new System.Windows.Forms.NumericUpDown();
            this.ElevUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CRGroupBox = new System.Windows.Forms.GroupBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.ConfirmListViewGroup = new System.Windows.Forms.ListView();
            this.NVMwritestates = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NVMreadstates = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CurrrangelengthCal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Currelevationcal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RadarPowerReduction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CurrentRadarPower = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SupVolt_L = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Rxinvalid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sensdef = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SensTempErr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DirectComboBox = new System.Windows.Forms.ComboBox();
            this.SetVelocityButton = new System.Windows.Forms.Button();
            this.SpeedUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SetYawButton = new System.Windows.Forms.Button();
            this.YawUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.tmrRead = new System.Windows.Forms.Timer(this.components);
            this.SSGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RangeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElevUpDown)).BeginInit();
            this.CRGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YawUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // SSGroupBox
            // 
            this.SSGroupBox.Controls.Add(this.label9);
            this.SSGroupBox.Controls.Add(this.OpTypeComboBox);
            this.SSGroupBox.Controls.Add(this.SetStatusButton);
            this.SSGroupBox.Controls.Add(this.RangeUpDown);
            this.SSGroupBox.Controls.Add(this.ElevUpDown);
            this.SSGroupBox.Controls.Add(this.label3);
            this.SSGroupBox.Controls.Add(this.label2);
            this.SSGroupBox.Controls.Add(this.label1);
            this.SSGroupBox.Location = new System.Drawing.Point(12, 12);
            this.SSGroupBox.Name = "SSGroupBox";
            this.SSGroupBox.Size = new System.Drawing.Size(470, 75);
            this.SSGroupBox.TabIndex = 9;
            this.SSGroupBox.TabStop = false;
            this.SSGroupBox.Text = "Set Rada\'s Status";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(132, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "Elevation(deg)";
            // 
            // OpTypeComboBox
            // 
            this.OpTypeComboBox.DisplayMember = "Target";
            this.OpTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OpTypeComboBox.FormattingEnabled = true;
            this.OpTypeComboBox.Items.AddRange(new object[] {
            "Target",
            "Object"});
            this.OpTypeComboBox.Location = new System.Drawing.Point(257, 33);
            this.OpTypeComboBox.Name = "OpTypeComboBox";
            this.OpTypeComboBox.Size = new System.Drawing.Size(98, 20);
            this.OpTypeComboBox.TabIndex = 7;
            // 
            // SetStatusButton
            // 
            this.SetStatusButton.Location = new System.Drawing.Point(372, 29);
            this.SetStatusButton.Name = "SetStatusButton";
            this.SetStatusButton.Size = new System.Drawing.Size(92, 23);
            this.SetStatusButton.TabIndex = 6;
            this.SetStatusButton.Text = "Set Status";
            this.SetStatusButton.UseVisualStyleBackColor = true;
            this.SetStatusButton.Click += new System.EventHandler(this.SetStatusButton_Click);
            // 
            // RangeUpDown
            // 
            this.RangeUpDown.Location = new System.Drawing.Point(8, 32);
            this.RangeUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.RangeUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.RangeUpDown.Name = "RangeUpDown";
            this.RangeUpDown.Size = new System.Drawing.Size(98, 21);
            this.RangeUpDown.TabIndex = 5;
            this.RangeUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // ElevUpDown
            // 
            this.ElevUpDown.DecimalPlaces = 2;
            this.ElevUpDown.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.ElevUpDown.Location = new System.Drawing.Point(134, 32);
            this.ElevUpDown.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.ElevUpDown.Name = "ElevUpDown";
            this.ElevUpDown.Size = new System.Drawing.Size(98, 21);
            this.ElevUpDown.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Output Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, -10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Elevation";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Range(m)";
            // 
            // CRGroupBox
            // 
            this.CRGroupBox.Controls.Add(this.ConfirmButton);
            this.CRGroupBox.Controls.Add(this.ConfirmListViewGroup);
            this.CRGroupBox.Location = new System.Drawing.Point(12, 255);
            this.CRGroupBox.Name = "CRGroupBox";
            this.CRGroupBox.Size = new System.Drawing.Size(470, 131);
            this.CRGroupBox.TabIndex = 0;
            this.CRGroupBox.TabStop = false;
            this.CRGroupBox.Text = "Confirm the Result";
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Enabled = false;
            this.ConfirmButton.Location = new System.Drawing.Point(372, 102);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(92, 23);
            this.ConfirmButton.TabIndex = 2;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ConfirmListViewGroup
            // 
            this.ConfirmListViewGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NVMwritestates,
            this.NVMreadstates,
            this.CurrrangelengthCal,
            this.Currelevationcal,
            this.RadarPowerReduction,
            this.CurrentRadarPower,
            this.SupVolt_L,
            this.Rxinvalid,
            this.Sensdef,
            this.SensTempErr});
            this.ConfirmListViewGroup.FullRowSelect = true;
            this.ConfirmListViewGroup.GridLines = true;
            this.ConfirmListViewGroup.Location = new System.Drawing.Point(6, 20);
            this.ConfirmListViewGroup.Name = "ConfirmListViewGroup";
            this.ConfirmListViewGroup.Size = new System.Drawing.Size(458, 63);
            this.ConfirmListViewGroup.TabIndex = 0;
            this.ConfirmListViewGroup.UseCompatibleStateImageBehavior = false;
            this.ConfirmListViewGroup.View = System.Windows.Forms.View.Details;
            // 
            // NVMwritestates
            // 
            this.NVMwritestates.Text = "NVMwritestates";
            this.NVMwritestates.Width = 102;
            // 
            // NVMreadstates
            // 
            this.NVMreadstates.Text = "NVMreadstates";
            this.NVMreadstates.Width = 94;
            // 
            // CurrrangelengthCal
            // 
            this.CurrrangelengthCal.Text = "CurrrangelengthCal";
            this.CurrrangelengthCal.Width = 76;
            // 
            // Currelevationcal
            // 
            this.Currelevationcal.Text = "Currelevationcal";
            this.Currelevationcal.Width = 52;
            // 
            // RadarPowerReduction
            // 
            this.RadarPowerReduction.Text = "RadarPowerReduction";
            this.RadarPowerReduction.Width = 106;
            // 
            // CurrentRadarPower
            // 
            this.CurrentRadarPower.Text = "CurrentRadarPower";
            // 
            // SupVolt_L
            // 
            this.SupVolt_L.Text = "SupVolt_L";
            // 
            // Rxinvalid
            // 
            this.Rxinvalid.Text = "Rxinvalid";
            // 
            // Sensdef
            // 
            this.Sensdef.Text = "Sensdef";
            // 
            // SensTempErr
            // 
            this.SensTempErr.Text = "SensTempErr";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DirectComboBox);
            this.groupBox1.Controls.Add(this.SetVelocityButton);
            this.groupBox1.Controls.Add(this.SpeedUpDown);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 75);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Radar\'s Velocity";
            // 
            // DirectComboBox
            // 
            this.DirectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DirectComboBox.FormattingEnabled = true;
            this.DirectComboBox.Items.AddRange(new object[] {
            "Standstill",
            "Forward",
            "Reverse"});
            this.DirectComboBox.Location = new System.Drawing.Point(134, 35);
            this.DirectComboBox.Name = "DirectComboBox";
            this.DirectComboBox.Size = new System.Drawing.Size(98, 20);
            this.DirectComboBox.TabIndex = 7;
            // 
            // SetVelocityButton
            // 
            this.SetVelocityButton.Location = new System.Drawing.Point(372, 31);
            this.SetVelocityButton.Name = "SetVelocityButton";
            this.SetVelocityButton.Size = new System.Drawing.Size(92, 23);
            this.SetVelocityButton.TabIndex = 6;
            this.SetVelocityButton.Text = "Set Velocity";
            this.SetVelocityButton.UseVisualStyleBackColor = true;
            this.SetVelocityButton.Click += new System.EventHandler(this.SetVelocityButton_Click);
            // 
            // SpeedUpDown
            // 
            this.SpeedUpDown.DecimalPlaces = 2;
            this.SpeedUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            this.SpeedUpDown.Location = new System.Drawing.Point(8, 34);
            this.SpeedUpDown.Maximum = new decimal(new int[] {
            1638,
            0,
            0,
            65536});
            this.SpeedUpDown.Name = "SpeedUpDown";
            this.SpeedUpDown.Size = new System.Drawing.Size(98, 21);
            this.SpeedUpDown.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "Speed(m/s)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(132, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "Direction";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SetYawButton);
            this.groupBox2.Controls.Add(this.YawUpDown);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 75);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set Radar\'s Yaw Rate";
            // 
            // SetYawButton
            // 
            this.SetYawButton.Location = new System.Drawing.Point(372, 33);
            this.SetYawButton.Name = "SetYawButton";
            this.SetYawButton.Size = new System.Drawing.Size(92, 23);
            this.SetYawButton.TabIndex = 4;
            this.SetYawButton.Text = "Set Yaw Rate";
            this.SetYawButton.UseVisualStyleBackColor = true;
            this.SetYawButton.Click += new System.EventHandler(this.SetYawButton_Click);
            // 
            // YawUpDown
            // 
            this.YawUpDown.DecimalPlaces = 2;
            this.YawUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.YawUpDown.Location = new System.Drawing.Point(8, 36);
            this.YawUpDown.Maximum = new decimal(new int[] {
            32766,
            0,
            0,
            131072});
            this.YawUpDown.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147352576});
            this.YawUpDown.Name = "YawUpDown";
            this.YawUpDown.Size = new System.Drawing.Size(98, 21);
            this.YawUpDown.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "Yaw Rate(deg/s)";
            // 
            // tmrRead
            // 
            this.tmrRead.Interval = 1;
            this.tmrRead.Tick += new System.EventHandler(this.tmrRead_Tick);
            // 
            // UserInitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 415);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CRGroupBox);
            this.Controls.Add(this.SSGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserInitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "User Initialize";
            this.SSGroupBox.ResumeLayout(false);
            this.SSGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RangeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElevUpDown)).EndInit();
            this.CRGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YawUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox SSGroupBox;
        private System.Windows.Forms.Button SetStatusButton;
        private System.Windows.Forms.NumericUpDown ElevUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox CRGroupBox;
        private System.Windows.Forms.ListView ConfirmListViewGroup;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SetVelocityButton;
        private System.Windows.Forms.NumericUpDown SpeedUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SetYawButton;
        private System.Windows.Forms.NumericUpDown YawUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox DirectComboBox;
        private System.Windows.Forms.ColumnHeader NVMwritestates;
        private System.Windows.Forms.ColumnHeader NVMreadstates;
        private System.Windows.Forms.ColumnHeader CurrrangelengthCal;
        private System.Windows.Forms.ColumnHeader Currelevationcal;
        private System.Windows.Forms.ColumnHeader RadarPowerReduction;
        private System.Windows.Forms.ColumnHeader CurrentRadarPower;
        private System.Windows.Forms.ColumnHeader SupVolt_L;
        private System.Windows.Forms.ColumnHeader Rxinvalid;
        private System.Windows.Forms.ColumnHeader Sensdef;
        private System.Windows.Forms.ColumnHeader SensTempErr;
        public System.Windows.Forms.Timer tmrRead;
        public System.Windows.Forms.ComboBox OpTypeComboBox;
        public System.Windows.Forms.NumericUpDown RangeUpDown;

    }
}