---
name: Hook Method 修復識別符參數化問題
overview: 在 IDbConnector 介面新增 default no-op hook method，讓需要特殊處理識別符的 connector（PostgreSQL、Oracle、MySQL）在 ExecuteNonQuery 前改寫 IDbCommand，繞過 DDL 識別符不能參數化的限制。
todos: []
isProject: true
---

# 從 Command 讀取參數在 Connector 組出完整 SQL

## Context

PostgreSQL / Oracle / MySQL 的 `COMMENT ON TABLE @TableName` 語法中，table name 是 SQL 識別符，不能用 ADO.NET 參數化。目前 `ConnService` 統一把 `@TableName` 當作參數綁定，導致：

- **PostgreSQL**: Npgsql 將 `@TableName` 轉成 `$1`，但 `COMMENT ON TABLE $1` 語法無效
- **Oracle**: 同樣問題，且 COMMENT 查詢用了 `@` 前綴而非 Oracle 的 `:` bind variable
- **MySQL**: `ALTER TABLE @TableName` 同樣不能參數化
- **SQL Server**: 不受影響（`OBJECT_ID(@TableName)` 中 `@TableName` 是字串值）

## 方案：Hook Method + Default No-op

在 `IDbConnector` 介面新增兩個 **default no-op** 方法，只接收 `IDbCommand`（無額外參數）。
ConnService 照原本流程設定 CommandText 和 Parameters 後，在 `ExecuteNonQuery` 前呼叫 hook。
需要特殊處理的 connector 覆寫 hook 改寫命令；不需要的（如 SQL Server）繼承 no-op。

```text
ConnService                              IDbConnector
    │                                         │
    ├─ GetUpsertTableDescriptionQuery() ────→ │ 回傳 SQL template（不變）
    ├─ cmd.CommandText = template              │
    ├─ cmd.AddParam(@TableName, ...)           │
    ├─ cmd.AddParam(@TableDescription, ...)    │
    ├─ PrepareUpsertTableDescriptionCommand(cmd) ──→ │ ← Hook
    │     SqlServer: no-op (default)           │
    │     PostgreSQL: 改寫 cmd                 │
    │     Oracle: 改寫 cmd + 修正參數前綴      │
    │     MySQL: 改寫 cmd                      │
    ├─ cmd.ExecuteNonQuery()                   │
```

### 設計模式


| 模式               | 應用                                                       |
| ---------------- | -------------------------------------------------------- |
| Strategy         | `IDbConnector` 為策略介面，ConnService 不依賴具體 connector         |
| Hook Method      | `PrepareUpsert*Command(IDbCommand)` 為可覆寫的 hook，預設 no-op  |
| Extension Method | `DbCommandExtensions` 提供共用的 `AddParam` / `GetParamValue` |


## 修改清單

### 1. 新增 `DbTool/Service/DbConnector/DbCommandExtensions.cs`

抽出 `AddParam` 和 `GetParamValue` 為 `IDbCommand` extension method，避免在每個 connector 和 ConnService 中重複：

```csharp
using System.Data;

public static class DbCommandExtensions
{
    /// <summary>
    /// 新增參數
    /// </summary>
    public static void AddParam(this IDbCommand cmd, string name, object value)
    {
        var p = cmd.CreateParameter();
        p.ParameterName = name;
        p.Value = value ?? DBNull.Value;
        cmd.Parameters.Add(p);
    }

    /// <summary>
    /// 從已綁定的 Parameters 中依名稱取值
    /// </summary>
    public static string? GetParamValue(this IDbCommand cmd, string name)
    {
        for (int i = 0; i < cmd.Parameters.Count; i++)
            if (cmd.Parameters[i] is IDbDataParameter p
                && string.Equals(p.ParameterName, name, StringComparison.OrdinalIgnoreCase))
                return p.Value?.ToString();
        return null;
    }
}
```

### 2. 修改 `DbTool/Service/DbConnector/IDbConnector.cs`

新增 2 個 default no-op hook method：

```csharp
/// <summary>
/// Hook：在 ExecuteNonQuery 前調整 upsert table description 命令。
/// 預設不做任何事。需要識別符插值的 connector 覆寫此方法。
/// </summary>
void PrepareUpsertTableDescriptionCommand(IDbCommand cmd) { }

/// <summary>
/// Hook：在 ExecuteNonQuery 前調整 upsert column description 命令。
/// </summary>
void PrepareUpsertColumnDescriptionCommand(IDbCommand cmd) { }
```

既有方法（`GetUpsertTableDescriptionQuery` 等）全部保留不動。

### 3. 修改 `DbTool/Service/ConnService.cs`

**InsertTableDescription**（第 89-108 行）在 `ExecuteNonQuery` 前插入 hook：

```csharp
public void InsertTableDescription(Schema schema)
{
    var queryTemplate = _connector.GetUpsertTableDescriptionQuery();

    for (int i = 0; i < schema.Tables.Count; i++)
    {
        if (!string.IsNullOrEmpty(schema.Tables[i].TableDescription))
        {
            using var con = _connector.CreateConnection(ConnString);
            using var cmd = con.CreateCommand();
            cmd.CommandText = queryTemplate;
            con.Open();

            cmd.AddParam("@TableName", schema.Tables[i].TableName);
            cmd.AddParam("@TableDescription", schema.Tables[i].TableDescription);

            _connector.PrepareUpsertTableDescriptionCommand(cmd);  // hook
            cmd.ExecuteNonQuery();
        }
    }
}
```

**InsertColumnDescription**（第 60-84 行）同理：

```csharp
public void InsertColumnDescription(Schema schema)
{
    var queryTemplate = _connector.GetUpsertColumnDescriptionQuery();
    if (string.IsNullOrEmpty(queryTemplate))
    {
        throw new NotSupportedException("此資料庫類型不支援更新欄位描述");
    }

    for (int i = 0; i < schema.Tables.Count; i++)
    {
        for (int c = 0; c < schema.Tables[i].Columns.Count; c++)
        {
            using var con = _connector.CreateConnection(ConnString);
            using var cmd = con.CreateCommand();
            cmd.CommandText = queryTemplate;
            con.Open();

            cmd.AddParam("@TableName", schema.Tables[i].TableName);
            cmd.AddParam("@ColumnName", schema.Tables[i].Columns[c].ColumnName);
            cmd.AddParam("@ColumnDescription", schema.Tables[i].Columns[c].ColumnDescription);

            _connector.PrepareUpsertColumnDescriptionCommand(cmd);  // hook
            cmd.ExecuteNonQuery();
        }
    }
}
```

同時將 `AddParameter` 私有方法的呼叫全部改用 `cmd.AddParam()`（extension method），包含 `SetColumn` 第 134 行。之後移除 `AddParameter` 私有方法。

### 4. `DbTool/Service/DbConnector/SqlServerConnector.cs` — 不需修改

繼承 default no-op，行為與重構前完全一致。

### 5. 修改 `DbTool/Service/DbConnector/PostgreSqlConnector.cs`

覆寫 hook，從 `cmd` 讀取識別符值，用雙引號插值改寫 CommandText，description 維持參數化：

```csharp
public void PrepareUpsertTableDescriptionCommand(IDbCommand cmd)
{
    var tableName = cmd.GetParamValue("@TableName");
    var description = cmd.GetParamValue("@TableDescription");

    cmd.Parameters.Clear();
    cmd.CommandText = $"COMMENT ON TABLE {QuoteIdentifier(tableName)} IS @TableDescription";
    cmd.AddParam("@TableDescription", description);
}

public void PrepareUpsertColumnDescriptionCommand(IDbCommand cmd)
{
    var tableName = cmd.GetParamValue("@TableName");
    var columnName = cmd.GetParamValue("@ColumnName");
    var description = cmd.GetParamValue("@ColumnDescription");

    cmd.Parameters.Clear();
    cmd.CommandText = $"COMMENT ON COLUMN {QuoteIdentifier(tableName)}.{QuoteIdentifier(columnName)} IS @ColumnDescription";
    cmd.AddParam("@ColumnDescription", description);
}

/// <summary>
/// PostgreSQL 識別符引號：雙引號包裹，內部 " 跳脫為 ""
/// </summary>
private static string QuoteIdentifier(string identifier)
    => "\"" + identifier.Replace("\"", "\"\"") + "\"";
```

### 6. 修改 `DbTool/Service/DbConnector/OracleConnector.cs`

同 PostgreSQL 模式，額外修正參數前綴為 Oracle 的 `:` bind variable：

```csharp
public void PrepareUpsertTableDescriptionCommand(IDbCommand cmd)
{
    var tableName = cmd.GetParamValue("@TableName");
    var description = cmd.GetParamValue("@TableDescription");

    cmd.Parameters.Clear();
    cmd.CommandText = $"COMMENT ON TABLE {QuoteIdentifier(tableName)} IS :TableDescription";
    cmd.AddParam(":TableDescription", description);
}

public void PrepareUpsertColumnDescriptionCommand(IDbCommand cmd)
{
    var tableName = cmd.GetParamValue("@TableName");
    var columnName = cmd.GetParamValue("@ColumnName");
    var description = cmd.GetParamValue("@ColumnDescription");

    cmd.Parameters.Clear();
    cmd.CommandText = $"COMMENT ON COLUMN {QuoteIdentifier(tableName)}.{QuoteIdentifier(columnName)} IS :ColumnDescription";
    cmd.AddParam(":ColumnDescription", description);
}

private static string QuoteIdentifier(string identifier)
    => "\"" + identifier.Replace("\"", "\"\"") + "\"";
```

### 7. 修改 `DbTool/Service/DbConnector/MySqlConnector.cs`

MySQL 識別符用反引號。只需覆寫 table description hook（column description 的 hook 不會被呼叫，因為 ConnService 在 hook 前就因空 template 拋出 NotSupportedException）：

```csharp
public void PrepareUpsertTableDescriptionCommand(IDbCommand cmd)
{
    var tableName = cmd.GetParamValue("@TableName");
    var description = cmd.GetParamValue("@TableDescription");

    cmd.Parameters.Clear();
    cmd.CommandText = $"ALTER TABLE {QuoteIdentifier(tableName)} COMMENT = @TableDescription";
    cmd.AddParam("@TableDescription", description);
}

private static string QuoteIdentifier(string identifier)
    => "`" + identifier.Replace("`", "``") + "`";
```

## 變更總覽


| 檔案                       | 變更                               | 影響             |
| ------------------------ | -------------------------------- | -------------- |
| `DbCommandExtensions.cs` | 新增（共用 AddParam / GetParamValue）  | 消除重複           |
| `IDbConnector.cs`        | 新增 2 個 default no-op method      | 不影響既有實作        |
| `ConnService.cs`         | 插入 hook 呼叫 + 改用 extension method | 最小改動           |
| `SqlServerConnector.cs`  | 不需修改                             | 零影響            |
| `PostgreSqlConnector.cs` | 覆寫 2 個 hook + QuoteIdentifier    | 修復 COMMENT ON  |
| `OracleConnector.cs`     | 覆寫 2 個 hook + 修正參數前綴             | 修復 COMMENT ON  |
| `MySqlConnector.cs`      | 覆寫 1 個 hook + QuoteIdentifier    | 修復 ALTER TABLE |


## 驗證

1. Build 確認所有 connector 編譯通過
2. SQL Server: 行為完全不變（hook 為 no-op）
3. PostgreSQL: 產生 `COMMENT ON TABLE "tablename" IS $1`
4. Oracle: 產生 `COMMENT ON TABLE "TABLENAME" IS :TableDescription`
5. MySQL: 產生 `ALTER TABLE `tablename` COMMENT = @TableDescription`

