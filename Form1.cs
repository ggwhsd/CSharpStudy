using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Xml.Linq;
using System.Runtime.InteropServices;

namespace MarketRiskUI
{
    
    public partial class Form1 : Form
    {
        /* delegate的使用，在界面更新时，经常使用，这样可以将其他线程中对主界面的更新提交给主线程来更新。
         * 文本文件读写
         * 网络连接基础
         * datagrid表格的使用
        */
        DataTable dt;
        // The port number for the remote device.     
        private const int port = 22222;
        // ManualResetEvent instances signal completion.     
        //定义回调
        private delegate void SetTextCallBack(string strValue);
        //声明
        private SetTextCallBack setCallBack;

        //定义接收服务端发送消息的回调
        private delegate void ReceiveMsgCallBack(string strMsg);
        //声明
        private ReceiveMsgCallBack receiveCallBack;

        //创建连接的Socket
        Socket socketSend;
        //创建接收客户端发送消息的线程
        Thread threadReceive;

       

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// connect按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(this.txt_IP.Text.Trim());
                socketSend.Connect(ip, Convert.ToInt32(this.txt_Port.Text.Trim()));
                //实例化回调
                setCallBack = new SetTextCallBack(SetValue);
                receiveCallBack = new ReceiveMsgCallBack(SetValue);
                this.txt_Log.Invoke(setCallBack, "连接成功");

                //开启一个新的线程不停的接收服务器发送消息的线程
                threadReceive = new Thread(new ThreadStart(Receive));
                //设置为后台线程
                threadReceive.IsBackground = true;
                threadReceive.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接服务端出错:" + ex.ToString());
            }

            dt = new DataTable("c++");
            dt.Columns.Add("seq", System.Type.GetType("System.String"));
            dt.Columns.Add("name", typeof(String));
            dt.Columns.Add("price", typeof(String));
            dt.Columns.Add("volumn", typeof(String));
            dt.Columns.Add("BidPrice", typeof(String));
            dt.Columns.Add("AskPrice", typeof(String));
            dt.Columns.Add("bidVolumn", typeof(String));
            dt.Columns.Add("askVolumn", typeof(String));
            dt.Columns.Add("m.ask", typeof(String));
            dt.Columns.Add("m.bid", typeof(String));
            dt.Columns.Add("m.askvolumn", typeof(String));
            dt.Columns.Add("m.bidvolumn", typeof(String));
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            DataRow dr2 = dt.NewRow();
            dt.Rows.Add(dr2);
            dt.Rows[0][1] = "CF901";
            dt.Rows[1][1] = "CF902";
            songsDataGridView.DataSource = dt;

        }

        private void SetValue(string strValue)
        {
            this.txt_Log.AppendText(strValue + "\r \n");
        }
     
        private void FrmClient_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }



        private void Receive()
        {
            try
            {
                DateTime date_time = DateTime.Now;

                while (true)
                {
                    Thread.Sleep(1000);
                    
                    byte[] buffer = new byte[2048];
                    //实际接收到的字节数
                    int r = socketSend.Receive(buffer,38,SocketFlags.None);
                    //NetworkStream netStream = new NetworkStream(socketSend);
                    //byte[] datasize = new byte[4];
                    //int r = netStream.Read(datasize, 0, 4);
                    if (r == 0)
                    {
                        this.txt_Log.Invoke(receiveCallBack, "没有收到数据:" + socketSend.RemoteEndPoint);
                        continue;
                    }
                    else
                    {

                        //string str = Encoding.Default.GetString(buffer, 0, r - 1);
                        //this.txt_Log.Invoke(receiveCallBack, "接收远程服务器:" + socketSend.RemoteEndPoint + "发送的消息:" + str);

                        string strRece = Encoding.ASCII.GetString(buffer);

                        //判断发送的数据的类型
                        if (strRece[0] == 0x01)//表示发送的是文字消息
                        {
                            string[] name = strRece.Split(',');
                            int j = 0;
                            while (j < dt.Rows.Count)
                            {
                                if (name[1] == (string)dt.Rows[j][1])
                                    break;
                                j++;
                            }
                            if (j >= dt.Rows.Count)
                            {
                                DataRow dr = dt.NewRow();
                                dt.Rows.Add(dr);
                                songsDataGridView.Invalidate();
                            }
                            
                            //int port =BitConverter.ToInt32(buffer,6);
                            for (int i = 0; i < name.Length; i++)
                            {
                                if (i > 3 && i < 6)
                                {

                                    //if(songsDataGridView.Rows[j].Cells[i].Style.BackColor == Color.Red)
                                    //    songsDataGridView.Rows[j].Cells[i].Style.BackColor = Color.Green;
                                    //else
                                    //    songsDataGridView.Rows[j].Cells[i].Style.BackColor = Color.Red;
                                    try
                                    {
                                        int oldValue = Convert.ToInt32(dt.Rows[j][i]);
                                        int newValue = Convert.ToInt32(name[i]);
                                        if (newValue > oldValue)
                                            songsDataGridView.Rows[j].Cells[i].Style.BackColor = Color.Red;
                                        else if (newValue < oldValue)
                                            songsDataGridView.Rows[j].Cells[i].Style.BackColor = Color.Green;
                                        else
                                        { }
                                    }
                                    catch (Exception err)
                                    {
                                    }


                                }

                                dt.Rows[j][i] = name[i];
                            }
                            //this.txt_Log.Invoke(receiveCallBack, "1接收远程服务器:" + socketSend.RemoteEndPoint + "发送的消息:" + strRece);
                        }
                        else
                        {
                            this.txt_Log.Invoke(receiveCallBack, "0接收远程服务器:" + socketSend.RemoteEndPoint + "发送的消息:" + strRece);
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("接收服务端发送的消息出错:" + ex.ToString());
            }
        }

        /// <summary>
        /// disconnect按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopListen_Click(object sender, EventArgs e)
        {
            //关闭socket
            socketSend.Close();
            //终止线程
            threadReceive.Abort();
        }
        /// <summary>
        /// 发送按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void send_Click(object sender, EventArgs e)
        {
            try
            {
                string strMsg = this.txt_Msg.Text.Trim();
                byte[] buffer = new byte[2048];
                buffer = Encoding.Default.GetBytes(strMsg);
                int receive = socketSend.Send(buffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送消息出错:" + ex.Message);
            }

        }

        /// <summary>
        /// 表格里面的单元格点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void songsDataGridView_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.songsDataGridView.Columns[e.ColumnIndex].Name == "Date")
                {
                    if (e.Value != null)
                    {
                        try
                        {
                            e.Value = DateTime.Parse(e.Value.ToString()).ToLongDateString();
                            e.FormattingApplied = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("{0} is not a valid date.", e.Value.ToString());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 表格对象的设计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            songsDataGridView.ColumnCount = 5;
            songsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            songsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            songsDataGridView.ColumnHeadersDefaultCellStyle.Font =
            new Font(songsDataGridView.Font, FontStyle.Bold);
            songsDataGridView.Name = "SongData";
           // songsDataGridView.Location = new Point(8, 8);
            //songsDataGridView.Size = new Size(500, 250);
            songsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            songsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            songsDataGridView.GridColor = Color.Black;
            songsDataGridView.RowHeadersVisible = false;

            songsDataGridView.Columns[0].Name = "Release Date";
            songsDataGridView.Columns[1].Name = "Track";
            songsDataGridView.Columns[2].Name = "Title";
            songsDataGridView.Columns[3].Name = "Artist";
            songsDataGridView.Columns[4].Name = "Album";
            songsDataGridView.Columns[4].DefaultCellStyle.Font =
                new Font(songsDataGridView.DefaultCellStyle.Font, FontStyle.Italic);

            songsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            songsDataGridView.MultiSelect = false;
            //songsDataGridView.Dock = DockStyle.Fill;

            songsDataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(songsDataGridView_CellFormatting);
        }

        /// <summary>
        /// 填充数据
        /// </summary>
        private void PopulateDataGridView()
        {

            string[] row0 = { "11/22/1968", "29", "Revolution 9",
            "Beatles", "The Beatles [White Album]" };
            string[] row1 = { "1960", "6", "Fools Rush In",
            "Frank Sinatra", "Nice 'N' Easy" };
            string[] row2 = { "11/11/1971", "1", "One of These Days",
            "Pink Floyd", "Meddle" };
            string[] row3 = { "1988", "7", "Where Is My Mind?",
            "Pixies", "Surfer Rosa" };
            string[] row4 = { "5/1981", "9", "Can't Find My Mind",
            "Cramps", "Psychedelic Jungle" };
            string[] row5 = { "6/10/2003", "13",
            "Scatterbrain. (As Dead As Leaves.)",
            "Radiohead", "Hail to the Thief" };
            string[] row6 = { "6/30/1992", "3", "Dress", "P J Harvey", "Dry" };

            songsDataGridView.Rows.Add(row0);
            songsDataGridView.Rows.Add(row1);
            songsDataGridView.Rows.Add(row2);
            songsDataGridView.Rows.Add(row3);
            songsDataGridView.Rows.Add(row4);
            songsDataGridView.Rows.Add(row5);
            songsDataGridView.Rows.Add(row6);
            

            songsDataGridView.Columns[0].DisplayIndex = 3;
            songsDataGridView.Columns[1].DisplayIndex = 4;
            songsDataGridView.Columns[2].DisplayIndex = 0;
            songsDataGridView.Columns[3].DisplayIndex = 1;
            songsDataGridView.Columns[4].DisplayIndex = 2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        /// <summary>
        /// 綁定數據源的方式，init2按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //创建一个名为"Table_New"的空表

            dt = new DataTable("test");
            dt.Columns.Add("Name", System.Type.GetType("System.String"));
            dt.Columns.Add("Date", typeof(String));
            DataColumn dc = new DataColumn("Title", typeof(String));
            dt.Columns.Add(dc);
            for (int i = 0; i < 5; i++)
            {
                dt.Columns.Add("Column"+i, typeof(String));
            }
            
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            dt.Rows.Add("张三", DateTime.Now.ToShortDateString(),"大boss","AAAAAA","AAAAAAA","AAAAAAAA","AAAAAAAAA","AAAAAAAAA");//Add里面参数的数据顺序要和dt中的列的顺序对应 
            dt.Rows.Add("张四", DateTime.Now.ToShortDateString(), "小boss", "AAAAAA", "AAAAAAA", "AAAAAAAA", "AAAAAAAAA", "AAAAAAAAA");//Add里面参数的数据顺序要和dt中的列的顺序对应 
            for (int i = 0; i < 10000; i++)
            {

                dt.Rows.Add("张四", DateTime.Now.ToShortDateString(), "小boss" + i, "AAAAAA", "AAAAAAA", "AAAAAAAA", "AAAAAAAAA", "AAAAAAAAA");//Add里面参数的数据顺序要和dt中的列的顺序对应 
            }
            songsDataGridView.DataSource = dt;

        }
        /// <summary>
        /// 表格设计，play2按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            
            songsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            songsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            songsDataGridView.ColumnHeadersDefaultCellStyle.Font =
            new Font(songsDataGridView.Font, FontStyle.Bold);
            songsDataGridView.Name = "SongData";
            //songsDataGridView.Location = new Point(8, 8);
            //songsDataGridView.Size = new Size(500, 250);
            songsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            songsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            songsDataGridView.GridColor = Color.Black;
            songsDataGridView.RowHeadersVisible = false;

            songsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            songsDataGridView.MultiSelect = false;
            //songsDataGridView.Dock = DockStyle.Fill;

            songsDataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(songsDataGridView_CellFormatting);
        }

        Thread []threadDisplay;
        /// <summary>
        /// refresh2按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            //开启一个新的线程不停的接收服务器发送消息的线程
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
            }
            else {
                timer1.Enabled = true;
            }
        }
        public void Display(string j)
        {
           
            try
            {
                int i = 10;
                while (i>0)
                {
                    i--;
                    
                    dt.Rows[i][2] = j;
                    dt.Rows[i][3] = j;
                    dt.Rows[i][4] = j;

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("接收服务端发送的消息出错:" + ex.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Display(DateTime.Now.ToString());
        }

        /// <summary>
        /// 写入excel文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            ExcelOp eop = new ExcelOp();
            eop.Open(System.Environment.CurrentDirectory+"\\"+txt_excelfile.Text,true);
            eop.SetCellProperty1("Sheet1", 1, 1, 100, 2, 10, "宋体", 3);
            int i = 1;
            while (i < 100)
            {
                eop.SetCellValue("Sheet1", i, 2, "hello"+i.ToString());
                i++;
            }
            eop.Save();
            eop.Close();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            ExcelOp eop = new ExcelOp();
            eop.Open(System.Environment.CurrentDirectory + "\\" + txt_excelfile.Text,false);
            int i = 1;
            while (i < 100)
            {
                txt_excelContext.AppendText(eop.GetCellValue("Sheet1", i, 2));
                i++;
            }
            eop.Save();
            eop.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            
            f2.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();

            f4.Hide();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.ShowDialog();
            MessageBox.Show(f5.a);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            GDI gDI = new GDI();
            gDI.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            songsDataGridView.DataSource = dt;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                //songsDataGridView.Invalidate();
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //将XML文件加载进来
            XDocument document = XDocument.Load(@"C:\Users\a\Desktop\GUGW\03CPPcode\CTPSolutionHedgeFAK\CTPtest\ContractProperties.xml");
            //获取到XML的根元素进行操作
            XElement root = document.Root;
            XElement contracts = root.Element("Contracts");
            //获取name标签的值
            XElement Contract = contracts.Element("Contract");
            //获取根元素下的所有子元素
            IEnumerable<XElement> enumerable = Contract.Elements();
            foreach (XElement item in enumerable)
            {
                    Console.WriteLine(item.Name +"["+ item.Attribute("type").Value + "]:"+item.Value);   //输出 name  name1   
            }
            
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //获取根节点对象
           // XDocument document = new XDocument();
            XElement root = new XElement("Root");
            XElement Contracts = new XElement("Contracts");
            XElement contract = new XElement("Contract");
            contract.SetElementValue("InstrumentID", "pt123");
            contract.SetElementValue("ExchangeID", "CCCC");
            contract.SetElementValue("FunctionType", "c");
            contract.Element("InstrumentID").SetAttributeValue("type","char[30]");
            Contracts.Add(contract);
            root.Add(Contracts);
            // document.Add(root);
            root.Save(@"C:\Users\a\Desktop\123.xml");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            //将XML文件加载进来
            XDocument document = XDocument.Load(@"C:\Users\a\Desktop\123.xml");
            //获取到XML的根元素进行操作
            XElement root = document.Root;
            XElement contracts = root.Element("Contracts");
            //获取name标签的值
            XElement Contract = contracts.Element("Contract");
            //获取根元素下的所有子元素
            IEnumerable<XElement> enumerable = Contract.Elements();
            foreach (XElement item in enumerable)
            {
                Console.WriteLine(item.Name  + item.Value);   //输出 name  name1   
            }
            XElement isntrument = Contract.Element("InstrumentID");
            isntrument.SetValue(isntrument.Value+DateTime.Now.ToBinary());
            document.Save(@"C:\Users\a\Desktop\123.xml");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            JsonForm jsonForm = new JsonForm();
            jsonForm.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Utils utils = new Utils();
            utils.Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            PanelTest pl = new PanelTest();
            pl.Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            AsyncNetworkStream asyn = new AsyncNetworkStream()
                 ;
    
            asyn.Show();

        }

        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        //下面是可用的常量，根据不同的动画效果声明自己需要的
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果
        private void Form1_Load(object sender, EventArgs e)
        {
            int x = Screen.PrimaryScreen.WorkingArea.Left + 210;
            int y = Screen.PrimaryScreen.WorkingArea.Top + 96;

            this.Location = new Point(x, y);//设置窗体在屏幕右下角显示
            AnimateWindow(this.Handle, 2000, AW_BLEND | AW_ACTIVE );
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 2000, AW_BLEND | AW_HIDE);
            
        }
    }
}
