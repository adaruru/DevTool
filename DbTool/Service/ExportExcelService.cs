using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.Reflection;
using Color = System.Drawing.Color;

public class ExportExcelService
{

    public string ExportExcelSchema(Schema Schema, string connStrBox)
    {
        //範本或規格 Excel 檔案名稱
        string destinationPath = Path.Combine(Directory.GetCurrentDirectory(), $"{Schema.SchemaName}Schema_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx");
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        string message = $"檔案產製完成儲存於{destinationPath}";

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

            var tableSheet = package.Workbook.Worksheets[Schema.Tables[i].TableName];
            if (tableSheet == null)
            {
                tableSheet = package.Workbook.Worksheets.Add(Schema.Tables[i].TableName);
            }
            else
            {
                //處理sheet超出31字元同名的情況
                tableSheet = package.Workbook.Worksheets.Add($"{i}-{Schema.Tables[i].TableName}");
            }

            for (int r = 0; r < Schema.Tables[i].Columns.Count(); r++)
            {
                var column = 0;
                tableSheet.Cells[1, 1].Value = Schema.Tables[i].TableName;

                if (FormControl.IsTableDescriptionShow)
                {
                    tableSheet.Cells[1, 2].Value = Schema.Tables[i].TableDescription;
                }

                if (FormControl.IsSortShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "Sort";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Sort;
                }
                column++;
                tableSheet.Cells[2, column].Value = "Column";
                tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].ColumnName;

                if (FormControl.IsDataTypeShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "DataType";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].DataType;
                }
                if (FormControl.IsDefaultValueShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "DefaultValue";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].DefaultValue;
                }
                if (FormControl.IsIdentityShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "Identity";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Identity;
                }
                if (FormControl.IsPrimaryKeyShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "PrimaryKey";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].PrimaryKey;
                }
                if (FormControl.IsNotNullShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "NotNull";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].NotNull;
                }
                if (FormControl.IsLengthShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "Length";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Length;
                }
                if (FormControl.IsPrecisionShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "Precision";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Precision;
                }
                if (FormControl.IsScaleShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "Scale";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Scale;
                }
                if (FormControl.IsColumnDescriptionShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "Description";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].ColumnDescription;
                }

                tableSheet.Cells.AutoFitColumns(); //調整欄寬
                tableSheet.View.TabSelected = false;// 設置為不選取狀態

                //設置table樣式
                using (var range = tableSheet.Cells[1, 1, 1, 2])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.Lavender);
                }
                using (var range = tableSheet.Cells[2, 1, 2, column])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                }
                using (var range = tableSheet.Cells[3, 1, Schema.Tables[i].Columns.Count + 2, column])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightCyan);
                }

                using (var range = tableSheet.Cells[1, 1, Schema.Tables[i].Columns.Count + 2, column])
                {
                    // Set the border for the range
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    range.Style.Border.Top.Color.SetColor(Color.Black);
                    range.Style.Border.Left.Color.SetColor(Color.Black);
                    range.Style.Border.Right.Color.SetColor(Color.Black);
                    range.Style.Border.Bottom.Color.SetColor(Color.Black);
                }
            }
        }

        tocSheet.Cells.AutoFitColumns();//調整欄寬
        using (var range = tocSheet.Cells[1, 1, 1, 2])
        {
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
        }
        using (var range = tocSheet.Cells[2, 1, Schema.Tables.Count + 1, 2])
        {
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(Color.LightCyan);
        }
        using (var range = tocSheet.Cells[1, 1, Schema.Tables.Count + 1, 2])
        {
            // Set the border for the range
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            range.Style.Border.Top.Color.SetColor(Color.Black);
            range.Style.Border.Left.Color.SetColor(Color.Black);
            range.Style.Border.Right.Color.SetColor(Color.Black);
            range.Style.Border.Bottom.Color.SetColor(Color.Black);
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
            var tableSheet = package.Workbook.Worksheets[Schema.Tables[i].TableName];
            if (tableSheet == null)
            {
                tableSheet = package.Workbook.Worksheets.Copy("ColumnSample", Schema.Tables[i].TableName);
            }
            else
            {
                //處理sheet超出31字元同名的情況
                tableSheet = package.Workbook.Worksheets.Copy("ColumnSample", $"{i}-{Schema.Tables[i].TableName}");
            }

            for (int r = 0; r < Schema.Tables[i].Columns.Count(); r++)
            {
                var column = 0;
                tableSheet.Cells[1, 1].Value = Schema.Tables[i].TableName;
                if (FormControl.IsTableDescriptionShow)
                {
                    tableSheet.Cells[1, 2].Value = Schema.Tables[i].TableDescription;
                }

                if (FormControl.IsSortShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "Sort";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Sort;
                }
                column++;
                tableSheet.Cells[2, column].Value = "Column";
                tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].ColumnName;

                if (FormControl.IsDataTypeShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "DataType";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].DataType;
                }
                if (FormControl.IsDefaultValueShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "DefaultValue";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].DefaultValue;
                }
                if (FormControl.IsIdentityShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "Identity";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Identity;
                }
                if (FormControl.IsPrimaryKeyShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "PrimaryKey";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].PrimaryKey;
                }
                if (FormControl.IsNotNullShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "NotNull";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].NotNull;
                }
                if (FormControl.IsLengthShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "Length";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Length;
                }
                if (FormControl.IsPrecisionShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "Precision";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Precision;
                }
                if (FormControl.IsScaleShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "Scale";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Scale;
                }
                if (FormControl.IsColumnDescriptionShow)
                {
                    column++;
                    tableSheet.Cells[2, column].Value = "Description";
                    tableSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].ColumnDescription;
                }
                tableSheet.Cells.AutoFitColumns(); //調整欄寬
                tableSheet.View.TabSelected = false;// 設置為不選取狀態
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
}
