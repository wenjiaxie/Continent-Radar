using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Peak.Can.Basic;
using TPCANHandle = System.Byte;



namespace PCAN_ARS308_Radar
{    
    public partial class MainForm : Form
    {
        
        public Point CentrePoint;
        private Bitmap BackgroundBuffer;
        private Bitmap RadarBuffer;
        private Bitmap ObjectBuffer;
        private double RotateAngle = 0;

        public string statusBuffer = "";
        public string stringBuffer = "";

        public MainForm()
        {
            InitializeComponent();

            //Program.pcan.InitializeBasicComponents();
            this.CentrePoint = new Point(this.RadarPictureBox.Width / 2, this.RadarPictureBox.Height / 2);
            BackgroundBuffer = new Bitmap(this.RadarPictureBox.Width, this.RadarPictureBox.Height);
            RadarBuffer = new Bitmap(this.RadarPictureBox.Width, this.RadarPictureBox.Height);
            ObjectBuffer = new Bitmap(this.RadarPictureBox.Width, this.RadarPictureBox.Height);

            this.StopButton.Enabled = false;
            this.StartButton.Enabled = true;
        }

        /*
        //画图测试按钮
        private void StartButton_Click(object sender, EventArgs e)
        {


            this.StatusLabel.Visible = false;
            using (Graphics g = Graphics.FromImage(BackgroundBuffer))
            {
                RadarShowing ra = new RadarShowing(this.CentrePoint.X, this.CentrePoint.Y);
                ra.DrawCircle(g, 6);
                ra.DrawCrossLine(g, 10);
            }
            this.RefreshTimer.Start();

        }
        */

        # region Programme of Showing
        //画图程序
        private void RadarPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(BackgroundBuffer, 0, 0);
            e.Graphics.DrawImage(RadarBuffer, 0, 0);
            e.Graphics.DrawImage(ObjectBuffer, 0, 0);
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(RadarBuffer))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.Clear(Color.Transparent);
                RadarShowing ra = new RadarShowing(CentrePoint.X, CentrePoint.Y);
                g.FillPie(new LinearGradientBrush(ra.ToMonitorPoint(CentrePoint.X, RotateAngle),
                    ra.ToMonitorPoint(CentrePoint.X, RotateAngle + 30),
                    Color.FromArgb(200, Color.DarkGreen),
                    Color.FromArgb(0, Color.DarkGreen)),
                    new Rectangle(0, 0, 2 * CentrePoint.X, 2 * CentrePoint.Y),
                    (int)-RotateAngle,
                    -30
                    );
                RotateAngle -= 1.5;


            }
            this.RadarPictureBox.Invalidate();
            Program.uif.tmrRead_Tick(this, new EventArgs());
        }

        private void RefreshTimer2_Tick(object sender, EventArgs e)
        {
            using (Graphics gg = Graphics.FromImage(ObjectBuffer))
            {
                if(Program.md.list60Bh != null)
                    gg.Clear(Color.Transparent);
            }
            this.RadarPictureBox.Invalidate();
        }

        //画图程序结束
        /*更新点的坐标*/
        public void DrawObj(Point pt)
        {
            using (Graphics gg = Graphics.FromImage(ObjectBuffer))
            {
                RadarShowing ra = new RadarShowing(CentrePoint.X, CentrePoint.Y);
                gg.SmoothingMode = SmoothingMode.HighQuality;
                //gg.Clear(Color.Transparent);
                ra.DrawObject(gg, pt);
            }
            this.RadarPictureBox.Invalidate();
        }

        #endregion

        private void MainForm_Move(object sender, EventArgs e)
        { 
            Point P = this.DesktopLocation;
            Program.mff.SetDesktopLocation((P.X + this.Size.Width + 5), P.Y );
            Program.sif.SetDesktopLocation((P.X + this.Size.Width + 5), P.Y );
            Program.wmf.SetDesktopLocation((P.X + this.Size.Width + 5), P.Y );
            Program.tlf.SetDesktopLocation((P.X + this.Size.Width + 5), P.Y );
            Program.uif.SetDesktopLocation((P.X + this.Size.Width + 5), P.Y );
        } 

        private void InitializingButton_Click(object sender, EventArgs e)
        {

            Point P = this.DesktopLocation;

            Program.sif.SetDesktopLocation((int)(P.X + this.Size.Width + 3), P.Y);
            Program.mff.Hide() ; MessageFilterButton.Text = "Message Filter >>";
            Program.uif.Hide() ; UserInitButton.Text = "User Initialize>>";
            Program.wmf.Hide() ; WriteMsgButton.Text = "Write Message  >>";
            Program.tlf.Hide() ; TargetListButton.Text = "Target List    >>";
            if (!Program.sif.Visible)
            {
                InitializingButton.Text = "Sys Initiallze <<";
                Program.sif.Show(this);
            }
            else
            {
                InitializingButton.Text = "Sys Initiallze >>";
                Program.sif.Hide();
            }
        }

        private void MessageFilterButton_Click(object sender, EventArgs e)
        {
            Point P = this.DesktopLocation;
            Program.mff.SetDesktopLocation((int)(P.X + this.Size.Width + 3), P.Y);
            Program.uif.Hide();
            Program.wmf.Hide();
            Program.tlf.Hide();
            Program.sif.Hide();
            InitializingButton.Text = "Sys Initiallze >>";
            MessageFilterButton.Text = "Message Filter>>";
            UserInitButton.Text = "User Initialize>>";
            WriteMsgButton.Text = "Write Message  >>";
            TargetListButton.Text = "Target List    >>";
            
            if (!Program.mff.Visible)
            {
                MessageFilterButton.Text = "Message Filter <<";
                Program.mff.Show();
            }
            else
            {
                MessageFilterButton.Text = "Message Filter >>";
                Program.mff.Hide();
            }
        }

        private void UserInitButton_Click(object sender, EventArgs e)
        {
            Point P = this.DesktopLocation;
            Program.mff.Hide();
            Program.wmf.Hide();
            Program.tlf.Hide();
            Program.sif.Hide();
            MessageFilterButton.Text = "Message Filter >>";
            InitializingButton.Text = "Sys Initiallze >>";
            WriteMsgButton.Text = "Write Message  >>";
            TargetListButton.Text = "Target List    >>";
            Program.uif.SetDesktopLocation((int)(P.X + this.Size.Width + 3), P.Y);
            if (!Program.uif.Visible)
            {
                UserInitButton.Text = "User Initialize<<";

                Program.uif.Show();
            }
            else
            {
                UserInitButton.Text = "User Initialize>>";
                Program.uif.Hide();
            }
        }

        private void WriteMsgButton_Click(object sender, EventArgs e)
        {
            Point P = this.DesktopLocation;
            Program.wmf.SetDesktopLocation((int)(P.X + this.Size.Width + 3), P.Y);
            Program.mff.Hide();
            Program.uif.Hide();
            Program.tlf.Hide();
            Program.sif.Hide();
            UserInitButton.Text = "User Initialize>>";
            MessageFilterButton.Text = "Message Filter >>";
            InitializingButton.Text = "Sys Initiallze >>";
            TargetListButton.Text = "Target List    >>";
            
            if (!Program.wmf.Visible)
            {
                WriteMsgButton.Text = "Write Message  <<";

                Program.wmf.Show();
            }
            else
            {
                WriteMsgButton.Text = "Write Message  >>";
                Program.wmf.Hide();
            }
        }

        private void TargetListButton_Click(object sender, EventArgs e)
        {
            Point P = this.DesktopLocation;
            Program.tlf.SetDesktopLocation((int)(P.X + this.Size.Width + 3), P.Y);
            Program.mff.Hide();
            Program.uif.Hide();
            Program.wmf.Hide();
            Program.sif.Hide();
            WriteMsgButton.Text = "Write Message  >>";
            UserInitButton.Text = "User Initialize>>";
            MessageFilterButton.Text = "Message Filter >>";
            InitializingButton.Text = "Sys Initiallze >>";


            if (!Program.tlf.Visible)
            {
                TargetListButton.Text = "Target List    <<";
                Program.tlf.Show();
            }
            else
            {
                TargetListButton.Text = "Target List    >>";
                Program.tlf.Hide();
            }
        }



        private void StopButton_Click(object sender, EventArgs e)
        {
            this.RefreshTimer.Stop();
            Program.md.tmrDisplay.Stop();
            Program.uif.tmrRead.Stop();
            this.StartButton.Enabled = true;
            this.StopButton.Enabled = false;
            //Program.mf.MsgShowButton.Enabled = false;
        }
        
        public void IncludeTextMessage(string status, string content )
        {
            ListViewItem ielst = new ListViewItem();
            System.DateTime currentime = new DateTime();
            currentime = System.DateTime.Now;
            ielst.Text = currentime.Year.ToString() + "-" + currentime.Month.ToString() + "-" + currentime.Day.ToString() + "  " + currentime.ToString("t") + ":" + currentime.Second.ToString() + ":" + currentime.Millisecond.ToString();
            ielst.SubItems.Add( new ListViewItem.ListViewSubItem() {Text = status} );
            ielst.SubItems.Add( new ListViewItem.ListViewSubItem() {Text = content} );
            this.InfoAndErrListView.Items.Add(ielst);
            InfoAndErrListView.Items[this.InfoAndErrListView.Items.Count - 1].Selected = true;
        }

        public void _StartButton_Click(object sender, EventArgs e)
        {
            this.StatusLabel.Visible = false;
            using (Graphics g = Graphics.FromImage(BackgroundBuffer))
            {
                RadarShowing ra = new RadarShowing(this.CentrePoint.X, this.CentrePoint.Y);
                ra.DrawCircle(g, 6);
                ra.DrawCrossLine(g, 10);
            }
            this.RefreshTimer.Start();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Program.md.H60AcheckBox.Enabled = (Program.uif.OpTypeComboBox.SelectedIndex == 1);
            Program.md.H60BCheckBox.Enabled = (Program.uif.OpTypeComboBox.SelectedIndex == 1);
            Program.md.H60CCheckBox.Enabled = (Program.uif.OpTypeComboBox.SelectedIndex == 1);
            Program.md.H701checkBox.Enabled = (Program.uif.OpTypeComboBox.SelectedIndex == 0);
            Program.md.H702CheckBox.Enabled = (Program.uif.OpTypeComboBox.SelectedIndex == 0);
            
            this.StartButton.Enabled = false;
            this.StopButton.Enabled = true;
            Program.md.MsgListView.Items.Clear();
            Program.md.tmrDisplay_Tick(this, new EventArgs());
            Program.tlf.TargetTimer.Start();
            this.RefreshTimer2.Start();
            //this.RefreshTimer.Start();
        }

        private void MsgShowButton_Click(object sender, EventArgs e)
        {
            if (Program.md.Visible)
            {
                Program.md.Hide();
                Program.mf.MsgShowButton.Text = "Show Message";
                Program.mf.MsgShowButton.Enabled = true;
            }
            else
            {
                Program.md.Show();
                Program.mf.MsgShowButton.Text = "Hide Message";
                Program.mf.MsgShowButton.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.af.Show();
        }


        /*error list
        public string MyErrorLst(int errornum)
        {
            switch(errornum)
            {
                case 1:
                    return "a";
                case 2:
                    return "b";
                case 3:
                    return "c";
                case 4:
                    return "d";
                case 5:
                    return "e";
                default:
                    return "Unexpected Error!";
            }
            
        }
         * */
    
    }
}
