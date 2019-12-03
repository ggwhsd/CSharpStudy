using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Apache.NMS;
using Apache.NMS.Util;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using Newtonsoft.Json;

namespace MarketRiskUI
{


    public partial class ActiveMQ_TOPIC : Form
    {
        public ActiveMQ_TOPIC()
        {
            InitializeComponent();
        }

        private void textBox_Monitor_TextChanged(object sender, EventArgs e)
        {

        }
        private Producer producer;

        private void button1_Click(object sender, EventArgs e)
        {

            if (producer != null)
            {
                producer.Init();
                producer.SetTopic();
                producer.CreateProducer();
            }
            else
            {
                producer = new Producer();
                producer.Init();
                producer.SetTopic();
                producer.CreateProducer();
                
            }
        }

        private Consumer[] consumers=new Consumer[100];
        private void button2_Click(object sender, EventArgs e)
        {
            int i = int.Parse(textBox3.Text);
            for (int index = 0; index < i; index++)
            {
                Consumer consumer = consumers[index];
                
                if (consumer!= null)
                {
                    if (textBox_selector.Text.ToString() != "")
                    {
                        consumer.Selector = textBox_selector.Text.ToString();
                    }
                    consumer.Init();
                    consumer.SetTopic();
                    consumer.CreateConsumer();
                }
                else
                {
                   
                    consumer = new Consumer();
                    if (textBox_selector.Text.ToString() != "")
                    {
                        consumer.Selector = textBox_selector.Text.ToString();
                    }
                    consumers[index] = consumer;
                    consumer.Init();
                    consumer.SetTopic();
                    consumer.CreateConsumer();
                }
            }



        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            AdvisoryExample ex = new AdvisoryExample();
            ex.EnumerateQueues();
            ex.EnumerateTopics();
            ex.EnumerateDestinations();
            ex.ShutDown();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            int i = int.Parse(textBox3.Text);
            for (int index = 0; index < i; index++)
            {
                Consumer consumer = consumers[index];
                if (consumer != null)
                {
                    consumer.Close();
                }
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            producer.Close();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "发送耗时"+producer.SendMsg(textBox_send.Text.ToString(),int.Parse(textBox2.Text))+"秒";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            int i = int.Parse(textBox3.Text);
            for (int index = 0; index < i; index++)
            {
                Consumer consumer = consumers[index];
                if (consumer != null)
                {
                    consumer.cleanStart();
                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "发送耗时" + producer.SendSelectorMsg(textBox_send.Text.ToString(), int.Parse(textBox2.Text)) + "秒";

        }
    }
    public class topicCfg 
        {
            public static string topicStr = "Test";
            public static string url = "tcp://localhost:61616/";
            public static string user = "admin";
            public static string passwd = "admin";
        };
    public class CustomData
    {
        public int nameCode { get; set; }
        public string desc { get; set; }
    }
    class Producer
    {
        private IConnection connection;
        private ISession session;
        private IDestination dest;
        private IMessageProducer prod;
        public Producer()
        {
            
            
           
        }
        public void Init()
        {
            IConnectionFactory factory = new ConnectionFactory(topicCfg.url);
            if (connection == null)
            {
                connection = factory.CreateConnection(topicCfg.user, topicCfg.passwd);
                connection.Start();
                session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
            }
        }
        public void SetTopic()
        {
            dest = session.GetTopic(topicCfg.topicStr);
        }
        public void CreateProducer()
        {
            
            prod = session.CreateProducer(dest);
            
        }
        public double SendSelectorMsg(string content, int count)
        {
            //定义topic名
            CustomData message = new CustomData();
            message.desc = content;
            message.nameCode = 9527;
            string str = JsonConvert.SerializeObject(message);
            byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            // IMessage msg = prod.CreateBytesMessage(bytes);
            TimeSpan ts = new TimeSpan();
            DateTime start = DateTime.Now;

            for (int i = 0; i < count; i++)
            {
                IMessage msg = prod.CreateTextMessage(str);
                msg.Properties.SetString("filter","demo");  //设置selector
                msg.Properties.SetDouble("double", 1.11);
                prod.Send(msg, MsgDeliveryMode.NonPersistent, MsgPriority.Normal, TimeSpan.MinValue);

            }
            DateTime end = DateTime.Now;
            ts = end - start;
            return ts.TotalSeconds;
        }
        public double SendMsg(string content,int count)
        {
            //定义topic名
            CustomData message = new CustomData();
            message.desc = content;
            message.nameCode = 9527;
            string str = JsonConvert.SerializeObject(message);
            byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            // IMessage msg = prod.CreateBytesMessage(bytes);
            TimeSpan ts = new TimeSpan();
            DateTime start = DateTime.Now;
           
            for (int i = 0; i < count; i++)
            {
                IMessage msg = prod.CreateTextMessage(str);
                prod.Send(msg, MsgDeliveryMode.NonPersistent, MsgPriority.Normal, TimeSpan.MinValue);

            }
            DateTime end = DateTime.Now;
            ts = end - start;
            return ts.TotalSeconds;
        }
        public void Close()
        {
            if (connection != null)
            {
                session.Close();
                
                connection.Close();
                connection = null;
            }
        }

    }
    class Consumer
    {
        private IConnection connection;
        private ISession session;
        private IDestination dest;
        private IMessageConsumer cons;
        private string selector=null;
        public Consumer()
        {



        }
        public void Init()
        {
            IConnectionFactory factory = new ConnectionFactory(topicCfg.url);
            if (connection == null)
            {
                connection = factory.CreateConnection(topicCfg.user, topicCfg.passwd);
                connection.Start();
                session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
            }
        }
        public void SetTopic()
        {
            dest = session.GetTopic(topicCfg.topicStr);
        }
       
        public void CreateConsumer()
        {
            // cons = session.CreateConsumer(dest);
            cons = session.CreateDurableConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic(topicCfg.topicStr),"customer", selector, false);
            
            cons.Listener += new MessageListener(consumer_Listener);

        }
        private DateTime start;
        private DateTime end;
        private bool isStart=false;
        private TimeSpan ts;

        public string Selector { get => selector; set => selector = value; }

        public void cleanStart()
        {
            isStart = false;
        }
        void consumer_Listener(IMessage message)
        {

            if (isStart == false)
            {
                start = DateTime.Now;
                isStart = true;
            }
            try
            {
                ITextMessage msg = (ITextMessage)message;
               
                end = DateTime.Now;
                ts = end - start;
                Console.WriteLine("Receive: " + msg.Text + " span "+ ts.TotalSeconds);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public void Close()
        {
            if (connection != null)
            {
                cons.Close();
                session.Close();

                connection.Close();
                connection = null;
                
            }
        }

    }
    class AdvisoryExample
    {
        private IConnection connection;
        private ISession session;

        public const String QUEUE_ADVISORY_DESTINATION = "ActiveMQ.Advisory.Queue";
        public const String TOPIC_ADVISORY_DESTINATION = "ActiveMQ.Advisory.Topic";
        public const String TEMPQUEUE_ADVISORY_DESTINATION = "ActiveMQ.Advisory.TempQueue";
        public const String TEMPTOPIC_ADVISORY_DESTINATION = "ActiveMQ.Advisory.TempTopic";

        public const String ALLDEST_ADVISORY_DESTINATION = QUEUE_ADVISORY_DESTINATION + "," +
                                                           TOPIC_ADVISORY_DESTINATION + "," +
                                                           TEMPQUEUE_ADVISORY_DESTINATION + "," +
                                                           TEMPTOPIC_ADVISORY_DESTINATION;

        public AdvisoryExample()
        {
            IConnectionFactory factory = new ConnectionFactory();

            connection = factory.CreateConnection();
            connection.Start();
            session = connection.CreateSession();
        }

        public void EnumerateQueues()
        {
            Console.WriteLine("Listing all Queues on Broker:");

            IDestination dest = session.GetTopic(QUEUE_ADVISORY_DESTINATION);

            using (IMessageConsumer consumer = session.CreateConsumer(dest))
            {
                IMessage advisory;

                while ((advisory = consumer.Receive(TimeSpan.FromMilliseconds(2000))) != null)
                {
                    ActiveMQMessage amqMsg = advisory as ActiveMQMessage;

                    if (amqMsg.DataStructure != null)
                    {
                        DestinationInfo info = amqMsg.DataStructure as DestinationInfo;
                        if (info != null)
                        {
                            Console.WriteLine("   Queue: " + info.Destination.ToString());
                        }
                    }
                }
            }
            Console.WriteLine("Listing Complete.");
        }

        public void EnumerateTopics()
        {
            Console.WriteLine("Listing all Topics on Broker:");

            IDestination dest = session.GetTopic(TOPIC_ADVISORY_DESTINATION);

            using (IMessageConsumer consumer = session.CreateConsumer(dest))
            {
                IMessage advisory;

                while ((advisory = consumer.Receive(TimeSpan.FromMilliseconds(2000))) != null)
                {
                    ActiveMQMessage amqMsg = advisory as ActiveMQMessage;

                    if (amqMsg.DataStructure != null)
                    {
                        DestinationInfo info = amqMsg.DataStructure as DestinationInfo;
                        if (info != null)
                        {
                            Console.WriteLine("   Topic: " + info.Destination.ToString());
                        }
                    }
                }
            }
            Console.WriteLine("Listing Complete.");
        }

        public void EnumerateDestinations()
        {
            Console.WriteLine("Listing all Destinations on Broker:");

            IDestination dest = session.GetTopic(ALLDEST_ADVISORY_DESTINATION);

            using (IMessageConsumer consumer = session.CreateConsumer(dest))
            {
                IMessage advisory;

                while ((advisory = consumer.Receive(TimeSpan.FromMilliseconds(2000))) != null)
                {
                    ActiveMQMessage amqMsg = advisory as ActiveMQMessage;

                    if (amqMsg.DataStructure != null)
                    {
                        DestinationInfo info = amqMsg.DataStructure as DestinationInfo;
                        if (info != null)
                        {
                            string destType = info.Destination.IsTopic ? "Topic" : "Qeue";
                            destType = info.Destination.IsTemporary ? "Temporary" + destType : destType;
                            Console.WriteLine("   " + destType + ": " + info.Destination.ToString());
                        }
                    }
                }
            }
            Console.WriteLine("Listing Complete.");
        }

        public void ShutDown()
        {
            session.Close();
            connection.Close();
        }

      
        public void SendMQ()
        {
                 }
    };
}
