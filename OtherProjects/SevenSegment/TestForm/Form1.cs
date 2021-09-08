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
            sevenSegmentArray1.SetDefaultStyleColor();
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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            sevenSegment1.CustomPattern = Decimal.ToInt32(numericUpDown1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            sevenSegmentArray1.ItalicFactor = trackBar2.Value / 100.0f;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sevenSegmentArray1.Value = textBox1.Text;
        }
    }
}
