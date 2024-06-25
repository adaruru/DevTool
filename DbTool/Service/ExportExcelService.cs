using DocumentFormat.OpenXml.Presentation;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.Reflection;
using Color = System.Drawing.Color;

public class ExportExcelService
{
    public string ExportExcelSchema(Schema Schema, string connStrBox)
    {
        //Excel 檔案名稱
        string destinationPath = Path.Combine(Directory.GetCurrentDirectory(), $"{Schema.SchemaName}Schema_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx");
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        string message = $"檔案產製完成儲存於{destinationPath}";

        //use template
        string resourceName = "DbTool.Template.StyleTemplate.xlsx";
        Assembly assembly = Assembly.GetExecutingAssembly();
        using Stream resourceStream = assembly.GetManifestResourceStream(resourceName);
        if (resourceStream == null)
        {
            MessageBox.Show($"Embedded resource '{resourceName}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return message;
        }

        ExcelStyle tableListHeaderStyle;
        ExcelStyle tableListStyle;
        ExcelStyle columnTableNameStyle;
        ExcelStyle columnHeaderStyle;
        ExcelStyle columnStyle;
        using (var templatePack = new ExcelPackage(resourceStream))
        {
            var styleSheet = templatePack.Workbook.Worksheets["StyleTemplate"];
            tableListHeaderStyle = styleSheet.Cells[1, 1].Style;
            tableListStyle = styleSheet.Cells[2, 1].Style;
            columnTableNameStyle = styleSheet.Cells[3, 1].Style;
            columnHeaderStyle = styleSheet.Cells[4, 1].Style;
            columnStyle = styleSheet.Cells[5, 1].Style;
        }

        using var package = new ExcelPackage();
        var tocSheet = package.Workbook.Worksheets.Add("TableLists");
        for (int i = 0; i < Schema.Tables.Count; i++)
        {
            tocSheet.Cells[1, 1].Value = "Table";
            tocSheet.Cells[i + 2, 1].Value = Schema.Tables[i].TableName;

            if (FormControl.IsTableDescriptionShow)
            {
                tocSheet.Cells[1, 2].Value = "Description";
                tocSheet.Cells[i + 2, 2].Value = Schema.Tables[i].TableDescription;
            }

            var columnSheet = package.Workbook.Worksheets[Schema.Tables[i].TableName];
            if (columnSheet == null)
            {
                columnSheet = package.Workbook.Worksheets.Add(Schema.Tables[i].TableName);
            }
            else
            {
                //處理sheet超出31字元同名的情況
                columnSheet = package.Workbook.Worksheets.Add($"{i}-{Schema.Tables[i].TableName}");
            }

            for (int r = 0; r < Schema.Tables[i].Columns.Count(); r++)
            {
                var column = 0;
                columnSheet.Cells[1, 1].Value = Schema.Tables[i].TableName;

                if (FormControl.IsTableDescriptionShow)
                {
                    columnSheet.Cells[1, 2].Value = Schema.Tables[i].TableDescription;
                }

                if (FormControl.IsSortShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "Sort";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Sort;
                }
                column++;
                columnSheet.Cells[2, column].Value = "Column";
                columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].ColumnName;

                if (FormControl.IsDataTypeShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "DataType";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].DataType;
                }
                if (FormControl.IsDefaultValueShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "DefaultValue";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].DefaultValue;
                }
                if (FormControl.IsIdentityShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "Identity";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Identity;
                }
                if (FormControl.IsPrimaryKeyShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "PrimaryKey";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].PrimaryKey;
                }
                if (FormControl.IsNotNullShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "NotNull";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].NotNull;
                }
                if (FormControl.IsLengthShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "Length";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Length;
                }
                if (FormControl.IsPrecisionShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "Precision";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Precision;
                }
                if (FormControl.IsScaleShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "Scale";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Scale;
                }
                if (FormControl.IsColumnDescriptionShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "Description";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].ColumnDescription;
                }

                columnSheet.Cells.AutoFitColumns(); //調整欄寬
                columnSheet.View.TabSelected = false;// 設置為不選取狀態

                //設置table樣式
                using (var range = columnSheet.Cells[1, 1, 1, 2])
                {
                    //range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //range.Style.Fill.BackgroundColor.SetColor(Color.Lavender);
                }
                using (var range = columnSheet.Cells[2, 1, 2, column])
                {
                    //range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //range.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                }
                using (var range = columnSheet.Cells[3, 1, Schema.Tables[i].Columns.Count + 2, column])
                {
                    //range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //range.Style.Fill.BackgroundColor.SetColor(Color.LightCyan);
                }

                using (var range = columnSheet.Cells[1, 1, Schema.Tables[i].Columns.Count + 2, column])
                {
                    // Set the border for the range
                    //range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    //range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    //range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    //range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    //range.Style.Border.Top.Color.SetColor(Color.Black);
                    //range.Style.Border.Left.Color.SetColor(Color.Black);
                    //range.Style.Border.Right.Color.SetColor(Color.Black);
                    //range.Style.Border.Bottom.Color.SetColor(Color.Black);
                }
            }
        }

        tocSheet.Cells.AutoFitColumns();//調整欄寬
        using (var range = tocSheet.Cells[1, 1, 1, 2])
        {
            //range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //range.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
        }
        using (var range = tocSheet.Cells[2, 1, Schema.Tables.Count + 1, 2])
        {
            //range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //range.Style.Fill.BackgroundColor.SetColor(Color.LightCyan);
        }

        using (var range = tocSheet.Cells[1, 1, Schema.Tables.Count + 1, 2])
        {
            // Set the border for the range
            //range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            //range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            //range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            //range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            //range.Style.Border.Top.Color.SetColor(Color.Black);
            //range.Style.Border.Left.Color.SetColor(Color.Black);
            //range.Style.Border.Right.Color.SetColor(Color.Black);
            //range.Style.Border.Bottom.Color.SetColor(Color.Black);
        }

        // 開啟時只選取TableLists
        package.Workbook.View.ActiveTab = 0;

        package.SaveAs(new FileInfo(destinationPath));
        Process.Start(new ProcessStartInfo
        {
            FileName = destinationPath,
            UseShellExecute = true
        });
        return destinationPath;
    }

    public string ExportExcelSchemaWithTemplate(Schema Schema, string connStrBox, bool isTemplate)
    {
        //範本或規格 Excel 檔案名稱
        string destinationPath = isTemplate ?
            Path.Combine(Directory.GetCurrentDirectory(), "ImportDescription.xlsx") :
            Path.Combine(Directory.GetCurrentDirectory(), $"{Schema.SchemaName}Schema_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx");
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        string message = $"檔案產製完成儲存於{destinationPath}";

        //use template
        string resourceName = "DbTool.Template.Schema.xlsx";
        Assembly assembly = Assembly.GetExecutingAssembly();
        using Stream resourceStream = assembly.GetManifestResourceStream(resourceName);
        if (resourceStream == null)
        {
            MessageBox.Show($"Embedded resource '{resourceName}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return message;
        }

        using var package = new ExcelPackage(resourceStream);
        var tocSheet = package.Workbook.Worksheets["TableLists"];
        for (int i = 0; i < Schema.Tables.Count; i++)
        {
            tocSheet.Cells[1, 1].Value = "Table";
            tocSheet.Cells[i + 2, 1].Value = Schema.Tables[i].TableName;

            if (FormControl.IsTableDescriptionShow)
            {
                tocSheet.Cells[1, 2].Value = "Description";
                tocSheet.Cells[i + 2, 2].Value = Schema.Tables[i].TableDescription;
            }

            if (isTemplate && Schema.Tables[i].TableName.Length > 31)
            {
                message += $"{Schema.Tables[i].TableName}名稱超過31字元，不支援excel匯入，請自行修改資料庫描述";
                continue;
            }
            var columnSheet = package.Workbook.Worksheets[Schema.Tables[i].TableName];
            if (columnSheet == null)
            {
                columnSheet = package.Workbook.Worksheets.Copy("ColumnSample", Schema.Tables[i].TableName);
            }
            else
            {
                //處理sheet超出31字元同名的情況
                columnSheet = package.Workbook.Worksheets.Copy("ColumnSample", $"{i}-{Schema.Tables[i].TableName}");
            }

            for (int r = 0; r < Schema.Tables[i].Columns.Count(); r++)
            {
                var column = 0;
                columnSheet.Cells[1, 1].Value = Schema.Tables[i].TableName;
                if (FormControl.IsTableDescriptionShow)
                {
                    columnSheet.Cells[1, 2].Value = Schema.Tables[i].TableDescription;
                }

                if (FormControl.IsSortShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "Sort";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Sort;
                }
                column++;
                columnSheet.Cells[2, column].Value = "Column";
                columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].ColumnName;

                if (FormControl.IsDataTypeShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "DataType";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].DataType;
                }
                if (FormControl.IsDefaultValueShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "DefaultValue";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].DefaultValue;
                }
                if (FormControl.IsIdentityShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "Identity";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Identity;
                }
                if (FormControl.IsPrimaryKeyShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "PrimaryKey";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].PrimaryKey;
                }
                if (FormControl.IsNotNullShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "NotNull";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].NotNull;
                }
                if (FormControl.IsLengthShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "Length";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Length;
                }
                if (FormControl.IsPrecisionShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "Precision";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Precision;
                }
                if (FormControl.IsScaleShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "Scale";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Scale;
                }
                if (FormControl.IsColumnDescriptionShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = "Description";
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].ColumnDescription;
                }
                columnSheet.Cells.AutoFitColumns(); //調整欄寬
                columnSheet.View.TabSelected = false;// 設置為不選取狀態
            }
        }
        tocSheet.Cells.AutoFitColumns();//調整欄寬
        package.Workbook.Worksheets.Delete("ColumnSample");

        // 開啟時只選取TableLists
        package.Workbook.View.ActiveTab = 0;

        package.SaveAs(new FileInfo(destinationPath));
        Process.Start(new ProcessStartInfo
        {
            FileName = destinationPath,
            UseShellExecute = true
        });
        return destinationPath;
    }

    private void CopyStyle(ExcelStyle source, ExcelStyle destination)
    {
        // Copy Fill
        destination.Fill.PatternType = source.Fill.PatternType;
        destination.Fill.BackgroundColor.SetColor(Color.AliceBlue);
        destination.Fill.PatternColor.SetColor(Color.AliceBlue);

        // Copy Font
        destination.Font.Name = source.Font.Name;
        destination.Font.Size = source.Font.Size;
        destination.Font.Bold = source.Font.Bold;
        destination.Font.Italic = source.Font.Italic;
        destination.Font.UnderLine = source.Font.UnderLine;
        destination.Font.Strike = source.Font.Strike;
        destination.Font.Color.SetColor(Color.Black);

        // Copy Border
        CopyBorderStyle(source.Border.Top, destination.Border.Top);
        CopyBorderStyle(source.Border.Bottom, destination.Border.Bottom);
        CopyBorderStyle(source.Border.Left, destination.Border.Left);
        CopyBorderStyle(source.Border.Right, destination.Border.Right);

        // Copy Alignment
        destination.HorizontalAlignment = source.HorizontalAlignment;
        destination.VerticalAlignment = source.VerticalAlignment;
        destination.WrapText = source.WrapText;
        destination.TextRotation = source.TextRotation;
        destination.Indent = source.Indent;
        destination.ReadingOrder = source.ReadingOrder;
    }

    private void CopyBorderStyle(ExcelBorderItem source, ExcelBorderItem destination)
    {
        destination.Style = source.Style;
        destination.Color.SetColor(Color.Black);
    }
}
