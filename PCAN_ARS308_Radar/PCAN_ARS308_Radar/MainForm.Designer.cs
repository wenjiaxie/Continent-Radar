namespace PCAN_ARS308_Radar
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.RadarPictureBox = new System.Windows.Forms.PictureBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.TestButton = new System.Windows.Forms.Button();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.InitializingButton = new System.Windows.Forms.Button();
            this.MessageFilterButton = new System.Windows.Forms.Button();
            this.UserInitButton = new System.Windows.Forms.Button();
            this.WriteMsgButton = new System.Windows.Forms.Button();
            this.TargetListButton = new System.Windows.Forms.Button();
            this._StartButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.InfoAndErrListView = new System.Windows.Forms.ListView();
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Content = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StopButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.MsgShowButton = new System.Windows.Forms.Button();
            this.RefreshTimer2 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RadarPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RadarPictureBox
            // 
            this.RadarPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RadarPictureBox.Location = new System.Drawing.Point(12, 12);
            this.RadarPictureBox.Name = "RadarPictureBox";
            this.RadarPictureBox.Size = new System.Drawing.Size(560, 560);
            this.RadarPictureBox.TabIndex = 0;
            this.RadarPictureBox.TabStop = false;
            this.RadarPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.RadarPictureBox_Paint);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.StatusLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.ForeColor = System.Drawing.Color.White;
            this.StatusLabel.Location = new System.Drawing.Point(153, 261);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(286, 37);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "No Device Found!";
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(678, 1);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(24, 20);
            this.TestButton.TabIndex = 2;
            this.TestButton.Text = "Test";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Visible = false;
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Interval = 10;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // InitializingButton
            // 
            this.InitializingButton.Location = new System.Drawing.Point(582, 354);
            this.InitializingButton.Name = "InitializingButton";
            this.InitializingButton.Size = new System.Drawing.Size(120, 26);
            this.InitializingButton.TabIndex = 3;
            this.InitializingButton.Text = "Sys Initialize >>";
            this.InitializingButton.UseVisualStyleBackColor = true;
            this.InitializingButton.Click += new System.EventHandler(this.InitializingButton_Click);
            // 
            // MessageFilterButton
            // 
            this.MessageFilterButton.Location = new System.Drawing.Point(582, 450);
            this.MessageFilterButton.Name = "MessageFilterButton";
            this.MessageFilterButton.Size = new System.Drawing.Size(120, 26);
            this.MessageFilterButton.TabIndex = 4;
            this.MessageFilterButton.Text = "Message Filter >>";
            this.MessageFilterButton.UseVisualStyleBackColor = true;
            this.MessageFilterButton.Click += new System.EventHandler(this.MessageFilterButton_Click);
            // 
            // UserInitButton
            // 
            this.UserInitButton.Location = new System.Drawing.Point(582, 386);
            this.UserInitButton.Name = "UserInitButton";
            this.UserInitButton.Size = new System.Drawing.Size(120, 26);
            this.UserInitButton.TabIndex = 5;
            this.UserInitButton.Text = "User Initialize>>";
            this.UserInitButton.UseVisualStyleBackColor = true;
            this.UserInitButton.Click += new System.EventHandler(this.UserInitButton_Click);
            // 
            // WriteMsgButton
            // 
            this.WriteMsgButton.Location = new System.Drawing.Point(582, 418);
            this.WriteMsgButton.Name = "WriteMsgButton";
            this.WriteMsgButton.Size = new System.Drawing.Size(120, 26);
            this.WriteMsgButton.TabIndex = 6;
            this.WriteMsgButton.Text = "Write Message  >>";
            this.WriteMsgButton.UseVisualStyleBackColor = true;
            this.WriteMsgButton.Click += new System.EventHandler(this.WriteMsgButton_Click);
            // 
            // TargetListButton
            // 
            this.TargetListButton.Location = new System.Drawing.Point(582, 482);
            this.TargetListButton.Name = "TargetListButton";
            this.TargetListButton.Size = new System.Drawing.Size(120, 26);
            this.TargetListButton.TabIndex = 7;
            this.TargetListButton.Text = "Target List    >>";
            this.TargetListButton.UseVisualStyleBackColor = true;
            this.TargetListButton.Click += new System.EventHandler(this.TargetListButton_Click);
            // 
            // _StartButton
            // 
            this._StartButton.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._StartButton.Location = new System.Drawing.Point(582, 604);
            this._StartButton.Name = "_StartButton";
            this._StartButton.Size = new System.Drawing.Size(120, 47);
            this._StartButton.TabIndex = 8;
            this._StartButton.Text = "_START";
            this._StartButton.UseVisualStyleBackColor = true;
            this._StartButton.Click += new System.EventHandler(this._StartButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.InfoAndErrListView);
            this.groupBox1.Location = new System.Drawing.Point(12, 589);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 118);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // InfoAndErrListView
            // 
            this.InfoAndErrListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Time,
            this.Status,
            this.Content});
            this.InfoAndErrListView.FullRowSelect = true;
            this.InfoAndErrListView.GridLines = true;
            this.InfoAndErrListView.HideSelection = false;
            this.InfoAndErrListView.Location = new System.Drawing.Point(6, 15);
            this.InfoAndErrListView.MultiSelect = false;
            this.InfoAndErrListView.Name = "InfoAndErrListView";
            this.InfoAndErrListView.Size = new System.Drawing.Size(548, 97);
            this.InfoAndErrListView.TabIndex = 1;
            this.InfoAndErrListView.UseCompatibleStateImageBehavior = false;
            this.InfoAndErrListView.View = System.Windows.Forms.View.Details;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 153;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 79;
            // 
            // Content
            // 
            this.Content.Text = "Content";
            this.Content.Width = 467;
            // 
            // StopButton
            // 
            this.StopButton.Font = new System.Drawing.Font("SimSun", 9F);
            this.StopButton.Location = new System.Drawing.Point(582, 660);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(120, 41);
            this.StopButton.TabIndex = 10;
            this.StopButton.Text = "STOP";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(582, 604);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(120, 37);
            this.StartButton.TabIndex = 11;
            this.StartButton.Text = "START";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // MsgShowButton
            // 
            this.MsgShowButton.Enabled = false;
            this.MsgShowButton.Location = new System.Drawing.Point(582, 514);
            this.MsgShowButton.Name = "MsgShowButton";
            this.MsgShowButton.Size = new System.Drawing.Size(120, 26);
            this.MsgShowButton.TabIndex = 12;
            this.MsgShowButton.Text = "Hide Message";
            this.MsgShowButton.UseVisualStyleBackColor = true;
            this.MsgShowButton.Click += new System.EventHandler(this.MsgShowButton_Click);
            // 
            // RefreshTimer2
            // 
            this.RefreshTimer2.Interval = 500;
            this.RefreshTimer2.Tick += new System.EventHandler(this.RefreshTimer2_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(582, 546);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 26);
            this.button1.TabIndex = 13;
            this.button1.Text = "About";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(710, 719);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MsgShowButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._StartButton);
            this.Controls.Add(this.TargetListButton);
            this.Controls.Add(this.WriteMsgButton);
            this.Controls.Add(this.UserInitButton);
            this.Controls.Add(this.MessageFilterButton);
            this.Controls.Add(this.InitializingButton);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.RadarPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(50, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Radar Scanning";
            this.Move += new System.EventHandler(this.MainForm_Move);
            ((System.ComponentModel.ISupportInitialize)(this.RadarPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox RadarPictureBox;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.Button _StartButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.ListView InfoAndErrListView;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader Content;
        public System.Windows.Forms.Timer RefreshTimer;
        public System.Windows.Forms.Button StartButton;
        public System.Windows.Forms.Button MsgShowButton;
        public System.Windows.Forms.Button InitializingButton;
        public System.Windows.Forms.Button MessageFilterButton;
        public System.Windows.Forms.Button UserInitButton;
        public System.Windows.Forms.Button WriteMsgButton;
        public System.Windows.Forms.Button TargetListButton;
        public System.Windows.Forms.Timer RefreshTimer2;
        public System.Windows.Forms.Button button1;
    }

}

