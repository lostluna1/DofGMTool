using DofGMTool.Helpers;
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
}
