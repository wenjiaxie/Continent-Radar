using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Peak.Can.Basic;
using TPCANHandle = System.Byte;

namespace PCAN_ARS308_Radar
{
    public partial class UserInitForm : Form
    {
        public UserInitForm()
        {
            InitializeComponent();
            this.OpTypeComboBox.SelectedIndex = 1;
            this.DirectComboBox.SelectedIndex = 0;
        }
        
        
        public List<string> lastmessage = new List<string>();
        
        //private TPCANHandle m_PcanHandle;
        //private System.Collections.ArrayList m_LastMsgsList;


        private void SetStatusButton_Click(object sender, EventArgs e)
        {
            TPCANMsg CANMsg = new TPCANMsg();
            TPCANStatus stsResult;
            CANMsg.DATA = new byte[8];
            CANMsg.ID = Convert.ToUInt32(0x200);
            CANMsg.LEN = Convert.ToByte(4);
            CANMsg.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            CANMsg.DATA[0] = Convert.ToByte(0x0F);
            CANMsg.DATA[1] = Convert.ToByte(this.RangeUpDown.Value);  //range_length
            CANMsg.DATA[2] = Convert.ToByte(this.ElevUpDown.Value * 4);  //range_elevation
            //CANMsg.DATA[3] = (byte)0x05;
            
            switch (this.OpTypeComboBox.SelectedIndex) 
            {
                case 0:
                    CANMsg.DATA[3] = (byte)0x05;
                    break;
                case 1:
                    CANMsg.DATA[3] = (byte)0x03;
                    break;           
            }
            
            stsResult = PCANBasic.Write(Program.pcan.m_PcanHandle, ref CANMsg);
            if (stsResult == TPCANStatus.PCAN_ERROR_OK)
                Program.mf.IncludeTextMessage("Success", "Message was successfully SENT");
            // An error occurred.  We show the error.
            //			
            else
                MessageBox.Show(Program.pcan.GetFormatedError(stsResult));


        }

        private void SetVelocityButton_Click(object sender, EventArgs e)
        {
            TPCANMsg CANMsg = new TPCANMsg();
            TPCANStatus stsResult;
            byte speedl = Convert.ToByte((byte)(this.SpeedUpDown.Value * 50) & (byte)0x00FF);
            byte speedh = Convert.ToByte(((byte)(this.SpeedUpDown.Value * 50) >> 8) & (byte)0x001F);  
            CANMsg.DATA = new byte[8];
            CANMsg.ID = Convert.ToUInt32(0x300);
            CANMsg.LEN = Convert.ToByte(3);
            CANMsg.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            CANMsg.DATA[0] = speedh; //speed 8-12bit
            CANMsg.DATA[1] = speedl; //speed 0-7bit
            switch (this.DirectComboBox.SelectedIndex)
            {
                case 0:
                    CANMsg.DATA[2] = (byte)0x00;
                    break;
                case 1:
                    CANMsg.DATA[2] = (byte)0x01;
                    break;
                case 2:
                    CANMsg.DATA[2] = (byte)0x02;
                    break;
            }
            //0x00不动 0x01向前 0x02向后 0x03不定
            stsResult = PCANBasic.Write(Program.pcan.m_PcanHandle, ref CANMsg);
            if (stsResult == TPCANStatus.PCAN_ERROR_OK)
                Program.mf.IncludeTextMessage("Success", "Message was successfully SENT");
            // An error occurred.  We show the error.
            //			
            else
                MessageBox.Show(Program.pcan.GetFormatedError(stsResult));
 
        }

        private void SetYawButton_Click(object sender, EventArgs e)
        {
            TPCANMsg CANMsg;
            TPCANStatus stsResult;
            byte Yawl = Convert.ToByte((UInt16)(((double)this.YawUpDown.Value + 327.68) * 100) & (byte)0x00FF);
            byte Yawh = Convert.ToByte(((UInt16)(((double)this.YawUpDown.Value + 327.68) * 100) >> 8) & (byte)0x00FF);
            CANMsg = new TPCANMsg();
            CANMsg.DATA = new byte[8];
            CANMsg.ID = Convert.ToUInt32(0x301);
            CANMsg.LEN = Convert.ToByte(2);
            CANMsg.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            CANMsg.DATA[0] = Yawh; //yaw 8-15bit
            CANMsg.DATA[1] = Yawl; //yaw 0-7bit
            stsResult = PCANBasic.Write(Program.pcan.m_PcanHandle,ref CANMsg);
            if (stsResult == TPCANStatus.PCAN_ERROR_OK)
                Program.mf.IncludeTextMessage("Success", "Message was successfully SENT");
            // An error occurred.  We show the error.
            //			
            else
                MessageBox.Show(Program.pcan.GetFormatedError(stsResult));
        }
        /*
        private void ProcessMessage(TPCANMsg theMsg, TPCANTimestamp itsTimeStamp)
        {
            // We search if a message (Same ID and Type) is 
            // already received or if this is a new message
            //
            lock (m_LastMsgsList.SyncRoot)
            {
                foreach (MessageStatus msg in m_LastMsgsList)
                {
                    if ((msg.CANMsg.ID == theMsg.ID) && (msg.CANMsg.MSGTYPE == theMsg.MSGTYPE))
                    {
                        // Modify the message and exit
                        //
                        msg.Update(theMsg, itsTimeStamp);
                        return;
                    }
                }
                // Message not found. It will created
                //
                InsertMsgEntry(theMsg, itsTimeStamp);
            }
        } 
        */
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            TPCANMsg CANMsg;
            TPCANTimestamp CANTimeStamp;
            TPCANStatus stsResult;

            // We execute the "Read" function of the PCANBasic                
            //
            stsResult = PCANBasic.Read(Program.pcan.m_PcanHandle, out CANMsg, out CANTimeStamp);
            if (stsResult == TPCANStatus.PCAN_ERROR_OK)
            {
                // We process the received message
                //

                //tmrRead_Tick(this, new EventArgs());
                ProcessMessage(CANMsg, CANTimeStamp);
                //tmrRead.Start();
            }
            else
                // If an error occurred, an information message is included
                //
                Program.mf.IncludeTextMessage("Error", Program.pcan.GetFormatedError(stsResult));
        }

        private void ProcessMessage(TPCANMsg theMsg, TPCANTimestamp itsTimeStamp)
        {
            //this.ConfirmListViewGroup.Items.Clear();

            ListViewItem newItem = new ListViewItem();
            switch (theMsg.ID)
            {
                case 0x201:
                    newItem.Text = Program.pcanm.NVMwritestates.ToString();
                    newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = Program.pcanm.NVMreadstates.ToString() });
                    newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = Program.pcanm.CurrrangelengthCal.ToString() });
                    newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = Program.pcanm.Currelevationcal.ToString() });
                    newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = Program.pcanm.RadarPowerReduction.ToString() });
                    newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = Program.pcanm.CurrentRadarPower.ToString() });
                    newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = Program.pcanm.SupVolt_L.ToString() });
                    newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = Program.pcanm.Rxinvalid.ToString() });
                    newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = Program.pcanm.Sensdef.ToString() });
                    newItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = Program.pcanm.SensTempErr.ToString() });
                    break;
                case 0x600:
                    lastmessage.Add(Program.pcanm.NooftarNear.ToString());
                    lastmessage.Add(Program.pcanm.NooftarFar.ToString());
                    break;
                case 0x701:
                    lastmessage.Add(Program.pcanm.NoofTar1.ToString());
                    lastmessage.Add(Program.pcanm.Tar_Ver.ToString());
                    lastmessage.Add(Program.pcanm.Tar_Dis.ToString());
                    break;
                case 0x702:
                    lastmessage.Add(Program.pcanm.NoofTar2.ToString());
                    lastmessage.Add(Program.pcanm.Tar_Length.ToString());
                    lastmessage.Add(Program.pcanm.Tar_Width.ToString());
                    lastmessage.Add(Program.pcanm.Tar_Ang.ToString());
                    lastmessage.Add(Program.pcanm.Tar_RCSValue.ToString());
                    break;
            }

            this.ConfirmListViewGroup.Items.Add(newItem);

        }

        public void tmrRead_Tick(object sender, EventArgs e)
        {
            ReadMessages();
            //ConfirmButton_Click(this, new EventArgs());
        }

        private void ReadMessages()
        {
            TPCANMsg CANMsg;
            TPCANTimestamp CANTimeStamp;
            TPCANStatus stsResult;

            // We read at least one time the queue looking for messages.
            // If a message is found, we look again trying to find more.
            // If the queue is empty or an error occurr, we get out from
            // the dowhile statement.
            //			
            do
            {
                // We execute the "Read" function of the PCANBasic                
                //
                stsResult = PCANBasic.Read(Program.pcan.m_PcanHandle, out CANMsg, out CANTimeStamp);

                // A message was received
                // We process the message(s)
                //
                if (stsResult == TPCANStatus.PCAN_ERROR_OK)
                    Program.pcan.ProcessMessage(CANMsg, CANTimeStamp);

            } while (Program.sif.ReleaseButton.Enabled && (!Convert.ToBoolean(stsResult & TPCANStatus.PCAN_ERROR_QRCVEMPTY)));
        }
        /*
        private void CANReadThreadFunc()
        {
            UInt32 iBuffer;
            TPCANStatus stsResult;

            iBuffer = Convert.ToUInt32(m_ReceiveEvent.SafeWaitHandle.DangerousGetHandle().ToInt32());
            // Sets the handle of the Receive-Event.
            //
            stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_RECEIVE_EVENT, ref iBuffer, sizeof(UInt32));

            if (stsResult != TPCANStatus.PCAN_ERROR_OK)
            {
                MessageBox.Show(GetFormatedError(stsResult), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // While this mode is selected
            while (rdbEvent.Checked)
            {
                // Waiting for Receive-Event
                // 
                if (m_ReceiveEvent.WaitOne(50))
                    // Process Receive-Event using .NET Invoke function
                    // in order to interact with Winforms UI (calling the 
                    // function ReadMessages)
                    // 
                    this.Invoke(m_ReadDelegate);
            }
        }
        */


    }
}
