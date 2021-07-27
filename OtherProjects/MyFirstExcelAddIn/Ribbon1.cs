using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Windows.Forms;

namespace MyFirstExcelAddIn
{
    public partial class Ribbon1
    {
        private Excel.Application ExcelApp = null;
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            ExcelApp = Globals.ThisAddIn.Application;
        }
        
        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            ExcelApp.ActiveCell.Value = "Robbin click";
        }

        private void group1_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            MessageBox.Show("DialogLauncher 用于扩展设置等功能");
        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            foreach (var customTaskPanel in Globals.ThisAddIn.CustomTaskPanes)
            {
                customTaskPanel.Visible = true;
            }
        }
    }
}
