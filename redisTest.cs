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
using System.Threading.Tasks;

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
                int count = 7000;
                string key = textBox_keys.Text;

                for (int i = 0; i < count; i++) {
                    //textBox1.Text += "\r\n" + i + " "+client.Get<string>(textBox_keys.Text);
                    client.Get<string>(key);
                    
                }
                DateTime end = DateTime.Now;
                TimeSpan ts = end - start;
                textBox2.Text += DateTime.Now + " " + "test ReadManyTimes[" + count + "] timeSpan[" + ts.TotalMilliseconds +  "]milliseconds \r\n";
                Console.WriteLine(textBox2.Text);
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            List<RedisClient> clients = new List<RedisClient>();
            int arrLen = 9;
            for (int index = 0; index < arrLen; index++)
            {
                clients.Add(new RedisClient(textBox_ip.Text.ToString(), Int32.Parse(textBox_port.Text.ToString()), textBox_passwd.Text.ToString()));
                
            }

            DateTime start = DateTime.Now;
            int count = 7000;
            ParallelLoopResult result =

                  System.Threading.Tasks.Parallel.For(0, (count / 1000 - 1), (int ii) =>

                  {
                      Console.WriteLine("迭代次数：{0},任务ID:{1},线程ID:{2},参数{3}", ii, Task.CurrentId, Thread.CurrentThread.ManagedThreadId, ii);
                      string key = textBox_keys.Text;

                      for (int i1 = ii*1000; i1 < ii*1000+1000; i1++)
                      {
                          //textBox1.Text += "\r\n" + i + " "+client.Get<string>(textBox_keys.Text);
                          clients[ii].Get<string>(key);

                      }


                  });
            DateTime end = DateTime.Now;
            TimeSpan ts = end - start;
            textBox2.Text += DateTime.Now + " " + "test ReadManyTimes[" + count + "] timeSpan[" + ts.TotalMilliseconds + "]milliseconds \r\n";

            int i = 0;
            while (result.IsCompleted == false)
            {
                await Task.Delay(1000);
                i++;
                Console.WriteLine("继续等待。"+" "+i+"秒");
            }

            foreach (RedisClient rc in clients)
            {
                rc.Quit();
            }
            

        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> values = new Dictionary<string, string>() {  };
            values.Add("string:name1", "p1");
            values.Add("string:name2", "p2");
            values.Add("string:name3", "p3");
            //一次写入多个value
            client.SetAll(values);
            //附加一个值
            client.AppendToValue("string:name1", "-firstone");
            List<string> keys = new List<string>();
            keys = values.Keys.ToList();
            //一次获取多个values
            List<string> keyValues = client.GetValues(keys);
            foreach (string v in keyValues)
            {
                textBox1.Text += "\r\n" + v;
            }
            //获取旧的value同时设置新的，get和set的组合
            textBox1.Text += "\r\n"+client.GetAndSetValue("string:name2", "p2 is new " + DateTime.Now.ToLongTimeString());


        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (client.ContainsKey("Increment") == true)
            {

                textBox1.Text += " "+client.IncrementValue("Increment");
            }
            else
            {
                client.Set("Increment",1);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (client.ContainsKey("Increment") == true)
            {

                textBox1.Text += " " + client.DecrementValue("Increment");
            }
            else
            {
                client.Set("Increment", 1);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //right push，语义是栈的压栈操作
            client.PushItemToList("list:name", "p1");
            client.PushItemToList("list:name", "p2");
            //设置列表的超时
            client.ExpireEntryAt("list:name", DateTime.Now.AddMinutes(1));

        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "\r\n"+client.GetListCount("list:name");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //left push
            client.PrependItemToList("list:name", "p3");
            client.PrependItemToList("list:name", "p4");
            //设置列表的超时
            client.ExpireEntryAt("list:name", DateTime.Now.AddMinutes(1));
        }

        private void button12_Click(object sender, EventArgs e)
        {
            client.AddItemToList("list:name", "p5");

            client.AddRangeToList("list:name", new List<string> { "p6", "p7" });
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //lpush，是在左边，即表头前插入数据，所以插入最晚的数据，在第一个位置
            StringBuilder sbr = new StringBuilder();
            sbr.Append("\r\n");
            
            List<string> results = client.GetAllItemsFromList("list:name");
            foreach (string item in results)
            {
                sbr.Append(item).Append(" ");
            }
            textBox1.Text += "\r\n" + sbr.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            StringBuilder sbr = new StringBuilder();
            sbr.Append("\r\n");
            foreach (string item in client.GetRangeFromList("list:name",2,-1))
            {
                sbr.Append(item).Append(" ");
            }
            textBox1.Text += "\r\n" + sbr.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //列表最右边一个元素移除并返回。 语义：栈概念上的弹出含义
            textBox1.Text += "\r\n "+ client.PopItemFromList("list:name");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //列表最右边一个元素移除并返回
            textBox1.Text += "\r\n " + client.RemoveStartFromList("list:name");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //移除列表最右边的一个元素，若不存在，则阻塞等待1秒，若1秒时间之后仍然不存在，返回空。
            //语义：栈概念上的弹出含义
            textBox1.Text += "\r\n " + client.BlockingPopItemFromList("list:name",TimeSpan.FromSeconds(1));
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //语义：入队.  在列表的最左边添加
            client.EnqueueItemOnList("list:name",DateTime.Now.ToLongTimeString());
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //语义：出队. 在列表的最右边出去
            textBox1.Text += "\r\n " + client.DequeueItemFromList("list:name");
        }
    }
}
