using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AdvancedMemory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = @"每个按钮都需要在一个新的进程中打开，以便演示不同进程使用共享内存";
            label2.Text = @"内存映射文件的使用演示";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            long capacity = 1 << 10 << 10;
            using (var mmf = MemoryMappedFile.CreateOrOpen("MMF1", capacity))
            {
                var viewAccessor = mmf.CreateViewAccessor(0, capacity);
                while (true)
                {
                    await Task.Delay(1000);
                    string input = $"测试时间{DateTime.Now.ToLongTimeString()}";
                    viewAccessor.Write(0, input.Length);
                    viewAccessor.WriteArray<char>(4, input.ToArray(), 0, input.Length);
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            using (var mmf = MemoryMappedFile.OpenExisting("MMF1"))
            {
                MemoryMappedViewAccessor viewAccessor = mmf.CreateViewAccessor();
                while (true)
                {
                    int strLength = viewAccessor.ReadInt32(0);
                    char[] chars = new char[strLength];
                    viewAccessor.ReadArray<char>(4, chars, 0, strLength);

                    textBox_output.Text = new string(chars);
                    await Task.Delay(1000);
                }
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            long capacity = 1 << 10 << 10;
            using (var mmf = MemoryMappedFile.OpenExisting("MMF1"))
            {
                using (var mmfStream = mmf.CreateViewStream(0, capacity))
                {
                    using (BinaryReader rdr = new BinaryReader(mmfStream, Encoding.Unicode))
                    {
                        while (true) {
                            mmfStream.Seek(0, SeekOrigin.Begin);
                            int lenght = rdr.ReadInt32();
                            char[] chars = rdr.ReadChars(lenght);
                            textBox_output.Text = new string(chars);
                            await Task.Delay(1000);
                        }
                    }
                }
            }
        }

        private MemoryMappedFile mmf = null;
        private MemoryMappedViewAccessor viewAccessor;
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                mmf = MemoryMappedFile.CreateFromFile("MyFile.dat", FileMode.OpenOrCreate, "MyFile", 512);
                textBox_output2.Text = "内存文件映射创建完成\r\n";
                viewAccessor = mmf.CreateViewAccessor();
                //可以访问局部和全部
                //viewAccessor = mmf.CreateViewAccessor(0,512/2);
                textBox_output2.Text += "读取对象创建完成\r\n";
            }
            catch (Exception err)
            {

            }
        }

        private void ShowFileMessage()
        {
            StringBuilder strBuild = new StringBuilder(512);
            strBuild.Append("开始读取：\r\n");

            int j = 0;
            for (int i = 0; i < 512; i += 2, j++)
            {
                strBuild.Append("\t");
                char ch = viewAccessor.ReadChar(i);
                strBuild.Append(j).Append(":").Append(ch);

            }
            textBox_output2.Text += strBuild;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowFileMessage();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string input = "这是测试数据，this is a block of tested data";
            char[] arrays = input.ToArray();
            //byte[] arraysByte = Encoding.UTF8.GetBytes(input);
            viewAccessor.WriteArray<char>(0, arrays, 0, input.Length);
            textBox_output2.Text += "写入完成\r\n";
        }

        private NamedPipeClientStream pipeClient = new NamedPipeClientStream("localhost", "pipName1", PipeDirection.InOut,
            PipeOptions.Asynchronous, System.Security.Principal.TokenImpersonationLevel.None);
        StreamWriter sw = null;

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                pipeClient.Connect(5000);
                sw = new StreamWriter(pipeClient);
                sw.AutoFlush = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接建立失败，请确保server端程序被打开");
                this.Close();
            }
        }

    
        private NamedPipeServerStream pipeServer =
            new NamedPipeServerStream("pipName1", PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);

        private  void button10_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(delegate {
                pipeServer.BeginWaitForConnection( (o) =>
                {
                    NamedPipeServerStream pServer = (NamedPipeServerStream)o.AsyncState;
                    pServer.EndWaitForConnection(o);
                    StreamWriter sw = new StreamWriter(pServer);
                    
                        this.Invoke((MethodInvoker) delegate
                        {
                            textBox_output3.Text += "有连接\r\n";

                        });
                    sw.WriteLine("管道收到连接，这是一条回馈消息");
                    sw.AutoFlush = true;

                },pipeServer
                );
            });
        }


        private void button11_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(pipeClient);
            string str = sr.ReadLine();
            textBox_output3.Text += str;
        }
    }
}
