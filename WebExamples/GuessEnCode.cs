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
using System.Windows.Forms;

namespace MarketRiskUI.WebExamples
{
    public partial class GuessEnCode : Form
    {
        public GuessEnCode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox_url.Text;
            string str = DownloadString(url);
        }

        private string DownloadString(string url)
        {
            string html = "";
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                Stream responseStream = response.GetResponseStream();
                Encoding encoding = GuessDownloadEncoding(response);
                if (encoding != null)
                {
                    lbl_encoding.Text = encoding.EncodingName;
                    StreamReader reader = new StreamReader(responseStream, encoding);
                    html = reader.ReadToEnd();
                    textBox2.Text = html;
                    reader.Close();
                }//读取header的content-Type属性中的charset
                else
                {
                    byte[] htmlByte = GetByteContent(responseStream);
                    html = Encoding.GetEncoding("utf-8").GetString(htmlByte);
                    string reg_charset = "(<meta[^>]*charset=(?<charset>[^>'\"]*)[\\s\\S]*?>)|(xml[^>]+encoding=(\"|')*(?<charset>[^>'\"]*)[\\s\\S]*?>)";
                    Regex r = new Regex(reg_charset, RegexOptions.IgnoreCase);
                    Match m = r.Match(html);
                    string encodingName = (m.Captures.Count != 0) ? m.Result("${charset}") : "";
                    lbl_encoding.Text = encodingName;
                    if (encodingName != "")
                    {
                        html = Encoding.GetEncoding(encodingName).GetString(htmlByte);
                        textBox2.Text = html;
                    }
                }//默认用etf-8码解读元数据中的charset
                responseStream.Close();
                response.Close();
            }
            catch (UriFormatException exception)
            {
                Console.WriteLine(exception.Message.ToString());
            }
            catch (WebException exception2)
            {
                Console.WriteLine(exception2.Message.ToString());
            }
            return html;
        }
        private static byte[] GetByteContent(Stream stream)
        {
            ArrayList arBuffer = new ArrayList();
            byte[] buffer = new byte[1024];
            int offset = 1024;
            int count = stream.Read(buffer, 0, offset);
            while (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    arBuffer.Add(buffer[i]);
                }
                count = stream.Read(buffer, 0, offset);
            }
            return (byte[])arBuffer.ToArray(typeof(byte));
        }

        private static Encoding GuessDownloadEncoding(HttpWebResponse response)
        {
            string charset = GetCharSet(response.ContentType);
            if (charset == "") charset = GetCharSet(response.Headers["Content-Type"]);
            try
            {
                if (charset != "") return Encoding.GetEncoding(charset);
            }
            catch { }
            return null;
        }

        private static string GetCharSet(string contentType)
        {
            Console.WriteLine("contentType:" + contentType);
            if (contentType == null || contentType == "") return "";
            string[] strArray = contentType.ToLower().Split(new char[] { ';', '=', ' ' });
            bool flag = false;
            foreach (string str2 in strArray)
            {
                if (str2 == "charset")
                {
                    flag = true;
                }
                else if (flag)
                {
                    return str2;
                }
            }
            return "";
        }
    }
}
