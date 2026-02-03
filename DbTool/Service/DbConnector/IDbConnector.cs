// DevTool 2.1 
// Copyright (C) 2024, Adaruru

using System.Data;

public interface IDbConnector
{
    /// <summary>
    /// 建立資料庫連線
    /// </summary>
    IDbConnection CreateConnection(string connString);

    /// <summary>
    /// 取得測試連線用的查詢語句
    /// </summary>
    string GetTestConnectionQuery();

    /// <summary>
    /// 取得所有資料表的查詢語句
    /// </summary>
    string GetTableQuery();

    /// <summary>
    /// 取得資料表欄位的查詢語句
    /// </summary>
    string GetColumnQuery();

    /// <summary>
    /// 取得新增/更新資料表描述的查詢語句
    /// </summary>
    string GetUpsertTableDescriptionQuery();

    /// <summary>
    /// 取得新增/更新欄位描述的查詢語句
    /// </summary>
    string GetUpsertColumnDescriptionQuery();

    /// <summary>
    /// 資料庫型別轉換為 C# 型別
    /// </summary>
    string MapDataTypeToCSharp(Column column);

    /// <summary>
    /// 取得欄位預設初始值
    /// </summary>
    string GetDefaultInitialValue(Column column);
}
