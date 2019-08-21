using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MarketRiskUI
{
    public partial class redisTest : Form
    {
        public redisTest()
        {
            InitializeComponent();
        }

        private RedisClient client;
        private void button_con_Click(object sender, EventArgs e)
        {
            if(client==null)
                client = new RedisClient(textBox_ip.Text.ToString(), Int32.Parse(textBox_port.Text.ToString()), textBox_passwd.Text.ToString());
            //client = new RedisClient("192.168.0.233", 6379, "foobared");
            
            client.Set<string>("username", "gugw");
            if (client.Exists("username")>0)
            {
                textBox1.Text += "has username!\r\n";
                textBox1.Text += client.Get<string>("username");
                
            }
 
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (client.HasConnected)
            {
                client.Quit();
                textBox1.Text += " disconnected";
                client = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (client !=null )
            {
                textBox1.Text += client.Get<string>(textBox_keys.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                client.Set<string>(textBox_keys.Text, textBox_value.Text);
                textBox1.Text += client.Get<string>(textBox_keys.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                DateTime start = DateTime.Now;
                int count = 1000;
                for(int i = 0; i < count; i++) {
                    //textBox1.Text += "\r\n" + i + " "+client.Get<string>(textBox_keys.Text);
                    client.Get<string>(textBox_keys.Text);
                }
                DateTime end = DateTime.Now;
                TimeSpan ts = end - start;
                textBox2.Text += DateTime.Now + " " + "test ReadManyTimes[" + count + "] timeSpan[" + ts.TotalMilliseconds +  "]milliseconds \r\n";
            }
        }
    }
}
