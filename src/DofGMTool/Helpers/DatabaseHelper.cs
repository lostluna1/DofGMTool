using DofGMTool.Models;
using FreeSql;
using MySqlConnector;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace DofGMTool.Helpers;

public static class DatabaseHelper
{
    // 用于缓存不同数据库的 IFreeSql<MySqlFlag> 实例
    private static readonly Dictionary<string, IFreeSql<MySqlFlag>> _fsqlCache = new();
    // 用于记录已初始化的连接
    private static readonly ConcurrentDictionary<MySqlConnection, bool> _initializedConnections = new();

    // 获取数据库连接
    public static IFreeSql<MySqlFlag> GetMySqlConnection(string databaseName)
    {
        ConnectionInfo? connectionInfo = GlobalVariables.Instance.ConnectionInfo;
        if (connectionInfo == null)
        {
            Debug.WriteLine("全局变量未初始化，请检查。");
            return null;
        }

        // 检查必填字段是否为空
        if (string.IsNullOrWhiteSpace(connectionInfo.Ip) ||
            string.IsNullOrWhiteSpace(connectionInfo.Port) ||
            string.IsNullOrWhiteSpace(connectionInfo.User) ||
            string.IsNullOrWhiteSpace(connectionInfo.Password))
        {
            Debug.WriteLine("连接信息不完整，请检查IP、端口、用户名和密码是否已填写。");
            return null;
        }

        // 如果缓存中已有对应的 IFreeSql<MySqlFlag> 实例，直接返回
        if (_fsqlCache.TryGetValue(databaseName, out IFreeSql<MySqlFlag>? fsql))
        {
            return fsql;
        }

        // 构建连接字符串
        string connectionString = $"Data Source={connectionInfo.Ip};Port={connectionInfo.Port};User ID={connectionInfo.User};Password={connectionInfo.Password};Initial Catalog={databaseName};Charset=latin1;SslMode=none;ConvertZeroDateTime=True;Pooling=true;Min Pool Size=1;Max Pool Size=100;Connection Timeout=25;";

        try
        {
            // 创建新的 IFreeSql<MySqlFlag> 实例
            fsql = new FreeSqlBuilder()
                .UseConnectionString(DataType.MySql, connectionString)
                .UseAutoSyncStructure(false)
                .UseMonitorCommand(cmd => Debug.WriteLine($"Sql：{cmd.CommandText}"))
                .Build<MySqlFlag>(); // 指定泛型参数

            // 测试数据库连接
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.OpenAsync();

                // 执行初始化命令
                using MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SET Charset latin1;";
                cmd.ExecuteNonQueryAsync();

                conn.Close();
            }

            // 注册 AOP 事件，在连接打开后执行初始化命令
            fsql.Aop.CommandBefore += async (s, e) =>
            {
                if (e.Command.Connection is MySqlConnection conn)
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        await conn.OpenAsync();
                    }

                    // 检查连接是否已初始化
                    if (!_initializedConnections.ContainsKey(conn))
                    {
                        // 执行初始化命令
                        using MySqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "SET Charset latin1;";
                        await cmd.ExecuteNonQueryAsync();

                        // 标记连接已初始化
                        _initializedConnections.TryAdd(conn, true);
                    }
                }
            };

            // 缓存实例
            _fsqlCache[databaseName] = fsql;

            return fsql;
        }
        catch (MySqlException ex)
        {
            Debug.WriteLine($"无法连接到数据库 '{databaseName}'：{ex.Message}");
            throw new Exception($"无法连接到数据库 '{databaseName}'：{ex.Message},请检查连接信息");
        }
    }
}
