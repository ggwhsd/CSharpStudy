using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarketRiskUI
{
    public partial class ActiveMQ_QUEUE : Form
    {
        public ActiveMQ_QUEUE()
        {
            InitializeComponent();
        }
        private QProducer producer;
        private QConsumer[] consumers = new QConsumer[100];

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            if (producer != null)
            {
                producer.Init();
                producer.SetTopic();
                producer.CreateProducer();
            }
            else
            {
                producer = new QProducer();
                producer.Init();
                producer.SetTopic();
                producer.CreateProducer();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            producer.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = int.Parse(textBox3.Text);
            for (int index = 0; index < i; index++)
            {
                QConsumer consumer = consumers[index];

                if (consumer != null)
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
                   
                    consumer = new QConsumer();
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

        private void button4_Click(object sender, EventArgs e)
        {
            int i = int.Parse(textBox3.Text);
            for (int index = 0; index < i; index++)
            {
                QConsumer consumer = consumers[index];
                if (consumer != null)
                {
                    consumer.Close();
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            int i = int.Parse(textBox3.Text);
            for (int index = 0; index < i; index++)
            {
                QConsumer consumer = consumers[index];
                if (consumer != null)
                {
                    consumer.cleanStart();
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "发送耗时" + producer.SendMsg(textBox_send.Text.ToString(), int.Parse(textBox2.Text)) + "秒";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "发送耗时" + producer.SendSelectorMsg(textBox_send.Text.ToString(), int.Parse(textBox2.Text)) + "秒";

        }
    }
    class QProducer
    {
        private IConnection connection;
        private ISession session;
        private IDestination dest;
        private IMessageProducer prod;
        public QProducer()
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
            dest = session.GetQueue(topicCfg.topicStr);
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
                msg.Properties.SetString("filter", "demo");  //设置selector
                msg.Properties.SetDouble("double", 1.11);
                prod.Send(msg, MsgDeliveryMode.NonPersistent, MsgPriority.Normal, TimeSpan.MinValue);

            }
            DateTime end = DateTime.Now;
            ts = end - start;
            return ts.TotalSeconds;
        }
        public double SendMsg(string content, int count)
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
    class QConsumer
    {
        private IConnection connection;
        private ISession session;
        private IDestination dest;
        private IMessageConsumer cons;
        private string selector = null;
        public QConsumer()
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
            dest = session.GetQueue(topicCfg.topicStr);
        }

        public void CreateConsumer()
        {
            cons = session.CreateConsumer(dest, selector);
            
            cons.Listener += new MessageListener(consumer_Listener);
        }
        private DateTime start;
        private DateTime end;
        private bool isStart = false;
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
                Console.WriteLine("Receive: " + msg.Text + " span " + ts.TotalSeconds);
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

}
