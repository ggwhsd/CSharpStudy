using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace MyFirstExcelAddIn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //控制excel
            ExcelApp = Globals.ThisAddIn.Application;
        }
        private Excel.Application ExcelApp = null;

        public Excel.Application ExcelApp1 { get => ExcelApp; set => ExcelApp = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            ExcelApp.ActiveCell.Value = textBox1.Text;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ExcelApp.ActiveCell.Address;
            
        }
    }
}
