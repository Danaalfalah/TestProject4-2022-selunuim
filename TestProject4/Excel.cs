using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject4
    {
    class Excel
        {

        Application excel = new Application();
        Workbook wb;
        Worksheet wh;

        public void OpenExcel(string path , int sheet)
            {
            wb = excel.Workbooks.Open(path);
            wh = wb.Worksheets[sheet];
            }
        public string ReadExcel(int c , int r)
            {
            return wh.Cells[c][r].value.ToString();
            }

        public void CloseExcel()
            {
            excel.Workbooks.Close();
            }
        }
    }
