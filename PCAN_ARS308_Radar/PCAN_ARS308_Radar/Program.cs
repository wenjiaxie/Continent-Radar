using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Peak.Can.Basic;

namespace PCAN_ARS308_Radar
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static MainForm mf;
        public static SystemInitializingForm sif;
        public static MessageFilterForm mff;
        public static UserInitForm uif;
        public static WriteMsgForm wmf;
        public static TargetLstForm tlf;
        public static MsgDisplay md;
        public static AboutForm af;
        public static PCANClass pcan = new PCANClass();
        public static PCANClass.MessageStatus pcanm = new PCANClass.MessageStatus(new TPCANMsg(), new TPCANTimestamp(), 2);
        //public static PCANBasic pcanb = new Peak.Can.Basic();


        [STAThread]
        static void Main()
        { 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mf = new MainForm();
            sif = new SystemInitializingForm();
            mff = new MessageFilterForm();
            uif = new UserInitForm();
            wmf = new WriteMsgForm();
            md = new MsgDisplay();
            tlf = new TargetLstForm();
            af = new AboutForm();
            Application.Run(mf);
            pcan.InitializeBasicComponents();
        }
    }
}
