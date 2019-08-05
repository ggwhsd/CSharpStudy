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
    }
}
