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
    public partial class PanelTest : Form
    {
        public PanelTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            panel1.Location = new Point(panel1.Location.X + 100, panel1.Location.Y + 100);
        }
    }
}
