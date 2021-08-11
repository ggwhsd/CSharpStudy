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

        private void button21_Click(object sender, EventArgs e)
        {
            client.AddItemToSet("set:name", DateTime.Now.ToLongTimeString());
            client.AddItemToSet("set:name", "set1");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            StringBuilder sbr = new StringBuilder();
            textBox1.Text += "\r\n" + client.GetSetCount("set:name");
            foreach (string p in client.GetAllItemsFromSet("set:name"))
            {
                sbr.Append(p).Append(" ");
            }
            textBox1.Text += "\r\n" + sbr.ToString();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            client.PopItemFromSet("set:name");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox1.Text="\r\n"+client.GetRandomItemFromSet("set:name");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            client.RemoveItemFromSet("set:name","set1");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            client.MoveBetweenSets("set:name", "set2:name","set1");

            StringBuilder sbr = new StringBuilder();

            foreach (string p in client.GetAllItemsFromSet("set2:name"))
            {
                sbr.Append(p).Append(" ");
            }
            textBox1.Text += "\r\n" + sbr.ToString();

            //client.StoreUnionFromSets 并集合放到新的集合中。
            //client.StoreDifferencesFromSet 将不同的数据放到新的集合中。
        }

        private void button27_Click(object sender, EventArgs e)
        {
            client.AddItemToSortedSet("sortset:name", "ssn1", 1);
            client.AddItemToSortedSet("sortset:name", "ssn2", 3);
            client.AddItemToSortedSet("sortset:name", "ssn3", 2);
            client.AddRangeToSet("sortset:name", new List<string> { "ssn4","ssn5"});

        }

        private void button29_Click(object sender, EventArgs e)
        {

            StringBuilder sbr = new StringBuilder();
            foreach (var value in client.GetAllItemsFromSortedSet("sortset:name"))
            {
                sbr.Append(value).Append(" ");
            }
            textBox1.Text +="\r\n"+ sbr.ToString();

            sbr.Clear();
            foreach (var value in client.GetAllItemsFromSortedSetDesc("sortset:name"))
            {
                sbr.Append(value).Append(" ");
            }
            textBox1.Text += "\r\n" + sbr.ToString();
            sbr.Clear();
            foreach (var value in client.GetAllWithScoresFromSortedSet("sortset:name"))
            {
                sbr.Append(value.Key).Append("-" + value.ToString()).Append(" ");
            }
            textBox1.Text += "\r\n" + sbr.ToString();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            client.RemoveItemFromSortedSet("sortset:name", "ssn2");
        }

        private void button31_Click(object sender, EventArgs e)
        {
            textBox1.Text +="\r\n"+ client.GetItemIndexInSortedSet("sortset:name", "ssn4");
        }

        private void button33_Click(object sender, EventArgs e)
        {
            StringBuilder sbr = new StringBuilder();
            //GetRangeWithScoresFromSortedSetByHighestScore
            foreach (var value in client.GetRangeFromSortedSetByHighestScore("sortset:name",1,10))
            {
                sbr.Append(value).Append(" ");
            }
            textBox1.Text += "\r\n" + sbr.ToString();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            StringBuilder sbr = new StringBuilder();
            //GetRangeWithScoresFromSortedSetByLowestScore
            foreach (var value in client.GetRangeFromSortedSetByLowestScore("sortset:name", 1, 10))
            {
                sbr.Append(value).Append(" ");
            }
            textBox1.Text += "\r\n" + sbr.ToString();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            StringBuilder sbr = new StringBuilder();
          
            foreach (var value in client.GetRangeFromSortedSet("sortset:name", 1, 10))
            {
                sbr.Append(value).Append(" ");
            }
            textBox1.Text += "\r\n" + sbr.ToString();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            //按照排名删除
            client.RemoveRangeFromSortedSet("sortset:name", 1, 2);
            //按分数删除 RemoveRangeFromSortedSetByScore
            //删除分数最大的 PopItemWithHighestScoreFromSortedSet
            //删除分数最小的 PopItemWithLowestScoreFromSortedSet
            
        }

        private void button32_Click(object sender, EventArgs e)
        {
            client.SortedSetContainsItem("sortset:name", "ssn4");
        }

        private void button36_Click(object sender, EventArgs e)
        {
            //某个元素增加分数   client.IncrementItemInSortedSet(key, value, scoreBy);
            //将多个keys合并到newkey中 交集  StoreIntersectFromSortedSets(newkey,keys);
            //将多个keys合并到newkey中  并集 StoreUnionFromSortedSets(newkey, keys);

        }

        private void button37_Click(object sender, EventArgs e)
        {
            client.SetEntryInHash("hash:name", "h1", "h1name");
            client.SetEntryInHash("hash:name", "h2", "h1name");
            client.SetEntryInHash("hash:name", "h3", "h1name");
            client.SetEntryInHashIfNotExists("hash:name", "h3", "h1name");
        }

    

        private void button38_Click(object sender, EventArgs e)
        {
            var rtn = client.GetAllEntriesFromHash("hash:name");
            //GetHashKeys(hashid);
            //GetHashValues(hashid);
            foreach (KeyValuePair<string, string> entry in rtn)
            {
                textBox1.Text += "\r\n" + entry.Key + "-" + entry.Value;
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            client.RemoveEntryFromHash("hash:name", "h1");
            
        }

        private void button42_Click(object sender, EventArgs e)
        {
            textBox1.Text +="\r\n"+ client.GetValueFromHash("hash:name", "h1");
            //GetValuesFromHash(hashid, keys);获取多个key对应的多个value
        }

        private void button43_Click(object sender, EventArgs e)
        {
            client.Remove("hash:name");
        }

        private void button44_Click(object sender, EventArgs e)
        {
            textBox1.Text += "\r\n"+ client.HashContainsEntry("hash:name", "h1").ToString();
            //IncrementValueInHash(hashid, key, countBy);  对hashid中某个key进行增
        }

        private void button40_Click(object sender, EventArgs e)
        {
            client.FlushAll();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            using (var trans = client.CreateTransaction())
            {
                try
                {
                    
                    trans.QueueCommand(p =>
                    {
                        client.Set<int>("name", 123);
                        long value = client.IncrementValueBy("name", 3);

                    });
                    trans.Commit();
                }
                catch(Exception err)
                {
                    
                    
                }
            }

        }

        private void button45_Click(object sender, EventArgs e)
        {
            client.Set("lock", 1);
            using (client.AcquireLock("lock"))
            {
                client.Set("lock", 2);

            }
            textBox1.Text = client.Get<int>("lock").ToString();


        }
        IRedisSubscription subscription = null;
        public void Sub()
        {
            if (redisClientManager == null)
            {
                redisClientManager = new PooledRedisClientManager(textBox_passwd.Text + "@" + textBox_ip.Text.ToString() + ":" + textBox_port.Text.ToString());
            }
            subscription = redisClientManager.GetClient().CreateSubscription();
            subscription.OnMessage = (channel, msg) =>
            {
                Console.WriteLine($"从频道：{channel}上接受到消息：{msg},时间：{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}");
                Console.WriteLine($"频道订阅数目：{subscription.SubscriptionCount}");
            };
            subscription.OnSubscribe = (channel) =>
            {
                Console.WriteLine("订阅客户端：开始订阅" + channel);
                
            };
            subscription.OnUnSubscribe = (a) => { Console.WriteLine("订阅客户端：取消订阅"); subscription.Dispose(); };
            subscription.SubscribeToChannels("channel1");
           
        }
        private Thread t = null;
        private void button46_Click(object sender, EventArgs e)
        {
            t = new Thread(new ThreadStart(Sub));
            t.IsBackground = true;
            t.Start();
        }
        IRedisClientsManager redisClientManager = null;
        RedisPubSubServer pubSubServer = null;
        //发布直接用client.PublishMessage即可发布消息，但是如下方式可以起到监听发布者的功能
        private void button47_Click(object sender, EventArgs e)
        {
            redisClientManager = new PooledRedisClientManager(textBox_passwd.Text +"@"+ textBox_ip.Text.ToString()+":"+textBox_port.Text.ToString());
            
            pubSubServer = new RedisPubSubServer(redisClientManager, "channel1")
            {
                OnMessage = (channel, msg) =>
                {
                    Console.WriteLine($"pubServer {channel} 发布服务发布消息 {msg}");
                },
                OnStart = () =>
                {
                    Console.WriteLine($"pubServer 发布服务start ");
                },
                OnStop = () => { Console.WriteLine("pubServer 发布服务停止"); },
                OnUnSubscribe = (channel) => { Console.WriteLine("pubServer 取消订阅 "+channel); },
                OnError = (err) => { Console.WriteLine("pubServer " + err.Message); },
                OnFailover = (s) => { Console.WriteLine("pubServer " + s); }
            };
            pubSubServer.Start();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            client.PublishMessage("channel1", "消息时间【"+DateTime.Now.ToString()+"】");
            
        }

        private void button49_Click(object sender, EventArgs e)
        {
            pubSubServer.Stop();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            //订阅者的订阅和取消订阅都是blocking方法
            new Thread(()=> { subscription.UnSubscribeFromChannels("channel1"); }).Start();
        }
    }

 
}
