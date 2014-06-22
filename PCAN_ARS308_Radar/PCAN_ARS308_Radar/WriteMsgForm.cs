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
    public partial class WriteMsgForm : Form
    {
        //private PCANClass pcan;
        //private PCANClass.MessageStatus pcanm;
        public WriteMsgForm()
        {
            InitializeComponent();
            
        }
        
        
        private void WriteButton_Click(object sender, EventArgs e)
        {
            TPCANMsg CANMsg;
            TextBox txtbCurrentTextBox;
            TPCANStatus stsResult;
            
            // We create a TPCANMsg message structure 
            //
            CANMsg = new TPCANMsg();
            CANMsg.DATA = new byte[8];

            // We configurate the Message.  The ID (max 0x1FF),
            // Length of the Data, Message Type (Standard in 
            // this example) and die data
            //
            CANMsg.ID = Convert.ToUInt32(this.IdTextBox.Text, 16);
            CANMsg.LEN = Convert.ToByte(this.LengthUpDown.Value);
            CANMsg.MSGTYPE = (this.ExtendedFrameCheckBox_WM.Checked) ? TPCANMessageType.PCAN_MESSAGE_EXTENDED : TPCANMessageType.PCAN_MESSAGE_STANDARD;
            // If a remote frame will be sent, the data bytes are not important.
            //
            if (this.RTRCheckBox.Checked)
                CANMsg.MSGTYPE |= TPCANMessageType.PCAN_MESSAGE_RTR;
            else
            {
                // We get so much data as the Len of the message
                //
                txtbCurrentTextBox = D0;
                for (int i = 0; i < CANMsg.LEN; i++)
                {
                    CANMsg.DATA[i] = Convert.ToByte(txtbCurrentTextBox.Text, 16);
                    if (i < 7)
                        txtbCurrentTextBox = (TextBox)this.GetNextControl(txtbCurrentTextBox, true);
                }
            }

            // The message is sent to the configured hardware
            //
            stsResult = PCANBasic.Write(Program.pcan.m_PcanHandle, ref CANMsg);

            // The message was successfully sent
            //
            if (stsResult == TPCANStatus.PCAN_ERROR_OK)
                 Program.mf.IncludeTextMessage("Success", "Message was successfully SENT");
            // An error occurred.  We show the error.
            //			
            else
                MessageBox.Show(Program.pcan.GetFormatedError(stsResult));
            
        }

        private void ExtendedFrameCheckBox_WM_CheckedChanged(object sender, EventArgs e)
        {
            uint uiTemp;

            this.IdTextBox.MaxLength = (this.ExtendedFrameCheckBox_WM.Checked) ? 8 : 3;

            // the only way that the text length can be bigger als MaxLength
            // is when the change is from Extended to Standard message Type.
            // We have to handle this and set an ID not bigger than the Maximum
            // ID value for a Standard Message (0x7FF)
            //
            if (this.IdTextBox.Text.Length > this.IdTextBox.MaxLength)
            {
                uiTemp = Convert.ToUInt32(this.IdTextBox.Text, 16);
                this.IdTextBox.Text = (uiTemp < 0x7FF) ? string.Format("{0:X3}", uiTemp) : "7FF";
            }

            IdTextBox_Leave(this, new EventArgs());	
        }

        private void IdTextBox_Leave(object sender, EventArgs e)
        {
            int iTextLength;
            uint uiMaxValue;

            // Calculates the text length and Maximum ID value according
            // with the Message Type
            //
            iTextLength = (this.ExtendedFrameCheckBox_WM.Checked) ? 8 : 3;
            uiMaxValue = (this.ExtendedFrameCheckBox_WM.Checked) ? (uint)0x1FFFFFFF : (uint)0x7FF;

            // The Textbox for the ID is represented with 3 characters for 
            // Standard and 8 characters for extended messages.
            // Therefore if the Length of the text is smaller than TextLength,  
            // we add "0"
            //
            while (this.IdTextBox.Text.Length != iTextLength)
                this.IdTextBox.Text = ("0" + this.IdTextBox.Text);

            // We check that the ID is not bigger than current maximum value
            //
            if (Convert.ToUInt32(this.IdTextBox.Text, 16) > uiMaxValue)
                this.IdTextBox.Text = string.Format("{0:X" + iTextLength.ToString() + "}", uiMaxValue);	
        }

        private void IdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chCheck;

            // We convert the Character to its Upper case equivalent
            //
            chCheck = char.ToUpper(e.KeyChar);

            // The Key is the Delete (Backspace) Key
            //
            if (chCheck == 8)
                return;
            // The Key is a number between 0-9
            //
            if ((chCheck > 47) && (chCheck < 58))
                return;
            // The Key is a character between A-F
            //
            if ((chCheck > 64) && (chCheck < 71))
                return;

            // Is neither a number nor a character between A(a) and F(f)
            //
            e.Handled = true;	
        }

        private void D0_Leave(object sender, EventArgs e)
        {
            TextBox txtbCurrentTextbox;

            // all the Textbox Data fields are represented with 2 characters.
            // Therefore if the Length of the text is smaller than 2, we add
            // a "0"
            //
            if (sender.GetType().Name == "TextBox")
            {
                txtbCurrentTextbox = (TextBox)sender;
                while (txtbCurrentTextbox.Text.Length != 2)
                    txtbCurrentTextbox.Text = ("0" + txtbCurrentTextbox.Text);
            }
        }

        private void RTRCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TextBox txtbCurrentTextBox;

            txtbCurrentTextBox = D0;

            // If the message is a RTR, no data is sent. The textbox for data 
            // will be turned invisible
            // 
            for (int i = 0; i < 8; i++)
            {
                txtbCurrentTextBox.Enabled = !this.RTRCheckBox.Checked;
                if (i < 7)
                    txtbCurrentTextBox = (TextBox)this.GetNextControl(txtbCurrentTextBox, true);
            }
        }

    }
}
