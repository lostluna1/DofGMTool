using DofGMTool.Activation;
using DofGMTool.Contracts.Services;
using DofGMTool.Core.Contracts.Services;
using DofGMTool.Core.Services;
using DofGMTool.Models;
using DofGMTool.Services;
using DofGMTool.ViewModels;
using DofGMTool.Views;
using FreeSql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Diagnostics;
using Windows.Storage;

namespace DofGMTool;

// To learn more about WinUI 3, see https://docs.microsoft.com/windows/apps/winui/winui3/.
public partial class App : Application
{
    // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging
    public IHost Host
    {
        get;
    }

    public static T GetService<T>()
        where T : class
    {
        return (App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service
            ? throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.")
            : service;
    }

    public static WindowEx MainWindow { get; } = new MainWindow();

    public static UIElement? AppTitlebar
    {
        get; set;
    }

    public App()
    {
        InitializeComponent();

        Host = Microsoft.Extensions.Hosting.Host.
        CreateDefaultBuilder().
        UseContentRoot(AppContext.BaseDirectory).
        ConfigureServices((context, services) =>
        {
            // Default Activation Handler
            services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

            // Other Activation Handlers

            // Services
            services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddTransient<INavigationViewService, NavigationViewService>();

            services.AddSingleton<IActivationService, ActivationService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IPvfExtensionsService, PvfExtensionsService>();
            services.AddSingleton<IInventoryManageService, InventoryManageService>();
            services.AddSingleton<IEquipSlotProcessor, EquipSlotProcessor>();
            services.AddSingleton<ICharacterManagerService, CharacterManagerService>();
            services.AddSingleton<ISendMailService, SendMailService>();
            // HttpClient
            services.AddHttpClient();
            services.AddSingleton<IApiService, HttpService>();
            //services.AddSingleton<CharacInfo>();// 注册角色信息服务

            // Core Services
            services.AddSingleton<IFileService, FileService>();

            // Views and ViewModels
            services.AddTransient<MailManageViewModel>();
            services.AddTransient<MailManagePage>();
            services.AddTransient<CharacterManageViewModel>();
            services.AddTransient<CharacterManagePage>();
            services.AddTransient<InventoryManageViewModel>();
            services.AddTransient<InventoryManagePage>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<SettingsPage>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<MainPage>();
            services.AddTransient<ShellPage>();
            services.AddTransient<ShellViewModel>();

            static IFreeSql<SqliteFlag> fsqlSqlite(IServiceProvider r)
            {
                string localFolder = ApplicationData.Current.LocalFolder.Path;
                string sqlitePath = System.IO.Path.Combine(localFolder, "database.sqlite");

                IFreeSql<SqliteFlag> fsql2 = new FreeSqlBuilder().UseConnectionString(DataType.Sqlite, $"Data Source={sqlitePath};")
                .UseAdoConnectionPool(true)
                .UseMonitorCommand(cmd => Debug.WriteLine($"Sql：{cmd.CommandText}"))
                .Build<SqliteFlag>();
                return fsql2;
            }

            services.AddSingleton<IFreeSql<SqliteFlag>>(fsqlSqlite);
            // Configuration
            services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
            services.Configure<ApiSettings>(context.Configuration.GetSection(nameof(ApiSettings)));
        }).
        Build();

        UnhandledException += App_UnhandledException;
    }

    /// <summary>
    /// 全局异常处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        e.Handled = true;

        var dialog = new ContentDialog
        {
            Title = "错误！",
            Content = $" {e.Exception.Message}",
            CloseButtonText = "我知道了",
            XamlRoot = /*App.CurrentWindow.Content.XamlRoot//*/MainWindow.Content.XamlRoot
        };

        await dialog.ShowAsync();
    }

    public static Window CurrentWindow = Window.Current;

    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        //CurrentWindow = new LoginWindow();

        App.MainWindow.Closed += CurrentWindow_Closed;
        //CurrentWindow.Activate();
        base.OnLaunched(args);

        await App.GetService<IActivationService>().ActivateAsync(args);
    }
    private void CurrentWindow_Closed(object sender, WindowEventArgs e)
    {
        //DatabaseHelper.Instance.Dispose();
    }
}
