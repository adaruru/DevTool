// DevTool 2.1 
// Copyright (C) 2024, Adaruru

public static class DbConnectorFactory
{
    /// <summary>
    /// 根據資料庫類型建立對應的 Connector
    /// </summary>
    public static IDbConnector Create(DbTypeEnum dbType = DbTypeEnum.SqlServer)
    {
        return dbType switch
        {
            DbTypeEnum.SqlServer => new SqlServerConnector(),
            DbTypeEnum.MySql => new MySqlDbConnector(),
            DbTypeEnum.Oracle => new OracleConnector(),
            DbTypeEnum.PostgreSql => new PostgreSqlConnector(),
            _ => new SqlServerConnector()
        };
    }
}
