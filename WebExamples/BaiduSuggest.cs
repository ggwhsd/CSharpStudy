using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarketRiskUI.WebExamples
{
    public partial class BaiduSuggest : Form
    {
        public BaiduSuggest()
        {
            InitializeComponent();
        }
        public  Random rand = new Random();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = this.textBox1.Text;
            string[] words = text.Split("', \"".ToCharArray());
            string word = words[words.Length - 1];//最后一个单词
                                                  //也可以这样:
                                                  //word = System.Text.RegularExpressions.Regex.Replace( text, @"(^|.*\W)(\w+)$",  "$2"); 
            string sug = GetBaiduSuggestion(word); //得到Suggestion
            if (sug == null || sug == "") return;

            this.listBox1.Items.Clear();
            string[] ary = sug.Split(',');
            for (int i = 0; i < ary.Length; i++) //填充列表
            {
                this.listBox1.Items.Add(ary[i].Replace("'", "").Replace("\"", ""));
            }
        }
        public string GetBaiduSuggestion(string wd)
        {
            string url = "http://suggestion.baidu.com/su?wd=" + myUrlEncode(wd);
            url += "&rnd=" + rand.Next();
            string suggestion = DownloadString(url);
            //"window.baidu.sug({q:'人们',p:false,s:['人们简称它为','人们网','人们教育出版社','人们通常选择对显卡的哪个部分进行超频','人们最先用什么动物进行宇宙飞行实验的','人们把那些买进股票 期待涨价后售出的行为称作','人们称哪届奥运会是跑表 皮尺时代的结束.','人们在收拾鱼身时涂下列哪种东西可防滑','人们日报','人们的梦']});"
            string sug = System.Text.RegularExpressions.Regex.Replace(suggestion, @".*,s:\[([^\]]*)\].*", "$1");
            return sug;

        }
        //url中的编码，使用自己写的方法
        private string myUrlEncode(string wd)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(wd);
            string res = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                res += "%" + bytes[i].ToString("X2");
            }
            return res;
        }
        //url中的编码，使用类库提供的方法
        public string encodeURIComponent(string wd)
        {
            return System.Web.HttpUtility.UrlEncode(wd, Encoding.UTF8).ToUpper();
        }
        public string DownloadString(string url)
        {
            System.Net.WebClient webclient = new System.Net.WebClient();
            webclient.Credentials = new System.Net.CredentialCache();
            webclient.Headers["Cookie"] = "BDUSS=FkcmZZckFNN1h3V0JxdDN4aWFVWmI0bDVwakpzYn5BZn5ZQ25KQkxOVGtvQlpOQVFBQUFBJCQAAAAAAAAAAApRLgtnzNkJZHN0YW5nMjAwMAAAAAAAAAAAAAAAAAAAAAAAAAAAAADAymRxAAAAAMDKZHEAAAAAuFNCAAAAAAAxMC4yMy4yNOQT70zkE";

            byte[] data = webclient.DownloadData(url);
            return System.Text.Encoding.Default.GetString(data);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex < 0) return;

            string text = this.textBox1.Text;
            string[] words = text.Split("', \"".ToCharArray());
            string word = words[words.Length - 1];
            int idx = text.LastIndexOf(word);

            string sug = this.listBox1.SelectedItem.ToString();

            this.textBox1.Text = text.Substring(0, idx) + sug;

            this.textBox1.Focus();
            this.textBox1.SelectionStart = this.textBox1.Text.Length;
        }
    }
}
