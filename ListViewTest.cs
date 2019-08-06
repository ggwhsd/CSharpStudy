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
    public partial class ListViewTest : Form
    {
        public ListViewTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListView lv = listView1;
            //添加列名
            ColumnHeader c1 = new ColumnHeader();
            c1.Width = 100;
            c1.Text = "姓名";
            ColumnHeader c2 = new ColumnHeader();
            c2.Width = 100;
            c2.Text = "性别";
            ColumnHeader c3 = new ColumnHeader();
            c3.Width = 100;
            c3.Text = "电话";
            //设置属性
            lv.GridLines = true;  //显示网格线
            lv.FullRowSelect = true;  //显示全行
            lv.MultiSelect = false;  //设置只能单选
            lv.View = View.Details;  //设置显示模式为详细
            lv.HoverSelection = true;  //当鼠标停留数秒后自动选择
            //把列名添加到listview中
            lv.Columns.Add(c1);
            lv.Columns.Add(c2);
            lv.Columns.Add(c3);
            lv.Columns.Add("籍贯", 100);  //相当于上面的添加列名的步骤

        }

        private void button2_Click(object sender, EventArgs e)
        {
           // this.listView1.BeginUpdate(); //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
                                          //获取文本框中的值
            string name = this.txtName.Text;
            string sex = this.txtSex.Text;
            string phone = this.txtPhone.Text;
            string address = this.txtAddress.Text;
            //创建行对象
            ListViewItem li = new ListViewItem(name);
            //添加同一行的数据
            li.SubItems.Add(sex);
            li.SubItems.Add(phone);
            li.SubItems.Add(address);
            //将行对象绑定在listview对象中
            listView1.Items.Add(li);
            MessageBox.Show("新增数据成功！");
            
            //  this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {

                //把修改后的文本框内容添加到listview中
                listView1.SelectedItems[0].SubItems[0].Text = this.txtName.Text;
                listView1.SelectedItems[0].SubItems[1].Text = this.txtSex.Text;
                listView1.SelectedItems[0].SubItems[2].Text = this.txtPhone.Text;
                listView1.SelectedItems[0].SubItems[3].Text = this.txtAddress.Text;
                MessageBox.Show("修改数据成功！");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //当有选择行的数据时
           
            if (listView1.Items.Count > 0)
            {
                foreach (ListViewItem li in listView1.Items)
                {
                        li.BackColor = SystemColors.Window;
                }
             
            }

            if (this.listView1.SelectedItems.Count > 0)
            {

                //把选择的信息显示在相应的文本框中
                this.txtName.Text = this.listView1.SelectedItems[0].SubItems[0].Text;
                this.txtSex.Text = this.listView1.SelectedItems[0].SubItems[1].Text;
                this.txtPhone.Text = this.listView1.SelectedItems[0].SubItems[2].Text;
                this.txtAddress.Text = this.listView1.SelectedItems[0].SubItems[3].Text;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                //移除整一行
                this.listView1.SelectedItems[0].Remove();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //列表有数据
            if (listView1.Items.Count > 0)
            {
                foreach (ListViewItem li in listView1.Items)
                {
                    if (li.SubItems[0].Text == this.textBox1.Text)
                    {
                        MessageBox.Show("存在该名称");
                        return;
                    }
                }
                MessageBox.Show("没有找到该姓名");
            }
            else
            {
                MessageBox.Show("未输入列表数据");
            }
        }

        private void listView1_Leave(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems[0].BackColor = Color.FromArgb(255,0,120,215); //第一个参数为透明度，越大越不透明。
            }
        }
    }
}
