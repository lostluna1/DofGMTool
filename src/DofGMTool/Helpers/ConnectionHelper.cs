using DofGMTool.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
using Windows.Storage;

namespace DofGMTool.Helpers;

public static class ConnectionHelper
{
    private const string ConnectionsFileName = "connections.json";
    public static ConnectionInfo? SelectedConnection { get; set; }
    public static async Task<ObservableCollection<ConnectionInfo>> LoadConnectionsAsync()
    {
        var connections = new ObservableCollection<ConnectionInfo>();
        StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        StorageFile file = await localFolder.CreateFileAsync(ConnectionsFileName, CreationCollisionOption.OpenIfExists);
        string json = await FileIO.ReadTextAsync(file);
        if (!string.IsNullOrEmpty(json))
        {
            connections = JsonSerializer.Deserialize<ObservableCollection<ConnectionInfo>>(json) ?? new ObservableCollection<ConnectionInfo>();
        }
        return connections;
    }

    public static async Task SaveConnectionsAsync(ObservableCollection<ConnectionInfo> connections)
    {
        StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        StorageFile file = await localFolder.CreateFileAsync(ConnectionsFileName, CreationCollisionOption.ReplaceExisting);
        string json = JsonSerializer.Serialize(connections);
        await FileIO.WriteTextAsync(file, json);
    }

    public static async Task AddConnectionAsync(ConnectionInfo connection)
    {
        var connections = await LoadConnectionsAsync();
        connections.Add(connection);
        await SaveConnectionsAsync(connections);
    }
    public static async Task SetDefaultConnectionAsync(ConnectionInfo connection)
    {
        // ������������
        var connections = await LoadConnectionsAsync();

        // ���������б����������ӵ� IsSelected ����Ϊ false
        foreach (var conn in connections)
        {
            conn.IsSelected = false;
        }

        // ���Ҳ������µ�Ĭ������
        var selectedConnection = connections.FirstOrDefault(c => c.Name == connection.Name);

        if (selectedConnection != null)
        {
            selectedConnection.IsSelected = true;
        }
        else
        {
            // ���δ���б����ҵ������ӣ�������ӵ��б�����ΪĬ��
            connection.IsSelected = true;
            connections.Add(connection);
        }

        // ������º�������б�
        await SaveConnectionsAsync(connections);
    }

    public static async Task DeleteConnectionAsync(ConnectionInfo connection)
    {
        var connections = await LoadConnectionsAsync();
        connections.Remove(connection);
        await SaveConnectionsAsync(connections);
    }
}
