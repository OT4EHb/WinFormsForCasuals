using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace WinFormsApp1
{
    internal class ExcelExporter<T> : IDisposable
    {
        readonly Excel.Application App;
        readonly Excel.Workbook Wb;
        readonly Excel.Worksheet Ws;
        readonly string path;
        bool disposed = false;
        int row = 2;
        public ExcelExporter(string path)
        {
            try
            {
                this.path = path;
                App = new();
                Wb = App.Workbooks.Add();
                Ws = App.Worksheets[1];
                Ws.Name = typeof(T).Name;

                var properties = typeof(T).GetProperties();
                var fields = typeof(T).GetFields();
                int column = 1;
                foreach (var prop in properties)
                {
                    Ws.Cells[1, column++] = prop.Name;
                }
                foreach (var field in fields)
                {
                    Ws.Cells[1, column++] = field.Name;
                }
            }
            catch
            {
                Dispose();
                throw;
            }
        }

        ~ExcelExporter()
        {
            Dispose();
        }

        public void Dispose()
        {
            SaveAndClose();
            GC.SuppressFinalize(this);
        }

        public void AddData(IEnumerable<T> items)
        {
            ObjectDisposedException.ThrowIf(disposed, typeof(ExcelExporter<T>));
            ArgumentNullException.ThrowIfNull(items);

            var properties = typeof(T).GetProperties();
            var fields = typeof(T).GetFields();

            foreach (var item in items)
            {
                int column = 1;
                foreach (var prop in properties)
                {
                    var value = prop.GetValue(item);
                    Ws.Cells[row, column++] = FormatValue(value);
                }
                foreach (var field in fields)
                {
                    var value = field.GetValue(item);
                    Ws.Cells[row, column++] = FormatValue(value);
                }
                row++;
            }
        }

        private string FormatValue(object? value)
        {
            if (value == null) return "";
            if (value is System.Collections.IEnumerable enumerable &&
                value is not string)
            {
                var items = new List<string>();
                foreach (var item in enumerable)
                {
                    items.Add(item?.ToString() ?? "");
                }
                return string.Join("; ", items);
            }

            return value.ToString() ?? "";
        }

        public void SaveAndClose()
        {
            disposed = true;
            if (Ws != null)
            {
                Ws.UsedRange.Columns.AutoFit();
            }
            if (Wb != null)
            {
                Wb.Close(SaveChanges: true, Filename: path);
            }
            if (App != null)
            {
                App.Quit();
            }
        }
    }
}
