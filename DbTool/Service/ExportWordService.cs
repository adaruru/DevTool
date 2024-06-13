using DbTool.Service;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using System.Diagnostics;
using System.Reflection;
using WordTable = DocumentFormat.OpenXml.Wordprocessing.Table;

public class ExportWordService
{
    public string ExportWordSchema(Schema Schema, string connStrBox)
    {
        string resourceName = FormControl.isWordWithToc ? "DbTool.Template.SchemaToc.docx" : "DbTool.Template.Schema.docx";

        Assembly assembly = Assembly.GetExecutingAssembly();
        using Stream resourceStream = assembly.GetManifestResourceStream(resourceName);
        byte[] templateBytes;

        if (resourceStream == null)
        {
            MessageBox.Show($"Embedded resource '{resourceName}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "";
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

        //附於現有檔案
        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(destinationPath, true))
        {
            MainDocumentPart mainPart = wordDoc.MainDocumentPart;
            AddHeadingStyles(mainPart);

            var BorderSingle = BorderValues.Single;
            var schemaTable = Schema.Tables;
            for (int i = 0; i < schemaTable.Count; i++)
            {
                Paragraph p1 = new Paragraph(new Run(new Text($"{schemaTable[i].TableName}  {schemaTable[i].TableDescription}")));
                SetStyle(p1, "Heading1");
                mainPart.Document.Body.AppendChild(p1);

                WordTable table = new WordTable();
                // Set table properties
                TableProperties tblProps = new TableProperties(
                    new TableWidth { Width = "5000", Type = TableWidthUnitValues.Pct },
                    new TableBorders(
                        new TopBorder { Val = BorderSingle, Size = 1 },
                        new BottomBorder { Val = BorderSingle, Size = 1 },
                        new LeftBorder { Val = BorderSingle, Size = 1 },
                        new RightBorder { Val = BorderSingle, Size = 1 },
                        new InsideHorizontalBorder { Val = BorderSingle, Size = 1 },
                        new InsideVerticalBorder { Val = BorderSingle, Size = 1 },
                        new FontSize { Val = "20" }
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
                AddNewLine(mainPart);
            }
            mainPart.Document.Save();
        }

        Process.Start(new ProcessStartInfo(destinationPath) { UseShellExecute = true });
        return destinationPath;
    }

    public string ExportWordSchemaPerTable(Schema Schema, string connStrBox)
    {
        var schemaDir = Path.Combine(Directory.GetCurrentDirectory(), $"{Schema.SchemaName}資料庫規格");
        if (!Directory.Exists(schemaDir))
        {
            Directory.CreateDirectory(schemaDir);
        }

        string resourceName = FormControl.isWordWithToc ? "DbTool.Template.SchemaToc.docx" : "DbTool.Template.Schema.docx";

        var schemaTable = Schema.Tables;
        for (int i = 0; i < schemaTable.Count; i++)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using Stream resourceStream = assembly.GetManifestResourceStream(resourceName);
            byte[] templateBytes;

            if (resourceStream == null)
            {
                MessageBox.Show($"Embedded resource '{resourceName}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            using (var memoryStream = new MemoryStream())
            {
                resourceStream.CopyTo(memoryStream);
                templateBytes = memoryStream.ToArray();
            }

            var docxBytes = WordRender.GenerateDocx(templateBytes,
                   new Dictionary<string, string>()
                   {
                       ["Title"] = $"{Schema.SchemaName}-{schemaTable[i].TableName}資料表規格",
                       ["PubDate"] = $"{DateTime.Now:yyyy年MM月dd日HH:mm:ss}",
                       ["Source"] = $"{connStrBox}"
                   });

            string destinationPath = Path.Combine(schemaDir, $"{schemaTable[i].TableName}.docx");
            File.WriteAllBytes(destinationPath, docxBytes);

            //附於現有檔案
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(destinationPath, true))
            {
                MainDocumentPart mainPart = wordDoc.MainDocumentPart;
                AddHeadingStyles(mainPart);
                var BorderSingle = BorderValues.Single;
                WordTable table = new WordTable();
                // Set table properties
                TableProperties tblProps = new TableProperties(
                    new TableWidth { Width = "5000", Type = TableWidthUnitValues.Pct },
                    new TableBorders(
                        new TopBorder { Val = BorderSingle, Size = 1 },
                        new BottomBorder { Val = BorderSingle, Size = 1 },
                        new LeftBorder { Val = BorderSingle, Size = 1 },
                        new RightBorder { Val = BorderSingle, Size = 1 },
                        new InsideHorizontalBorder { Val = BorderSingle, Size = 1 },
                        new InsideVerticalBorder { Val = BorderSingle, Size = 1 },
                        new FontSize { Val = "20" }
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
                AddNewLine(mainPart);

                mainPart.Document.Save();
            }
        }
        return schemaDir;
    }

    /// <summary>
    /// 新建wrod參考
    /// </summary>
    public void UseWord()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "test.docx");
        //新建檔案
        using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
        {
            // Add a main document part
            MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
            mainPart.Document = new Document();
            Body body = mainPart.Document.AppendChild(new Body());
            WordTable table = new WordTable();
            var r1 = GetTableRow();
            table.Append(r1);
            mainPart.Document.Body.AppendChild(table);
            mainPart.Document.Save();
        }
    }
    public TableRow GetTableRow()
    {
        var tr = new TableRow();
        var c1 = GetCellFont12("TableName");
        var c2 = GetCellFont12("TableDescription");
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
        var c3 = GetCellFont12(schemaTable.TableName);
        var c4 = GetCellFont12(schemaTable.TableDescription);
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
            cells.Add(GetCellFont10FilledColor("Sort"));
        }
        if (FormControl.IsDataTypeShow)
        {
            cells.Add(GetCellFont10FilledColor("DataType"));
        }
        if (FormControl.IsDefaultValueShow)
        {
            cells.Add(GetCellFont10FilledColor("DefaultValue"));
        }
        if (FormControl.IsIdentityShow)
        {
            cells.Add(GetCellFont10FilledColor("Identity"));
        }
        if (FormControl.IsPrimaryKeyShow)
        {
            cells.Add(GetCellFont10FilledColor("PrimaryKey"));
        }
        if (FormControl.IsNotNullShow)
        {
            cells.Add(GetCellFont10FilledColor("NotNull"));
        }
        if (FormControl.IsLengthShow)
        {
            cells.Add(GetCellFont10FilledColor("Length"));
        }
        if (FormControl.IsPrecisionShow)
        {
            cells.Add(GetCellFont10FilledColor("Precision"));
        }
        if (FormControl.IsScaleShow)
        {
            cells.Add(GetCellFont10FilledColor("Scale"));
        }
        if (FormControl.IsColumnDescriptionShow)
        {
            cells.Add(GetCellFont10FilledColor("ColumnDescription"));
        }
        for (int ci = 0; ci < cells.Count; ci++)
        {
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
            cells.Add(GetCellFont10(column.Sort));
        }
        if (FormControl.IsDataTypeShow)
        {
            cells.Add(GetCellFont10(column.DataType));
        }
        if (FormControl.IsDefaultValueShow)
        {
            cells.Add(GetCellFont10(column.DefaultValue));
        }
        if (FormControl.IsIdentityShow)
        {
            cells.Add(GetCellFont10(column.Identity));
        }
        if (FormControl.IsPrimaryKeyShow)
        {
            cells.Add(GetCellFont10(column.PrimaryKey));
        }
        if (FormControl.IsNotNullShow)
        {
            cells.Add(GetCellFont10(column.NotNull));
        }
        if (FormControl.IsLengthShow)
        {
            cells.Add(GetCellFont10(column.Length));
        }
        if (FormControl.IsPrecisionShow)
        {
            cells.Add(GetCellFont10(column.Precision));
        }
        if (FormControl.IsScaleShow)
        {
            cells.Add(GetCellFont10(column.Scale));
        }
        if (FormControl.IsColumnDescriptionShow)
        {
            cells.Add(GetCellFont10(column.ColumnDescription));
        }
        for (int ci = 0; ci < cells.Count; ci++)
        {
            tr.Append(cells[ci]);
        }
        return tr;
    }
    public TableCell GetCellFont10FilledColor(string text)
    {
        var run = new Run(new Text(text));
        run.RunProperties = new RunProperties(new FontSize { Val = "20" });
        var paragraph = new Paragraph(run);
        var cell = new TableCell(paragraph);

        // Set cell properties
        TableCellProperties tcp = new TableCellProperties(
            new Shading()
            {
                Color = "auto",
                Fill = "#82B3D4",//blue //"D9EAD3", green
                Val = ShadingPatternValues.Clear
            });
        cell.Append(tcp);
        return cell;
    }

    public TableCell GetCellFont10(string text)
    {
        var run = new Run(new Text(text));
        run.RunProperties = new RunProperties(new FontSize { Val = "20" });
        var paragraph = new Paragraph(run);
        return new TableCell(paragraph);
    }
    public TableCell GetCellFont12(string text)
    {
        var run = new Run(new Text(text));
        run.RunProperties = new RunProperties(new FontSize { Val = "24" });
        var paragraph = new Paragraph(run);
        return new TableCell(paragraph);
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
    private void AddNewLine(MainDocumentPart mainPart)
    {
        Paragraph emptyParagraph = new Paragraph(new Run(new Text("")));
        mainPart.Document.Body.AppendChild(emptyParagraph);
    }
}
