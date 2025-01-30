using DofGMTool.Models;
using FreeSql;
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
        string connectionString = $"data source=192.168.200.131;port=3306;user id=game;password=uu5!^%jg;initial catalog={databaseName};sslmode=none;max pool size=2;Charset=latin1;Allow User Variables=True";
        IFreeSql<MySqlFlag> fsql = new FreeSqlBuilder().UseConnectionString(DataType.MySql, connectionString)
            .UseMonitorCommand(cmd => Debug.WriteLine($"Sql£º{cmd.CommandText}"))
            .Build<MySqlFlag>();
        return fsql;
    }


}
