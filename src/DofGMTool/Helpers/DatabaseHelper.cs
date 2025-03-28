using DofGMTool.Constant;
using DofGMTool.Models;
using FreeSql;
using MySqlConnector;
using System.Diagnostics;

namespace DofGMTool.Helpers;

public static class DatabaseHelper
{
    // ���ڻ��治ͬ���ݿ�� IFreeSql ʵ��
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

    // �������ԣ��ṩ�ⲿ����
    public static IFreeSql DTaiwan => _dTaiwan.Value;
    public static IFreeSql TaiwanCain => _taiwanCain.Value;
    public static IFreeSql TaiwanCain2nd => _taiwanCain2nd.Value;
    public static IFreeSql TaiwanBilling => _taiwanBilling.Value;
    public static IFreeSql TaiwanLogin => _taiwanLogin.Value;
    public static void ResetConnections()
    {
        _dTaiwan = new(() => CreateFreeSqlInstance(DBNames.D_Taiwan));
        // ������������ݿ�ʵ����Ҳ��Ҫ����
        _taiwanCain = new(() => CreateFreeSqlInstance(DBNames.TaiwanCain));
        _taiwanCain2nd = new(() => CreateFreeSqlInstance(DBNames.TaiwanCain2nd));
        _taiwanBilling = new(() => CreateFreeSqlInstance(DBNames.TaiwanBilling));
        _taiwanLogin = new(() => CreateFreeSqlInstance(DBNames.TaiwanLogin));
    }

    /// <summary>
    /// �������ݿ������Ƿ���Ч��
    /// </summary>
    /// <param name="connectionInfo">����������Ϣ�� ConnectionInfo ����</param>
    /// <returns>������ӳɹ������� true�����򷵻� false��</returns>
    public static async Task<bool> TestDatabaseConnectionAsync(ConnectionInfo connectionInfo)
    {
        if (connectionInfo == null)
        {
            throw new ArgumentNullException(nameof(connectionInfo), "������Ϣ����Ϊ�ա�");
        }

        // �������ֶ��Ƿ�Ϊ��
        //if (string.IsNullOrWhiteSpace(connectionInfo.Ip) ||
        //    string.IsNullOrWhiteSpace(connectionInfo.Port) ||
        //    string.IsNullOrWhiteSpace(connectionInfo.User) ||
        //    string.IsNullOrWhiteSpace(connectionInfo.Password))
        //{
        //    throw new InvalidOperationException("������Ϣ������������ IP���˿ڡ��û����������Ƿ�����д��");
        //}

        // ���������ַ���
        string connectionString = $"Server={connectionInfo.Ip};Port={connectionInfo.Port};User ID={connectionInfo.User};Password={connectionInfo.Password};SslMode=None;";

        try
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                // ���ӳɹ�
                return true;
            }
        }
        catch (Exception ex)
        {
            // ��¼�쳣��Ϣ
            Debug.WriteLine($"���ݿ����Ӳ���ʧ�ܣ�{ex.Message}");
            // ����ʧ��
            return false;
        }
    }

    // ���� IFreeSql ʵ���ķ���
    private static IFreeSql CreateFreeSqlInstance(string databaseName)
    {
        ConnectionInfo? connectionInfo = GlobalVariables.Instance.ConnectionInfo;
        if (connectionInfo == null)
        {
            return null;
            //throw new InvalidOperationException("������Ϣδ��ʼ�������顣");
        }

        // �������ֶ��Ƿ�Ϊ��
        if (string.IsNullOrWhiteSpace(connectionInfo.Ip) ||
            string.IsNullOrWhiteSpace(connectionInfo.Port) ||
            string.IsNullOrWhiteSpace(connectionInfo.User) ||
            string.IsNullOrWhiteSpace(connectionInfo.Password))
        {
            return null;
            //throw new InvalidOperationException("������Ϣ������������IP���˿ڡ��û����������Ƿ�����д��");
        }

        // ���������ַ���
        string connectionString = $"Data Source={connectionInfo.Ip};Port={connectionInfo.Port};User ID={connectionInfo.User};Password={connectionInfo.Password};Initial Catalog={databaseName};Charset=latin1;SslMode=none;ConvertZeroDateTime=True;Pooling=true;Min Pool Size=1;Max Pool Size=4000;Connection Timeout=25;";

        try
        {
            var fsql = new FreeSqlBuilder()
                .UseConnectionFactory(DataType.MySql, () =>
                {
                    var conn = new MySqlConnection(connectionString);
                    conn.Open(); // �����׳��쳣
                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SET Charset latin1;";
                        cmd.ExecuteNonQuery();
                    }
                    return conn;
                })
                .UseAutoSyncStructure(true) // �Զ�ͬ��ʵ��ṹ�����ݿ�
                .UseAdoConnectionPool(true)
                .UseMonitorCommand(cmd => Debug.WriteLine($"Sql��{cmd.CommandText}"))
                .Build();

            Debug.WriteLine($"�������µ� FreeSql ʵ�������ݿ⣺{databaseName}");

            return fsql;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"���� FreeSql ʵ��ʱ��������{ex.Message}");
            // �׳��Զ����쳣�������÷�����
            throw new Exception($"�޷����ӵ����ݿ� {databaseName}������������Ϣ��", ex);
        }
    }
}
