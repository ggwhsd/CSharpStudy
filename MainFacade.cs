using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MarketRiskUI.LittleExamples;

namespace MarketRiskUI
{
    public partial class MainFacade : Form
    {
        public MainFacade()
        {
            InitializeComponent();
        }

        private void 屏幕保护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenProtectExample sce = new ScreenProtectExample();
            sce.Show();
        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 historyMain = new Form1();
            historyMain.Show();
        }
    }
}
