// DevTool 2.1
// Copyright (C) 2024, Adaruru

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
