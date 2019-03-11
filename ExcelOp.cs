using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;

namespace MarketRiskUI
{
    class ExcelOp
    {
        public string str_Filename;
        Application app;
        Workbooks wbks;
        public Workbook wb;
        public Worksheets wss;
        public Worksheet ws;


        /// <summary>
        /// 创建一个Excel对象
        /// </summary>
        public void Create()
        {
            app = new Application();
            wbks = app.Workbooks;
            wb = wbks.Add(true);
        }

        /// <summary>
        /// 打开
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool Open(string filename,bool isDisplay)
        {
            try
            {
                object missing = System.Reflection.Missing.Value;
                app = new Application();
                wbks = app.Workbooks;
                wb = wbks.Open(filename, true, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
                str_Filename = filename;
                app.Visible = isDisplay;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public Worksheet GetSheet(string SheetName)
        {
            Worksheet s = (Worksheet)wb.Worksheets[SheetName];
            return s;
        }

        public Worksheet AddSheet(string SheetName)
        {
            Worksheet s = (Worksheet)wb.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            s.Name = SheetName;
            return s;
        }

        /// <summary>
        /// 复制并添加一个工作表
        /// </summary>
        /// <param name="OldSheetName"> 被复制工作表</param>
        /// <param name="NewSheetName">新表</param>
        public void CloneSheet(string OldSheetName, string NewSheetName)
        {
            Microsoft.Office.Interop.Excel.Worksheet oldSheet = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[OldSheetName];
            oldSheet.Copy(oldSheet, Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet s = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[OldSheetName + " (2)"];
            s.Name = NewSheetName;
        }

        /// <summary>
        /// 删除一个工作表
        /// </summary>
        /// <param name="SheetName">工作表名称</param>
        public void DelSheet(string SheetName)
        {
            ((Worksheet)wb.Worksheets[SheetName]).Delete();
        }

        /// <summary>
        /// 设置单元格的值
        /// </summary>
        /// <param name="ws">工作表</param>
        /// <param name="x">行标</param>
        /// <param name="y">列标</param>
        /// <param name="value">数据</param>
        public void SetCellValue(Worksheet ws, int x, int y, object value)
        {
            ws.Cells[x, y] = value;
        }

        public void SetCellValue(string sheetname, int x, int y, object value)
        {
            GetSheet(sheetname).Cells[x, y] = value;
        }

        public string GetCellValue(string sheetname, int x, int y)
        {
            return GetSheet(sheetname).Cells[x, y].Text.ToString();
        }


        /// <summary>
        /// 设置单元格属性
        /// </summary>
        /// <param name="ws">工作表</param>
        /// <param name="Startx">起始行标</param>
        /// <param name="Starty">起始列标</param>
        /// <param name="Endx">终止行标</param>
        /// <param name="Endy">终止列标</param>
        /// <param name="size">字体大小</param>
        /// <param name="name">字体</param>
        /// <param name="color">颜色</param>
        /// <param name="HorizontalAlignment">对齐方式</param>
        public void SetCellProperty(Worksheet ws, int Startx, int Starty, int Endx, int Endy, int size, string name, int color)
        {
            ws.Range[ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]].Font.Name = name;
            ws.Range[ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]].Font.Size = size;
            ws.Range[ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]].Font.ColorIndex = color;
        }

        public void SetCellProperty1(string sheetname, int Startx, int Starty, int Endx, int Endy, int size, string name, int color)
        {
            ws = GetSheet(sheetname);
            ws.Range[ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]].Font.Name = name;
            ws.Range[ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]].Font.Size = size;
            ws.Range[ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]].Font.ColorIndex = color;
            //ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).HorizontalAlignment = HorizontalAlignment;
        }

        /// <summary>
        /// 将内存中数据表格插入到Excel指定工作表的指定位置
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="ws">工作表名称</param>
        /// <param name="startX">起始行标</param>
        /// <param name="startY">起始列标</param>
        public void InsertTable(System.Data.DataTable dt, string ws, int startX, int startY)
        {
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= dt.Columns.Count - 1; j++)
                {
                    GetSheet(ws).Cells[startX + i, j + startY] = dt.Rows[i][j];
                }
            }
        }


        /// <summary>
        /// 保存文档
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            if (str_Filename == "")
            {
                return false;
            }
            else
            {
                try
                {
                    wb.Save();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// 文档另存为
        /// </summary>
        /// <param name="FileName">文件名（包含路径）</param>
        /// <returns></returns>
        public bool SaveAs(object FileName)
        {
            try
            {
                wb.SaveAs(FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Close()
        {
            wb.Close(Type.Missing, Type.Missing, Type.Missing);
            wbks.Close();
            app.DisplayAlerts = false;
            app.Quit();
            wb = null;
            wbks = null;
            app = null;
            GC.Collect();
        }

    }
}
