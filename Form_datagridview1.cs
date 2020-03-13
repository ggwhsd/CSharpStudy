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
    /*
     * 交替行样式设计
     * this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;
this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor =
    Color.Beige;
     * /

    /*
     * 创建未绑定的 Windows 窗体 DataGridView 控件，无需绑定数据源。用于数据量较小的时候使用比较好。
     */
    public partial class Form_datagridview1 : Form
    {
        public Form_datagridview1()
        {
            InitializeComponent();
        }

        

        private void Form_datagridview1_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            PopulateDataGridView();
        }

        private void addNewRowButton_Click(object sender, EventArgs e)
        {
            this.songsDataGridView.Rows.Add();
        }

        private void deleteRowButton_Click(object sender, EventArgs e)
        {
            if (this.songsDataGridView.SelectedRows.Count > 0 &&
        this.songsDataGridView.SelectedRows[0].Index !=
        this.songsDataGridView.Rows.Count - 1)
            {
                this.songsDataGridView.Rows.RemoveAt(
                    this.songsDataGridView.SelectedRows[0].Index);
            }
        }

        private void SetupDataGridView()
        {
            songsDataGridView.ColumnCount = 5;
            //列头样式
            songsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            songsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            songsDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(songsDataGridView.Font, FontStyle.Bold);

            songsDataGridView.Name = "songsDataGridView";
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
            this.songsDataGridView.GridColor = Color.BlueViolet;
            //最前面的第一列空列是否显示
            songsDataGridView.RowHeadersVisible = true;
            //边框样式
            songsDataGridView.BorderStyle = BorderStyle.Fixed3D;

            songsDataGridView.Columns[0].Name = "Release Date";
            songsDataGridView.Columns[1].Name = "Track";
            songsDataGridView.Columns[2].Name = "Title";
            songsDataGridView.Columns[3].Name = "Artist";
            songsDataGridView.Columns[4].Name = "Album";
            songsDataGridView.Columns[4].DefaultCellStyle.Font =  new Font(songsDataGridView.DefaultCellStyle.Font, FontStyle.Italic);

            songsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            songsDataGridView.MultiSelect = false;
            songsDataGridView.Dock = DockStyle.Fill;
        }

        private void songsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (this.songsDataGridView.Columns[e.ColumnIndex].Name == "Release Date")
                {
                    if (e.Value != null)
                    {
                        try
                        {
                            e.Value = DateTime.Parse(e.Value.ToString())
                                .ToLongDateString();
                            e.FormattingApplied = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("{0} is not a valid date.", e.Value.ToString());
                        }
                    }
                }
            }
        }

        private void PopulateDataGridView()
        {

            string[] row0 = { "11/22/1968", "29", "Revolution 9",
            "Beatles", "The Beatles [White Album]" };
            string[] row1 = { "1960", "6", "Fools Rush In",
            "Frank Sinatra", "Nice 'N' Easy" };
            string[] row2 = { "11/11/1971", "1", "One of These Days",
            "Pink Floyd", "Meddle" };
            string[] row3 = { "1988", "7", "Where Is My Mind?",
            "Pixies", "Surfer Rosa" };
            string[] row4 = { "5/1981", "9", "Can't Find My Mind",
            "Cramps", "Psychedelic Jungle" };
            string[] row5 = { "6/10/2003", "13",
            "Scatterbrain. (As Dead As Leaves.)",
            "Radiohead", "Hail to the Thief" };
            string[] row6 = { "6/30/1992", "3", "Dress", "P J Harvey", "Dry" };

            songsDataGridView.Rows.Add(row0);
            songsDataGridView.Rows.Add(row1);
            songsDataGridView.Rows.Add(row2);
            songsDataGridView.Rows.Add(row3);
            songsDataGridView.Rows.Add(row4);
            songsDataGridView.Rows.Add(row5);
            songsDataGridView.Rows.Add(row6);

            songsDataGridView.Columns[0].DisplayIndex = 3;
            songsDataGridView.Columns[0].ReadOnly = true;
            songsDataGridView.Columns[1].DisplayIndex = 4;
            songsDataGridView.Columns[2].DisplayIndex = 0;
            songsDataGridView.Columns[3].DisplayIndex = 1;
            songsDataGridView.Columns[4].DisplayIndex = 2;
        }

        private void onlySet_Click(object sender, EventArgs e)
        {
            songsDataGridView.ReadOnly = true;
            songsDataGridView.AllowUserToAddRows = false;
            songsDataGridView.AllowUserToDeleteRows = false;
        }
        private bool isUseCellPainting = false;
        private void songsDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (isUseCellPainting)
            {
                if (this.songsDataGridView.Columns["Album"].Index ==
        e.ColumnIndex && e.RowIndex >= 0)
                {
                    Rectangle newRect = new Rectangle(e.CellBounds.X + 1,
                        e.CellBounds.Y + 1, e.CellBounds.Width - 4,
                        e.CellBounds.Height - 4);

                    using (
                        Brush gridBrush = new SolidBrush(this.songsDataGridView.GridColor),
                        backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                    {
                        using (Pen gridLinePen = new Pen(gridBrush))
                        {
                            // Erase the cell.
                            e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                            // Draw the grid lines (only the right and bottom lines;
                            // DataGridView takes care of the others).
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                                e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                                e.CellBounds.Bottom - 1);
                            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                                e.CellBounds.Top, e.CellBounds.Right - 1,
                                e.CellBounds.Bottom);

                            // Draw the inset highlight box.
                            e.Graphics.DrawRectangle(Pens.Blue, newRect);

                            // Draw the text content of the cell, ignoring alignment.
                            if (e.Value != null)
                            {
                                e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
                                    Brushes.Crimson, e.CellBounds.X + 2,
                                    e.CellBounds.Y + 2, StringFormat.GenericDefault);
                            }
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
                isUseCellPainting = checkBox1.Checked;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                songsDataGridView.EditMode = DataGridViewEditMode.EditOnF2;
            }
            else
            {
                songsDataGridView.EditMode = DataGridViewEditMode.EditOnKeystroke;
            }
        }
        //错误图标
        private void songsDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            /*
     CellValidating 如果单元格值验证失败, 请将Cancel System.Windows.Forms.DataGridViewCellValidatingEventArgs类的属性设置为true。 

     这将导致DataGridView控件阻止光标离开该单元格。 将行ErrorText中的属性设置为解释性字符串。 

     这会显示一个错误图标, 其中包含包含错误文本的工具提示。 

     在事件处理程序中, ErrorText将行上的属性设置为空字符串。 CellEndEdit 仅CellEndEdit当单元格退出编辑模式时, 才会发生此事件, 如果验证失败, 则无法执行此操作。

     取消此事件将取消对当前单元格所做的更改。 如果在数据绑定模式下取消此事件，则不会将新值推送到基础数据源。 如果在虚拟模式下取消此事件，则不会引发 CellValuePushed 事件。
            */
            string headerText =
         songsDataGridView.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the CompanyName column.
            if (!headerText.Equals("Track")) return;

            // Confirm that the cell is not empty.
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                songsDataGridView.Rows[e.RowIndex].Cells[0].ErrorText =
                    "error";
                e.Cancel = true;
            }
            else
            {
                songsDataGridView.Rows[e.RowIndex].Cells[0].ErrorText = "";
                e.Cancel = false;
            }
        }

        private void songsDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            MessageBox.Show("CellBeginEdit"+ e.RowIndex);
        }

        private void songsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("CellEndEdit"+e.RowIndex);
        }

        private void songsDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            
           Console.WriteLine(e.RowIndex.ToString());
            
        }

        private void songsDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }
    }
}
