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
    public partial class SpliterTest : Form
    {
        
        public SpliterTest()
        {
            InitializeComponent();
        }
        private int origionWidth = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            origionWidth = splitContainer1.Panel1.Width;
            splitContainer1.SplitterDistance = button3.Width;
            splitContainer1.SplitterWidth = 1;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = origionWidth;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = splitContainer1.Width;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "<")
            {
                
                button1_Click(null, null);
                btn.Text = ">";
            }
            else
            {
                btn.Text = "<";
                button4_Click(null, null);
            }

        }
    }
}
