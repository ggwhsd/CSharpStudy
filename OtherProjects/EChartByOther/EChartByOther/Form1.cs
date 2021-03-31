using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EChartByOther
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = System.Environment.CurrentDirectory;
            this.webBrowser1.Url = new Uri(str + "\\..\\..\\webPage\\" + comboBox1.Text.Trim());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            webBrowser1.AllowWebBrowserDrop = false;
            webBrowser1.IsWebBrowserContextMenuEnabled = false;
            webBrowser1.WebBrowserShortcutsEnabled = false;
            webBrowser1.ScriptErrorsSuppressed = true;

            //（这个属性比较重要，可以通过这个属性，把WINFROM中的变量，传递到JS中，供内嵌的网页使用；但设置到的类型必须是COM可见的，所以要设置     [System.Runtime.InteropServices.ComVisibleAttribute(true)]，因为我的值设置为this,所以这个特性要加载窗体类上）
            webBrowser1.ObjectForScripting = this;
            string str = System.Environment.CurrentDirectory;
            string[] paths = Directory.GetFiles(str + "\\..\\..\\webPage\\");
            foreach (var item in paths)
            {
                //获取文件后缀名  
                string extension = Path.GetExtension(item).ToLower();
                if (extension == ".html")
                {
                    comboBox1.Items.Add(Path.GetFileName(item));
                }
            }

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
                this.webBrowser1.Url = new Uri(str + "\\" + comboBox1.Text.Trim());
            }
        }
    }
}
