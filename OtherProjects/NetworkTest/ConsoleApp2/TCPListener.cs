using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class TCPListener
    {
        Thread Thread0 = null;
        public void Start()
        {
            //Thread0 = new Thread(new ThreadStart(StartTCPLinstener));
            //Thread0.Start();

            StartTCPLinstener();
        }
        private bool first = true;
        private Socket socket = null;
        private Socket client = null;
        private Thread thread = null;
        private int count = 0;
        private void StartTCPLinstener()
        {
            if (first)
            {

                IPAddress ip = IPAddress.Parse("127.0.0.1");
                IPEndPoint server = new IPEndPoint(ip, Int32.Parse("28888"));

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(server);
                socket.Listen(10);
                Console.WriteLine("监听端口:"+server.Port);
                first = false;
            }
            try
            {
                while (true)
                {
                   
                    client = socket.Accept(); //程序处于阻塞状态
                    count++;

                    Console.WriteLine(count.ToString()+ "，新连接:" + client.RemoteEndPoint.ToString());
                    thread = new Thread(new ThreadStart(AcceptMessage));
                    thread.Start();
                    Timer t = new Timer(TimerCLose, client, TimeSpan.FromSeconds(10),Timeout.InfiniteTimeSpan);
                    
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("客户" + client.RemoteEndPoint.ToString() + "建立tcp连接");
            }
        }
        private void TimerCLose(object state)
        {
            Socket socket = state as Socket;
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            Console.WriteLine("自动关闭tcp连接");

        }
        private void AcceptMessage()
        {
            while (true)
            {
                try
                {
                    NetworkStream netStream = new NetworkStream(client);

                    byte[] message = new byte[1024];
                    int recv = netStream.Read(message, 0, 1023);  //内容
                    if (recv > 0)
                        Console.WriteLine(Encoding.ASCII.GetString(message));
                    else
                    {
                        Console.WriteLine("与客户的正常断开了!" + recv);
                        break;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine("与客户的连接断开了!" + err.Message);
                    break;
                }
            }
        }
    }
}
