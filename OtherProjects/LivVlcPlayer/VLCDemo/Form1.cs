using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VLCDemo
{
    //https://zhuanlan.zhihu.com/p/204998521
    //https://code.videolan.org/videolan/LibVLCSharp/-/tree/master
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            vlcs.Add(vlcControl1);
            vlcs.Add(vlcControl2);
            vlcs.Add(vlcControl3);
            vlcs.Add(vlcControl4);
            vlcs.Add(vlcControl5);
            vlcs.Add(vlcControl6);
            vlcs.Add(vlcControl7);
            vlcs.Add(vlcControl8);
            vlcs.Add(vlcControl9);
        }

        public List<Vlc.DotNet.Forms.VlcControl> vlcs = new List<Vlc.DotNet.Forms.VlcControl>();
       
        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string filename = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
            }


            //本地文件播放
            int index = Convert.ToInt32(btn.Tag.ToString());
            vlcs[index].Play(new FileInfo(filename));

        }

        //手动设置vlc的native 的dll库，用于自己安装了vlc播放器，直接调用vlc中的库文件
        //如果已经nuget对应的VideoLAN.LibVLC.Windows则会自动下载如下的库文件，也需要设置路径。
        private void vlcControl1_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDire = new FileInfo(currentAssembly.Location).DirectoryName;
            if (currentDire != null)
            {
                if (IntPtr.Size == 4)
                {
                    e.VlcLibDirectory = new DirectoryInfo(Path.GetFullPath(@".\libvlc\win-x86\"));
                }
                else
                {
                    e.VlcLibDirectory = new DirectoryInfo(Path.GetFullPath(@".\libvlc\win-x64\"));
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //网络媒体播放
            //var videoUri = new Uri("udp://@:ip:port");
            var videoUri = new Uri(textBox1.Text);
            vlcControl8.Play(videoUri);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            decimal i = numericUpDown1.Value;
            if (i >= 0 && i < 9)
            {
                vlcs[Convert.ToInt32(i)].Stop();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            decimal i = numericUpDown1.Value;
            if (i >= 0 && i < 9)
            {
                vlcs[Convert.ToInt32(i)].Size = new Size(vlcs[Convert.ToInt32(i)].Size.Width * 3, vlcs[Convert.ToInt32(i)].Size.Height * 3);
                vlcs[Convert.ToInt32(i)].BringToFront();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            decimal i = numericUpDown1.Value;
            if (i >= 0 && i < 9)
            {
                vlcs[Convert.ToInt32(i)].BringToFront();
                vlcs[Convert.ToInt32(i)].Size = new Size(vlcs[Convert.ToInt32(i)].Size.Width / 3, vlcs[Convert.ToInt32(i)].Size.Height / 3);
            }
        }
    }
}
