using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MarketRiskUI
{
    /*
        * 数据源绑定方式 以及 使用 virtualMode方式 操作datagridview。
        * datagridview的virtualMode打开后，可以使用xxxNeeded函数。
        * virtualMode和datasource没有必然关联，可以不关联。
        */
    public partial class Form_datagidview2 : Form
    {
        public Form_datagidview2()
        {
            InitializeComponent();
        }
       
        private void SetupGridView()
        {
            DataGridView songsDataGridView = dgv1;
          
            //列头样式
            songsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            songsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            songsDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(songsDataGridView.Font, FontStyle.Bold);

            songsDataGridView.Name = "dgv";
            //行高
            songsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            //列头边框
            songsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //单元格
            songsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            //行头边框
            songsDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //网格线
            //songsDataGridView.GridColor = Color.Black;
            songsDataGridView.GridColor = Color.BlueViolet;
            //最前面的第一列空列是否显示
            songsDataGridView.RowHeadersVisible = true;
            //边框样式
            songsDataGridView.BorderStyle = BorderStyle.FixedSingle;

            songsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            songsDataGridView.MultiSelect = false;
        }
        private DataTable dt = null;

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                PopulateGridView_VirtualMode();
            }
            else
            {
                PopulateGridView_noVirtualMode();
            }
        }
        private void PopulateGridView_VirtualMode()
        {
            //创建一个名为"Table_New"的空表
            if (dt == null)
            {
                dt = new DataTable("test");
                dt.Columns.Add("Choice", System.Type.GetType("System.String"));
                dt.Columns.Add("Name", System.Type.GetType("System.String"));
                dt.Columns.Add("Date", typeof(String));
                DataColumn dc = new DataColumn("Title", typeof(String));
                dt.Columns.Add(dc);
                for (int i = 0; i < 5; i++)
                {
                    dt.Columns.Add("Column" + i, typeof(String));
                }

                DataGridViewCheckBoxColumn CheckColunms = new DataGridViewCheckBoxColumn();
                CheckColunms.Name = "Choice";
                CheckColunms.HeaderText = "Choice";

                CheckColunms.Width = 60;
                CheckColunms.TrueValue = "1";
                CheckColunms.FalseValue = "0";

                CheckColunms.DataPropertyName = "Choice";

                dgv1.Columns.Insert(0, CheckColunms);


                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                col.Name = "Name";
                col.HeaderText = "Name";
                dgv1.Columns.Add(col);

                dgv1.VirtualMode = true;


            }
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            dt.Rows.Add("0", "张三", DateTime.Now.ToShortDateString(), "大boss", "AAAAAA", "AAAAAAA", "AAAAAAAA", "AAAAAAAAA", "AAAAAAAAA");//Add里面参数的数据顺序要和dt中的列的顺序对应 
            dt.Rows.Add("0", "张四", DateTime.Now.ToShortDateString(), "小boss", "AAAAAA", "AAAAAAA", "AAAAAAAA", "AAAAAAAAA", "AAAAAAAAA");//Add里面参数的数据顺序要和dt中的列的顺序对应 

        }
        private void PopulateGridView_noVirtualMode()
        {
            //创建一个名为"Table_New"的空表
            if (dt == null)
            {
                dt = new DataTable("test");
                dt.Columns.Add("Choice", System.Type.GetType("System.String"));
                dt.Columns.Add("Name", System.Type.GetType("System.String"));
                dt.Columns.Add("Date", typeof(String));
                DataColumn dc = new DataColumn("Title", typeof(String));
                dt.Columns.Add(dc);
                for (int i = 0; i < 5; i++)
                {
                    dt.Columns.Add("Column" + i, typeof(String));
                }
                DataColumn[] cols = new DataColumn[] { dt.Columns["Name"] };
                dt.PrimaryKey = cols;
                DataGridViewCheckBoxColumn CheckColunms = new DataGridViewCheckBoxColumn();
                CheckColunms.Name = "Choice";
                CheckColunms.HeaderText = "Choice";

                CheckColunms.Width = 60;
                CheckColunms.TrueValue = "1";
                CheckColunms.FalseValue = "0";

                CheckColunms.DataPropertyName = "Choice";

                dgv1.Columns.Insert(0, CheckColunms);

                //将数据表绑定
                dgv1.DataSource = dt;
               
              
                //设置以下列为只读，datagridview本身为可编辑

                dgv1.Columns[4].ReadOnly = true;
                dgv1.Columns[5].ReadOnly = true;


            }
            DataRow dr = dt.NewRow();
          
            dt.Rows.Add("0", "张三", DateTime.Now.ToShortDateString(), "大boss", "AAAAAA", "AAAAAAA", "AAAAAAAA", "AAAAAAAAA", "AAAAAAAAA");//Add里面参数的数据顺序要和dt中的列的顺序对应 
            dt.Rows.Add("0", "张四", DateTime.Now.ToShortDateString(), "小boss", "AAAAAA", "AAAAAAA", "AAAAAAAA", "AAAAAAAAA", "AAAAAAAAA");//Add里面参数的数据顺序要和dt中的列的顺序对应 

        }



        private void 获取datatable中的数据_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("{0},{1},{2}",dr[0],dr[1],dr[3]);
            }
        }

        private void dgv1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            //MessageBox.Show("CellValueNeeded");
            /// 从记录集中读取数据   
            if (e.RowIndex == dgv1.RowCount-1)
                return;
            string colName = dgv1.Columns[e.ColumnIndex].DataPropertyName;
            //e.Value = dt.Rows[e.RowIndex][colName].ToString();
            e.Value = "1";
        }

        private void dgv1_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            MessageBox.Show("CellValuePushed");
        }

        private void dgv1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            MessageBox.Show("选中了新的一行 触发了DefaultValuesNeeded");
            //未操作datatable，而是直接操作datagridview
            e.Row.Cells[0].Value = "1";
            //操作datatable
            //dt.Rows.Add("0", "张五", DateTime.Now.ToShortDateString(), "大boss", "AAAAAA", "AAAAAAA", "AAAAAAAA", "AAAAAAAAA", "AAAAAAAAA");//Add里面参数的数据顺序要和dt中的列的顺序对应 

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgv1.RowCount = 2;
        }
        private int i = 1;

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Enabled = true;
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            DataRow dr = dt.Rows.Find("Add_2");
            if (dr == null)
            {

                dr = dt.Rows.Add("0", "Add_" + i.ToString(), DateTime.Now.ToShortDateString(), "大boss", "AAAAAA", "AAAAAAA", "AAAAAAAA", "AAAAAAAAA", "AAAAAAAAA");//Add里面参数的数据顺序要和dt中的列的顺序对应 

            }
            else
            {
                dr[4] = "abcdefghigk" + i.ToString();
            }
            dgv1.InvalidateColumn(4);
            dgv1.Update();



        }
    }
}
