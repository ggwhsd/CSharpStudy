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
    public partial class Form_datagridview3 : Form
    {
        public Form_datagridview3()
        {
            InitializeComponent();
        }
        ComboBox comboxChoose = new ComboBox();
        DateTimePicker dateTimePicker1 = new DateTimePicker();
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtSex = new DataTable();
            dtSex.Columns.Add("Value");
            dtSex.Columns.Add("Name");
            DataRow drSex;
            drSex = dtSex.NewRow();
            drSex["Name"] = "男";
            drSex["Value"] = SEX.男;
            dtSex.Rows.Add(drSex);
            drSex = dtSex.NewRow();
            drSex["Name"] = "女";
            drSex["Value"] = SEX.女;
            dtSex.Rows.Add(drSex);
            comboxChoose.ValueMember = "Value";
            comboxChoose.DisplayMember = "Name";
            comboxChoose.DataSource = dtSex;

            DataTable dtData = new DataTable();
            dtData.Columns.Add("ChineseName");
            dtData.Columns.Add("Sex");
            dtData.Columns.Add("date");
            DataRow drData;
            drData = dtData.NewRow();
            drData["ChineseName"] = "a1";
            drData["Sex"] = SEX.男.ToString();
            drData["date"] = DateTime.Now.ToString();
            dtData.Rows.Add(drData);
            drData = dtData.NewRow();
            drData["ChineseName"] = "a2";
            drData["Sex"] = SEX.女.ToString();
            drData["date"] = DateTime.Now.ToString();
            dtData.Rows.Add(drData);
            drData = dtData.NewRow();
            drData["ChineseName"] = "a3";
            drData["Sex"] = SEX.男.ToString();
            drData["date"] = DateTime.Now.ToString();
            dtData.Rows.Add(drData);
            drData = dtData.NewRow();
            drData["ChineseName"] = "a4";
            drData["Sex"] = SEX.女.ToString();
            drData["date"] = DateTime.Now.ToString();
            dtData.Rows.Add(drData);
            drData = dtData.NewRow();
            drData["ChineseName"] = "a5";
            drData["Sex"] = SEX.男.ToString();
            drData["date"] = DateTime.Now.ToString();
            dtData.Rows.Add(drData);
            dataGridView1.DataSource = dtData;

            comboxChoose.Visible = false;
            dateTimePicker1.Visible = false;
            dataGridView1.Controls.Add(comboxChoose);
            dataGridView1.Controls.Add(dateTimePicker1);
            comboxChoose.SelectedIndexChanged += new EventHandler(cmb_Temp_SelectedIndexChanged);
        }

        private void cmb_Temp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Text == SEX.男.ToString())
            {
                dataGridView1.CurrentCell.Value = SEX.男.ToString();
                dataGridView1.CurrentCell.Tag = "";
            }
            else
            {
                dataGridView1.CurrentCell.Value = SEX.女.ToString();
                dataGridView1.CurrentCell.Tag = "";
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine(e.Context.ToString() + e.Exception.Message + " " + e.GetType().ToString());
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentCell == null)
                return;
            try
            {
                if (this.dataGridView1.CurrentCell.ColumnIndex == 1)
                {
                    Rectangle rect = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, false);
                    string sexValue = dataGridView1.CurrentCell.Value.ToString();
                    if (sexValue == SEX.男.ToString())
                    {
                        comboxChoose.Text = SEX.男.ToString();
                    }
                    else
                    {
                        comboxChoose.Text = SEX.女.ToString();
                    }
                    comboxChoose.Left = rect.Left;
                    comboxChoose.Top = rect.Top;
                    comboxChoose.Width = rect.Width;
                    comboxChoose.Height = rect.Height;
                    comboxChoose.Visible = true;
                }
                else
                {
                    comboxChoose.Visible = false;
                }

                if (this.dataGridView1.CurrentCell.ColumnIndex == 2 && this.dataGridView1.CurrentCell.Value != null)
                {
                    Rectangle rect = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, false);
                    dateTimePicker1.Left = rect.Left;
                    dateTimePicker1.Top = rect.Top;
                    dateTimePicker1.Width = rect.Width;
                    dateTimePicker1.Height = rect.Height;
                    dateTimePicker1.Visible = true;
                }
                else
                {
                    dateTimePicker1.Visible = false;
                }

            }
            catch (Exception err)
            {
                Console.WriteLine(" 异常哦 111"+err.Message);
            }
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            this.comboxChoose.Visible = false;
            dateTimePicker1.Visible = false;
        }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            this.comboxChoose.Visible = false;
            dateTimePicker1.Visible = false;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
    }

    enum SEX
    {
        男,
        女
    }
}
