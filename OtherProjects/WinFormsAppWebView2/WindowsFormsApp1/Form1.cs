using Microsoft.Web.WebView2.Core;
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

        private void webView_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            //在页面开始前注入脚本并执行
            String uri = e.Uri;
            if (!uri.StartsWith("https://"))
            {
                //立即执行脚本
                webView.CoreWebView2.ExecuteScriptAsync($"alert('{uri} is not safe, try an https link')");
                e.Cancel = true;
            }
            
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            //主机从webview中接收数据
            webView.CoreWebView2.WebMessageReceived += UpdateAddressBar;

            //如下需要通过刷新页面或者重新导航到页面才能触发调用。
            //webview从主机中接收数据
            //注入脚本，在DocumentCreated时候调用
            await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.addEventListener(\'message\', event => { alert(event.data);  console.log(event.data) }  );");

            //从webview发送数据给主机
            //注入脚本，在DocumentCreated时候调用
            await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.postMessage(window.document.URL);");
        }

        void UpdateAddressBar(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            //读取数据
            String uri = args.TryGetWebMessageAsString();
            addressBar.Text = uri;
            //从主机发送数据给webview
            webView.CoreWebView2.PostWebMessageAsString(uri);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        
        }
    }
}
