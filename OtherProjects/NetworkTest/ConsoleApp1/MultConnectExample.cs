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
    class MultConnectExample
    {
        public void Start(bool isAutoClose=false)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint server = new IPEndPoint(ip, Int32.Parse("28888"));
            int count = 1000;
            List<Socket> sockets = new List<Socket>();
            while (count > 0)
            {
                count--;
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    socket.Connect(server);
                    sockets.Add(socket);
                }
                catch
                {

                    return;
                }
               // sendMsg(socket);
            }
            if (isAutoClose)
            {
                foreach (Socket client in sockets)
                {
                    try
                    {
                        client.Shutdown(SocketShutdown.Both);
                        client.Close();
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine("" + err.Message);
                    }
                }
            }
            else
            {
               
            }

        }

        private void sendMsg(Socket socket)
        {
            NetworkStream netstream = new NetworkStream(socket);
            byte[] sendbytes = sendbytes = System.Text.Encoding.ASCII.GetBytes("hello world");
            netstream.Write(sendbytes, 0, sendbytes.Length);
            netstream.Flush();
        }
    }
}
