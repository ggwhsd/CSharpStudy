using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using FoxMMManagerServer.DBEntitys;
using Newtonsoft.Json;
using System.IO;

namespace HttpClientTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private HttpClient requestClient;
        private HttpClient RequestClient { get { return requestClient; } } 

        private async void button2_Click(object sender, EventArgs e)
        {
            
            string urlRequest = textBox1.Text;
            requestClient = new HttpClient();
            requestClient.BaseAddress = new Uri(urlRequest);
            var response = await requestClient.GetAsync(textBox2.Text);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                richTextBox1.SelectionColor = Color.Blue;
                richTextBox1.SelectedText = "hello连接成功\r\n";
            }
            else
            {
                richTextBox1.SelectionColor = Color.Red;
                richTextBox1.SelectedText = "hello连接失败\r\n";

            }
            richTextBox1.SelectedText = Encoding.Default.EncodingName;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            textBox3.Visible = false;
            var response = await requestClient.GetAsync(textBox2.Text);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                richTextBox1.SelectionColor = Color.Blue;
                richTextBox1.SelectedText = "api请求处理成功\r\n";
                // string msg = await response.Content.ReadAsStringAsync();
                Stream stream = await response.Content.ReadAsStreamAsync();
                StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
                string msg = sr.ReadToEnd();
                richTextBox1.SelectedText = "header content-type: "+ response.Content.Headers.ContentType + "\r\n";
                richTextBox1.SelectedText = msg + "\r\n";
            }
            else
            {
                richTextBox1.SelectionColor = Color.Red;
                richTextBox1.SelectedText = "api请求处理失败\r\n";
                string msg = await response.Content.ReadAsStringAsync();
                richTextBox1.SelectedText = msg + "\r\n";
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = comboBox1.Text;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var response = await requestClient.GetAsync(textBox2.Text);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                richTextBox1.SelectionColor = Color.Blue;
                richTextBox1.SelectedText = "api请求处理成功\r\n";
                string msg = await response.Content.ReadAsStringAsync();
                richTextBox1.SelectedText = "header content-type: " + response.Content.Headers.ContentType + "\r\n";
                richTextBox1.SelectedText = msg + "\r\n";
                // List<Dictionary<string,string>> resutls=Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(msg);
               //Object value= Newtonsoft.Json.JsonConvert.DeserializeObject(msg);
               List<Instrument> results = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Instrument>>(msg);
            }
            else
            {
                richTextBox1.SelectionColor = Color.Red;
                richTextBox1.SelectedText = "api请求处理失败\r\n";
                string msg = await response.Content.ReadAsStringAsync();
                richTextBox1.SelectedText = msg + "\r\n";
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Visible == true)
            {
                requestClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0");
                requestClient.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                requestClient.DefaultRequestHeaders.Add("Keep-Alive", "timeout=600");

                
                var json = textBox3.Text;
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                
                var response = await requestClient.PostAsync(textBox2.Text, data);

                richTextBox1.SelectedText = response.Content.Headers.ContentType.CharSet;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    richTextBox1.SelectionColor = Color.Blue;
                    richTextBox1.SelectedText = "api请求处理成功\r\n";
                    
                   // string msg = await response.Content.ReadAsStringAsync();
                     Stream stream =await response.Content.ReadAsStreamAsync();
                    StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
                    string msg = sr.ReadToEnd();
                    richTextBox1.SelectedText = "header content-type: " + response.Content.Headers.ContentType + "\r\n";
                    richTextBox1.SelectedText = msg + "\r\n";
                  
                   
                }
                else
                {
                    richTextBox1.SelectionColor = Color.Red;
                    richTextBox1.SelectedText = "api请求处理失败\r\n";
                    string msg = await response.Content.ReadAsStringAsync();
                    richTextBox1.SelectedText = msg + "\r\n";
                }
            }
            else
            {
                
            }
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Visible = true;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
           
        }
    }
}
