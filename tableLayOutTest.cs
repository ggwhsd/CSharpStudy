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
    public partial class tableLayOutTest : Form
    {
        public tableLayOutTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            tableLayoutPanel1.SetRowSpan(button1, 2);
            tableLayoutPanel1.SetColumnSpan(label1, 2);
            label1.Anchor = AnchorStyles.Left |AnchorStyles.Right;
            label1.BackColor = Color.Yellow;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "隐藏")
            {
                tableLayoutPanel1.ColumnStyles[1].Width = 0;
                btn.Text = "显示";
                
            }
            else
            {
                tableLayoutPanel1.ColumnStyles[1].Width = 25F;
                btn.Text = "隐藏";
            }
        }
    }
}
