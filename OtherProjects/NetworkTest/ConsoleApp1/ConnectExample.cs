using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace ConsoleApp1
{
    class ConnectExample
    {
        void ShowMsg(string str)
        {

            Console.WriteLine(DateTime.Now.ToLongTimeString() + " " + str);
        }
        public void Start()
        {
            ShowMsg("Hello World!");

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint server = new IPEndPoint(ip, Int32.Parse("28888"));
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(server);
            }
            catch
            {
                ShowMsg("与服务器连接失败！");
                return;
            }

            NetworkStream netstream = new NetworkStream(socket);
            byte[] sendbytes = sendbytes = System.Text.Encoding.ASCII.GetBytes("hello world");
            netstream.Write(sendbytes, 0, sendbytes.Length);
            netstream.Flush();
            ShowMsg("等待服务端主动断开连接");
            Thread.Sleep(TimeSpan.FromSeconds(11));

            try
            {
                netstream.Write(sendbytes, 0, sendbytes.Length);
                netstream.Flush();
            }
            catch (Exception err)
            {
                ShowMsg("发送消息失败1:" + err.Message);
            }
            try
            {
                socket = null;
                int count = 0;
                while (true)
                {
                    count++;
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    bool isConnect = false;
                    try
                    {
                        socket.Connect(server);
                        isConnect = true;
                    }
                    catch (Exception err)
                    {
                        ShowMsg("重连失败" + err.Message + "次数【" + count + "】");
                    }
                    if (isConnect)
                    {
                        ShowMsg("重连成功");
                        netstream = new NetworkStream(socket);
                        netstream.Write(sendbytes, 0, sendbytes.Length);
                        netstream.Flush();
                        ShowMsg("发送成功");
                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                        break;
                    }
                    else
                    {
                        Thread.Sleep(10);
                    }
                }
            }
            catch (Exception err)
            {
                ShowMsg("发送消息失败2:" + err.Message);
            }

            ShowMsg("输入任何消息，退出");
            Console.ReadLine();

            ShowMsg("Bye Bye!");
        }
    }
}
