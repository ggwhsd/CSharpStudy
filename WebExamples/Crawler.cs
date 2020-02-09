using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace MarketRiskUI.WebExamples
{
    public partial class Crawler : Form
    {
        public Crawler()
        {
            InitializeComponent();
        }
        private WebClient webClient = new WebClient();
        private Hashtable urls = new Hashtable();
        private int count = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            
            

            urls.Add(url, false); //加入初始页面
            showmessage = new AddMessage(Showmsg);
            new Thread(new ThreadStart(Crawl)).Start(); //开始爬行

        }
        private delegate void AddMessage(string context);
        AddMessage showmessage;
        

        public void Showmsg(string context)
        {
            textBox2.Text += context;
        }

        public void updateLog(string c)
        {
            this.Invoke(showmessage, c);
        }
        private void Crawl()
        {
            updateLog("开始爬行了....");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys) //找到一个还没有下载过的链接
                {
                    if ((bool)urls[url]) continue; //已经下载过的，不再下载
                    current = url;
                }
                if (current == null || count > 10) break;

                updateLog("爬行" + current + "页面！");

                string html = DownLoad(current); //下载

                urls[current] = true;
                count++;

                Parse(html); //解析，并加入新的链接
            }
            updateLog("爬行结束");
        }

        public string DownLoad(string url)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Timeout = 30000;
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                byte[] buffer = ReadInstreamIntoMemory(response.GetResponseStream());
                string fileName = count.ToString();
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
                string html = Encoding.UTF8.GetString(buffer);
                return html;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            return "";
        }
        public void Parse(string html)
        {
            try
            {
                string strRef = @"(href|HREF|src|SRC)[ ]*=[ ]*[""'][^""'#>]+[""']";
                MatchCollection matches = new Regex(strRef).Matches(html);
                foreach (Match match in matches)
                {
                    strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\'', '#', ' ', '>');
                    if (strRef.Length == 0) continue;
                    if (strRef.IndexOf("http") != 0) continue;
                    if (urls[strRef] == null) urls[strRef] = false;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private static byte[] ReadInstreamIntoMemory(Stream stream)
        {
            int bufferSize = 16384;
            byte[] buffer = new byte[bufferSize];
            MemoryStream ms = new MemoryStream();
            while (true)
            {
                int numBytesRead = stream.Read(buffer, 0, bufferSize);
                if (numBytesRead <= 0) break;
                ms.Write(buffer, 0, numBytesRead);
            }
            return ms.ToArray();
        }
    }
}
