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
        // 加载所有连接
        var connections = await LoadConnectionsAsync();

        // 遍历连接列表，将所有连接的 IsSelected 设置为 false
        foreach (var conn in connections)
        {
            conn.IsSelected = false;
        }

        // 查找并设置新的默认连接
        var selectedConnection = connections.FirstOrDefault(c => c.Name == connection.Name);

        if (selectedConnection != null)
        {
            selectedConnection.IsSelected = true;
        }
        else
        {
            // 如果未在列表中找到该连接，则将其添加到列表并设置为默认
            connection.IsSelected = true;
            connections.Add(connection);
        }

        // 保存更新后的连接列表
        await SaveConnectionsAsync(connections);
    }

    public static async Task DeleteConnectionAsync(ConnectionInfo connection)
    {
        var connections = await LoadConnectionsAsync();
        connections.Remove(connection);
        await SaveConnectionsAsync(connections);
    }
}
