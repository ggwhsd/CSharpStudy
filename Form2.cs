using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MarketRiskUI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            IPAddress localIp = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEP = new IPEndPoint(localIp,8000);
            Console.WriteLine("the local ipendpoint is:{0}",localEP.ToString());
            Console.WriteLine("the address is:{0}",localEP.Address);
            Console.WriteLine("the addressfamily is:{0}",localEP.AddressFamily);
            
        }
        Thread thread1;
        Thread thread2;
        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
            thread1 = new Thread(new ThreadStart(method1));
            thread2 = new Thread(new ThreadStart(method2));
            thread1.Priority = ThreadPriority.Highest;
            thread2.Priority = ThreadPriority.Normal;
            thread1.Start();
            thread2.Start();

        }
        public void method1()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (i == 200)
                    Thread.Sleep(30);
                else
                    textBox1.AppendText("#"+i.ToString());
            }

        }
        public void method2()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (i == 400)
                    Thread.Sleep(5);
                else
                    textBox2.AppendText("*"+ i.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sendString = "你好，继续努力啊";
            Send(sendString);
            Send("quit");
            

        }
        private void Send(string message)
        {
           
            IPEndPoint remoteip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            UdpClient udp1 = new UdpClient();
            
            try
            {
                byte[] sendBytes;
                if (isUnicode)
                {
                    sendBytes = Encoding.Unicode.GetBytes(message);
                   
                }
                else
                    sendBytes = Encoding.ASCII.GetBytes(message);

                udp1.Send(sendBytes, sendBytes.Length, remoteip);
                MessageBox.Show("udp1 send {0}", message);
                if (message == "quit")
                {
                    return;
                }
               
                byte[] getBytes = udp1.Receive(ref remoteip);
                string getString;
                if (isUnicode)
                {
                    getString = Encoding.Unicode.GetString(getBytes);
                }
                else
                {
                    getString = Encoding.ASCII.GetString(getBytes);
                }
                MessageBox.Show("udp1 receive {0}", getString);
                udp1.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("udp1 error {0}", err.ToString());
                udp1.Close();
            }
        }

        private  void StartLinstener()
        {
            UdpClient udpserver = new UdpClient(9999);
            IPEndPoint myHost = null;

            try
            {
                while (true)
                {
                    Console.WriteLine("udpserver 等待接收");
                    byte[] getBytes = udpserver.Receive(ref myHost);
                    string getString;
                    if (isUnicode)
                        getString = Encoding.Unicode.GetString(getBytes, 0, getBytes.Length);
                    else
                        getString = Encoding.ASCII.GetString(getBytes, 0, getBytes.Length);
                    Console.WriteLine("udpserver receive {0}", getString);
                    if (getString == "quit")
                    {
                        break;

                    }
                    string sendString = "hello ,take care of yourself!";
                    Console.WriteLine("udpserver send {0}", sendString);
                    byte[] sendBytes;
                    if (isUnicode)
                        sendBytes = Encoding.Unicode.GetBytes(sendString);
                    else
                        sendBytes = Encoding.ASCII.GetBytes(sendString);
                    udpserver.Send(sendBytes, sendBytes.Length, "127.0.0.1", myHost.Port);
                }
                udpserver.Close();

            }
            catch (Exception err)
            {
                Console.WriteLine("udp server error {0}", err.ToString());
                udpserver.Close();
            }

        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            thread1 = new Thread(new ThreadStart(StartLinstener));
            thread1.Start();
            MessageBox.Show("已经启动udp server 端口9999");
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        

        }
        private Socket socket;
        private Socket newsocket;
        private Thread thread3;
        Thread Thread0;
        private void button9_Click(object sender, EventArgs e)
        {

            Thread0 = new Thread(new ThreadStart(StartTCPLinstener));
            Thread0.Start();

        }

        bool first = true;
        private void StartTCPLinstener()
        {
            if (first)
            {
                btnStartListen.Enabled = false;
                IPAddress ip = IPAddress.Parse(this.textBoxIP.Text);
                IPEndPoint server = new IPEndPoint(ip, Int32.Parse(textBoxPort.Text));

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(server);
                socket.Listen(10);
                first = false;
            }
            try
            {
                newsocket = socket.Accept(); //程序处于阻塞状态
                thread3 = new Thread(new ThreadStart(AcceptMessage));
                thread3.Start();

            }
            catch (Exception err)
            {
                lbState.Items.Add("客户" + newsocket.RemoteEndPoint.ToString() + "建立tcp连接");
            }
        }
        private void AcceptMessage()
        {
            while (true)
            {
                try
                {
                    NetworkStream netStream = new NetworkStream(newsocket);
                    byte[] datasize = new byte[4];  //内容长度
                    netStream.Read(datasize,0,4);
                    int size = System.BitConverter.ToInt32(datasize, 0);
                    byte[] message = new byte[size];
                    int dataleft = size;
                    int start = 0;
                    while (dataleft > 0)
                    {
                        int recv = netStream.Read(message,start,dataleft);  //内容
                        start += recv;
                        dataleft -= recv;
                    }
                    if (isUnicode)
                    {
                        rtbAccept.Text = Encoding.Unicode.GetString(message);
                    }
                    else
                    {
                        rtbAccept.Text = Encoding.ASCII.GetString(message);
                    }

                }
                catch (Exception err)
                {
                    lbState.Items.Add("与客户的连接断开了!");
                    break;
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string str = rtbSend.Text;
            int i = str.Length;
            if (i == 0)
            {
                return;
            }
            else
            {
                //unicode 每个字占用两个字节
                if (isUnicode)
                    i *= 2;
                else
                {
                }

            }
            byte[] datasize = new byte[4];
            datasize = BitConverter.GetBytes(i);
            byte[] sendbytes;
            if (isUnicode)
            {
                sendbytes = System.Text.Encoding.Unicode.GetBytes(str);
            }
            else
            {
                sendbytes = System.Text.Encoding.ASCII.GetBytes(str);
            }
            try
            {
                NetworkStream netstream = new NetworkStream(newsocket);
                netstream.Write(datasize, 0, 4);
                netstream.Write(sendbytes, 0, sendbytes.Length);
                netstream.Flush();
                this.rtbSend.Text = "";
            }
            catch
            {
                MessageBox.Show("无法发送");
            }

       
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStartListen.Enabled = true;
            try
            {
               // socket.Disconnect(false);
                //socket.Shutdown(SocketShutdown.Both);
               
                socket.Close();
               
                if (newsocket.Connected)
                {
                    newsocket.Close();
                   
                }
                thread3.Abort();
            }
            catch (ThreadAbortException err)
            {
                MessageBox.Show("线程关闭！");
            }
            catch(Exception err)
            {
                MessageBox.Show("监听尚未开始，关闭无效"+ err.Message);
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                if (newsocket.Connected)
                {
                    newsocket.Close();
                    thread3.Abort();

                }
            }
            catch
            {

            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        Thread thread4;
        private void btnRequest_Click(object sender, EventArgs e)
        {

            IPAddress ip = IPAddress.Parse(tbIP.Text);
            IPEndPoint server = new IPEndPoint(ip, Int32.Parse(tbPort.Text));
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(server);
            }
            catch {
                MessageBox.Show("与服务器连接失败！");
                return;
            }
            this.btnRequest.Enabled = false;
            this.lbStateC.Items.Add("与服务器连接成功");
            thread4 = new Thread(new ThreadStart(CAcceptMessage));
            thread4.Start();
        }

        private void CAcceptMessage()
        {
            while (true)
            {
                try {
                    NetworkStream netStream = new NetworkStream(socket);
                    byte[] datasize = new byte[4];
                    netStream.Read(datasize,0,4);
                    int size = BitConverter.ToInt32(datasize,0);
                    byte[] message = new byte[size];
                    int dataleft = size;
                    int start = 0;
                    while (dataleft > 0)
                    {
                        int recv = netStream.Read(message,start,dataleft);
                        start += recv;
                        dataleft -= recv;
                    }
                    if (isUnicode)
                        this.rtbReceC.Text = Encoding.Unicode.GetString(message);
                    else
                        this.rtbReceC.Text = Encoding.ASCII.GetString(message);

                }
                catch {
                    lbStateC.Items.Add("服务器断开连接");
                    break;
                }
            }
        }

        private void btnCSend_Click(object sender, EventArgs e)
        {
            string str = rtbSendC.Text;
            int i = str.Length;
            if (i == 0)
            {
                return;
            }
            else
            {
                if(isUnicode)
                    i *= 2;

            }
            byte[] datasize = new byte[4];
            datasize = BitConverter.GetBytes(i);
            byte[] sendbytes;
            if (isUnicode)
                sendbytes = System.Text.Encoding.Unicode.GetBytes(str);
            else
                sendbytes = System.Text.Encoding.ASCII.GetBytes(str);
            try
            {
                NetworkStream netstream = new NetworkStream(socket);
                netstream.Write(datasize, 0, 4);
                netstream.Write(sendbytes, 0, sendbytes.Length);
                netstream.Flush();
                rtbSendC.Text = "";

            }
            catch
            {
                MessageBox.Show("无法发送");
            }
        }

        private void btnCClose_Click(object sender, EventArgs e)
        {
            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                lbStateC.Items.Add("与主机断开连接");
                thread4.Abort(); 
            }
            catch
            {
                MessageBox.Show("尚未与主机连接，断开无效");
            }
            btnRequest.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string localName = Dns.GetHostName();
            Console.WriteLine("主机名：{0}", localName);

            IPHostEntry localHost = Dns.GetHostEntry(localName);
            foreach (IPAddress localIP in localHost.AddressList)
            {
                Console.WriteLine("ip address:{0}", localIP.ToString());
            }

            IPAddress ip1 = IPAddress.Parse("127.0.0.1");
            Console.WriteLine("{0} {1}", ip1.ToString(), ip1.AddressFamily.ToString());
            //Console.ReadKey();
        }

        private void btnString_Click(object sender, EventArgs e)
        {
            string str = textBoxString.Text;

            textBoxString.AppendText("length:" + str.Length + "\r\n");
            str = str.Trim();
            textBoxString.AppendText("trim():" + str + "\r\n");
            char[] trimChars = {' ', 'a', 'c' };
            textBoxString.AppendText("trim(char[] ):" + str.Trim(trimChars)+"\r\n");
            textBoxString.AppendText("upper:" + str.ToUpper() + "\r\n");
            char[] split = {':',' '};
            string[] nWords = str.Split(split, 2);
            textBoxString.AppendText("split(\':\'):" + nWords[0] + " : "+nWords[1].PadLeft(10,'0') + "\r\n");
            textBoxString.AppendText("Substring()"+str.Substring(0,5)+"\r\n");
            textBoxString.AppendText("Replace(\"a\",\"b\")"+str.Replace('a','*')+"\r\n");
            textBoxString.AppendText("ToCharArray()" + str.ToCharArray());
            Console.WriteLine(sizeof(char));
            


        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedIndex == 3)
            {
                textBox3.Text = "异步socket，其实相比较于同步socket的方式， " +
                    "就是在发送、接收等过程中，使用了回调函数，" +
                    "比如connect过程，使用connect则必须要等到连接建立完成后，程序才能往下走；" +
                    "使用beginConnect和endConnect则可以实现异步方式，BeginConnect(remoteip,new AsyncCallback(ConnectServer),socket)"
                    + "则会发起连接，当连接返回信息后会回调ConnectServer方法，该方法中之行EndConnect，然后就可以之行发送和接收等下一步操作了。";
            }
        }

        private void btnSendraw_Click(object sender, EventArgs e)
        {


            string str = rtbSend.Text;
            int i = str.Length;
           
            byte[] datasize = new byte[10];

            datasize = System.Text.Encoding.ASCII.GetBytes(String.Format("{0:D10}",i));
            byte[] sendbytes = System.Text.Encoding.ASCII.GetBytes(str);
            try
            {
                NetworkStream netstream = new NetworkStream(newsocket);
                netstream.Write(datasize, 0, datasize.Length);
                netstream.Write(sendbytes, 0, sendbytes.Length);
                netstream.Flush();
                this.rtbSend.Text = "";
            }
            catch
            {
                MessageBox.Show("无法发送");
            }

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            string filename =file.FileName;

            string inLine = null;

           
            if (File.Exists(filename) == false)
            {
                MessageBox.Show("error: file does not exist");
                return;
            }
            else
            {
                Random rd = new Random();

                int count = 0;
                int index = 0;
                if (filename.Contains("trade_Log") == true)
                {
                    index = 24;
                }
                FileStream fs1 = new FileStream(filename, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs1);
                inLine = sw.ReadLine();
                string strRandomRange = textBox_random.Text;
                string[] ranges = strRandomRange.Split(',');
                int min = Int32.Parse(ranges[0]);
                int max = Int32.Parse(ranges[1]);

                while (inLine != null)
                {
                    count++;
                    if (inLine.Length > index)
                    {
                        rtbSend.Text = inLine.Substring(index);
                        btnSendraw_Click(null, null);
                    }
                    Thread.Sleep(rd.Next(min, max));
                    inLine = sw.ReadLine();
                }
                sw.Close();
                fs1.Close();
                MessageBox.Show("done,total send message "+count);
            }

        }
        private bool isUnicode = true;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                isUnicode = false;
            if (radioButton2.Checked)
                isUnicode = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1_CheckedChanged(sender, e);
        }
    }
}
