using System.Data;
using OfficeOpenXml;

namespace webmvc.Models.Process
{
    public class ExcelProcess
    {
        public DataTable ReadExcelToDataTable(string filePath)
        {
            var dt = new DataTable();

            // bắt buộc với EPPlus


            FileInfo fileInfo = new FileInfo(filePath);

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // sheet 1

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                // 👉 tạo cột (header)
                for (int col = 1; col <= colCount; col++)
                {
                    dt.Columns.Add(worksheet.Cells[1, col].Value?.ToString());
                }

                // 👉 đọc dữ liệu từ dòng 2
                for (int row = 2; row <= rowCount; row++)
                {
                    DataRow dr = dt.NewRow();

                    for (int col = 1; col <= colCount; col++)
                    {
                        dr[col - 1] = worksheet.Cells[row, col].Value?.ToString();
                    }

                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }
    }
}