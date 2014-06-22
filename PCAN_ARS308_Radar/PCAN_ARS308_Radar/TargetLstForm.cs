using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Peak.Can.Basic;

namespace PCAN_ARS308_Radar
{

    public partial class TargetLstForm : Form
    {
        int No = (int)Program.md.NoofTagtobDspUpDown.Value;
        public TargetLstForm()
        {
            InitializeComponent();
            //if (Program.mf.StartButton.Enabled)
            //TargetDisplay();
            
        }

        private void TargetDisplay()
        {
            //int No = 0;
            int yi = 33;
            int xj = 65;
            int yj = 29;



            for (int k = 1; k <= No; k++)
            {
                this.labelDo.Visible = true;
                this.labelvel.Visible = true;
                this.labelDa.Visible = true;
                this.labelLen.Visible = true;
                this.labelWid.Visible = true;
                Label lb = new Label();
                lb.AutoSize = true;
                lb.Text = "Target " + k;
                lb.Location = new System.Drawing.Point(5, yi);
                yi += 27;
                lb.Name = "label" + (k + 5);
                lb.Size = new System.Drawing.Size(53, 12);
                //lb.TabIndex = 100;
                this.Controls.Add(lb);
            }
            for (int i = 1; i <= 6; i++)
            {
                for (int j = 1; j <= No; j++)
                {
                    TextBox tb = new TextBox();
                    tb.Location = new System.Drawing.Point(xj, yj);
                    yj += 27;
                    tb.Name = "textBox" + j.ToString() + i.ToString();
                    tb.Tag = j.ToString() + i.ToString();
                    tb.Size = new System.Drawing.Size(70, 21);
                    tb.Enabled = false;
                    /*
                    lock (Program.pcan.m_LastMsgsList.SyncRoot)
                    {
                        foreach (PCANClass.MessageStatus msgStatus in Program.pcan.m_LastMsgsList)
                        {
                            // Get the data to actualize
                            //
                            if (msgStatus.MarkedAsUpdated)
                            {
                                msgStatus.MarkedAsUpdated = false;
                                    switch (i)
                                    {
                                        case 1:
                                            if(msgStatus.NoofTar1 == j && Convert.ToInt32(msgStatus.IdString) == 0x701)
                                            tb.Text = msgStatus.Tar_Dis;
                                            break;
                                        case 2:
                                            if(msgStatus.NoofTar1 == j && Convert.ToInt32(msgStatus.IdString) == 0x701)
                                            tb.Text = msgStatus.Tar_Ver;
                                            break;
                                        case 3:
                                            if (msgStatus.NoofTar1 == j && Convert.ToInt32(msgStatus.IdString) == 0x702)
                                                tb.Text = msgStatus.Tar_Ang;
                                            break;
                                        case 4:
                                            if (msgStatus.NoofTar1 == j && Convert.ToInt32(msgStatus.IdString) == 0x702)
                                                tb.Text = msgStatus.Tar_Length;
                                            break;
                                        case 5:
                                            if (msgStatus.NoofTar1 == j && Convert.ToInt32(msgStatus.IdString) == 0x702)
                                                tb.Text = msgStatus.Tar_Width;
                                            break;
                                    }
                            }   
                        }
                    }
                    */
                    this.Controls.Add(tb);
                }
                xj += 76;
                yj = 29;
            } 
        }

        public System.Collections.ArrayList ptlist;

        private void TargetTimer_Tick(object sender, EventArgs e)
        {
            /*
            Control tb = new Control();

            foreach (PCANClass.MessageStatus msgStatus in Program.md.list60Bh)
            {

                for (int i = 1; i <= No; i++)
                {

                    if (tb.GetType().Name.Equals("textBox" + i.ToString() + "1"))
                        tb.Text = Obj_LongDispl(msgStatus);
                    else if (tb.GetType().Name.Equals("textBox" + i.ToString() + "2"))
                        tb.Text = Obj_LatDispl(msgStatus);
                    else if (tb.GetType().Name.Equals("textBox" + i.ToString() + "3"))
                        tb.Text = "";
                    else if (tb.GetType().Name.Equals("textBox" + i.ToString() + "4"))
                        tb.Text = "";
                    else if (tb.GetType().Name.Equals("textBox" + i.ToString() + "5"))
                        tb.Text = "";
                    else if (tb.GetType().Name.Equals("textBox" + i.ToString() + "6"))
                        tb.Text = "";

                    
                }
            }
              */

            ///
            ///test
            ///    
            int flag = 0;
            foreach (PCANClass.MessageStatus msgStatus in Program.md.list60Bh)
            {
                flag = 1;
                for (int i = 1; i <= No; i++)
                {
                    Point pt = new Point();
                    foreach (Control tb in this.Controls)
                    {
                        tb.ForeColor = Color.Green;

                        if (Obj_ID(msgStatus) == i.ToString() && Convert.ToDouble(Obj_ProbOfExist(msgStatus)) >= 0.9)
                        {                          
                            if (tb.Name == "textBoxa" + i.ToString() && (Obj_LongDispl(msgStatus) != "0.000"))
                            {
                                //Program.mf.RefreshTimer2.Start();
                                tb.Text = Obj_LongDispl(msgStatus);
                                pt.Y = Convert.ToInt16(Convert.ToDouble(Obj_LongDispl(msgStatus)) * Program.mf.CentrePoint.X / Convert.ToDouble(Program.uif.RangeUpDown.Value));
                            }
                            if (tb.Name == "textBoxb" + i.ToString() && (Obj_LatDispl(msgStatus) != "0.000"))
                            {
                                tb.Text = Obj_LatDispl(msgStatus);
                                pt.X = Convert.ToInt16(Convert.ToDouble(Obj_LatDispl(msgStatus)) * Program.mf.CentrePoint.X / Convert.ToDouble(Program.uif.RangeUpDown.Value));
                            }
                            if (tb.Name == "textBoxc" + i.ToString() && (Obj_LongDispl(msgStatus) != "0.000"))
                                tb.Text = Obj_VrelLong(msgStatus);
                            if (tb.Name == "textBoxd" + i.ToString() && (Obj_LongDispl(msgStatus) != "0.000"))
                                tb.Text = Obj_AccelLong(msgStatus);
                            if (tb.Name == "textBoxe" + i.ToString() && (Obj_LongDispl(msgStatus) != "0.000"))
                                tb.Text = Obj_Length(msgStatus);
                            if (tb.Name == "textBoxf" + i.ToString() && (Obj_LongDispl(msgStatus) != "0.000"))
                                tb.Text = Obj_Width(msgStatus);
                        }
                    }
                    if (pt.X != 0 && pt.Y != 0)
                    {
                        Program.mf.DrawObj(pt);
                        //Program.mf.RefreshTimer2.Stop();
                    }
                }
                //Program.mf.DrawObj(pt);
            }
            //if(flag == 1)
                //Program.md.list60Bh.Clear();
        }

        private int m_NoofTar1(PCANClass.MessageStatus msgStatus)
        {
            int tempstates = 0;
            if ((msgStatus.CANMsg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
            {
                tempstates = 0;
            }
            else if (msgStatus.CANMsg.ID == 0x701)
            {
                tempstates = msgStatus.CANMsg.DATA[0];
            }
            return tempstates;
        }

        private string m_Tar_Dis(PCANClass.MessageStatus msgStatus)
        {
            double tempstates = 0;
            if ((msgStatus.CANMsg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                return "Remote Request";

            else if (msgStatus.CANMsg.ID == 0x701)
            {
                tempstates = (int)(msgStatus.CANMsg.DATA[5] & 0x07) << 8 + msgStatus.CANMsg.DATA[6] / 10;
                return tempstates.ToString();
            }
            else
                return "NULL";

        }

        private string Obj_ID(PCANClass.MessageStatus msgStatus)
        {
            double tempstates = 0;
            if ((msgStatus.CANMsg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                return "Remote Request";

            else if (msgStatus.CANMsg.ID == 0x60B)
            {
                tempstates = (int)((msgStatus.CANMsg.DATA[0] >> 2) & 0x3F);
                return tempstates.ToString();
            }
            else
                return "NULL";
        }

        private string Obj_LongDispl(PCANClass.MessageStatus msgStatus)
        {
            double tempstates = 0.00;
            if ((msgStatus.CANMsg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                return "Remote Request";

            else if (msgStatus.CANMsg.ID == 0x60B)
            {
                tempstates = (double)(((msgStatus.CANMsg.DATA[1] << 3) & 0x3F8) + ((msgStatus.CANMsg.DATA[2] >> 5) & 0x07)) / 10;
                return tempstates.ToString("0.000");
            }
            else
                return "NULL";

        }

        private string Obj_LatDispl(PCANClass.MessageStatus msgStatus)
        {
            double tempstates = 0.00;
            if ((msgStatus.CANMsg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                return "Remote Request";

            else if (msgStatus.CANMsg.ID == 0x60B)
            {
                tempstates = (double)((((msgStatus.CANMsg.DATA[5] << 2) & 0xFFC) + ((msgStatus.CANMsg.DATA[6] >> 6) & 0x03))) / 10 - 52;
                return tempstates.ToString("0.000");
            }
            else
                return "NULL";

        }

        private string Obj_VrelLong(PCANClass.MessageStatus msgStatus)
        {
            double tempstates = 0;
            if ((msgStatus.CANMsg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                return "Remote Request";

            else if (msgStatus.CANMsg.ID == 0x60B)
            {
                tempstates = (double)(((msgStatus.CANMsg.DATA[2] << 7) & 0xF80) + ((msgStatus.CANMsg.DATA[3] >> 1) & 0x3F)) * 0.0625 - 128;
                return tempstates.ToString("0.000");
            }
            else
                return "NULL";

        }

        private string Obj_AccelLong(PCANClass.MessageStatus msgStatus)
        {
            double tempstates = 0;
            if ((msgStatus.CANMsg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                return "Remote Request";

            else if (msgStatus.CANMsg.ID == 0x60B)
            {
                tempstates = (double)(((msgStatus.CANMsg.DATA[3] << 8) & 0x1FF) + msgStatus.CANMsg.DATA[4]) * 0.0625 - 16;
                return tempstates.ToString("0.000");
            }
            else
                return "NULL";

        }

        private string Obj_Length(PCANClass.MessageStatus msgStatus)
        {
            int tempstates = 0;
            if ((msgStatus.CANMsg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                return "Remote Request";

            else if (msgStatus.CANMsg.ID == 0x60B)
            {
                tempstates = (int)(msgStatus.CANMsg.DATA[7] & 0x07);
                switch(tempstates)
                {
                    case 0:
                        return "unknown";
                    case 1:
                        return "<0.5m";
                    case 2:
                        return "<2m";
                    case 3:
                        return "<4m";
                    case 4:
                        return "<6m";
                    case 5:
                        return "<10m";
                    case 6:
                        return "<20m";
                    case 7:
                        return "exceeds";
                    default:
                        return "";
                }
                    
            }
            else
                return "NULL";
        }

        private string Obj_Width(PCANClass.MessageStatus msgStatus)
        {
            int tempstates = 0;
            if ((msgStatus.CANMsg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                return "Remote Request";

            else if (msgStatus.CANMsg.ID == 0x60B)
            {
                tempstates = (int)((msgStatus.CANMsg.DATA[7] >> 3) & 0x07);
                switch (tempstates)
                {
                    case 0:
                        return "unknown";
                    case 1:
                        return "<0.5m";
                    case 2:
                        return "<1m";
                    case 3:
                        return "<2m";
                    case 4:
                        return "<3m";
                    case 5:
                        return "<4m";
                    case 6:
                        return "<6m";
                    case 7:
                        return "exceeds";
                    default:
                        return "";
                }

            }
            else
                return "NULL";
        }

        private double Obj_ProbOfExist(PCANClass.MessageStatus msgStatus)
        {
            int tempstates = 0;
            if (msgStatus.CANMsg.ID == 0x60B)
            {
                tempstates = (int)((msgStatus.CANMsg.DATA[6]) & 0x07);
                switch (tempstates)
                {
                    case 0:
                        return 0;
                    case 1:
                        return 0.25;
                    case 2:
                        return 0.5;
                    case 3:
                        return 0.75;
                    case 4:
                        return 0.9;
                    case 5:
                        return 0.99;
                    case 6:
                        return 0.999;
                    case 7:
                        return 0.9999;
                    default:
                        return 0;
                }

            }
            else
                return 0;
        }
    
    }
 

}
        
