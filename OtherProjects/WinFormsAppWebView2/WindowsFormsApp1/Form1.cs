using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {



        public Form1()
        {
           
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            webView.Size = this.ClientSize - new System.Drawing.Size(webView.Location);
            goButton.Left = this.ClientSize.Width - goButton.Width;
            addressBar.Width = goButton.Left - addressBar.Left;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.Navigate(addressBar.Text);
            }
            else
            {
                MessageBox.Show("需要安装WebViews，稳定版本的Edge不支持WebViews，只有开发版本或者单独的webviews runtime、嵌入Edge chromium内核这三者之一支持" +
               " 到该网站下载即可 https://developer.microsoft.com/zh-cn/microsoft-edge/webview2/");
            }
        }
    }
}
