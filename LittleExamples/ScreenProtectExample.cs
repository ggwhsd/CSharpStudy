using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarketRiskUI.LittleExamples
{
    public partial class ScreenProtectExample : Form
    {
        public ScreenProtectExample()
        {
            InitializeComponent();
        }
        int deltaX = 10;
        int deltaY = 8;

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.textBox1.Left += deltaX;
            this.textBox1.Top += deltaY;
            if (this.textBox1.Top < 0 ||
                textBox1.Top + this.textBox1.Height > this.Height)
            {
                deltaY = -deltaY;
            }
            if (this.textBox1.Left < 0 ||
                this.textBox1.Left + this.textBox1.Width > this.Width)
            {
                deltaX = -deltaX;
            }
        }

        private void ScreenProtectExample_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.textBox1.Text.CompareTo("你真帅") == 0)
            {
                timer1.Stop();
                this.WindowState = FormWindowState.Normal;
                this.Close();
            }
             
        }
    }
}
