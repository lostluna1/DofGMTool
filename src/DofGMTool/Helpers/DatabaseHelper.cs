using DofGMTool.Constant;
using DofGMTool.Models;
using FreeSql;
using MySqlConnector;
using System.Diagnostics;

namespace DofGMTool.Helpers;

public static class DatabaseHelper
{
    // 用于缓存不同数据库的 IFreeSql 实例
    private static  Lazy<IFreeSql> _dTaiwan = new(() =>
    {
        return CreateFreeSqlInstance(DBNames.D_Taiwan);
    });

    private static  Lazy<IFreeSql> _taiwanCain = new(() =>
    {
        return CreateFreeSqlInstance(DBNames.TaiwanCain);
    });

    private static  Lazy<IFreeSql> _taiwanCain2nd = new(() =>
    {
        return CreateFreeSqlInstance(DBNames.TaiwanCain2nd);
    });

    private static  Lazy<IFreeSql> _taiwanBilling = new(() =>
    {
        return CreateFreeSqlInstance(DBNames.TaiwanBilling);
    });
    
    private static  Lazy<IFreeSql> _taiwanLogin = new(() =>
    {
        return CreateFreeSqlInstance(DBNames.TaiwanLogin);
    });

    // 公共属性，提供外部访问
    public static IFreeSql DTaiwan => _dTaiwan.Value;
    public static IFreeSql TaiwanCain => _taiwanCain.Value;
    public static IFreeSql TaiwanCain2nd => _taiwanCain2nd.Value;
    public static IFreeSql TaiwanBilling => _taiwanBilling.Value;
    public static IFreeSql TaiwanLogin => _taiwanLogin.Value;
    public static void ResetConnections()
    {
        _dTaiwan = new(() => CreateFreeSqlInstance(DBNames.D_Taiwan));
        // 如果有其他数据库实例，也需要重置
        _taiwanCain = new(() => CreateFreeSqlInstance(DBNames.TaiwanCain));
        _taiwanCain2nd = new(() => CreateFreeSqlInstance(DBNames.TaiwanCain2nd));
        _taiwanBilling = new(() => CreateFreeSqlInstance(DBNames.TaiwanBilling));
        _taiwanLogin = new(() => CreateFreeSqlInstance(DBNames.TaiwanLogin));
    }

    /// <summary>
    /// 测试数据库连接是否有效。
    /// </summary>
    /// <param name="connectionInfo">包含连接信息的 ConnectionInfo 对象。</param>
    /// <returns>如果连接成功，返回 true；否则返回 false。</returns>
    public static async Task<bool> TestDatabaseConnectionAsync(ConnectionInfo connectionInfo)
    {
        if (connectionInfo == null)
        {
            throw new ArgumentNullException(nameof(connectionInfo), "连接信息不能为空。");
        }

        // 检查必填字段是否为空
        //if (string.IsNullOrWhiteSpace(connectionInfo.Ip) ||
        //    string.IsNullOrWhiteSpace(connectionInfo.Port) ||
        //    string.IsNullOrWhiteSpace(connectionInfo.User) ||
        //    string.IsNullOrWhiteSpace(connectionInfo.Password))
        //{
        //    throw new InvalidOperationException("连接信息不完整，请检查 IP、端口、用户名和密码是否已填写。");
        //}

        // 构建连接字符串
        string connectionString = $"Server={connectionInfo.Ip};Port={connectionInfo.Port};User ID={connectionInfo.User};Password={connectionInfo.Password};SslMode=None;";

        try
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                // 连接成功
                return true;
            }
        }
        catch (Exception ex)
        {
            // 记录异常信息
            Debug.WriteLine($"数据库连接测试失败：{ex.Message}");
            // 连接失败
            return false;
        }
    }

    // 创建 IFreeSql 实例的方法
    private static IFreeSql CreateFreeSqlInstance(string databaseName)
    {
        ConnectionInfo? connectionInfo = GlobalVariables.Instance.ConnectionInfo;
        if (connectionInfo == null)
        {
            return null;
            //throw new InvalidOperationException("连接信息未初始化，请检查。");
        }

        // 检查必填字段是否为空
        if (string.IsNullOrWhiteSpace(connectionInfo.Ip) ||
            string.IsNullOrWhiteSpace(connectionInfo.Port) ||
            string.IsNullOrWhiteSpace(connectionInfo.User) ||
            string.IsNullOrWhiteSpace(connectionInfo.Password))
        {
            return null;
            //throw new InvalidOperationException("连接信息不完整，请检查IP、端口、用户名和密码是否已填写。");
        }

        // 构建连接字符串
        string connectionString = $"Data Source={connectionInfo.Ip};Port={connectionInfo.Port};User ID={connectionInfo.User};Password={connectionInfo.Password};Initial Catalog={databaseName};Charset=latin1;SslMode=none;ConvertZeroDateTime=True;Pooling=true;Min Pool Size=1;Max Pool Size=4000;Connection Timeout=25;";

        try
        {
            var fsql = new FreeSqlBuilder()
                .UseConnectionFactory(DataType.MySql, () =>
                {
                    var conn = new MySqlConnection(connectionString);
                    conn.Open(); // 可能抛出异常
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SET Charset latin1;";
                        cmd.ExecuteNonQuery();
                    }
                    return conn;
                })
                .UseAutoSyncStructure(true) // 自动同步实体结构到数据库
                .UseAdoConnectionPool(true)
                .UseMonitorCommand(cmd => Debug.WriteLine($"Sql：{cmd.CommandText}"))
                .Build();

            Debug.WriteLine($"创建了新的 FreeSql 实例，数据库：{databaseName}");

            return fsql;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"创建 FreeSql 实例时发生错误：{ex.Message}");
            // 抛出自定义异常，供调用方处理
            throw new Exception($"无法连接到数据库 {databaseName}，请检查连接信息。", ex);
        }
    }
}
