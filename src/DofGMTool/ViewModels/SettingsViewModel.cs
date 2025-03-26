using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DofGMTool.Contracts.Services;
using DofGMTool.Helpers;
using DofGMTool.Messages;
using DofGMTool.Models;
using Microsoft.UI.Xaml;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Input;
using Windows.ApplicationModel;

namespace DofGMTool.ViewModels;

public partial class SettingsViewModel : ObservableRecipient
{
    public IApiService ApiService { get; }
    public readonly IThemeSelectorService _themeSelectorService;

    [ObservableProperty]
    public partial ElementTheme ElementTheme { get; set; }

    [ObservableProperty]
    public partial string VersionDescription { get; set; }

    [ObservableProperty]
    public partial string ImagePacks2Path { get; set; } = string.Empty;

    public ICommand SwitchThemeCommand { get; }
    [ObservableProperty]
    public partial string? NewConnectionName { get; set; }
    [ObservableProperty]
    public partial string? NewConnectionIp { get; set; }

    [ObservableProperty]
    public partial string? NewConnectionPort { get; set; }

    [ObservableProperty]
    public partial string? NewConnectionUser { get; set; }

    [ObservableProperty]
    public partial string? NewConnectionPassword { get; set; }
    [ObservableProperty]
    public partial string? SelectedPassword { get; set; }

    [ObservableProperty]
    public partial ConnectionInfo? SelectedConnection { get; set; }


    [ObservableProperty]
    public partial ObservableCollection<ConnectionInfo> Connections { get; set; } = [];

    public SettingsViewModel(IThemeSelectorService themeSelectorService, IApiService apiService)
    {
        ApiService = apiService;
        _themeSelectorService = themeSelectorService;
        ElementTheme = _themeSelectorService.Theme;
        VersionDescription = GetVersionDescription();

        SwitchThemeCommand = new RelayCommand<ElementTheme>(
            async (param) =>
            {
                if (ElementTheme != param)
                {
                    ElementTheme = param;
                    await _themeSelectorService.SetThemeAsync(param);
                }
            });

        //Connections  = ConnectionHelper.LoadConnectionsAsync();
    }


    [RelayCommand]
    public async Task SendMailByPluginAsync()
    {
        var request = new Request
        {
            UserId = 1,
            Items =
            [
                new() { ItemId = 3037, Count = 500 },
                new() { ItemId = 100, Count = 500 }
            ]
        };

        try
        {
            ApiResponse<CharacInvenResponse> result = await ApiService.PostAsync<CharacInvenResponse>("/SendMailByUserId", request, true);
            Debug.WriteLine(result.Msg);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex.Message}");
            Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
        }
    }

    [RelayCommand]
    public async Task UpgradeEquippedItemsAsync()
    {
        try
        {
            var request = new
            {
                UserId = 1,
                Level = 1,
                Slot = 15
            };
            ApiResponse<CharacInvenResponse> result = await ApiService.PostAsync<CharacInvenResponse>("/UpgradeEquippedItems", request, true);
            Debug.WriteLine(result.Msg);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex.Message}");
            Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
        }
    }



    [RelayCommand]
    public async Task SaveNewConnectionAsync()
    {
        if (string.IsNullOrWhiteSpace(NewConnectionName) || string.IsNullOrWhiteSpace(NewConnectionIp) ||
            string.IsNullOrWhiteSpace(NewConnectionPort) || string.IsNullOrWhiteSpace(NewConnectionUser) ||
            string.IsNullOrWhiteSpace(NewConnectionPassword))
        {
            throw new Exception("检查连接信息是否完整");
        }
        var connection = new ConnectionInfo
        {
            Name = NewConnectionName,
            Ip = NewConnectionIp,
            Port = NewConnectionPort,
            User = NewConnectionUser,
            Password = NewConnectionPassword
        };

        await ConnectionHelper.AddConnectionAsync(connection);
        Connections = await ConnectionHelper.LoadConnectionsAsync();

        // 发送消息通知其他 ViewModel
        WeakReferenceMessenger.Default.Send(new ConnectionsUpdatedMessage(true));
    }

    [RelayCommand]
    public async Task SetDefaultConnectionAsync()
    {
        if (SelectedConnection != null)
        {
            await ConnectionHelper.SetDefaultConnectionAsync(SelectedConnection);
            await ConnectionHelper.LoadConnectionsAsync();

            // 发送消息通知其他 ViewModel
            WeakReferenceMessenger.Default.Send(new ConnectionsUpdatedMessage(true));
        }
    }

    [RelayCommand]
    public async Task DeleteSelectedConnectionAsync()
    {
        if (SelectedConnection != null)
        {
            await ConnectionHelper.DeleteConnectionAsync(SelectedConnection);
            Connections = await ConnectionHelper.LoadConnectionsAsync();

            // 发送消息通知其他 ViewModel
            WeakReferenceMessenger.Default.Send(new ConnectionsUpdatedMessage(true));
        }
    }
    private static string GetVersionDescription()
    {
        Version version;

        if (RuntimeHelper.IsMSIX)
        {
            PackageVersion packageVersion = Package.Current.Id.Version;
            version = new(packageVersion.Major, packageVersion.Minor, packageVersion.Build, packageVersion.Revision);
        }
        else
        {
            version = Assembly.GetExecutingAssembly().GetName().Version!;
        }

        return $"{"AppDisplayName".GetLocalized()} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
    }
}

