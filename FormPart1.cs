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


namespace MarketRiskUI
{

    public partial class Form1 
    {
        /// <summary>
        /// 创建txt文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            String str_filename;
            if (txt_filename.Text.Trim() == "")
            {
                MessageBox.Show("error: filename is empty");
                return;
            }
            else
            {
                str_filename = Environment.CurrentDirectory + "\\" + txt_filename.Text.Trim();
            }
            if (File.Exists(str_filename) == true)
            {
                MessageBox.Show("warning: filename existed");
            }
            else
            {
                FileStream fs1 = new FileStream(str_filename, FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);
             
                sw.WriteLine("testCreated");
                sw.Close();
                fs1.Close();
            }
        }
        /// <summary>
        /// 删除txt文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            String str_filename;
            if (txt_filename.Text.Trim() == "")
            {
                MessageBox.Show("error: filename is empty");
                return;
            }
            else
            {
                str_filename = Environment.CurrentDirectory + "\\" + txt_filename.Text.Trim();
            }
            if (File.Exists(str_filename) == false)
            {
                MessageBox.Show("warning: filename not exists");
            }
            else
            {
                File.Delete(str_filename);
            }

        }

        /// <summary>
        /// 当前目录下修改文件名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            String str_filename;
            String str_filename_new;
            if (txt_filename.Text.Trim() == "")
            {
                MessageBox.Show("error: filename is empty");
                return;
            }
            else
            {
                str_filename = Environment.CurrentDirectory + "\\" + txt_filename.Text.Trim();
                str_filename_new = Environment.CurrentDirectory + "\\" + txt_filename.Text.Trim().Replace(".txt","new.txt");
            }
            if (File.Exists(str_filename) == false || File.Exists(str_filename_new)==true)
            {
                MessageBox.Show("warning: filename not exists or new filename is exists");
            }
            else
            {
                File.Move(str_filename, str_filename+"new");
            }
        }

        /// <summary>
        /// 移动文件到其他目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            String str_filename;
            String str_filename_new;
            if (txt_filename.Text.Trim() == "")
            {
                MessageBox.Show("error: filename is empty");
                return;
            }
            else
            {
                str_filename = Environment.CurrentDirectory + "\\" + txt_filename.Text.Trim();
                str_filename_new = Environment.CurrentDirectory + "\\new\\" + txt_filename.Text.Trim().Replace(".txt", "new.txt");
            }
            if (File.Exists(str_filename) == false || File.Exists(str_filename_new) == true)
            {
                MessageBox.Show("warning: filename not exists or new filename is exists");
            }
            else
            {
                File.Move(str_filename, str_filename_new);
            }
        }

        /// <summary>
        /// 写入txt文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            String str_filename;
            if (txt_filename.Text.Trim() == "")
            {
                MessageBox.Show("error: filename is empty");
                return;
            }
            else
            {
                str_filename = Environment.CurrentDirectory + "\\" + txt_filename.Text.Trim();
            }
            if (File.Exists(str_filename) == false)
            {
                MessageBox.Show("error: file does not exist");
                return;
            }
            else
            {
                FileStream fs1 = new FileStream(str_filename, FileMode.Append, FileAccess.Write);//追加写入文件 
                StreamWriter sw = new StreamWriter(fs1);
                int i = 1;
                while (i < 100)
                {
                    sw.WriteLine("{0} {1} {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), "input line ",i);
                    i++;
                }
                sw.Close();
                fs1.Close();
            }
        }

        /// <summary>
        /// 读取txt文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            string inLine = null;
            String str_filename;
            if (txt_filename.Text.Trim() == "")
            {
                MessageBox.Show("error: filename is empty");
                return;
            }
            else
            {
                str_filename = Environment.CurrentDirectory + "\\" + txt_filename.Text.Trim();
            }
            if (File.Exists(str_filename) == false)
            {
                MessageBox.Show("error: file does not exist");
                return;
            }
            else
            {
                FileStream fs1 = new FileStream(str_filename, FileMode.Open, FileAccess.Read);//追加写入文件 
                StreamReader sw = new StreamReader(fs1);
                inLine = sw.ReadLine();
                while (inLine != null)
                {
                    txt_filecontext.AppendText(inLine + "\r\n");
                    inLine = sw.ReadLine();
                }
                sw.Close();
                fs1.Close();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string pwd = System.Environment.CurrentDirectory;
            DirectoryInfo d = Directory.CreateDirectory(pwd+"\\layer1");
            Directory.SetCurrentDirectory(pwd + "\\layer1");
            d.CreateSubdirectory("layer11");
            Directory.Delete(pwd + "\\layer1\\layer11",true);
            Directory.SetCurrentDirectory(pwd);   //切换工作目录。这样下面一行代码才能有效。
            Directory.Delete(pwd + "\\layer1",true);

        }
    }
}
