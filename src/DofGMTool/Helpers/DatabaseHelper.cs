using DofGMTool.Models;
using FreeSql;
using MySqlConnector;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace DofGMTool.Helpers;

public static class DatabaseHelper
{
    // ���ڻ��治ͬ���ݿ�� IFreeSql<MySqlFlag> ʵ��
    private static readonly Dictionary<string, IFreeSql<MySqlFlag>> _fsqlCache = new();
    // ���ڼ�¼�ѳ�ʼ��������
    private static readonly ConcurrentDictionary<MySqlConnection, bool> _initializedConnections = new();

    // ��ȡ���ݿ�����
    public static IFreeSql<MySqlFlag> GetMySqlConnection(string databaseName)
    {
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

        // ������������ж�Ӧ�� IFreeSql<MySqlFlag> ʵ����ֱ�ӷ���
        if (_fsqlCache.TryGetValue(databaseName, out IFreeSql<MySqlFlag>? fsql))
        {
            return fsql;
        }

        // ���������ַ���
        string connectionString = $"Data Source={connectionInfo.Ip};Port={connectionInfo.Port};User ID={connectionInfo.User};Password={connectionInfo.Password};Initial Catalog={databaseName};Charset=latin1;SslMode=none;ConvertZeroDateTime=True;Pooling=true;Min Pool Size=1;Max Pool Size=100;Connection Timeout=25;";

        try
        {
            // �����µ� IFreeSql<MySqlFlag> ʵ��
            fsql = new FreeSqlBuilder()
                .UseConnectionString(DataType.MySql, connectionString)
                .UseAutoSyncStructure(false)
                .UseMonitorCommand(cmd => Debug.WriteLine($"Sql��{cmd.CommandText}"))
                .Build<MySqlFlag>(); // ָ�����Ͳ���

            // �������ݿ�����
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.OpenAsync();

                // ִ�г�ʼ������
                using MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SET Charset latin1;";
                cmd.ExecuteNonQueryAsync();

                conn.Close();
            }

            // ע�� AOP �¼��������Ӵ򿪺�ִ�г�ʼ������
            fsql.Aop.CommandBefore += async (s, e) =>
            {
                if (e.Command.Connection is MySqlConnection conn)
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        await conn.OpenAsync();
                    }

                    // ��������Ƿ��ѳ�ʼ��
                    if (!_initializedConnections.ContainsKey(conn))
                    {
                        // ִ�г�ʼ������
                        using MySqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "SET Charset latin1;";
                        await cmd.ExecuteNonQueryAsync();

                        // ��������ѳ�ʼ��
                        _initializedConnections.TryAdd(conn, true);
                    }
                }
            };

            // ����ʵ��
            _fsqlCache[databaseName] = fsql;

            return fsql;
        }
        catch (MySqlException ex)
        {
            Debug.WriteLine($"�޷����ӵ����ݿ� '{databaseName}'��{ex.Message}");
            throw new Exception($"�޷����ӵ����ݿ� '{databaseName}'��{ex.Message},����������Ϣ");
        }
    }
}
