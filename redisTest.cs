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
            client = new RedisClient(textBox_ip.Text.ToString(), Int32.Parse(textBox_port.Text.ToString()), textBox_passwd.Text.ToString());
            //client = new RedisClient("192.168.0.233", 6379, "foobared");

            client.Set<string>("username", "gugw");
            if (client.Exists("username")>0)
            {
                textBox1.Text += "has username!\r\n";
                textBox1.Text += client.Get<string>("username");
                
            }
 
           
        }
    }
}
