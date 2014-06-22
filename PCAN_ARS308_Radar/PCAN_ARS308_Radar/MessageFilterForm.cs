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
   
    public partial class MessageFilterForm : Form
    {
        
        public MessageFilterForm()
        {
            InitializeComponent();
        }
                
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            UInt32 iBuffer;
            TPCANStatus stsResult;

            // Gets the current status of the message filter
            //
            if (!Program.pcan.GetFilterStatus(out iBuffer))
                return;

            // Configures the message filter for a custom range of messages
            //
            if (CustomRadioButton.Checked)
            {
                // Sets the custom filter
                //
                stsResult = PCANBasic.FilterMessages(
                Program.pcan.m_PcanHandle,
                Convert.ToUInt32(this.FromUpDown.Value),
                Convert.ToUInt32(this.ToUpDown.Value),
                this.ExtendedCheckBox.Checked ? TPCANMode.PCAN_MODE_EXTENDED : TPCANMode.PCAN_MODE_STANDARD);
                // If success, an information message is written, if it is not, an error message is shown
                //
                if (stsResult == TPCANStatus.PCAN_ERROR_OK)
                    Program.mf.IncludeTextMessage("Information", string.Format("The filter was customized. IDs from {0:X} to {1:X} will be received", this.FromUpDown.Text, this.ToUpDown.Text));
                else
                    MessageBox.Show(Program.pcan.GetFormatedError(stsResult));

                return;
            }

            // The filter will be full opened or complete closed
            //
            if (CloseRadioButton.Checked)
            {
                iBuffer = PCANBasic.PCAN_FILTER_CLOSE;
            }
            else
                iBuffer = PCANBasic.PCAN_FILTER_OPEN;

            // The filter is configured
            //
            stsResult = PCANBasic.SetValue(
                Program.pcan.m_PcanHandle,
                TPCANParameter.PCAN_MESSAGE_FILTER,
                ref iBuffer,
                sizeof(UInt32));

            // If success, an information message is written, if it is not, an error message is shown
            //
            if (stsResult == TPCANStatus.PCAN_ERROR_OK)
                Program.mf.IncludeTextMessage("Success", string.Format("The filter was successfully {0}", this.CloseRadioButton.Checked ? "closed." : "opened."));
            else
                MessageBox.Show(Program.pcan.GetFormatedError(stsResult));
        }
        
        private void CustomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.FromUpDown.Enabled = true;
            this.ToUpDown.Enabled = true;
        }

        private void OpenRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.FromUpDown.Enabled = false;
            this.ToUpDown.Enabled = false;
        }

        private void CloseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.FromUpDown.Enabled = false;
            this.ToUpDown.Enabled = false;
        }

        private void ExtendedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int iMaxValue;

            iMaxValue = (this.ExtendedCheckBox.Checked) ? 0x1FFFFFFF : 0x7FF;

            // We check that the maximum value for a selected filter 
            // mode is used
            //
            if (this.ToUpDown.Value > iMaxValue)
                this.ToUpDown.Value = iMaxValue;

            this.ToUpDown.Maximum = iMaxValue;
            if (this.FromUpDown.Value > iMaxValue)
                this.FromUpDown.Value = iMaxValue;

            this.FromUpDown.Maximum = iMaxValue;
        }

        private void QueryButton_Click(object sender, EventArgs e)
        {
            UInt32 iBuffer;

            // Queries the current status of the message filter
            //
            if (Program.pcan.GetFilterStatus(out iBuffer))
            {
                switch (iBuffer)
                {
                    // The filter is closed
                    //
                    case PCANBasic.PCAN_FILTER_CLOSE:
                        Program.mf.IncludeTextMessage("Information", "The Status of the filter is: closed.");
                        break;
                    // The filter is fully opened
                    //
                    case PCANBasic.PCAN_FILTER_OPEN:
                        Program.mf.IncludeTextMessage("Information", "The Status of the filter is: full opened.");
                        break;
                    // The filter is customized
                    //
                    case PCANBasic.PCAN_FILTER_CUSTOM:
                        Program.mf.IncludeTextMessage("Information", "The Status of the filter is: customized.");
                        break;
                    // The status of the filter is undefined. (Should never happen)
                    //
                    default:
                        Program.mf.IncludeTextMessage("Information", "The Status of the filter is: Invalid.");
                        break;
                }
            }
        }

        
    }
}
