using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarketRiskUI
{
    public partial class MenuContext : Form
    {
        public MenuContext()
        {
            InitializeComponent();
            address = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine(address);
        }
        private string address;


        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            StreamWriter s = new StreamWriter(address + "\\MenuHistory.ini", true);
            s.WriteLine(openFileDialog1.FileName);
            s.Flush();
            s.Close();
            ShowWindows(openFileDialog1.FileName);
        }


        public void ShowWindows(string fileName)
        {
            Image p = Image.FromFile(fileName);
            Form f = new Form();
            f.MdiParent = this;
            f.BackgroundImage = p;
            f.Show();
        }

        private void MenuContext_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(address + "\\MenuHistory.ini");
            int i= this.文件ToolStripMenuItem.DropDownItems.Count - 2;
            while (sr.Peek() >= 0)
            {
                ToolStripMenuItem menuitem = new ToolStripMenuItem(sr.ReadLine());
                this.文件ToolStripMenuItem.DropDownItems.Insert(i, menuitem);
                i++;
                menuitem.Click += new EventHandler(menuitem_Click);
            }
            sr.Close();
        }
        private void menuitem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            ShowWindows(item.Text);
        }
    }
}
