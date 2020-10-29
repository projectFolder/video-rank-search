using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace 네이버_플레이스_추출기.Class_Directory
{
    class saveExcel
    {

        ListView lstview;

        public saveExcel(ListView list)
        {
            this.lstview = list;
        }

        public void excelSave()
        {

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            String filePath = null;
            SaveFileDialog fd = new SaveFileDialog();
            fd.Title = "추출내용을 저장할 엑셀파일을 선택해주세요.";
            fd.Filter = "엑셀파일|*.xlsx";
            fd.InitialDirectory = Environment.CurrentDirectory;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                filePath = fd.FileName.ToString();
            }

            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Cells[1, 1] = "번호";
            xlWorkSheet.Cells[1, 2] = "키워드";
            xlWorkSheet.Cells[1, 3] = "검색제목";
            xlWorkSheet.Cells[1, 4] = "PC순위";
            xlWorkSheet.Cells[1, 5] = "모바일순위";

            for (int i = 1; i <= lstview.Items.Count; i++)
            {
                xlWorkSheet.Cells[i + 1, 1] = lstview.Items[i - 1].SubItems[1].Text;
                xlWorkSheet.Cells[i + 1, 2] = lstview.Items[i - 1].SubItems[2].Text;
                xlWorkSheet.Cells[i + 1, 3] = lstview.Items[i - 1].SubItems[3].Text;
                xlWorkSheet.Cells[i + 1, 4] = lstview.Items[i - 1].SubItems[4].Text;
                xlWorkSheet.Cells[i + 1, 5] = lstview.Items[i - 1].SubItems[5].Text;
            }

            xlWorkBook.SaveAs(filePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, misValue,
            misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

        }

    }
}
