namespace PCAN_ARS308_Radar
{
    partial class MsgDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsgDisplay));
            this.MsgListView = new System.Windows.Forms.ListView();
            this.clhType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhRcvTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tmrDisplay = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.H701checkBox = new System.Windows.Forms.CheckBox();
            this.H702CheckBox = new System.Windows.Forms.CheckBox();
            this.H60BCheckBox = new System.Windows.Forms.CheckBox();
            this.H60CCheckBox = new System.Windows.Forms.CheckBox();
            this.H60AcheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NoofTagtobDspUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NoofTagtobDspUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MsgListView
            // 
            this.MsgListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MsgListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhType,
            this.clhID,
            this.clhLength,
            this.clhData,
            this.clhCount,
            this.clhRcvTime});
            this.MsgListView.FullRowSelect = true;
            this.MsgListView.Location = new System.Drawing.Point(12, 12);
            this.MsgListView.Name = "MsgListView";
            this.MsgListView.Size = new System.Drawing.Size(560, 161);
            this.MsgListView.TabIndex = 15;
            this.MsgListView.UseCompatibleStateImageBehavior = false;
            this.MsgListView.View = System.Windows.Forms.View.Details;
            // 
            // clhType
            // 
            this.clhType.Text = "Type";
            // 
            // clhID
            // 
            this.clhID.Text = "ID";
            this.clhID.Width = 40;
            // 
            // clhLength
            // 
            this.clhLength.Text = "Length";
            // 
            // clhData
            // 
            this.clhData.Text = "Data";
            this.clhData.Width = 247;
            // 
            // clhCount
            // 
            this.clhCount.Text = "Count";
            this.clhCount.Width = 59;
            // 
            // clhRcvTime
            // 
            this.clhRcvTime.Text = "RcvTime";
            this.clhRcvTime.Width = 84;
            // 
            // tmrDisplay
            // 
            this.tmrDisplay.Interval = 1;
            this.tmrDisplay.Tick += new System.EventHandler(this.tmrDisplay_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ClearButton);
            this.groupBox1.Controls.Add(this.H701checkBox);
            this.groupBox1.Controls.Add(this.H702CheckBox);
            this.groupBox1.Controls.Add(this.H60BCheckBox);
            this.groupBox1.Controls.Add(this.H60CCheckBox);
            this.groupBox1.Controls.Add(this.H60AcheckBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NoofTagtobDspUpDown);
            this.groupBox1.Location = new System.Drawing.Point(578, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 161);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // ClearButton
            // 
            this.ClearButton.Enabled = false;
            this.ClearButton.Location = new System.Drawing.Point(6, 134);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(107, 21);
            this.ClearButton.TabIndex = 22;
            this.ClearButton.Text = "Clear all";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // H701checkBox
            // 
            this.H701checkBox.AutoSize = true;
            this.H701checkBox.Location = new System.Drawing.Point(5, 65);
            this.H701checkBox.Name = "H701checkBox";
            this.H701checkBox.Size = new System.Drawing.Size(48, 16);
            this.H701checkBox.TabIndex = 17;
            this.H701checkBox.Text = "701h";
            this.H701checkBox.UseVisualStyleBackColor = true;
            // 
            // H702CheckBox
            // 
            this.H702CheckBox.AutoSize = true;
            this.H702CheckBox.Location = new System.Drawing.Point(65, 65);
            this.H702CheckBox.Name = "H702CheckBox";
            this.H702CheckBox.Size = new System.Drawing.Size(48, 16);
            this.H702CheckBox.TabIndex = 18;
            this.H702CheckBox.Text = "702h";
            this.H702CheckBox.UseVisualStyleBackColor = true;
            // 
            // H60BCheckBox
            // 
            this.H60BCheckBox.AutoSize = true;
            this.H60BCheckBox.Location = new System.Drawing.Point(65, 87);
            this.H60BCheckBox.Name = "H60BCheckBox";
            this.H60BCheckBox.Size = new System.Drawing.Size(48, 16);
            this.H60BCheckBox.TabIndex = 20;
            this.H60BCheckBox.Text = "60Bh";
            this.H60BCheckBox.UseVisualStyleBackColor = true;
            // 
            // H60CCheckBox
            // 
            this.H60CCheckBox.AutoSize = true;
            this.H60CCheckBox.Location = new System.Drawing.Point(5, 109);
            this.H60CCheckBox.Name = "H60CCheckBox";
            this.H60CCheckBox.Size = new System.Drawing.Size(48, 16);
            this.H60CCheckBox.TabIndex = 21;
            this.H60CCheckBox.Text = "60Ch";
            this.H60CCheckBox.UseVisualStyleBackColor = true;
            // 
            // H60AcheckBox
            // 
            this.H60AcheckBox.AutoSize = true;
            this.H60AcheckBox.Location = new System.Drawing.Point(5, 87);
            this.H60AcheckBox.Name = "H60AcheckBox";
            this.H60AcheckBox.Size = new System.Drawing.Size(48, 16);
            this.H60AcheckBox.TabIndex = 19;
            this.H60AcheckBox.Text = "60Ah";
            this.H60AcheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "Number of Targets ";
            // 
            // NoofTagtobDspUpDown
            // 
            this.NoofTagtobDspUpDown.Location = new System.Drawing.Point(6, 38);
            this.NoofTagtobDspUpDown.Maximum = new decimal(new int[] {
            96,
            0,
            0,
            0});
            this.NoofTagtobDspUpDown.Name = "NoofTagtobDspUpDown";
            this.NoofTagtobDspUpDown.Size = new System.Drawing.Size(107, 21);
            this.NoofTagtobDspUpDown.TabIndex = 17;
            this.NoofTagtobDspUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // MsgDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 185);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MsgListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MsgDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Message";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NoofTagtobDspUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clhType;
        private System.Windows.Forms.ColumnHeader clhID;
        private System.Windows.Forms.ColumnHeader clhLength;
        private System.Windows.Forms.ColumnHeader clhData;
        private System.Windows.Forms.ColumnHeader clhCount;
        private System.Windows.Forms.ColumnHeader clhRcvTime;
        public System.Windows.Forms.Timer tmrDisplay;
        public System.Windows.Forms.ListView MsgListView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown NoofTagtobDspUpDown;
        public System.Windows.Forms.CheckBox H701checkBox;
        public System.Windows.Forms.CheckBox H702CheckBox;
        public System.Windows.Forms.CheckBox H60BCheckBox;
        public System.Windows.Forms.CheckBox H60CCheckBox;
        public System.Windows.Forms.CheckBox H60AcheckBox;
        private System.Windows.Forms.Button ClearButton;
    }
}