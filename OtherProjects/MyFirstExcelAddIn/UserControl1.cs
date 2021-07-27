using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace MyFirstExcelAddIn
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
           
        }
        private Excel.Application ExcelApp = null;

        public Excel.Application ExcelApp1 { get => ExcelApp; set => ExcelApp = value; }
        private void button1_Click(object sender, EventArgs e)
        {
            //控制excel
            ExcelApp = Globals.ThisAddIn.Application;
            Excel.Worksheet sheet = ExcelApp.ActiveSheet;
            Excel.Range rg;
            try
            {
                rg = (Excel.Range)ExcelApp.Selection;
                rg.Interior.Color = Color.Green;
            }
            catch (Exception)
            { }


        }
    }
}
