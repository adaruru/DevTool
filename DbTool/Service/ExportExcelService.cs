// DevTool 1.1 
// Copyright (C) 2024, Adaruru

using System.Diagnostics;
using System.Reflection;
using OfficeOpenXml;

public class ExportExcelService
{
    public string DownloadImportDescriptionTemplate(Schema Schema, string connStrBox)
    {
        //範本或規格 Excel 檔案名稱
        string destinationPath = Path.Combine(Directory.GetCurrentDirectory(), "ImportDescription.xlsx");
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        string message = $"{Lan.currentLan.FileGenerationCompleted}{destinationPath}";

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
            var columnSheet = package.Workbook.Worksheets.Copy("ColumnSample", $"{i + 1}");

            for (int r = 0; r < Schema.Tables[i].Columns.Count(); r++)
            {
                var column = 0;
                columnSheet.Cells[1, 1].Value = Schema.Tables[i].TableName;
                columnSheet.Cells[1, 2].Value = Schema.Tables[i].TableDescription;

                column++;
                columnSheet.Cells[2, column].Value = "Column";
                columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].ColumnName;

                column++;
                columnSheet.Cells[2, column].Value = "Description";
                columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].ColumnDescription;
                if (string.IsNullOrWhiteSpace(Schema.Tables[i].Columns[r].ColumnDescription))
                {
                    columnSheet.Cells[r + 3, column].Value = Lan.currentLan.PleaseEnter;
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
        return message;
    }

    public string ExportExcelSchema(Schema Schema, string connStrBox)
    {
        string message = string.Empty;

        if (!string.IsNullOrEmpty(FormControl.CustomThemeName))
        {
            //use custom template
            Stream resourceStream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), $"CustomTheme/{FormControl.CustomThemeName}"), FileMode.Open, FileAccess.Read);
            if (resourceStream == null)
            {
                MessageBox.Show($"resource {FormControl.CustomThemeName} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return message;
            }
            message += ProcessPackageSet(Schema, connStrBox, resourceStream);
        }
        else
        {
            //use default template
            string resourceName = "DbTool.Template.StyleTemplate.xlsx";
            Assembly assembly = Assembly.GetExecutingAssembly();
            using Stream resourceStream = assembly.GetManifestResourceStream(resourceName);
            if (resourceStream == null)
            {
                MessageBox.Show($"Embedded resource '{resourceName}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return message;
            }
            message += ProcessPackageSet(Schema, connStrBox, resourceStream);
        }
        return message;
    }
    public string ProcessPackageSet(Schema Schema, string connStrBox, Stream resourceStream)
    {
        //Excel 檔案名稱
        string destinationPath = Path.Combine(Directory.GetCurrentDirectory(), $"{Schema.SchemaName}Schema_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx");
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        string message = $"{Lan.currentLan.FileGenerationCompleted}{destinationPath}";

        var package = new ExcelPackage(resourceStream);
        var styleSheet = package.Workbook.Worksheets["StyleTemplate"];
        var tableListHeaderStyle = styleSheet.Cells[1, 1];
        var tableListStyle = styleSheet.Cells[2, 1];
        var columnTableNameStyle = styleSheet.Cells[3, 1];
        var columnHeaderStyle = styleSheet.Cells[4, 1];
        var columnStyle = styleSheet.Cells[5, 1];

        var tocSheet = package.Workbook.Worksheets.Add(Lan.currentLan.TableLists);
        for (int i = 0; i < Schema.Tables.Count; i++)
        {
            tocSheet.Cells[1, 1].Value = Lan.currentLan.Table;
            tocSheet.Cells[i + 2, 1].Value = Schema.Tables[i].TableName;

            if (FormControl.IsTableDescriptionShow)
            {
                tocSheet.Cells[1, 2].Value = Lan.currentLan.TableDescription;
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
                    columnSheet.Cells[2, column].Value = Lan.currentLan.Sort;
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Sort;
                }
                column++;
                columnSheet.Cells[2, column].Value = Lan.currentLan.Column;
                columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].ColumnName;

                if (FormControl.IsDataTypeShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = Lan.currentLan.DataType;
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].DataType;
                }
                if (FormControl.IsDefaultValueShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = Lan.currentLan.DefaultValue;
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].DefaultValue;
                }
                if (FormControl.IsIdentityShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = Lan.currentLan.Identity;
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Identity;
                }
                if (FormControl.IsPrimaryKeyShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = Lan.currentLan.PrimaryKey;
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].PrimaryKey;
                }
                if (FormControl.IsNotNullShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = Lan.currentLan.NotNull;
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].NotNull;
                }
                if (FormControl.IsLengthShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = Lan.currentLan.Length;
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Length;
                }
                if (FormControl.IsPrecisionShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = Lan.currentLan.Precision;
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Precision;
                }
                if (FormControl.IsScaleShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = Lan.currentLan.Scale;
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].Scale;
                }
                if (FormControl.IsColumnDescriptionShow)
                {
                    column++;
                    columnSheet.Cells[2, column].Value = Lan.currentLan.ColumnDescription;
                    columnSheet.Cells[r + 3, column].Value = Schema.Tables[i].Columns[r].ColumnDescription;
                }

                columnSheet.Cells.AutoFitColumns(); // 調整欄寬
                columnSheet.View.TabSelected = false;// 設置為不選取狀態

                //設置 table 樣式
                using (var range = columnSheet.Cells[1, 1, 1, 2])
                {
                    columnTableNameStyle.CopyStyles(range);
                }
                using (var range = columnSheet.Cells[2, 1, 2, column])
                {
                    columnHeaderStyle.CopyStyles(range);
                }
                using (var range = columnSheet.Cells[3, 1, Schema.Tables[i].Columns.Count + 2, column])
                {
                    columnStyle.CopyStyles(range);
                }
            }
        }

        tocSheet.Cells.AutoFitColumns();//調整欄寬
        //設置 toc 樣式
        using (var range = tocSheet.Cells[1, 1, 1, 2])
        {
            tableListHeaderStyle.CopyStyles(range);
        }
        using (var range = tocSheet.Cells[2, 1, Schema.Tables.Count + 1, 2])
        {
            tableListStyle.CopyStyles(range);
        }

        // 開啟時只選取 TableLists
        package.Workbook.View.ActiveTab = 0;
        package.Workbook.Worksheets.Delete("StyleTemplate");

        package.SaveAs(new FileInfo(destinationPath));
        Process.Start(new ProcessStartInfo
        {
            FileName = destinationPath,
            UseShellExecute = true
        });

        return message;
    }
}