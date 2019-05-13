﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace MarketRiskUI
{
    
    public partial class AsyncNetworkStream : Form
    {
        public AsyncNetworkStream()
        {
            InitializeComponent();
        }
        TCP_Server server = null;
        TCP_Client client = null;
        private void button1_Click(object sender, EventArgs e)
        {
            server = new TCP_Server();
            server.start();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client = new TCP_Client();
            client.start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
    class TCP_Server
    {
        static byte[] buffer = new byte[1024];
        private static int count = 0;
        bool status = true;
        public void start()
        {
            WriteLine("server:ready", ConsoleColor.Green); //绿色
            #region 启动程序
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any, 7788));
            socket.Listen(10000);
            socket.BeginAccept(new AsyncCallback(ClientAccepted), socket);
            Console.ReadLine();
            #endregion

        }
        #region 客户端连接成功
        /// <summary>
        /// 客户端连接成功
        /// </summary>
        /// <param name="ar"></param>
        public void ClientAccepted(IAsyncResult ar)
        {
            #region
            //设置计数器
            count++;
            var socket = ar.AsyncState as Socket;
            //这就是客户端的Socket实例，我们后续可以将其保存起来
            var client = socket.EndAccept(ar);
            //客户端IP地址和端口信息
            IPEndPoint clientipe = (IPEndPoint)client.RemoteEndPoint;

            WriteLine(clientipe + " is connected，total connects " + count, ConsoleColor.Yellow);

            //接收客户端的消息(这个和在客户端实现的方式是一样的）异步
            client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), client);
            //准备接受下一个客户端请求(异步)
            socket.BeginAccept(new AsyncCallback(ClientAccepted), socket);
            #endregion
        }
        #endregion
        #region 接收客户端的信息
        /// <summary>
        /// 接收某一个客户端的消息
        /// </summary>
        /// <param name="ar"></param>
        public void ReceiveMessage(IAsyncResult ar)
        {
            
            int length = 0;
            string message = "";
            var socket = ar.AsyncState as Socket;
            //客户端IP地址和端口信息
            IPEndPoint clientipe = (IPEndPoint)socket.RemoteEndPoint;
            try
            {
                #region
                //方法参考：http://msdn.microsoft.com/zh-cn/library/system.net.sockets.socket.endreceive.aspx
                length = socket.EndReceive(ar);
                if (status == false)
                {
                    socket.Close();
                    WriteLine(clientipe + " is disconnected " , ConsoleColor.Red);
                    return;
                }
                //读取出来消息内容
                message = Encoding.UTF8.GetString(buffer, 0, length);
                //输出接收信息
                WriteLine(clientipe + " ：" + message, ConsoleColor.White);
                //服务器发送消息
                socket.Send(Encoding.UTF8.GetBytes("server received data")); //默认Unicode
                //接收下一个消息(因为这是一个递归的调用，所以这样就可以一直接收消息）异步
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), socket);
                #endregion
            }
            catch (Exception ex)
            {
                //设置计数器
                count--;
                //断开连接
                WriteLine(clientipe + " is disconnected，total connects " + (count), ConsoleColor.Red);
            }
        }
        #endregion
        #region 扩展方法
        public static void WriteLine(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("[{0}] TCP_SERVER {1}", DateTime.Now.ToString("MM-dd HH:mm:ss"), str);
        }
        #endregion


    }

    class TCP_Client
    {
        bool status = true;
        #region 扩展方法
        public static void WriteLine(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("[{0}] TCP_CLIENT {1}", DateTime.Now.ToString("MM-dd HH:mm:ss"), str);
        }
        #endregion
        static byte[] buffer = new byte[1024];
        public void start()
        {
            try
            {
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect("127.0.0.1", 7788);
                WriteLine("client:connect to server success!", ConsoleColor.White);
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), socket);
                
                
                

            }
            catch (Exception ex)
            {
                WriteLine("client:error " + ex.Message, ConsoleColor.Red);
            }
            finally
            {
                Console.Read();
            }
        }

        #region 接收信息
        /// <summary>
        /// 接收信息
        /// </summary>
        /// <param name="ar"></param>
        public void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                var socket = ar.AsyncState as Socket;

                //方法参考：http://msdn.microsoft.com/zh-cn/library/system.net.sockets.socket.endreceive.aspx
                var length = socket.EndReceive(ar);
                if (status == false)
                {
                    socket.Close();
                    WriteLine(" TCP_Client disconnected ", ConsoleColor.Red);
                    return;
                }
                //读取出来消息内容
                var message = Encoding.ASCII.GetString(buffer, 0, length);

                //显示消息
                WriteLine(message, ConsoleColor.White);

                //接收下一个消息(因为这是一个递归的调用，所以这样就可以一直接收消息了）
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), socket);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message, ConsoleColor.Red);
            }
        }
        #endregion

    }
}
