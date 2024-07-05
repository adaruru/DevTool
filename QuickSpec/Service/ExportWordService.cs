using DbTool.Service;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using System.Diagnostics;
using System.Reflection;
using WordTable = DocumentFormat.OpenXml.Wordprocessing.Table;

public class ExportWordService
{
    public string ExportWordSchema(List<Class> classObject)
    {
        string resourceName = "QuickSpec.Template.spec.docx";

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
                   ["Title"] = $"資料庫規格",
                   ["PubDate"] = $"{DateTime.Now:yyyy年MM月dd日HH:mm:ss}",
               });

        string destinationPath = Path.Combine(Directory.GetCurrentDirectory(), $"Schema_{DateTime.Now:yyyyMMddHHmmss}.docx");
        File.WriteAllBytes(destinationPath, docxBytes);

        //附於現有檔案
        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(destinationPath, true))
        {
            MainDocumentPart mainPart = wordDoc.MainDocumentPart;
            AddHeadingStyles(mainPart);

            var BorderSingle = BorderValues.Single;

            for (int i = 0; i < classObject.Count; i++)
            {
                var p1 = GetParagraphHeading1($"1.{i + 1}{classObject[i].ClassName}");
                mainPart.Document.Body.AppendChild(p1);

                var funcs = classObject[i].Funcs;
                for (int j = 0; j < funcs.Count; j++)
                {
                    var p2 = GetParagraphHeading2($"1.{i + 1}.{j + 1}{funcs[j].FuncName}");
                    mainPart.Document.Body.AppendChild(p2);

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

                    var r3 = GetColumnHeaderRow(funcs[j].FuncName);
                    table.Append(r3);

                    var r4 = GetTableRow("簡要說明：", funcs[j].Brif);
                    table.Append(r4);

                    var r5 = GetTableRow("使用角色/功能：", funcs[j].UseRole);
                    table.Append(r5);

                    var r6 = GetTableRow("事件的基本流程：", funcs[j].Flow);
                    table.Append(r6);

                    var r7 = GetTableRow("Input 條件：", funcs[j].InputCon);
                    table.Append(r7);

                    var r8 = GetTableRow("Output 條件：", funcs[j].OutputCon);
                    table.Append(r8);

                    var r9 = GetTableRow("規格描述(業務規格)：", funcs[j].SpecDes);
                    table.Append(r9);

                    var r10 = GetTableRow("延伸點：", "NA");
                    table.Append(r10);

                    var r11 = GetTableRow("其他：", "NA");
                    table.Append(r11);

                    // Add the table to the document body
                    mainPart.Document.Body.AppendChild(table);
                    AddNewLine(mainPart);
                }
            }
            mainPart.Document.Save();
        }

        Process.Start(new ProcessStartInfo(destinationPath) { UseShellExecute = true });
        return destinationPath;
    }


    public TableRow GetColumnHeaderRow(string h)
    {
        TableRow tr = new TableRow();
        var cells = new List<TableCell>();
        cells.Add(GetCellFont10FilledColor(h));
        tr.Append(cells);
        return tr;
    }

    public TableCell GetCellFont10FilledColor(string text)
    {
        // 創建 Run 並設置字體大小和粗體
        var run = new Run(new Text(text));
        run.RunProperties = new RunProperties(
            new FontSize { Val = "24" },
            new Bold(),
            new RunFonts { Ascii = "Calibri", EastAsia = "標楷體" }  // Set font
        );

        // 創建段落並設置置中對齊
        var paragraph = new Paragraph(
            new ParagraphProperties(
                new Justification() { Val = JustificationValues.Center }
            ),
            run
        );

        var cell = new TableCell(paragraph);

        // 設置單元格屬性（僅包含背景色）
        TableCellProperties tcp = new TableCellProperties(
            new Shading()
            {
                Color = "auto",
                Fill = "#99CCFF", //itsBlue //"#82B3D4",//blue //"D9EAD3", green
                Val = ShadingPatternValues.Clear
            }
        );
        cell.Append(tcp);
        return cell;
    }

    public TableRow GetTableRow(string title, string content)
    {
        TableRow tr = new TableRow();
        var titleRun = new Run(new Text(title));
        titleRun.RunProperties = new RunProperties(
            new FontSize { Val = "24" },
            new Bold(),  // 设置粗体
            new RunFonts { Ascii = "Calibri", EastAsia = "標楷體" }  // Set font
        );
        var titleParagraph = new Paragraph(titleRun);

        // Split content by newlines
        var lines = content.Split(new[] { "\r\n", "\n" }, StringSplitOptions.TrimEntries);

        // 创建内容文本
        // Create content paragraphs for each line
        var contentParagraphs = lines.Select(line =>
        {
            var contentRun = new Run(new Text(line));
            contentRun.RunProperties = new RunProperties(
                new FontSize { Val = "24" },
                new RunFonts { Ascii = "Calibri", EastAsia = "標楷體" }  // Set font
            );
            return new Paragraph(contentRun);
        }).ToList();

        var cell = new TableCell(titleParagraph);
        foreach (var paragraph in contentParagraphs)
        {
            cell.Append(paragraph);
        }
        tr.Append(cell);
        return tr;
    }

    public TableCell GetCellFont12(string text)
    {
        var run = new Run(new Text(text));
        run.RunProperties = new RunProperties(new FontSize { Val = "24" });
        var paragraph = new Paragraph(run);
        return new TableCell(paragraph);
    }

    private Paragraph GetParagraphHeading2(string text)
    {
        // Create a run with the specified text
        Run run = new Run(new Text(text));

        // Set run properties to apply the desired font
        run.RunProperties = new RunProperties(
            new RunFonts { Ascii = "Calibri", EastAsia = "標楷體" }  // Set the font
        );

        // Create a paragraph and add the run
        Paragraph paragraph = new Paragraph(run);

        // Create paragraph properties and set the style to Heading1
        ParagraphProperties pPr = new ParagraphProperties();
        ParagraphStyleId paragraphStyleId = new ParagraphStyleId() { Val = "Heading2" };
        pPr.Append(paragraphStyleId);

        // Add the paragraph properties to the paragraph
        paragraph.PrependChild(pPr);
        return paragraph;
    }
    private Paragraph GetParagraphHeading1(string text)
    {
        // Create a run with the specified text
        Run run = new Run(new Text(text));

        // Set run properties to apply the desired font
        run.RunProperties = new RunProperties(
            new RunFonts { Ascii = "Calibri", EastAsia = "標楷體" }  // Set the font
        );

        // Create a paragraph and add the run
        Paragraph paragraph = new Paragraph(run);

        // Create paragraph properties and set the style to Heading1
        ParagraphProperties pPr = new ParagraphProperties();
        ParagraphStyleId paragraphStyleId = new ParagraphStyleId() { Val = "Heading1" };
        pPr.Append(paragraphStyleId);

        // Add the paragraph properties to the paragraph
        paragraph.PrependChild(pPr);
        return paragraph;
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
