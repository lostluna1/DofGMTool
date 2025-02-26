using DofGMTool.Models;
using FreeSql;
using MySqlConnector;
using System.Data.Common;
using System.Diagnostics;

namespace DofGMTool.Helpers;

public class DatabaseHelper : IDisposable
{

    public string? Ip { get; set; }
    public string? Port { get; set; }
    public string? User { get; set; }
    public string? Password { get; set; }

    // 单例实例
    public static DatabaseHelper Instance { get; } = new DatabaseHelper();

    // 私有构造函数，防止外部实例化
    private DatabaseHelper() { }

    private MySqlConnection? _connection;
    // 其他方法
    public IFreeSql<MySqlFlag> GetMySqlConnection(string databaseName)
    {
        // 使用实例属性构建连接字符串
        IFreeSql<MySqlFlag> fsql = new FreeSqlBuilder()
            .UseConnectionFactory(DataType.MySql, () =>
            {
                _connection = new MySqlConnection($"data source={Ip};port={Port};user id={User};password={Password};initial catalog={databaseName};sslmode=none;max pool size=50;Charset=latin1;ConvertZeroDateTime=True;");
                _connection.Open();
                MySqlCommand cmd = _connection.CreateCommand();
                cmd.CommandText = "SET Charset latin1;";
                cmd.ExecuteNonQuery();
                return _connection;
            })
            .UseMonitorCommand(cmd => Debug.WriteLine($"Sql：{cmd.CommandText}"))
            .Build<MySqlFlag>();
        return fsql;
    }

    // 实现IDisposable接口
    public void Dispose()
    {
        _connection?.Close();
        _connection?.Dispose();
    }
}
