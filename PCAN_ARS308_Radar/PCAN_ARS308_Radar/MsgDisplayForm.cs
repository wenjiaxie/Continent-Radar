using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Peak.Can.Basic;
using System.Runtime.InteropServices;
using System.Collections;

namespace PCAN_ARS308_Radar
{
    public partial class MsgDisplay : Form
    {
        public MsgDisplay()
        {
            InitializeComponent();
            this.TopMost = true;
            this.RemoveXButton(this.Handle.ToInt32());
            this.H60AcheckBox.Checked = true;
            this.H60BCheckBox.Checked = true;
            this.H60CCheckBox.Checked = true;
            this.H701checkBox.Checked = true;
            this.H702CheckBox.Checked = true;
            this.H60AcheckBox.Enabled = false;
            this.H60BCheckBox.Enabled = false;
            this.H60CCheckBox.Enabled = false;
            this.H701checkBox.Enabled = false;
            this.H702CheckBox.Enabled = false;
        }

        [DllImport("USER32.DLL")]
        public static extern int GetSystemMenu(int hwnd, int bRevert);
        [DllImport("USER32.DLL")]
        public static extern int RemoveMenu(int hMenu, int nPosition, int wFlags);

        /// <summary>
        /// 返回值，非零表示成功，零表示失败。
        /// </summary>
        /// <param name="iHWND">窗口的句柄</param>
        /// <returns>是否成功</returns>
        public int RemoveXButton(int iHWND)
        {
            int iSysMenu;
            const int MF_BYCOMMAND = 0x400; //0x400-关闭
            iSysMenu = GetSystemMenu(this.Handle.ToInt32(), 0);
            return RemoveMenu(iSysMenu, 6, MF_BYCOMMAND);//是6而不是其他
        }


        public void tmrDisplay_Tick(object sender, EventArgs e)
        {
            if (!Program.mf.StartButton.Enabled)
            {
                DisplayMessages2();
                this.ClearButton.Enabled = true;
            }
            else
                DisplayMessages();
        }

        private void DisplayMessages()
        {
            ListViewItem lviCurrentItem;

            lock (Program.pcan.m_LastMsgsList.SyncRoot)
            {
                foreach (PCANClass.MessageStatus msgStatus in Program.pcan.m_LastMsgsList)
                {
                    // Get the data to actualize
                    //
                    if (msgStatus.MarkedAsUpdated)
                    {
                        msgStatus.MarkedAsUpdated = false;
                        lviCurrentItem = this.MsgListView.Items[msgStatus.Position];

                        lviCurrentItem.SubItems[2].Text = msgStatus.CANMsg.LEN.ToString();
                        lviCurrentItem.SubItems[3].Text = msgStatus.DataString;
                        lviCurrentItem.SubItems[4].Text = msgStatus.Count.ToString();
                        lviCurrentItem.SubItems[5].Text = msgStatus.TimeString;
                    }
                }
            }
        }

        public ArrayList list60Bh = new ArrayList();

        private void DisplayMessages2()
        {
            ListViewItem lviCurrentItem;

            lock (Program.pcan.m_LastMsgsList.SyncRoot)
            {
                foreach (PCANClass.MessageStatus msgStatus in Program.pcan.m_LastMsgsList)
                {
                    // Get the data to actualize
                    //
                    if (msgStatus.MarkedAsUpdated)
                    {
                        msgStatus.MarkedAsUpdated = false;


                        if (Program.uif.OpTypeComboBox.SelectedIndex == 0)
                        {
                            if (
                                ((msgStatus.IdString == "701h" && this.H701checkBox.Checked) ||
                                 (msgStatus.IdString == "702h" && this.H702CheckBox.Checked)  ) &&
                                 (msgStatus.GetDataString2((int)this.NoofTagtobDspUpDown.Value) != "")
                                )
                            {
                                lviCurrentItem = new ListViewItem();

                                lviCurrentItem.Text = msgStatus.TypeString;
                                lviCurrentItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = msgStatus.IdString });
                                lviCurrentItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = msgStatus.CANMsg.LEN.ToString() });
                                //lviCurrentItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = msgStatus.DataString });
                                lviCurrentItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = msgStatus.GetDataString2((int)this.NoofTagtobDspUpDown.Value) });
                                lviCurrentItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "" });
                                lviCurrentItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = System.DateTime.Now.ToShortTimeString() + ":" + System.DateTime.Now.Second.ToString() + ":" + System.DateTime.Now.Millisecond });
                                this.MsgListView.Items.Add(lviCurrentItem);
                            }
                        }
                        else
                        {
                            if (
                                ((msgStatus.IdString == "60Ah" && this.H60AcheckBox.Checked) ||
                                 (msgStatus.IdString == "60Bh" && this.H60BCheckBox.Checked) ||
                                 (msgStatus.IdString == "60Ch" && this.H60CCheckBox.Checked)) &&
                                 (msgStatus.GetDataString3((int)this.NoofTagtobDspUpDown.Value) != "")
                                ) 
                            {
                                lviCurrentItem = new ListViewItem();

                                lviCurrentItem.Text = msgStatus.TypeString;
                                lviCurrentItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = msgStatus.IdString });
                                lviCurrentItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = msgStatus.CANMsg.LEN.ToString() });
                                //lviCurrentItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = msgStatus.DataString });
                                lviCurrentItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = msgStatus.GetDataString3((int)this.NoofTagtobDspUpDown.Value) });
                                lviCurrentItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "" });
                                lviCurrentItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = System.DateTime.Now.ToShortTimeString() + ":" + System.DateTime.Now.Second.ToString() + ":" + System.DateTime.Now.Millisecond });
                                this.MsgListView.Items.Add(lviCurrentItem);                                        
                            }

                            if ((msgStatus.IdString == "60Bh") && (msgStatus.GetDataString3((int)this.NoofTagtobDspUpDown.Value) != "") && ((((msgStatus.CANMsg.DATA[1] << 3) & 0x3F8) + ((msgStatus.CANMsg.DATA[2] >> 5) & 0x07)) != 0))
                                list60Bh.Add(msgStatus);
                        }
                    }   
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.MsgListView.Items.Clear();
            DisplayMessages2();
        }



    }
}
