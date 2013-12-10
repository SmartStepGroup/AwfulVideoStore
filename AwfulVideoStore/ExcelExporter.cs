#region Usings

using System.Collections.Generic;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;

#endregion

namespace AwfulVideoStore {
    public static class ExcelExporter {
        public static ExcelPackage Export(List<Movie> films) {
            var pck = new ExcelPackage();
            var ws = pck.Workbook.Worksheets.Add("Films");

            ws.Cells["A1"].LoadFromCollection(films, true);

            using (var rng = ws.Cells["A1:C1"]) {
                rng.Style.Font.Bold = true;
                rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));
                rng.Style.Font.Color.SetColor(Color.White);
            }

            using (var col = ws.Cells[2, 1, 2 + films.Count, 1]) {
                col.Style.Numberformat.Format = "#,##0.00";
                col.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            }
            return pck;
        }
    }
}