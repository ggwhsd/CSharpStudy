using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarketRiskUI
{
    public partial class Log4NetDemo : Form
    {
        public class LogHelper
        {
            public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");

            public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logtrade");

            public static void WriteLog(string info)
            {

                if (loginfo.IsInfoEnabled)
                {
                    loginfo.Info(info);
                }
            }

            public static void WriteLog(string info, Exception se)
            {
                if (logerror.IsErrorEnabled)
                {
                    logerror.Error(info, se);
                }
            }
        }

        public Log4NetDemo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < 300000)
            {
                LogHelper.WriteLog("当前时间:" + DateTime.Now);
                LogHelper.WriteLog("当前日期:", null);
                i++;
            }
        }
    }
}
