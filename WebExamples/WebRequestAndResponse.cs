using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace MarketRiskUI.WebExamples
{
    public partial class WebRequestAndResponse : Form
    {
        public WebRequestAndResponse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = DownloadString(textBox_url.Text);
            textBox2.Text = str;
        }

        private string DownloadString(string text)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(text) as HttpWebRequest;
                request.Credentials = CredentialCache.DefaultCredentials; ;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                Stream responseStream = response.GetResponseStream();
                Encoding encoding = Encoding.UTF8;
                StreamReader reader = new StreamReader(responseStream, encoding);
                string str = reader.ReadToEnd();
                reader.Close();
                responseStream.Close();
                response.Close();
                return str;
            }
            catch (UriFormatException exception)
            {
                Console.WriteLine(exception.Message.ToString());
                Console.WriteLine("Invalid URL format. ");
            }
            catch (WebException exception2)
            {
                Console.WriteLine(exception2.Message.ToString());
            }
            return "";
        }
    }
}
