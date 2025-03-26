using DofGMTool.Helpers;
using DofGMTool.Models;
using DofGMTool.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.Storage.Pickers;
using WinRT.Interop;

namespace DofGMTool.Views;

public sealed partial class SettingsPage : Page
{
    public SettingsViewModel ViewModel
    {
        get;
    }

    public SettingsPage()
    {
        ViewModel = App.GetService<SettingsViewModel>();
        InitializeComponent();
        LoadImagePacks2Path();
        Loaded += SettingsPage_Loaded;
    }

    private async void SettingsPage_Loaded(object sender, RoutedEventArgs e)
    {
        ViewModel.Connections = await ConnectionHelper.LoadConnectionsAsync();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var picker = new FolderPicker
        {
            SuggestedStartLocation = PickerLocationId.Desktop
        };
        picker.FileTypeFilter.Add("*");

        // 获取当前窗口的句柄
        nint hwnd = WindowNative.GetWindowHandle(App.MainWindow);
        InitializeWithWindow.Initialize(picker, hwnd);

        Windows.Storage.StorageFolder folder = await picker.PickSingleFolderAsync();
        if (folder != null)
        {
            NPKHelper.ImagePacks2Path = folder.Path;
            ViewModel.ImagePacks2Path = folder.Path;
            NPKHelper.SaveImagePacks2Path(folder.Path);
        }
    }

    private void LoadImagePacks2Path()
    {
        NPKHelper.ImagePacks2Path = NPKHelper.LoadImagePacks2Path();
        if (NPKHelper.ImagePacks2Path != null)
        {
            ViewModel.ImagePacks2Path = NPKHelper.ImagePacks2Path;
        }
    }

    private async void AddNewConnection(object sender, RoutedEventArgs e)
    {
        var dialog = new ConnectionInfoDialog(ViewModel)
        {
            XamlRoot = App.MainWindow.Content.XamlRoot

        };

        await dialog.ShowAsync();
    }

    private void InvertedListView_RightTapped(object sender, Microsoft.UI.Xaml.Input.RightTappedRoutedEventArgs e)
    {
        if (sender is ListView listView)
        {
            if ((e.OriginalSource as FrameworkElement)?.DataContext is ConnectionInfo clickedItem)
            {
                listView.SelectedItem = clickedItem;
            }
        }
    }
}
