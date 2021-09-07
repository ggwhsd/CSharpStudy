using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            trackBar1.Maximum = 100;
            trackBar1.Minimum = -100;
            timer1.Interval = 300;
            timer1.Enabled = true;
        }

       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            sevenSegment1.DecimalShow = radioButton1.Checked;
            sevenSegment1.DecimalOn = radioButton1.Checked;

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            sevenSegment1.ItalicFactor = trackBar1.Value / 100.0f;
        }
        private int i = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            sevenSegment1.Value = ((i++) % 10).ToString();
        }
    }
}
