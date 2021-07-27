using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace MyFirstExcelAddIn
{
    class MyAppContext
    {
        public static Excel.Application ExcelApp;   
        public static Office.CommandBar commandBar;  //工具栏
        public static Microsoft.Office.Tools.ActionsPane actionsPane;
    }
}
