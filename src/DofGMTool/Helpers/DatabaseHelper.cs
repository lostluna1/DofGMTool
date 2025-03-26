using DofGMTool.Models;
using FreeSql;
using MySqlConnector;
using System.Diagnostics;

namespace DofGMTool.Helpers;

public static class DatabaseHelper
{
    // ���ڻ��治ͬ���ݿ�� IFreeSql<MySqlFlag> ʵ��
    private static readonly Dictionary<string, IFreeSql<MySqlFlag>> _fsqlCache = new();

    // ���һ����̬����������¼ʵ����������
    private static int _fsqlInstanceCount = 0;

    // ��ȡ���ݿ�����
    public static IFreeSql<MySqlFlag>? GetMySqlConnection(string databaseName)
    {
        // ��ȡ���ö�ջ��Ϣ
        //var stackTrace = new StackTrace();
        //var callingFrame = stackTrace.GetFrame(1);
        //var method = callingFrame?.GetMethod();
        //var callerName = method?.Name;
        //var callerType = method?.DeclaringType?.FullName;

        //Debug.WriteLine($"GetMySqlConnection �������ߣ�{callerType}.{callerName}");

        ConnectionInfo? connectionInfo = GlobalVariables.Instance.ConnectionInfo;
        if (connectionInfo == null)
        {
            Debug.WriteLine("ȫ�ֱ���δ��ʼ�������顣");
            return null;
        }

        // �������ֶ��Ƿ�Ϊ��
        if (string.IsNullOrWhiteSpace(connectionInfo.Ip) ||
            string.IsNullOrWhiteSpace(connectionInfo.Port) ||
            string.IsNullOrWhiteSpace(connectionInfo.User) ||
            string.IsNullOrWhiteSpace(connectionInfo.Password))
        {
            Debug.WriteLine("������Ϣ������������IP���˿ڡ��û����������Ƿ�����д��");
            return null;
        }

        // �������������������Ϣ�����ݿ������
        string cacheKey = $"{connectionInfo.Ip}:{connectionInfo.Port}:{connectionInfo.User}:{databaseName}";

        // ������������ж�Ӧ�� IFreeSql<MySqlFlag> ʵ����ֱ�ӷ���
        if (_fsqlCache.TryGetValue(cacheKey, out IFreeSql<MySqlFlag>? fsql))
        {
            Debug.WriteLine($"ʹ�û���� FreeSql ʵ������ǰʵ��������{_fsqlInstanceCount}");
            return fsql;
        }

        // ���������ַ���
        string connectionString = $"Data Source={connectionInfo.Ip};Port={connectionInfo.Port};User ID={connectionInfo.User};Password={connectionInfo.Password};Initial Catalog={databaseName};Charset=latin1;SslMode=none;ConvertZeroDateTime=True;Pooling=true;Min Pool Size=1;Max Pool Size=100;Connection Timeout=25;";

        try
        {
            // �����µ� IFreeSql<MySqlFlag> ʵ��
            fsql = new FreeSqlBuilder()
                .UseConnectionFactory(DataType.MySql, () =>
                {
                    var conn = new MySqlConnection(connectionString);
                    conn.Open();
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SET Charset latin1;";
                        cmd.ExecuteNonQuery();
                    }
                    return conn;
                })
                .UseAutoSyncStructure(false)
                .UseAdoConnectionPool(true)
                .UseMonitorCommand(cmd => Debug.WriteLine($"Sql��{cmd.CommandText}"))
                .Build<MySqlFlag>(); // ָ�����Ͳ���

            // ����ʵ���������������������Ϣ
            _fsqlInstanceCount++;
            Debug.WriteLine($"�������µ� FreeSql ʵ������ǰʵ��������{_fsqlInstanceCount}");

            // �������ݿ�����
            //fsql.Ado.ExecuteConnectTest();

            // ����ʵ��
            _fsqlCache[cacheKey] = fsql;

            return fsql;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"�޷����ӵ����ݿ� '{databaseName}'��{ex.Message}");
            throw new Exception($"�޷����ӵ����ݿ� '{databaseName}'��{ex.Message}, ����������Ϣ");
        }
    }
}
