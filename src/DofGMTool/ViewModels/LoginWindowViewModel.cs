using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DofGMTool.Models;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;

namespace DofGMTool.ViewModels;
public partial class LoginWindowViewModel : ObservableValidator
{
    private IFreeSql<MySqlFlag>? Fsql { get; set; }

    [ObservableProperty]
    public partial bool IsLogging { get; set; } = false;

    [ObservableProperty]
    public partial bool ProgressBarShowError { get; set; } = false;

    [ObservableProperty]
    public partial string? Ip { get; set; } = "192.168.200.131";

    [ObservableProperty]
    public partial string? Port { get; set; } = "3306";

    [ObservableProperty]
    public partial string? User { get; set; } = "game";

    [ObservableProperty]
    public partial ObservableCollection<string>? Passwords { get; set; } = new ObservableCollection<string> { "uu5!^%jg", "123456" };

    [ObservableProperty]
    public partial string? SelectedPassword { get; set; }


    [RelayCommand]
    public async Task LoginAsync()
    {
        ProgressBarShowError = false;
        IsLogging = true;


        try
        {
            bool connected = await Task.Run(() =>
            {


                return Fsql.Ado.ExecuteConnectTest();
            });
            if (connected)
            {
                IsLogging = false;
                LoginSucceeded?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                IsLogging = true;
                ProgressBarShowError = true;
                //throw new Exception("连接失败，检查用户名及密码");
                var dialog = new ContentDialog
                {
                    Title = "错误！",
                    Content = $" 连接失败，检查用户名及密码",
                    CloseButtonText = "我知道了",
                    XamlRoot = App.CurrentWindow.Content.XamlRoot//MainWindow.Content.XamlRoot
                };

                await dialog.ShowAsync();
            }
        }
        catch
        {
            IsLogging = true;
            ProgressBarShowError = true;
            throw new Exception("连接失败，检查用户名及密码");
        }
    }

    public event EventHandler? LoginSucceeded;
}
