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
    public partial class Form5 : Form
    {
        /*
         * 关闭窗口会有提示
         * 禁止关闭窗口
         * 任务栏提示
         */
        public Form5()
        {
            InitializeComponent();
        }
        public string a;
        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
                
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if ((m.Msg == WM_SYSCOMMAND) && ((int)m.WParam == SC_CLOSE))
            {
                return;
            }
            base.WndProc(ref m);
            
        }
        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            a = "Form5";
            if (MessageBox.Show("将要关闭窗口，是否继续？", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            notifyIcon1.Icon = new Icon(@"C:\Users\a\Pictures\d5.ico");
            notifyIcon1.ShowBalloonTip(1000,"time",DateTime.Now.ToLocalTime().ToString(),ToolTipIcon.Info);
        }
    }
}
