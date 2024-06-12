using DbTool.Service;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using System.Diagnostics;
using System.Reflection;
using WordTable = DocumentFormat.OpenXml.Wordprocessing.Table;

public class ExportWordService
{
    public void ExportWordSchema(Schema Schema, string connStrBox)
    {
        //use template

        string resourceName = "DbTool.Template.Schema.docx";
        Assembly assembly = Assembly.GetExecutingAssembly();
        using Stream resourceStream = assembly.GetManifestResourceStream(resourceName);
        byte[] templateBytes;

        if (resourceStream == null)
        {
            MessageBox.Show($"Embedded resource '{resourceName}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        using (var memoryStream = new MemoryStream())
        {
            resourceStream.CopyTo(memoryStream);
            templateBytes = memoryStream.ToArray();
        }

        var docxBytes = WordRender.GenerateDocx(templateBytes,
               new Dictionary<string, string>()
               {
                   ["Title"] = $"{Schema.SchemaName}資料庫規格",
                   ["PubDate"] = $"{DateTime.Now:yyyy年MM月dd日HH:mm:ss}",
                   ["Source"] = $"連線字串 : {connStrBox}"
               });

        string destinationPath = Path.Combine(Directory.GetCurrentDirectory(), $"{Schema.SchemaName}{DateTime.Now:yyyyMMddHHmmss}.docx");
        File.WriteAllBytes(destinationPath, docxBytes);

        //新建 using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(destinationPath, true))
        {
            MainDocumentPart mainPart = wordDoc.MainDocumentPart;

            // 建立一個新的段落，用於產生一個空行
            Paragraph emptyParagraph = new Paragraph(new Run(new Text("")));
            mainPart.Document.Body.AppendChild(emptyParagraph);

            var Borderval = new EnumValue<BorderValues>(BorderValues.Single);
            var schemaTable = Schema.Tables;

            for (int i = 0; i < schemaTable.Count; i++)
            {
                WordTable table = new WordTable();
                // Set table properties
                TableProperties tblProps = new TableProperties(
                    new TableWidth { Width = "5000", Type = TableWidthUnitValues.Pct },
                    new TableBorders(
                        new TopBorder { Val = Borderval, Size = 12 },
                        new BottomBorder { Val = Borderval, Size = 12 },
                        new LeftBorder { Val = Borderval, Size = 12 },
                        new RightBorder { Val = Borderval, Size = 12 },
                        new InsideHorizontalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                        new InsideVerticalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 }
                    )
                );
                table.AppendChild(tblProps);

                var schemaCulumn = schemaTable[i].Columns;

                for (int j = 0; j < schemaCulumn.Count + 2; j++)
                {
                    if (j == 0)
                    {
                        TableRow tr = new TableRow();
                        TableCell cell1 = new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text($"Table"))));
                        TableCell cell2 = new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text($"TableDescription"))));
                        // Set cell properties
                        TableCellProperties tcp = new TableCellProperties(
                            new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = "2500" }
                            );
                        cell1.Append(tcp);
                        tr.Append(cell1);
                        tr.Append(cell2);
                        table.Append(tr);
                    }
                    if (j == 1)
                    {
                        TableRow tr = new TableRow();
                        TableCell cell1 = new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text($"{schemaTable[0].TableName}"))));
                        TableCell cell2 = new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text($"{schemaTable[0].TableDescription}"))));
                        // Set cell properties
                        TableCellProperties tcp = new TableCellProperties(
                            new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = "2500" }
                            );
                        cell1.Append(tcp);
                        tr.Append(cell1);
                        tr.Append(cell2);
                        table.Append(tr);
                    }
                    else
                    {
                        TableRow tr = new TableRow();
                        var c1 = new TableCell(new Paragraph(
                            new Run(
                                new Text($"ColumnName"))));
                        var c2 = new TableCell(new Paragraph(
                            new Run(
                                new Text($"Sort"))));
                        // Set cell properties
                        TableCellProperties tcp = new TableCellProperties(
                            new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = "410" }
                        );
                        c1.Append(tcp);
                        tr.Append(c1);
                        tr.Append(c2);
                        table.Append(tr);
                    }

                }
                // Add the table to the document body
                mainPart.Document.Body.AppendChild(table);

                Paragraph A = new Paragraph(new Run(new Text("")));
                mainPart.Document.Body.AppendChild(A);

            }
            mainPart.Document.Save();
        }

        Process.Start(new ProcessStartInfo(destinationPath) { UseShellExecute = true });
    }
}
