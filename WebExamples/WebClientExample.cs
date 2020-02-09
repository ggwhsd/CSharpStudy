using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace MarketRiskUI.WebExamples
{
    public partial class WebClientExample : Form
    {
        public WebClientExample()
        {
            InitializeComponent();
        }
        //WebClient是封装了的工具类，如果不追求太底层，可以直接使用这个。
        private void button1_Click(object sender, EventArgs e)
        {
            string url = @textBox_url.Text.ToString();
            WebClient client = new WebClient();
            byte[] pageData = client.DownloadData(url);
            string pageHtml = Encoding.Default.GetString(pageData);
            showData(pageHtml);
        }

        private void showData(string pageHtml)
        {
            textBox2.Text = pageHtml;
        }
    }
}
