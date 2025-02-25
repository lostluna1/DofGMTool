using DofGMTool.Models;
using FreeSql;
using MySqlConnector;
using System.Diagnostics;

namespace DofGMTool.Contracts.Services;
public interface IDatabaseService
{
    IFreeSql<MySqlFlag> GetMySqlConnection(string databaseName);
}

public class DatabaseService : IDatabaseService
{
    public IFreeSql<MySqlFlag> GetMySqlConnection(string databaseName)
    {
        IFreeSql<MySqlFlag> fsql = new FreeSqlBuilder()
            .UseConnectionFactory(DataType.MySql, () =>
            {
                var conn = new MySqlConnection($"data source=192.168.200.131;port=3306;user id=game;password=uu5!^%jg;initial catalog={databaseName};sslmode=none;max pool size=50;Charset=latin1;ConvertZeroDateTime=True;");
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SET Charset latin1;";
                cmd.ExecuteNonQuery();
                return conn;
            })
            .UseMonitorCommand(cmd => Debug.WriteLine($"Sql£º{cmd.CommandText}"))
            .Build<MySqlFlag>();
        return fsql;
    }
}

