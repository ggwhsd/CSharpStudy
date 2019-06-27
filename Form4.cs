using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MarketRiskUI
{
    
    public partial class Form4 : Form
    {
        /*托盘/任务栏图标功能、
         * 右键菜单功能
         * 工具栏
         * 菜单栏
         * 状态栏
         * 定时器
         * 进度条
         * 子窗口
         * 图片显示
         * 打开和窗口关闭时的动画效果
         * 闪烁窗口
         * 获取桌面大小
         */
        public const Int32 AW_SLIDE = 0x00040000;
        public const Int32 AW_VER_NEGATIVE = 0x00000008;
        public const Int32 AW_HIDE = 0x00010000;

        [DllImport("user32.dll")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        [DllImport("user32.dll")]
        private static extern bool FlashWindow(IntPtr handle, bool bInvert);

        int i = 1;
        public Form4()
        {
            InitializeComponent();
            //动画效果
            AnimateWindow(this.Handle,300,AW_SLIDE + AW_VER_NEGATIVE);
        }

        private void 关闭所有ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void ShowWindows(string fileName)
        {
            Image p = Image.FromFile(fileName);
            Form f = new Form();
            f.MdiParent = this;
            f.BackgroundImage = p;
            f.Show();
        }

        private void 打卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            this.openFileDialog1.ShowDialog();
            StreamWriter s= new StreamWriter(System.Environment.CurrentDirectory+"\\Menu.ini",true);
            s.WriteLine(openFileDialog1.FileName);
            s.Flush();
            s.Close();
            ShowWindows(openFileDialog1.FileName);

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory+"\\Menu.ini"); 
            int i = 文件ToolStripMenuItem.DropDownItems.Count - 1;
            while (sr.Peek() > 0)
            {
                ToolStripMenuItem menuitem = new ToolStripMenuItem(sr.ReadLine());
                this.文件ToolStripMenuItem.DropDownItems.Insert(i,menuitem);
                i++;
                menuitem.Click += new EventHandler(menuclick);

            }
            toolStripProgressBar1.Maximum = 10;


            listView1.Clear();

            listView1.Items.Add("time","设置时间",0);
            listView1.Items.Add("sms", "启用短信", 1);
            listView1.Items.Add("passwd", "设置密码",2);

        }
        private void menuclick(object sender, EventArgs e)
        {
            MessageBox.Show("hello"+e.ToString());
        }

        private void 打开子窗口ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void showdropdownToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            if (i == 1)
            {
                m5ToolStripMenuItem.Visible = false;
                m6ToolStripMenuItem.Visible = false;
                showdropdownToolStripMenuItem1.ShowDropDown();
                i = 2;
            }
            else
            {
                m5ToolStripMenuItem.Visible = true;
                m6ToolStripMenuItem.Visible = true;
                showdropdownToolStripMenuItem1.ShowDropDown();
                i = 1;
            }
        }

        private void Form4_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Focused == false)
            {
                this.Top = -30;
            }
            if(toolStripProgressBar1.Value< toolStripProgressBar1.Maximum)
            {
                toolStripProgressBar1.Value += 1;
                //toolStripProgressBar1.PerformStep();
            }
            FlashWindow(this.Handle,true);
            



        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Top = 60;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
                statusStrip1.Items[0].Text = "time:"+DateTime.Now.ToString();
            else
                statusStrip1.Items[0].Text = "";

        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Dock = DockStyle.None;
            button2.Dock = DockStyle.Top;
            button1.SendToBack();
            button1.Dock = DockStyle.Top;
           
            button3.Dock = DockStyle.Bottom;
            listView1.Dock = DockStyle.Bottom;
            listView1.Clear();
            listView1.Items.Add("plan", "近期计划", 0);
            listView1.Items.Add("record", "记录", 1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
         

        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            AnimateWindow(this.Handle, 300, AW_SLIDE + AW_VER_NEGATIVE + AW_HIDE);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string Width = Screen.PrimaryScreen.WorkingArea.Width.ToString();
            string height = Screen.PrimaryScreen.WorkingArea.Height.ToString();
            
            MessageBox.Show(Width+" "+height +"\r\n"+ Screen.AllScreens[1].WorkingArea.Width.ToString()+" "+ Screen.AllScreens[1].WorkingArea.Height.ToString());
        }

        private void 打开子窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
