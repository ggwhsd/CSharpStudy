using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MarketRiskUI
{
    public partial class DragExample : Form
    {
        public DragExample()
        {
            InitializeComponent();
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.listView1.SelectedItems.Count != 0)
            {
                this.listView1.DoDragDrop(this.listView1.SelectedItems[0], DragDropEffects.Copy);
            }
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            string format = e.Data.GetFormats()[0];
            ListViewItem item = (ListViewItem)e.Data.GetData(format);
            this.treeView1.Nodes.Add(item.Text);
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private bool isMouseDown = false;
        private Point mouseOffset; //记录鼠标指针的坐标
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOffset.X = e.X;
                mouseOffset.Y = e.Y;
                isMouseDown = true;

            }
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                int left = button1.Left + e.X - mouseOffset.X;
                int top = button1.Top + e.Y - mouseOffset.Y;
                button1.Location = new Point(left, top);
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            Array array = ((System.Array)e.Data.GetData(DataFormats.FileDrop));
            StringBuilder sbuilder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                sbuilder.AppendLine(array.GetValue(i).ToString());
            }
            textBox1.Text = sbuilder.ToString();
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
