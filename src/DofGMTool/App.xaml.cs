using System.Diagnostics;
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
        if ((App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service)
        {
            throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
        }

        return service;
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

            /*Func<IServiceProvider, IFreeSql<MySqlFlag>> fsqlMysql = r =>
            {
                var fsql1 = new FreeSqlBuilder().UseConnectionString(DataType.MySql, "str1")
            .Build<MySqlFlag>();
                return fsql1;
            };*/
            Func<IServiceProvider, IFreeSql<SqliteFlag>> fsqlSqlite = r =>
            {
                var localFolder = ApplicationData.Current.LocalFolder.Path;
                var sqlitePath = System.IO.Path.Combine(localFolder, "database.sqlite");

                var fsql2 = new FreeSqlBuilder().UseConnectionString(DataType.Sqlite, $"Data Source={sqlitePath};")
                .UseAdoConnectionPool(true)
                .UseMonitorCommand(cmd => Debug.WriteLine($"Sql：{cmd.CommandText}"))
                .Build<SqliteFlag>();
                return fsql2;
            };

            //services.AddSingleton<IFreeSql<MySqlFlag>>(fsqlMysql);
            services.AddSingleton<IFreeSql<SqliteFlag>>(fsqlSqlite);
            // Configuration
            services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
        }).
        Build();

        UnhandledException += App_UnhandledException;
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }


    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        await App.GetService<IActivationService>().ActivateAsync(args);
    }
}
