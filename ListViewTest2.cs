using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketRiskUI
{
    public partial class ListViewTest2 : Form
    {
        public ListViewTest2()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 使用组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.listView1.Columns.Add("列标题1", 120, HorizontalAlignment.Left); //一步添加
            this.listView1.Columns.Add("列标题2", 120, HorizontalAlignment.Left); //一步添加
            this.listView1.Columns.Add("列标题3", 120, HorizontalAlignment.Left); //一步添加
            this.listView1.Columns.Add("列标题4", 120, HorizontalAlignment.Left); //一步添加
            this.listView1.Columns.Add("列标题5", 120, HorizontalAlignment.Left); //一步添加
            ListViewGroup man_lvg = new ListViewGroup();
            man_lvg.Header = "男生";
            man_lvg.Name = "man";
            man_lvg.HeaderAlignment = HorizontalAlignment.Left;
            ListViewGroup women_lvg = new ListViewGroup();
            women_lvg.Header = "女生";
            women_lvg.Name = "women";
            listView1.Groups.Add(man_lvg);
            listView1.Groups.Add(women_lvg);
            listView1.ShowGroups = true;


            for (int i = 0; i < 5; i++)
            {
                ListViewItem lvi = new ListViewItem();
                //lvi.ImageIndex = i;
                lvi.Text = "item" + i;
                lvi.ForeColor = Color.Blue;
                lvi.SubItems.Add("第2列 " + i + "行");

                lvi.SubItems.Add("第3列 " + i + "行");
                lvi.SubItems.Add("1");
                lvi.SubItems.Add("");
                man_lvg.Items.Add(lvi);
                listView1.Items.Add(lvi);
            }

            for (int i = 0; i < 5; i++)
            {
                ListViewItem lvi = new ListViewItem();
                //lvi.ImageIndex = i;
                lvi.Text = "item" + i;
                lvi.ForeColor = Color.Blue;
                lvi.SubItems.Add("第2列 " + i + "行");

                lvi.SubItems.Add("第3列 " + i + "行");
                lvi.SubItems.Add("1");
                lvi.SubItems.Add("");
                women_lvg.Items.Add(lvi);
                listView1.Items.Add(lvi);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listView1.Items)
            {
                StringBuilder sbstr = new StringBuilder();
                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    sbstr.Append(item.SubItems[i].Text + ",");
                }
                Console.WriteLine(sbstr.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems)  //选中项遍历
            {
                listView1.Items.RemoveAt(lvi.Index); // 按索引移除
                                                     //listView1.Items.Remove(lvi);   //按项移除
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems)  //选中项遍历
            {
                int value = Int32.Parse(lvi.SubItems[3].Text);
                value += 1;
                lvi.SubItems[3].Text = value.ToString();
            }
        }

 
        private void button5_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems)  //选中项遍历
            {
                int value = Int32.Parse(lvi.SubItems[3].Text);
                value -= 1;
                lvi.SubItems[3].Text = value.ToString();
            }
        }
        //listview本身不支持，给listview添加一个按钮
        private Button btn = new Button();
        private void btn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems)  //选中项遍历
            {
                MessageBox.Show("ddd");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            btn.Visible = false;
            btn.Text = "测试按钮";
            btn.Click += this.btn_Click;
            this.btn.Size = new Size(this.listView1.Items[0].SubItems[4].Bounds.Width,
            this.listView1.Items[0].SubItems[4].Bounds.Height);
            listView1.Controls.Add(btn);
        }

        //让添加的按钮只显示再选中的单元格上，
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                this.btn.Size = new Size(this.listView1.Items[0].SubItems[4].Bounds.Width,
            this.listView1.Items[0].SubItems[4].Bounds.Height);
                this.btn.Location = new Point(lvi.SubItems[4].Bounds.Left,
            lvi.SubItems[4].Bounds.Top);
                this.btn.Visible = true;
            }
        }

        private void listView1_ChangeUICues(object sender, UICuesEventArgs e)
        {
            MessageBox.Show("ChangeUICues");
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            MessageBox.Show("DrawItem");
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            MessageBox.Show("Resize");
        }
    }
}
