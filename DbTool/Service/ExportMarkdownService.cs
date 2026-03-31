// DevTool 1.1
// Copyright (C) 2024, Adaruru

using System.Diagnostics;
using System.Text;

public class ExportMarkdownService
{
    public string ExportMarkdownSchema(Schema Schema, string connStrBox)
    {
        string destinationPath = Path.Combine(Directory.GetCurrentDirectory(), $"{Schema.SchemaName}Schema_{DateTime.Now:yyyyMMddHHmmss}.md");

        var sb = new StringBuilder();
        sb.AppendLine($"# {Schema.SchemaName}資料庫規格");
        sb.AppendLine();
        sb.AppendLine($"> 產製時間：{DateTime.Now:yyyy年MM月dd日HH:mm:ss}");
        sb.AppendLine($"> 來源：{connStrBox}");
        sb.AppendLine();
        sb.AppendLine("## 目錄");
        sb.AppendLine("[[_TOC_]]");
        sb.AppendLine();

        var schemaTable = Schema.Tables;
        for (int i = 0; i < schemaTable.Count; i++)
        {
            sb.AppendLine($"## {schemaTable[i].TableName}  {schemaTable[i].TableDescription}");
            sb.AppendLine();

            // header
            var headers = new List<string>();
            headers.Add("Column");
            if (FormControl.IsSortShow) headers.Add("Sort");
            if (FormControl.IsDataTypeShow) headers.Add("DataType");
            if (FormControl.IsDefaultValueShow) headers.Add("DefaultValue");
            if (FormControl.IsIdentityShow) headers.Add("Identity");
            if (FormControl.IsPrimaryKeyShow) headers.Add("PrimaryKey");
            headers.Add("ForeignKeyTable");
            if (FormControl.IsNotNullShow) headers.Add("NotNull");
            if (FormControl.IsLengthShow) headers.Add("Length");
            if (FormControl.IsPrecisionShow) headers.Add("Precision");
            if (FormControl.IsScaleShow) headers.Add("Scale");
            if (FormControl.IsColumnDescriptionShow) headers.Add("ColumnDescription");

            sb.AppendLine("| " + string.Join(" | ", headers) + " |");
            sb.AppendLine("| " + string.Join(" | ", headers.Select(_ => "---")) + " |");

            var columns = schemaTable[i].Columns;
            for (int j = 0; j < columns.Count; j++)
            {
                var col = columns[j];
                var values = new List<string>();
                values.Add(Escape(col.ColumnName));
                if (FormControl.IsSortShow) values.Add(Escape(col.Sort));
                if (FormControl.IsDataTypeShow) values.Add(Escape(col.DataType));
                if (FormControl.IsDefaultValueShow) values.Add(Escape(col.DefaultValue));
                if (FormControl.IsIdentityShow) values.Add(Escape(col.Identity));
                if (FormControl.IsPrimaryKeyShow) values.Add(Escape(col.PrimaryKey));
                values.Add(Escape(col.ForeignKeyTable));
                if (FormControl.IsNotNullShow) values.Add(Escape(col.NotNull));
                if (FormControl.IsLengthShow) values.Add(Escape(col.Length));
                if (FormControl.IsPrecisionShow) values.Add(Escape(col.Precision));
                if (FormControl.IsScaleShow) values.Add(Escape(col.Scale));
                if (FormControl.IsColumnDescriptionShow) values.Add(Escape(col.ColumnDescription));

                sb.AppendLine("| " + string.Join(" | ", values) + " |");
            }
            sb.AppendLine();
        }

        File.WriteAllText(destinationPath, sb.ToString(), Encoding.UTF8);
        Process.Start(new ProcessStartInfo(destinationPath) { UseShellExecute = true });
        return destinationPath;
    }

    private string Escape(string text)
    {
        if (string.IsNullOrEmpty(text)) return "";
        return text.Replace("|", "\\|").Replace("\r", "").Replace("\n", " ");
    }
}
