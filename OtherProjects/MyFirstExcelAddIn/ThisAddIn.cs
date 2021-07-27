using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace MyFirstExcelAddIn
{
    public partial class ThisAddIn
    {
        public Excel.Application ExcelApp = null;
        Microsoft.Office.Tools.CustomTaskPane ctp;
        UserControl1 u1 = new UserControl1();
        UserControl1 u2 = new UserControl1();
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            ExcelApp = Globals.ThisAddIn.Application;  //获取当前excel程序的控制权
            //ExcelApp.ActiveCell.Value = "ExcelAddInStart";
            /*Form1 f = new Form1();
            f.Show();*/
            ctp = Globals.ThisAddIn.CustomTaskPanes.Add(u1,"task panel 1");
            ctp.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionBottom;
            ctp.Visible = true;

            ctp = Globals.ThisAddIn.CustomTaskPanes.Add(u2, "task panel 2");
            ctp.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionLeft;
            ctp.Visible = true;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {

        }

        #region VSTO 生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
