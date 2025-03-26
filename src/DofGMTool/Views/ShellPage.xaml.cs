using DofGMTool.Contracts.Services;
using DofGMTool.Helpers;
using DofGMTool.Models;
using DofGMTool.ViewModels;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Windows.System;

namespace DofGMTool.Views;

// TODO: Update NavigationViewItem titles and icons in ShellPage.xaml.
public sealed partial class ShellPage : Page
{
    public ShellViewModel ViewModel
    {
        get;
    }

    //public CharacterManageViewModel CharacInfoViewModel
    //{
    //    get;
    //}

    public ShellPage(ShellViewModel viewModel/*, CharacterManageViewModel characterManageViewModel*/)
    {
        ViewModel = viewModel;
        //CharacInfoViewModel = characterManageViewModel;
        InitializeComponent();

        ViewModel.NavigationService.Frame = NavigationFrame;
        ViewModel.NavigationViewService.Initialize(NavigationViewControl);

        // TODO: Set the title bar icon by updating /Assets/WindowIcon.ico.
        // A custom title bar is required for full window theme and Mica support.
        // https://docs.microsoft.com/windows/apps/develop/title-bar?tabs=winui3#full-customization
        App.MainWindow.ExtendsContentIntoTitleBar = true;
        //App.MainWindow.SetTitleBar(AppTitleBar);
        App.MainWindow.Activated += MainWindow_Activated;
        //AppTitleBarText.Text = "AppDisplayName".GetLocalized();
    }
    private int _activationCount = 0;
    private async void OnLoaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        TitleBarHelper.UpdateTitleBar(RequestedTheme);

        KeyboardAccelerators.Add(BuildKeyboardAccelerator(VirtualKey.Left, VirtualKeyModifiers.Menu));
        KeyboardAccelerators.Add(BuildKeyboardAccelerator(VirtualKey.GoBack));

        _activationCount++;

        Debug.WriteLine($"OnLoaded 方法已被调用 {_activationCount} 次。");

        try
        {
            ObservableCollection<ConnectionInfo> connections = await ConnectionHelper.LoadConnectionsAsync();
            // 直接更新 ViewModel
            ViewModel.Connections = connections ?? new ObservableCollection<ConnectionInfo>();
            ViewModel.SelectedConnection = ViewModel.Connections.FirstOrDefault(c => c.IsSelected) ?? ViewModel.Connections.FirstOrDefault();
            ViewModel.IsConnecting = false;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error loading connections in OnLoaded: {ex.Message}");

            // 写入异常信息到 D:\log.txt 文件
            try
            {
                string logFilePath = @"D:\log.txt";
                string logMessage = $"[{DateTime.Now}] Error loading connections in OnLoaded: {ex.Message}\n{ex.StackTrace}\n\n";
                File.AppendAllText(logFilePath, logMessage);
            }
            catch (Exception logEx)
            {
                // 如果日志写入失败，输出调试信息
                Debug.WriteLine($"Failed to write log: {logEx.Message}");
            }

            // 弹出对话框，提示用户重试
            var dialog = new ContentDialog
            {
                Title = "加载连接信息失败",
                Content = "无法加载连接信息，请检查网络连接或联系管理员。",
                PrimaryButtonText = "重试",
                CloseButtonText = "取消",
                XamlRoot = App.MainWindow.Content.XamlRoot
            };

            ContentDialogResult result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                // 用户点击重试按钮，重新启动应用程序
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = Environment.ProcessPath,
                    UseShellExecute = true
                };
                Process.Start(processStartInfo);

                // 退出当前进程
                Process.GetCurrentProcess().Kill();
            }
        }

    }



    private void MainWindow_Activated(object sender, WindowActivatedEventArgs args)
    {

    }





    private void NavigationViewControl_DisplayModeChanged(NavigationView sender, NavigationViewDisplayModeChangedEventArgs args)
    {
        //AppTitleBar.Margin = new Thickness()
        //{
        //    Left = sender.CompactPaneLength * (sender.DisplayMode == NavigationViewDisplayMode.Minimal ? 2 : 1),
        //    Top = AppTitleBar.Margin.Top,
        //    Right = AppTitleBar.Margin.Right,
        //    Bottom = AppTitleBar.Margin.Bottom
        //};
    }

    private static KeyboardAccelerator BuildKeyboardAccelerator(VirtualKey key, VirtualKeyModifiers? modifiers = null)
    {
        var keyboardAccelerator = new KeyboardAccelerator() { Key = key };

        if (modifiers.HasValue)
        {
            keyboardAccelerator.Modifiers = modifiers.Value;
        }

        keyboardAccelerator.Invoked += OnKeyboardAcceleratorInvoked;

        return keyboardAccelerator;
    }

    private static void OnKeyboardAcceleratorInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
    {
        INavigationService navigationService = App.GetService<INavigationService>();

        bool result = navigationService.GoBack();

        args.Handled = result;
    }
}
