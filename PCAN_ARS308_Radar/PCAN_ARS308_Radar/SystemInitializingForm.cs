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
    public partial class SystemInitializingForm : Form
    {
        public SystemInitializingForm()
        {
            InitializeComponent();
            Program.pcan.InitializeBasicComponents();
            FillComboBoxData();
        }



        private void FillComboBoxData()
        {
            // Channels will be check
            //
            RefreshButton_Click(this, new EventArgs());

            // Baudrates 
            //
            this.BaudComboBox.SelectedIndex = 2; // 500 K

            // Hardware Type for no plugAndplay hardware
            //
            this.HWTypeComboBox.SelectedIndex = 0;

            // Interrupt for no plugAndplay hardware
            //
            this.INTComboBox.SelectedIndex = 0;

            // IO Port for no plugAndplay hardware
            //
            this.IOComboBox.SelectedIndex = 0;

            // Parameters for GetValue and SetValue function calls
            //
            //cbbParameter.SelectedIndex = 0;
        }

        private void InitButton_Click(object sender, EventArgs e)
        {
            TPCANStatus stsResult;

            Program.mf.StartButton.Enabled = true;
            // Connects a selected PCAN-Basic channel
            //
            stsResult = PCANBasic.Initialize(
                Program.pcan.m_PcanHandle,
                Program.pcan.m_Baudrate,
                Program.pcan.m_HwType,
                Convert.ToUInt32(this.IOComboBox.Text, 16),
                Convert.ToUInt16(this.INTComboBox.Text));

            if (stsResult != TPCANStatus.PCAN_ERROR_OK)
                MessageBox.Show(Program.pcan.GetFormatedError(stsResult));

            // Sets the connection status of the main-form
            //
            else
            {
                string status = "Success";
                string content = "System Successfully Initialized!";
                Program.mf.IncludeTextMessage(status, content);
                SetConnectionStatus(stsResult == TPCANStatus.PCAN_ERROR_OK);
                Program.md.Show();
                Program.mf.StartButton.Enabled = true;
                Program.mf.MsgShowButton.Enabled = true;
            }

        }
       
        private void SetConnectionStatus(bool bConnected)
        {
            // Buttons
            //
            this.InitButton.Enabled = !bConnected;
            //btnRead.Enabled = bConnected && rdbManual.Checked;
            //btnWrite.Enabled = bConnected;
            this.ReleaseButton.Enabled = bConnected;
            //btnFilterApply.Enabled = bConnected;
            //btnFilterQuery.Enabled = bConnected;
            //btnGetVersions.Enabled = bConnected;
            this.RefreshButton.Enabled = !bConnected;
            //btnStatus.Enabled = bConnected;
            //btnReset.Enabled = bConnected;

            // ComboBoxs
            //
            this.BaudComboBox.Enabled = !bConnected;
            this.HardwareComboBox.Enabled = !bConnected;
            this.HWTypeComboBox.Enabled = !bConnected;
            this.IOComboBox.Enabled = !bConnected;
            this.INTComboBox.Enabled = !bConnected;
            
            // Hardware configuration and read mode
            //
            if (!bConnected)
                HardwareComboBox_SelectedIndexChanged(this, new EventArgs());
            else
            {
                if (!this.ReleaseButton.Enabled)
                    return;

                // According with the kind of reading, a timer, a thread or a button will be enabled
                //
                else
                {
                    // Abort Read Thread if it exists
                    //
                    if (Program.pcan.m_ReadThread != null)
                    {
                        Program.pcan.m_ReadThread.Abort();
                        Program.pcan.m_ReadThread.Join();
                        Program.pcan.m_ReadThread = null;
                    }

                    // Enable Timer
                    //
                    //Program.uif.tmrRead.Enabled = ReleaseButton.Enabled;
                    if(ReleaseButton.Enabled)
                        Program.uif.tmrRead.Start();
                    else
                        Program.uif.tmrRead.Stop();

                    //ReleaseButton.Enabled ? Program.uif.tmrRead.Start() : Program.uif.tmrRead.Stop(); 
                    
                }
                //Program.md.tmrDisplay.Enabled = bConnected;
                if (ReleaseButton.Enabled)
                    Program.md.tmrDisplay.Start();
                else
                    Program.md.tmrDisplay.Stop();
            }
            // 雷达图旋转，表示连接成功
            //
            Program.mf._StartButton_Click(this, new EventArgs());

            Program.mf.RefreshTimer.Enabled = bConnected;
        }
        /*
        private void ReleaseButton_Click(object sender, EventArgs e)
        {
            // Releases a current connected PCAN-Basic channel
            //
            PCANBasic.Uninitialize(m_PcanHandle);
            tmrRead.Enabled = false;
            if (m_ReadThread != null)
            {
                m_ReadThread.Abort();
                m_ReadThread.Join();
                m_ReadThread = null;
            }
            
            // Sets the connection status of the main-form
            //
            SetConnectionStatus(false);
        }
        */
        private void HardwareComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bNonPnP;
            string strTemp;

            // Get the handle fromt he text being shown
            //
            strTemp = this.HardwareComboBox.Text;
            strTemp = strTemp.Substring(strTemp.IndexOf('(')+1, 2);

            // Determines if the handle belong to a No Plug&Play hardware 
            //
            Program.pcan.m_PcanHandle = Convert.ToByte(strTemp,16);
            bNonPnP = Program.pcan.m_PcanHandle <= PCANBasic.PCAN_DNGBUS1;
            // Activates/deactivates configuration controls according with the 
            // kind of hardware
            //
            this.HWTypeComboBox.Enabled = bNonPnP;
            this.IOComboBox.Enabled = bNonPnP;
            this.INTComboBox.Enabled = bNonPnP;
        }

        //private TPCANHandle[] m_HandlesArray = Program.pcan.m_HandlesArray; 

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            UInt32 iBuffer;
            TPCANStatus stsResult;

            // Clears the Channel combioBox and fill it again with 
            // the PCAN-Basic handles for no-Plug&Play hardware and
            // the detected Plug&Play hardware
            //
            this.HardwareComboBox.Items.Clear();
            try
            {
                for (int i = 0; i < Program.pcan.m_HandlesArray.Length; i++)
                //for (int i = 0; i < Program.pcan.m_HandlesArray.Length; i++)
                {
                    // Includes all no-Plug&Play Handles
                    if (Program.pcan.m_HandlesArray[i] <= PCANBasic.PCAN_DNGBUS1)
                        this.HardwareComboBox.Items.Add(FormatChannelName(Program.pcan.m_HandlesArray[i]));
                    else
                    {
                        // Checks for a Plug&Play Handle and, according with the return value, includes it
                        // into the list of available hardware channels.
                        //
                        stsResult = PCANBasic.GetValue(Program.pcan.m_HandlesArray[i], TPCANParameter.PCAN_CHANNEL_CONDITION, out iBuffer, sizeof(UInt32));
                        if ((stsResult == TPCANStatus.PCAN_ERROR_OK) && (iBuffer == PCANBasic.PCAN_CHANNEL_AVAILABLE))
                            this.HardwareComboBox.Items.Add(FormatChannelName(Program.pcan.m_HandlesArray[i]));
                    }
                }
                HardwareComboBox.SelectedIndex = HardwareComboBox.Items.Count - 1;
            }
            catch (DllNotFoundException)
            {
                MessageBox.Show("Unable to find the library: PCANBasic.dll !","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
        }

        private string FormatChannelName(TPCANHandle handle)
        {
            TPCANDevice devDevice;
            byte byChannel;

            // Gets the owner device and channel for a 
            // PCAN-Basic handle
            //
            devDevice = (TPCANDevice)(handle >> 4);
            byChannel = (byte)(handle & 0xF);

            // Constructs the PCAN-Basic Channel name and return it
            //
            return string.Format("{0} {1} ({2:X2}h)", devDevice, byChannel, handle);//X2 2位16进制

            //devDevide.ToString() + " " + byChannel.ToString() + " (" + handle.ToString() + "h)";
        }

        private void BaudComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Saves the current selected baudrate register code
            //
            switch (this.BaudComboBox.SelectedIndex)
            {
                case 0:
                    Program.pcan.m_Baudrate = TPCANBaudrate.PCAN_BAUD_1M;
                    break;
                case 1:
                    Program.pcan.m_Baudrate = TPCANBaudrate.PCAN_BAUD_800K;
                    break;
                case 2:
                    //Program.pcanm.m_Baudrate = new TPCANBaudrate();
                    Program.pcan.m_Baudrate = TPCANBaudrate.PCAN_BAUD_500K;
                    break;
                case 3:
                    Program.pcan.m_Baudrate = TPCANBaudrate.PCAN_BAUD_250K;
                    break;
                case 4:
                    Program.pcan.m_Baudrate = TPCANBaudrate.PCAN_BAUD_125K;
                    break;
                case 5:
                    Program.pcan.m_Baudrate = TPCANBaudrate.PCAN_BAUD_100K;
                    break;
                case 6:
                    Program.pcan.m_Baudrate = TPCANBaudrate.PCAN_BAUD_95K;
                    break;
                case 7:
                    Program.pcan.m_Baudrate = TPCANBaudrate.PCAN_BAUD_83K;
                    break;
                case 8:
                    Program.pcan.m_Baudrate = TPCANBaudrate.PCAN_BAUD_50K;
                    break;
                case 9:
                    Program.pcan.m_Baudrate = TPCANBaudrate.PCAN_BAUD_47K;
                    break;
                case 10:
                    Program.pcan.m_Baudrate = TPCANBaudrate.PCAN_BAUD_33K;
                    break;
                case 11:
                    Program.pcan.m_Baudrate = TPCANBaudrate.PCAN_BAUD_20K;
                    break;
                case 12:
                    Program.pcan.m_Baudrate = TPCANBaudrate.PCAN_BAUD_10K;
                    break;
                case 13:
                    Program.pcan.m_Baudrate = TPCANBaudrate.PCAN_BAUD_5K;
                    break;
            }
        }

        private void HWTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Saves the current type for a no-Plug&Play hardware
            //
            switch (this.HWTypeComboBox.SelectedIndex)
            {
                case 0:
                    Program.pcan.m_HwType = TPCANType.PCAN_TYPE_ISA;
                    break;
                case 1:
                    Program.pcan.m_HwType = TPCANType.PCAN_TYPE_ISA_SJA;
                    break;
                case 2:
                    Program.pcan.m_HwType = TPCANType.PCAN_TYPE_ISA_PHYTEC;
                    break;
                case 3:
                    Program.pcan.m_HwType = TPCANType.PCAN_TYPE_DNG;
                    break;
                case 4:
                    Program.pcan.m_HwType = TPCANType.PCAN_TYPE_DNG_EPP;
                    break;
                case 5:
                    Program.pcan.m_HwType = TPCANType.PCAN_TYPE_DNG_SJA;
                    break;
                case 6:
                    Program.pcan.m_HwType = TPCANType.PCAN_TYPE_DNG_SJA_EPP;
                    break;
            }
        }

        private void ReleaseButton_Click(object sender, EventArgs e)
        {
            // Releases a current connected PCAN-Basic channel
            //
            PCANBasic.Uninitialize(Program.pcan.m_PcanHandle);
            Program.uif.tmrRead.Enabled = false;
            if (Program.pcan.m_ReadThread != null)
            {
                Program.pcan.m_ReadThread.Abort();
                Program.pcan.m_ReadThread.Join();
                Program.pcan.m_ReadThread = null;
            }

            // Sets the connection status of the main-form
            //
            SetConnectionStatus(false);
            Program.mf.RefreshTimer.Stop();
            Program.mf.IncludeTextMessage("Success", "Device Disconnected!");

            Program.mf.UserInitButton.Enabled = false;
            Program.mf.WriteMsgButton.Enabled = false;
            Program.mf.MessageFilterButton.Enabled = false;
            Program.mf.TargetListButton.Enabled = false;

            Program.md.Hide();
        }

        

    }

        
}
