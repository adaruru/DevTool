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
        string resourceName = FormControl.isWordWithToc ? "DbTool.Template.SchemaToc.docx" : "DbTool.Template.Schema.docx";

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
                   ["Source"] = $"{connStrBox}"
               });

        string destinationPath = Path.Combine(Directory.GetCurrentDirectory(), $"{Schema.SchemaName}{DateTime.Now:yyyyMMddHHmmss}.docx");
        File.WriteAllBytes(destinationPath, docxBytes);

        //新建 using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(destinationPath, true))
        {
            MainDocumentPart mainPart = wordDoc.MainDocumentPart;
            AddHeadingStyles(mainPart);

            // 建立一個新的段落，用於產生一個空行
            Paragraph emptyParagraph = new Paragraph(new Run(new Text("")));
            mainPart.Document.Body.AppendChild(emptyParagraph);

            var Borderval = new EnumValue<BorderValues>(BorderValues.Single);
            var schemaTable = Schema.Tables;

            for (int i = 0; i < schemaTable.Count; i++)
            {
                Paragraph p1 = new Paragraph(new Run(new Text($"TableName : {schemaTable[i].TableName}  {schemaTable[i].TableDescription}")));
                SetStyle(p1, "Heading1");
                mainPart.Document.Body.AppendChild(p1);

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

                //var r1 = GetTableRow();
                //table.Append(r1);
                //var r2 = GetTableDescriptionRow(schemaTable[i]);
                //table.Append(r2);
                var r3 = GetColumnHeaderRow();
                table.Append(r3);

                var schemaCulumn = schemaTable[i].Columns;
                for (int j = 0; j < schemaCulumn.Count; j++)
                {
                    var tr = GetColumnValueRow(schemaCulumn[j]);
                    table.Append(tr);
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
    public TableRow GetTableRow()
    {
        var tr = new TableRow();
        var c1 = new TableCell(
            new Paragraph(new Run(new Text($"TableName"))));
        var c2 = new TableCell(
            new Paragraph(new Run(new Text($"TableDescription"))));
        // Set cell properties
        var tcp1 = new TableCellProperties(
            new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = "2500" }
            );
        c1.Append(tcp1);
        tr.Append(c1);
        tr.Append(c2);
        return tr;
    }
    public TableRow GetTableDescriptionRow(Table schemaTable)
    {
        var tr = new TableRow();
        var c3 = new TableCell(
            new Paragraph(
                new Run(
                    new Text($"{schemaTable.TableName}"))));
        var c4 = new TableCell(
            new Paragraph(
                new Run(
                    new Text($"{schemaTable.TableDescription}"))));
        // Set cell properties
        var tcp2 = new TableCellProperties(
            new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = "2500" }
            );
        c3.Append(tcp2);
        tr.Append(c3);
        tr.Append(c4);
        return tr;
    }
    public TableRow GetColumnHeaderRow()
    {
        TableRow tr = new TableRow();
        var cells = new List<TableCell>();
        if (FormControl.IsSortShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text("Sort"))));
            cells.Add(c);
        }
        if (FormControl.IsDataTypeShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text("DataType"))));
            cells.Add(c);
        }
        if (FormControl.IsDefaultValueShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text("DefaultValue"))));
            cells.Add(c);
        }
        if (FormControl.IsIdentityShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text("Identity"))));
            cells.Add(c);
        }
        if (FormControl.IsPrimaryKeyShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text("PrimaryKey"))));
            cells.Add(c);
        }
        if (FormControl.IsNotNullShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text("NotNull"))));
            cells.Add(c);
        }
        if (FormControl.IsLengthShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text("Length"))));
            cells.Add(c);
        }
        if (FormControl.IsPrecisionShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text("Precision"))));
            cells.Add(c);
        }
        if (FormControl.IsScaleShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text("Scale"))));
            cells.Add(c);
        }
        if (FormControl.IsColumnDescriptionShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text("Description"))));
            cells.Add(c);
        }
        var count = cells.Count() == 0 ? 1 : cells.Count();
        var width = 5000 / count;
        // Set cell properties
        TableCellProperties tcp = new TableCellProperties(
            new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = width.ToString() }
        );
        for (int ci = 0; ci < cells.Count; ci++)
        {
            if (ci == 0)
            {
                cells[ci].AppendChild(tcp);
            }
            tr.Append(cells[ci]);
        }
        return tr;
    }
    public TableRow GetColumnValueRow(Column column)
    {
        TableRow tr = new TableRow();
        var cells = new List<TableCell>();

        if (FormControl.IsSortShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text(column.Sort))));
            cells.Add(c);
        }
        if (FormControl.IsDataTypeShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text(column.DataType))));
            cells.Add(c);
        }
        if (FormControl.IsDefaultValueShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text(column.DefaultValue))));
            cells.Add(c);
        }
        if (FormControl.IsIdentityShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text(column.Identity))));
            cells.Add(c);
        }
        if (FormControl.IsPrimaryKeyShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text(column.PrimaryKey))));
            cells.Add(c);
        }
        if (FormControl.IsNotNullShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text(column.NotNull))));
            cells.Add(c);
        }
        if (FormControl.IsLengthShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text(column.Length))));
            cells.Add(c);
        }
        if (FormControl.IsPrecisionShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text(column.Precision))));
            cells.Add(c);
        }
        if (FormControl.IsScaleShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text(column.Scale))));
            cells.Add(c);
        }
        if (FormControl.IsColumnDescriptionShow)
        {
            var c = new TableCell(new Paragraph(new Run(new Text(column.ColumnDescription))));
            cells.Add(c);
        }
        var count = cells.Count() == 0 ? 1 : cells.Count();
        var width = 5000 / count;
        // Set cell properties
        TableCellProperties tcp = new TableCellProperties(
            new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = width.ToString() }
        );
        for (int ci = 0; ci < cells.Count; ci++)
        {
            if (ci == 0)
            {
                cells[ci].AppendChild(tcp);
            }
            tr.Append(cells[ci]);
        }
        return tr;
    }

    public void ExportWordSchemaPerTable(Schema Schema, string connStrBox)
    {
        //use template
        string resourceName = FormControl.isWordWithToc ? "DbTool.Template.SchemaToc.docx" : "DbTool.Template.Schema.docx";
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
                   ["Title"] = "XXXX資料庫規格",
                   ["PubDate"] = "2021-04-01",
                   ["Source"] = "XXXXX 連線字串"
               });
        string destinationPath = Path.Combine(Directory.GetCurrentDirectory(), $"Schema_{DateTime.Now:HHmmss}.docx");
        File.WriteAllBytes(destinationPath, docxBytes);

        //新建 using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(destinationPath, true))
        {
            // Add a main document part
            MainDocumentPart mainPart = wordDoc.MainDocumentPart;
            mainPart.Document = new Document();
            Body body = mainPart.Document.AppendChild(new Body());

            // Create a table
            WordTable table = new WordTable();

            var Borderval = new EnumValue<BorderValues>(BorderValues.Single);
            // Set table properties
            TableProperties tblProps = new TableProperties(
                new TableWidth { Width = "10000", Type = TableWidthUnitValues.Pct }, // 設定表格寬度為頁面寬度的50%
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

            // Add rows and cells to the table
            for (int r = 0; r < 3; r++)
            {
                TableRow tr = new TableRow();
                if (r == 0)
                {
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
                        new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = "5000" }
                        );
                    cell1.Append(tcp);
                    tr.Append(cell1);
                    tr.Append(cell2);
                }
                else
                {
                    for (int column = 0; column < 3; column++)
                    {
                        TableCell cell = new TableCell(new Paragraph(new Run(new Text($"Cell {r + 1},{column + 1}"))));
                        // Set cell properties
                        TableCellProperties tcp = new TableCellProperties(
                            new TableCellWidth { Type = TableWidthUnitValues.Dxa, Width = "2400" }
                        );
                        cell.Append(tcp);
                        tr.Append(cell);
                    }
                }
                table.Append(tr);
            }

            // Add the table to the document body
            body.AppendChild(table);
        }

        Process.Start(new ProcessStartInfo(destinationPath) { UseShellExecute = true });
    }

    private void SetStyle(Paragraph paragraph, string styleId)
    {
        ParagraphProperties pPr = new ParagraphProperties();
        ParagraphStyleId paragraphStyleId = new ParagraphStyleId() { Val = styleId };
        pPr.Append(paragraphStyleId);
        paragraph.PrependChild(pPr);
    }

    private void AddHeadingStyles(MainDocumentPart mainPart)
    {
        StyleDefinitionsPart styleDefinitionsPart = mainPart.StyleDefinitionsPart;
        if (styleDefinitionsPart == null)
        {
            styleDefinitionsPart = mainPart.AddNewPart<StyleDefinitionsPart>();
            styleDefinitionsPart.Styles = new Styles();
        }

        Styles styles = styleDefinitionsPart.Styles;

        // 添加 Heading1 样式
        Style heading1 = new Style()
        {
            Type = StyleValues.Paragraph,
            StyleId = "Heading1",
            CustomStyle = true
        };
        heading1.Append(new StyleName() { Val = "Heading 1" });
        heading1.Append(new BasedOn() { Val = "Normal" });
        heading1.Append(new NextParagraphStyle() { Val = "Normal" });
        heading1.Append(new UIPriority() { Val = 9 });
        heading1.Append(new PrimaryStyle());
        heading1.Append(new StyleParagraphProperties(
            new SpacingBetweenLines() { Before = "240", After = "60" },
            new OutlineLevel() { Val = 1 }));
        styles.Append(heading1);

        // 添加 Heading2 样式
        Style heading2 = new Style()
        {
            Type = StyleValues.Paragraph,
            StyleId = "Heading2",
            CustomStyle = true
        };
        heading2.Append(new StyleName() { Val = "Heading 2" });
        heading2.Append(new BasedOn() { Val = "Normal" });
        heading2.Append(new NextParagraphStyle() { Val = "Normal" });
        heading2.Append(new UIPriority() { Val = 9 });
        heading2.Append(new PrimaryStyle());
        heading2.Append(new StyleParagraphProperties(
            new SpacingBetweenLines() { Before = "240", After = "60" },
            new OutlineLevel() { Val = 2 }));
        styles.Append(heading2);
    }

}
