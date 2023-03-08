using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace UIDesignDemo2
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        public Form1()
        {
            InitializeComponent();
            //绘制圆角的窗体
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            panel_nav.Height = btn_dashboard.Height;
            panel_nav.Top = btn_dashboard.Top;
            panel_nav.Left = btn_dashboard.Left;
            btn_dashboard.BackColor = Color.FromArgb(43, 51, 73);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel_nav.Height = btn_dashboard.Height;
            panel_nav.Top = btn_dashboard.Top;
            panel_nav.Left = btn_dashboard.Left;
            btn_dashboard.BackColor = Color.FromArgb(43, 51, 73);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel_nav.Height = button1.Height;
            panel_nav.Top = button1.Top;
            panel_nav.Left = button1.Left;
            button1.BackColor = Color.FromArgb(43, 51, 73);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel_nav.Height = button2.Height;
            panel_nav.Top = button2.Top;
            panel_nav.Left = button2.Left;
            button2.BackColor = Color.FromArgb(43, 51, 73);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel_nav.Height = button3.Height;
            panel_nav.Top = button3.Top;
            panel_nav.Left = button3.Left;
            button3.BackColor = Color.FromArgb(43, 51, 73);
        }

        private void btn_dashboard_Leave(object sender, EventArgs e)
        {
            btn_dashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button1_Leave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button2_Leave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button3_Leave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel_nav.Height = button4.Height;
            panel_nav.Top = button4.Top;
            panel_nav.Left = button4.Left;
            button4.BackColor = Color.FromArgb(43, 51, 73);
        }

        private void button4_Leave(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(24, 30, 54);
        }
    }
}
