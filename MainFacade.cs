using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MarketRiskUI.LittleExamples;
using MarketRiskUI.WebExamples;

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

        private void 素数计算使用bool方式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrimeFilter pf = new PrimeFilter();
            pf.Show();
        }

        private void 排块游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridGame gg = new GridGame();
            gg.Show();
        }

        private void 常用工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils tools = new Utils();
            tools.Show();
        }

        private void 复制文件删除注释ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOStudy copyFile = new IOStudy();
            copyFile.StreamInFileStream("./AttributeExample.cs", "./AttributeExample.txt");
        }

        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalcExample cal = new CalcExample();
            cal.Show();
        }

        private void gDIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI gdi = new GDI();
            gdi.Show();
        }

        private void webClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebClientExample wce = new WebClientExample();
            wce.Show();
        }

        private void webRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebRequestAndResponse req = new WebRequestAndResponse();
            req.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GuessEnCode ge = new GuessEnCode();
            ge.Show();
        }

        private void getGoldPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetGoldPrice gold = new GetGoldPrice();
            gold.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Crawler cl = new Crawler();
            cl.Show();
        }
    }
}
