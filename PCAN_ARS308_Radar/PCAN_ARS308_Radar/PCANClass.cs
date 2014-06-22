using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Peak.Can.Basic;
using System.Windows.Forms;

using TPCANHandle = System.Byte;


namespace PCAN_ARS308_Radar
{
    public class PCANClass
    {
       #region Structures
        /// <summary>
        /// Message Status structure used to show CAN Messages
        /// in a ListView
        /// </summary>
        #region Original


        public class MessageStatus
        {
            private TPCANMsg m_Msg;
            private TPCANTimestamp m_TimeStamp;
            private TPCANTimestamp m_oldTimeStamp;
            private int m_iIndex;
            private int m_Count;
            private bool m_bShowPeriod;
            private bool m_bWasChanged;
            public MessageStatus(TPCANMsg canMsg, TPCANTimestamp canTimestamp, int listIndex)
            {
                m_Msg = canMsg;
                m_TimeStamp = canTimestamp;
                m_oldTimeStamp = canTimestamp;
                m_iIndex = listIndex;
                m_Count = 1;
                m_bShowPeriod = true;
                m_bWasChanged = false;
            }

            public void Update(TPCANMsg canMsg, TPCANTimestamp canTimestamp)
            {
                m_Msg = canMsg;
                m_oldTimeStamp = m_TimeStamp;
                m_TimeStamp = canTimestamp;
                m_bWasChanged = true;
                m_Count += 1;
            }

            public TPCANMsg CANMsg
            {
                get { return m_Msg; }
            }

            public TPCANTimestamp Timestamp
            {
                get { return m_TimeStamp; }
            }

            public int Position
            {
                get { return m_iIndex; }
            }

            public string TypeString
            {
                get { return GetMsgTypeString(); }
            }

            public string IdString
            {
                get { return GetIdString(); }
            }

            public string DataString
            {
                get { return GetDataString(); }
            }

            public int Count
            {
                get { return m_Count; }
            }

            public bool ShowingPeriod
            {
                get { return m_bShowPeriod; }
                set
                {
                    if (m_bShowPeriod ^ value)
                    {
                        m_bShowPeriod = value;
                        m_bWasChanged = true;
                    }
                }
            }

            public bool MarkedAsUpdated
            {
                get { return m_bWasChanged; }
                set { m_bWasChanged = value; }
            }

            public string TimeString
            {
                get { return GetTimeString(); }
            }

            private string GetTimeString()
            {
                double fTime;

                fTime = m_TimeStamp.millis + (m_TimeStamp.micros / 1000.0);
                if (m_bShowPeriod)
                    fTime -= (m_oldTimeStamp.millis + (m_oldTimeStamp.micros / 1000.0));
                return fTime.ToString("F1");
            }

            private string GetDataString()
            {
                string strTemp;

                strTemp = "";

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                    return "Remote Request";
                else
                    for (int i = 0; i < m_Msg.LEN; i++)
                        strTemp += string.Format("{0:X2} ", m_Msg.DATA[i]);

                return strTemp;
            }

            public string GetDataString2(int targetNotobDisplayed)
            {
                string strTemp;

                strTemp = "";

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                    return "Remote Request";
                else
                    for (int i = 0; i < m_Msg.LEN; i++)
                    {
                        if (m_Msg.DATA[0] <= targetNotobDisplayed)
                        {
                            strTemp += string.Format("{0:X2} ", m_Msg.DATA[i]);

                        }
                        
                    }            
                return strTemp;
            }

            public string GetDataString3(int targetNotobDisplayed)
            {
                string strTemp = "";
                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                    return "Remote Request";
                else if (m_Msg.ID == 0x60B)
                    for (int i = 0; i < m_Msg.LEN; i++)
                    {
                        //if (((m_Msg.DATA[0] >> 2) & 0x3F) <= targetNotobDisplayed)
                        if ((((m_Msg.DATA[1] << 3) & 0xFF8) + ((m_Msg.DATA[2] >> 5) & 0x07)) != 0)
                        {
                            strTemp += string.Format("{0:X2} ", m_Msg.DATA[i]);

                        }
                    }
                else //if (m_Msg.ID == 0x60C)
                    for (int i = 0; i < m_Msg.LEN; i++)
                        strTemp += string.Format("{0:X2} ", m_Msg.DATA[i]);
                return strTemp;
            }

            private string GetIdString()
            {
                // We format the ID of the message and show it
                //
                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_EXTENDED) == TPCANMessageType.PCAN_MESSAGE_EXTENDED)
                    return string.Format("{0:X8}h", m_Msg.ID);
                else
                    return string.Format("{0:X3}h", m_Msg.ID);
            }

            private string GetMsgTypeString()
            {
                string strTemp;

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_EXTENDED) == TPCANMessageType.PCAN_MESSAGE_EXTENDED)
                    strTemp = "EXTENDED";
                else
                    strTemp = "STANDARD";

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                    strTemp += "/RTR";

                return strTemp;
            }
        #endregion

            #region readbitfrombyte
            /// <summary>
            /// 获取数据中某一位的值
            /// </summary>
            /// <param name="input">传入的数据类型,可换成其它数据类型,比如Int</param>
            /// <param name="index">要获取的第几位的序号,从0开始</param>
            /// <returns>返回值为-1表示获取值失败</returns>
            private int GetbitValue(byte input, int index)
            {
                if (index > sizeof(byte))
                {
                    return -1;
                }
                //左移到最高位
                int value = input << (sizeof(byte) - 1 - index);
                //右移到最低位
                value = value >> (sizeof(byte) - 1);
                return value;
            }
            #endregion

            //////////////////////////////////////////////////////////////////////////
            ///自行添加变量forARS308的output
            /////////////////////////////////////////////////////////////////////////

            #region outputstates
            public int NVMwritestates
            {
                get { return m_NVMwritestates(); }
            }
            private int m_NVMwritestates()
            {
                int tempstates;
                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    tempstates = 0;
                    return tempstates;
                }
                else if (m_Msg.ID == 0x200)
                {
                    byte temp;
                    int bit4;
                    temp = (byte)m_Msg.DATA[2];
                    bit4 = GetbitValue(temp, 4) == 1 ? tempstates = 0 : tempstates = 1;
                    return tempstates;
                }
                else
                {
                    tempstates = 0;
                    return tempstates;
                }

            }


            public int NVMreadstates
            {
                get { return m_NVMreadstates(); }
            }
            private int m_NVMreadstates()
            {
                int tempstates;

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    tempstates = 0;
                    return tempstates;
                }
                else if (m_Msg.ID == 0x200)
                {
                    byte temp;
                    temp = m_Msg.DATA[2];
                    tempstates = (GetbitValue(temp, 3) * 2 + GetbitValue(temp, 2));
                    return tempstates;
                }
                else
                {
                    tempstates = 0;
                    return tempstates;
                }
            }


            public int CurrrangelengthCal
            {
                get { return m_CurrrangelengthCal(); }
            }
            private int m_CurrrangelengthCal()
            {
                int tempstates = 0;

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    tempstates = 0;
                    return tempstates;
                }
                else if (m_Msg.ID == 0x200)
                {
                    byte length;
                    length = m_Msg.DATA[4];
                    for (int i = 0; i <= 7; i++)
                    {
                        tempstates = tempstates + (2 ^ i) * GetbitValue(length, i);
                    }
                    return tempstates;
                }
                else
                {
                    tempstates = 0;
                    return tempstates;
                }

            }


            public float Currelevationcal
            {
                get { return m_Currelevationcal(); }
            }
            private float m_Currelevationcal()
            {
                float tempstates = 0;

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    tempstates = 0;
                    return tempstates;
                }
                else if (m_Msg.ID == 0x200)
                {
                    byte elevation;
                    elevation = m_Msg.DATA[3];
                    for (int i = 0; i <= 7; i++)
                    {
                        tempstates = tempstates + (2 ^ i) * GetbitValue(elevation, i);
                    }
                    tempstates = tempstates / 255 * 32;
                    return tempstates;
                }
                else
                {
                    tempstates = 0;
                    return tempstates;
                }
            }


            public int RadarPowerReduction
            {
                get { return m_RadarPowerReduction(); }
            }
            private int m_RadarPowerReduction()
            {
                int tempstates;
                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    tempstates = 0;
                    return tempstates;
                }
                else if (m_Msg.ID == 0x200)
                {
                    byte temp;
                    int bit7;
                    temp = (byte)m_Msg.DATA[0];
                    bit7 = GetbitValue(temp, 7) == 1 ? tempstates = 0 : tempstates = 1;
                    return tempstates;
                }
                else
                {
                    tempstates = 0;
                    return tempstates;
                }
            }


            public int CurrentRadarPower
            {
                get { return m_CurrentRadarPower(); }
            }
            private int m_CurrentRadarPower()
            {
                int tempstates;
                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    tempstates = 0;
                    return tempstates;
                }
                else if (m_Msg.ID == 0x200)
                {
                    byte temp;
                    int bit7;
                    temp = (byte)m_Msg.DATA[0];
                    bit7 = GetbitValue(temp, 1) == 1 ? tempstates = 0 : tempstates = 1;
                    return tempstates;
                }
                else
                {
                    tempstates = 0;
                    return tempstates;
                }
            }


            public string SupVolt_L
            {
                get { return m_SupVolt_L(); }
            }
            private string m_SupVolt_L()
            {
                int tempstates;
                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    tempstates = 0;
                    return tempstates.ToString();
                }
                else if (m_Msg.ID == 0x200)
                {
                    byte temp;
                    int bit7;
                    temp = (byte)m_Msg.DATA[0];
                    bit7 = GetbitValue(temp, 6) == 1 ? tempstates = 0 : tempstates = 1;
                    return tempstates.ToString();
                }
                else
                {
                    return "null";                
                }
            }


            public int Rxinvalid
            {
                get { return m_Rxinvalid(); }
            }
            private int m_Rxinvalid()
            {
                int tempstates;

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    tempstates = 0;
                    return tempstates;
                }
                else if (m_Msg.ID == 0x200)
                {
                    byte temp;
                    temp = m_Msg.DATA[2];
                    tempstates = (GetbitValue(temp, 1) * 2 + GetbitValue(temp, 0));
                    return tempstates;
                }
                else
                {
                    tempstates = 0;
                    return tempstates;
                }
            }


            public int Sensdef
            {
                get { return m_Sensdef(); }
            }
            private int m_Sensdef()
            {
                int tempstates;
                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    tempstates = 0;
                    return tempstates;
                }
                else if (m_Msg.ID == 0x200)
                {
                    byte temp;
                    int bit7;
                    temp = (byte)m_Msg.DATA[0];
                    bit7 = GetbitValue(temp, 5) == 1 ? tempstates = 0 : tempstates = 1;
                    return tempstates;
                }
                else
                {
                    tempstates = 0;
                    return tempstates;
                }
            }


            public int SensTempErr
            {
                get { return m_SensTempErr(); }
            }
            private int m_SensTempErr()
            {
                int tempstates;
                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    tempstates = 0;
                    return tempstates;
                }
                else if (m_Msg.ID == 0x200)
                {
                    byte temp;
                    int bit7;
                    temp = (byte)m_Msg.DATA[0];
                    bit7 = GetbitValue(temp, 3) == 1 ? tempstates = 0 : tempstates = 1;
                    return tempstates;
                }
                else
                {
                    tempstates = 0;
                    return tempstates;
                }
            }



            #endregion
            /////////////////////////////////////////////////////////////////////////
            ///自行添加变量forARS308的Targetlist
            /////////////////////////////////////////////////////////////////////////
            #region targetlist

            public string NooftarNear
            {
                get { return m_NooftarNear(); }
            }
            private string m_NooftarNear()
            {
                int tempstates = 0;

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    return "Remote Request";
                }
                else if (m_Msg.ID == 0x600)
                {
                    byte length;
                    length = m_Msg.DATA[0];
                    for (int i = 0; i <= 7; i++)
                    {
                        tempstates = tempstates + (2 ^ i) * GetbitValue(length, i);
                    }
                    return tempstates.ToString();
                }
                else
                {
                    return "null";
                }
            }
            public int NooftarFar
            {
                get { return m_NooftarFar(); }
            }
            private int m_NooftarFar()
            {
                int tempstates = 0;

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    tempstates = 0;
                    return tempstates;
                }
                else if (m_Msg.ID == 0x600)
                {
                    byte length;
                    length = m_Msg.DATA[1];
                    for (int i = 0; i <= 7; i++)
                    {
                        tempstates = tempstates + (2 ^ i) * GetbitValue(length, i);
                    }
                    return tempstates;
                }
                else
                {
                    tempstates = 0;
                    return tempstates;
                }
            }
            /////////////////////////////////////////以上是0x600报文中的量
            public int NoofTar1
            {
                get { return m_NoofTar1(); }
            }
            private int m_NoofTar1()
            {
                int tempstates = 0;

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    tempstates = 0;
                    return tempstates;
                }
                else if (m_Msg.ID == 0x701)
                {
                    byte length;
                    length = m_Msg.DATA[0];
                    for (int i = 0; i <= 7; i++)
                    {
                        tempstates = tempstates + (2 ^ i) * GetbitValue(length, i);
                    }
                    return tempstates;
                }
                else
                {
                    tempstates = 0;
                    return tempstates;
                }
            }

            /// <summary>
            /// 0x701中的报文
            /// </summary>
            public string Tar_Dis_Rms
            {
                get { return m_Tar_Dis_Rms(); }
            }
            private string m_Tar_Dis_Rms()
            {
                float tempstates = 0;

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    return "Remote Request";
                }
                else if (m_Msg.ID == 0x701)
                {
                    byte length;
                    length = m_Msg.DATA[1];
                    for (int i = 0; i <= 7; i++)
                    {
                        tempstates = tempstates + (2 ^ i) * GetbitValue(length, i);
                    }
                    tempstates = tempstates / 255 * (float)25.5 - 10;
                    return tempstates.ToString();
                }
                else
                {
                    return "NULL";
                }
            }
            public string Tar_Ang_Rms
            {
                get { return m_Tar_Ang_Rms(); }
            }
            private string m_Tar_Ang_Rms()
            {
                float tempstates = 0;

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    return "Remote Request";
                }
                else if (m_Msg.ID == 0x701)
                {
                    byte length;
                    length = m_Msg.DATA[2];
                    for (int i = 1; i <= 7; i++)
                    {
                        tempstates = tempstates + (2 ^ i) * GetbitValue(length, i);
                    }
                    tempstates = tempstates / (float)127 * (float)12.7;
                    return tempstates.ToString();
                }
                else
                {
                    return "NULL";
                }
            }
            public string Tar_Ver_Rms
            {
                get { return m_Tar_Ver_Rms(); }
            }
            private string m_Tar_Ver_Rms()
            {
                float tempstates = 0;

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    return "Remote Request";
                }
                else if (m_Msg.ID == 0x701)
                {
                    byte length;
                    byte tempbyte;
                    length = m_Msg.DATA[3];
                    tempbyte = m_Msg.DATA[2];
                    for (int i = 0; i <= 7; i++)
                    {
                        tempstates = tempstates + (2 ^ i) * GetbitValue(length, i);
                    }
                    tempstates = tempstates + (2 ^ 8) * GetbitValue(tempbyte, 0);
                    tempstates = tempstates / (float)512 * (float)15.33 - 5;
                    return tempstates.ToString();
                }
                else
                {
                    return "NULL";
                }
            }
            public string Tar_Ver
            {
                get { return m_Tar_Ver(); }
            }
            private string m_Tar_Ver()
            {
                float tempstates = 0;
                float auxilary = 0;
                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    return "Remote Request";
                }
                else if (m_Msg.ID == 0x701)
                {
                    byte length;
                    byte tempbyte;
                    length = m_Msg.DATA[4];
                    tempbyte = m_Msg.DATA[5];
                    for (int i = 0; i <= 7; i++)
                    {
                        tempstates = tempstates + (2 ^ (i + 4)) * GetbitValue(length, i);
                    }
                    for (int t = 4; t <= 7; t++)
                    {
                        auxilary = auxilary + (2 ^ (t - 4)) * GetbitValue(tempbyte, t);
                    }
                    tempstates = auxilary + tempstates;
                    return tempstates.ToString();
                }
                else
                {
                    return "NULL";
                }
            }
            public string Tar_Dis
            {
                get { return m_Tar_Dis(); }
            }
            private string m_Tar_Dis()
            {
                float tempstates = 0;
                float auxilary = 0;
                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    return "Remote Request";
                }
                else if (m_Msg.ID == 0x701)
                {
                    byte length;
                    byte tempbyte;
                    length = m_Msg.DATA[6];
                    tempbyte = m_Msg.DATA[5];
                    for (int i = 0; i <= 7; i++)
                    {
                        tempstates = tempstates + (2 ^ i) * GetbitValue(length, i);
                    }
                    for (int t = 0; t <= 2; t++)
                    {
                        auxilary = auxilary + (2 ^ (t + 8)) * GetbitValue(tempbyte, t);
                    }
                    tempstates = auxilary + tempstates;
                    return tempstates.ToString();
                }
                else
                {
                    return "NULL";
                }
            }

            ///<summary>
            ///0x702中报文
            ///</summary>
            ///
            public string NoofTar2
            {
                get { return m_Nooftar2(); }
            }
            private string m_Nooftar2()
            {
                int tempstates = 0;

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    return "Remote Request";
                }
                else if (m_Msg.ID == 0x702)
                {
                    byte length;
                    length = m_Msg.DATA[0];
                    for (int i = 0; i <= 7; i++)
                    {
                        tempstates = tempstates + (2 ^ i) * GetbitValue(length, i);
                    }
                    return tempstates.ToString();
                }
                else
                {
                    return "NULL";
                }
            }
            public string Tar_PdH0
            {
                get { return m_Tar_PdH0(); }
            }
            private string m_Tar_PdH0()
            {
                int tempstates = 0;

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    return "Remote Request";
                }
                else if (m_Msg.ID == 0x702)
                {
                    byte length;
                    length = m_Msg.DATA[2];
                    for (int i = 1; i <= 7; i++)
                    {
                        tempstates = tempstates + (2 ^ i) * GetbitValue(length, i);
                    }

                    return tempstates.ToString();
                }
                else
                {
                    return "NULL";
                }
            }
            public string Tar_Length
            {
                get { return m_Tar_Length(); }
            }
            private string m_Tar_Length()
            {
                float tempstates = 0;
                float auxilary = 0;
                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    return "Remote Request";
                }
                else if (m_Msg.ID == 0x702)
                {
                    byte length;
                    byte tempbyte;
                    length = m_Msg.DATA[2];
                    tempbyte = m_Msg.DATA[1];
                    for (int i = 0; i <= 7; i++)
                    {
                        tempstates = tempstates + (2 ^ (i + 4)) * GetbitValue(length, i);
                    }
                    for (int t = 0; t <= 0; t++)
                    {
                        auxilary = auxilary + (2 ^ (t + 8)) * GetbitValue(tempbyte, t);
                    }
                    tempstates = auxilary + tempstates;
                    tempstates = tempstates / 511 * (float)51.1;
                    return tempstates.ToString();
                }
                else
                {
                    return "NULL";
                }
            }
            public string Tar_Width
            {
                get { return m_Tar_Width(); }
            }
            private string m_Tar_Width()
            {
                float tempstates = 0;
                float auxilary = 0;
                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    return "Remote Request";
                }
                else if (m_Msg.ID == 0x702)
                {
                    byte length;
                    byte tempbyte;
                    length = m_Msg.DATA[4];
                    tempbyte = m_Msg.DATA[3];
                    for (int i = 0; i <= 7; i++)
                    {
                        tempstates = tempstates + (2 ^ (i + 4)) * GetbitValue(length, i);
                    }
                    for (int t = 0; t <= 0; t++)
                    {
                        auxilary = auxilary + (2 ^ (t + 8)) * GetbitValue(tempbyte, t);
                    }
                    tempstates = auxilary + tempstates;
                    tempstates = tempstates / 511 * (float)51.1;
                    return tempstates.ToString();
                }
                else
                {
                    return "NULL";
                }
            }
            public string Tar_Ang_State
            {
                get { return m_Tar_Ang_State(); }
            }
            private string m_Tar_Ang_State()
            {
                int tempstates;

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    return "Remote Request";
                }
                else if (m_Msg.ID == 0x702)
                {
                    byte temp;
                    temp = m_Msg.DATA[5];
                    tempstates = (GetbitValue(temp, 5) * 2 + GetbitValue(temp, 4));
                    return tempstates.ToString();
                }
                else
                {
                    return "NULL";
                }
            }
            public string Tar_Type
            {
                get { return m_Tar_Type(); }
            }
            private string m_Tar_Type()
            {
                int tempstates;

                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    return "Remote Request";
                }
                else if (m_Msg.ID == 0x702)
                {
                    byte temp;
                    temp = m_Msg.DATA[5];
                    tempstates = (GetbitValue(temp, 7) * 2 + GetbitValue(temp, 6));
                    return tempstates.ToString();
                }
                else
                {
                    return "NULL";
                }
            }
            public string Tar_Ang
            {
                get { return m_Tar_Ang(); }
            }
            private string m_Tar_Ang()
            {
                float tempstates = 0;
                float auxilary = 0;
                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    return "Remote Request";
                }
                else if (m_Msg.ID == 0x702)
                {
                    byte length;
                    byte tempbyte;
                    length = m_Msg.DATA[6];
                    tempbyte = m_Msg.DATA[5];
                    for (int i = 2; i <= 7; i++)
                    {
                        tempstates = tempstates + (2 ^ (i - 2)) * GetbitValue(length, i);
                    }
                    for (int t = 0; t <= 3; t++)
                    {
                        auxilary = auxilary + (2 ^ (t + 6)) * GetbitValue(tempbyte, t);
                    }
                    tempstates = auxilary + tempstates;
                    tempstates = tempstates / 1024 * (float)102.3 - 30;
                    return tempstates.ToString();
                }
                else
                {
                    return "NULL";
                }
            }
            public string Tar_RCSValue
            {
                get { return m_Tar_RCSValue(); }
            }
            private string m_Tar_RCSValue()
            {
                float tempstates = 0;
                float auxilary = 0;
                if ((m_Msg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) == TPCANMessageType.PCAN_MESSAGE_RTR)
                {
                    return "Remote Request";
                }
                else if (m_Msg.ID == 0x702)
                {
                    byte length;
                    byte tempbyte;
                    length = m_Msg.DATA[7];
                    tempbyte = m_Msg.DATA[6];
                    for (int i = 0; i <= 7; i++)
                    {
                        tempstates = tempstates + (2 ^ i) * GetbitValue(length, i);
                    }
                    for (int t = 0; t <= 1; t++)
                    {
                        auxilary = auxilary + (2 ^ (t + 8)) * GetbitValue(tempbyte, t);
                    }
                    tempstates = auxilary + tempstates;
                    tempstates = tempstates / 1024 * (float)102.3 - 50;
                    return tempstates.ToString();
                }
                else
                {
                    return "NULL";
                }
            }
            #endregion

            #region Delegates
            /// <summary>
            /// Read-Delegate Handler
            /// </summary>
            public delegate void ReadDelegateHandler();
            #endregion

            
            /// <summary>
            /// Gets the current status of the PCAN-Basic message filter
            /// </summary>
            /// <param name="status">Buffer to retrieve the filter status</param>
            /// <returns>If calling the function was successfull or not</returns>

        }
        #endregion



        public void InitializeBasicComponents()
        {
            // Creates the list for received messages
            //
            m_LastMsgsList = new System.Collections.ArrayList();
            // Creates the delegate used for message reading
            //
            m_ReadDelegate = new ReadDelegateHandler(ReadMessages);
            // Creates the event used for signalize incomming messages 
            //
            m_ReceiveEvent = new System.Threading.AutoResetEvent(false);
            // Creates an array with all possible PCAN-Channels
            //
            m_HandlesArray = new TPCANHandle[] 
            { 
                PCANBasic.PCAN_ISABUS1,
                PCANBasic.PCAN_ISABUS2,
                PCANBasic.PCAN_ISABUS3,
                PCANBasic.PCAN_ISABUS4,
                PCANBasic.PCAN_ISABUS5,
                PCANBasic.PCAN_ISABUS6,
                PCANBasic.PCAN_ISABUS7,
                PCANBasic.PCAN_ISABUS8,
                PCANBasic.PCAN_DNGBUS1,
                PCANBasic.PCAN_PCIBUS1,
                PCANBasic.PCAN_PCIBUS2,
                PCANBasic.PCAN_PCIBUS3,
                PCANBasic.PCAN_PCIBUS4,
                PCANBasic.PCAN_PCIBUS5,
                PCANBasic.PCAN_PCIBUS6,
                PCANBasic.PCAN_PCIBUS7,
                PCANBasic.PCAN_PCIBUS8,
                PCANBasic.PCAN_USBBUS1,
                PCANBasic.PCAN_USBBUS2,
                PCANBasic.PCAN_USBBUS3,
                PCANBasic.PCAN_USBBUS4,
                PCANBasic.PCAN_USBBUS5,
                PCANBasic.PCAN_USBBUS6,
                PCANBasic.PCAN_USBBUS7,
                PCANBasic.PCAN_USBBUS8,
                PCANBasic.PCAN_PCCBUS1,
                PCANBasic.PCAN_PCCBUS2
            };

            // Fills and configures the Data of several comboBox components
            //
            //FillComboBoxData();

            // Prepares the PCAN-Basic's debug-Log file
            //
            ConfigureLogFile();
        }

        private void ConfigureLogFile()
        {
            UInt32 iBuffer;

            // Sets the mask to catch all events
            //
            iBuffer = PCANBasic.LOG_FUNCTION_ALL;

            // Configures the log file. 
            // NOTE: The Log capability is to be used with the NONEBUS Handle. Other handle than this will 
            // cause the function fail.
            //
            PCANBasic.SetValue(PCANBasic.PCAN_NONEBUS, TPCANParameter.PCAN_LOG_CONFIGURE, ref iBuffer, sizeof(UInt32));
        }

        public bool GetFilterStatus(out uint status)
        {
            TPCANStatus stsResult;

            // Tries to get the sttaus of the filter for the current connected hardware
            //
            stsResult = PCANBasic.GetValue(m_PcanHandle, TPCANParameter.PCAN_MESSAGE_FILTER, out status, sizeof(UInt32));

            // If it fails, a error message is shown
            //
            if (stsResult != TPCANStatus.PCAN_ERROR_OK)
            {
                MessageBox.Show(GetFormatedError(stsResult));
                return false;
            }
            return true;
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
                stsResult = PCANBasic.Read(m_PcanHandle, out CANMsg, out CANTimeStamp);

                // A message was received
                // We process the message(s)
                //
                if (stsResult == TPCANStatus.PCAN_ERROR_OK)
                    ProcessMessage(CANMsg, CANTimeStamp);

            } while (Program.sif.ReleaseButton.Enabled && (!Convert.ToBoolean(stsResult & TPCANStatus.PCAN_ERROR_QRCVEMPTY)));
        }

        public void ProcessMessage(TPCANMsg theMsg, TPCANTimestamp itsTimeStamp)
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
        
        private void InsertMsgEntry(TPCANMsg newMsg, TPCANTimestamp timeStamp)
        {
            MessageStatus msgStsCurrentMsg;
            ListViewItem lviCurrentItem;

            lock (m_LastMsgsList.SyncRoot)
            {
                // We add this status in the last message list
                //
                msgStsCurrentMsg = new MessageStatus(newMsg, timeStamp, Program.md.MsgListView.Items.Count);
                m_LastMsgsList.Add(msgStsCurrentMsg);

                // Add the new ListView Item with the Type of the message
                //	
                lviCurrentItem = Program.md.MsgListView.Items.Add(msgStsCurrentMsg.TypeString);
                // We set the ID of the message
                //
                lviCurrentItem.SubItems.Add(msgStsCurrentMsg.IdString);
                // We set the length of the Message
                //
                lviCurrentItem.SubItems.Add(newMsg.LEN.ToString());
                // We set the data of the message. 	
                //
                lviCurrentItem.SubItems.Add(msgStsCurrentMsg.DataString);
                // we set the message count message (this is the First, so count is 1)            
                //
                lviCurrentItem.SubItems.Add(msgStsCurrentMsg.Count.ToString());
                // Add time stamp information if needed
                //
                lviCurrentItem.SubItems.Add(msgStsCurrentMsg.TimeString);
            }
        }
        
        public string GetFormatedError(TPCANStatus error)
        {
            StringBuilder strTemp;

            // Creates a buffer big enough for a error-text
            //
            strTemp = new StringBuilder(256);
            // Gets the text using the GetErrorText API function
            // If the function success, the translated error is returned. If it fails,
            // a text describing the current error is returned.
            //
            if (PCANBasic.GetErrorText(error, 0, strTemp) != TPCANStatus.PCAN_ERROR_OK)
                return string.Format("An error occurred. Error-code's text ({0:X}) couldn't be retrieved", error);
            else
                return strTemp.ToString();
        }



        #region Delegates
        /// <summary>
        /// Read-Delegate Handler
        /// </summary>
        public delegate void ReadDelegateHandler();
        #endregion


        #region 
        /// <summary>
        /// Saves the handle of a PCAN hardware
        /// </summary>
        public TPCANHandle m_PcanHandle;
        /// <summary>
        /// Saves the baudrate register for a conenction
        /// </summary>
        public TPCANBaudrate m_Baudrate;
        /// <summary>
        /// Saves the type of a non-plug-and-play hardware
        /// </summary>
        public TPCANType m_HwType;
        /// <summary>
        /// Stores the status of received messages for its display
        /// </summary>
        public System.Collections.ArrayList m_LastMsgsList;
        /// <summary>
        /// Read Delegate for calling the function "ReadMessages"
        /// </summary>
        public ReadDelegateHandler m_ReadDelegate;
        /// <summary>
        /// Receive-Event
        /// </summary>
        public System.Threading.AutoResetEvent m_ReceiveEvent;
        /// <summary>
        /// Thread for message reading (using events)
        /// </summary>
        public System.Threading.Thread m_ReadThread;
        /// <summary>
        /// Handles of the current available PCAN-Hardware
        /// </summary>
        public TPCANHandle[] m_HandlesArray;
        #endregion

        //MainForm mf = new MainForm();
        /*public void IncludeTextMessage(string strMsg)
        {
            this.InfoListBox.Items.Add(strMsg);
            this.InfoListBox.SelectedIndex = this.InfoListBox.Items.Count - 1;
        }
         */
    }
}
