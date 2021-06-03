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
    class MyDataSource
    {
        public int Value { get; set; }
    }
    public class BlogNew
    {
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
    }
    class datagridviewBindMethod : Form
    {
        private BindingSource bindingSource1;

        private TextBox textBox1;
        private TextBox textBox2;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        public datagridviewBindMethod()
        {
            InitializeControlsAndDataSource();
        }
        //通过bindingsource方式，将一个数据源同时绑定到datagridview和textbox上，并且实现了双向更新显示
        //textBox上更新，会同步更新到数据源，数据源再反向显示到datagridivew
        //datagridview上更新，会同步到数据源，再反向到textBox

        private void InitializeControlsAndDataSource()
        {
            // Initialize the controls and set location, size and
            // other basic properties.
            this.dataGridView1 = new DataGridView();
            this.dataGridView2 = new DataGridView();
            this.bindingSource1 = new BindingSource();
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();
            this.textBox3 = new TextBox();
            this.textBox4 = new TextBox();
            button1 = new Button();
            this.dataGridView1.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = DockStyle.None;
            this.dataGridView1.Location = new Point(0, 0);
            this.dataGridView1.Size = new Size(292, 150);
            this.dataGridView2.ColumnHeadersHeightSizeMode =
               DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = DockStyle.None;
            this.dataGridView2.Location = new Point(0, 300);
            this.dataGridView2.Size = new Size(292, 150);
            this.textBox1.Location = new Point(132, 156);
            this.textBox1.Size = new Size(100, 20);
            this.textBox2.Location = new Point(12, 156);
            this.textBox2.Size = new Size(100, 20);
            this.textBox3.Location = new Point(12, 180);
            this.textBox3.Size = new Size(100, 20);
            this.textBox4.Location = new Point(12, 210);
            this.textBox4.Size = new Size(100, 20);
            this.button1.Location = new Point(12, 240);
            this.button1.Size = new Size(100, 20);
            this.button1.Text = "文本框和属性值绑定";
            this.ClientSize = new Size(292, 266);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);

            button1.Click += Button1_Click;

            // Declare the DataSet and add a table and column.
            DataSet set1 = new DataSet();
            set1.Tables.Add("Menu");
            set1.Tables[0].Columns.Add("Beverages");

            // Add some rows to the table.
            set1.Tables[0].Rows.Add("coffee");
            set1.Tables[0].Rows.Add("tea");
            set1.Tables[0].Rows.Add("hot chocolate");
            set1.Tables[0].Rows.Add("milk");
            set1.Tables[0].Rows.Add("orange juice");

            // Set the data source to the DataSet.
            bindingSource1.DataSource = set1;

            //Set the DataMember to the Menu table.
            bindingSource1.DataMember = "Menu";

            //方式1：gridview和text绑定dataset，可以实现双向同步. UI<->data
            dataGridView1.DataSource = bindingSource1;
            textBox1.DataBindings.Add("Text", bindingSource1,
                "Beverages", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text", bindingSource1,
                "Beverages", true, DataSourceUpdateMode.OnPropertyChanged);
            bindingSource1.BindingComplete +=
                new BindingCompleteEventHandler(bindingSource1_BindingComplete);

            //方式2：这个主要就是通过本身拥有的属。 UI->data  直接绑定某个属性，当控件值被用户更新，会自动修改shareValue，但是shareValue后续变化无法更新到控件。
            this.textBox3.DataBindings.Add("Text", this, "shareValue", false, DataSourceUpdateMode.OnPropertyChanged);

            //方式3：自定义简单类数据. UI->data. UI上数据更新，data数据也会更新
            MyDataSource my = new MyDataSource();
            my.Value = 111;
            textBox4.DataBindings.Add("Text", my, "Value", false, DataSourceUpdateMode.OnPropertyChanged);

            //方式4：List<BlogNew>，该方式，后续ui更新，不会再更新到原来的data上。data更新，也不会反应到ui上。
            blogNews = new List<BlogNew>();
            blogNews.Add(new BlogNew { BlogID = 1, BlogTitle = "人生若只如初见" });
            blogNews.Add(new BlogNew { BlogID = 2, BlogTitle = "何事秋风悲画扇" });
            blogNews.Add(new BlogNew { BlogID = 3, BlogTitle = "最喜欢纳兰性德" });
            dataGridView1.DataSource = null;
            dataGridView1.DataBindings.Add("DataSource", this, "blogNews", false, DataSourceUpdateMode.OnPropertyChanged);

            //方式5：BindingList，ui更新，data也会更新。 data更新，ui也会更新
            blogNewsRegardUI = new BindingList<BlogNew>();
            blogNewsRegardUI.Add(new BlogNew { BlogID = 11, BlogTitle = "僵卧孤村不自哀" });
            blogNewsRegardUI.Add(new BlogNew { BlogID = 12, BlogTitle = "尚思为国戍轮台" });
            blogNewsRegardUI.Add(new BlogNew { BlogID = 13, BlogTitle = "夜阑卧听风吹雨" });

            dataGridView2.DataBindings.Add("DataSource", this, "blogNewsRegardUI", false, DataSourceUpdateMode.OnPropertyChanged);

        }
        public int shareValue { get; set; }
        public List<BlogNew> blogNews { get; set; }
        public BindingList<BlogNew> blogNewsRegardUI { get; set; }


        private void Button1_Click(object sender, EventArgs e)
        {
            /*
                        var data = dataGridView1.DataSource as List<BlogNew>;
                        data.Add(new BlogNew { BlogID = 4, BlogTitle = "取次花丛懒回顾，半缘修道半缘君" });

                        foreach (BlogNew blogNew in dataGridView1.DataSource as List<BlogNew>)
                        {
                            MessageBox.Show(blogNew.BlogID + "--" + blogNew.BlogTitle);
                        }
                        */

            //如下操作数据源都可以更新到datagridview2，都可以双向绑定更新。
            var dataRegardUI = dataGridView2.DataSource as BindingList<BlogNew>;
            //dataRegardUI.Add(new BlogNew { BlogID = 20, BlogTitle = "竹外桃花三两枝，春江水暖鸭先知" });
            blogNewsRegardUI.Add(new BlogNew { BlogID = 20, BlogTitle = "三两" });

        }

        private void bindingSource1_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            // Check if the data source has been updated, and that no error has occurred.
            if (e.BindingCompleteContext ==
                BindingCompleteContext.DataSourceUpdate && e.Exception == null)
            {
                Console.WriteLine("If not, end the current edit");
                // If not, end the current edit.
                e.Binding.BindingManagerBase.EndCurrentEdit();
            }
        }
    }
}
