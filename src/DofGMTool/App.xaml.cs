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
using SqlSugar;
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
            //Func<IServiceProvider, IFreeSql<MySqlFlag>> fsqlMysql = r =>
            //{
            //    var fsql1 = new FreeSqlBuilder().UseConnectionFactory(DataType.MySql, () =>
            //    {
            //        var conn = new MySqlConnection("data source=192.168.200.131;port=3306;user id=game;password=uu5!^%jg;initial catalog=taiwan_cain;sslmode=none;max pool size=2;Charset=latin1;");
            //        conn.Open(); 
            //        var cmd = conn.CreateCommand();
            //        cmd.CommandText = "SET Charset latin1;";
            //        cmd.ExecuteNonQuery();
            //        return conn;
            //    })
            //    .UseMonitorCommand(cmd => Debug.WriteLine($"Sql：{cmd.CommandText}"))
            //    .Build<MySqlFlag>();

            //    return fsql1;
            //};


            Func<IServiceProvider, IFreeSql<MySqlFlag>> fsqlMysql = r =>
            {
                string connectionString = "data source=192.168.200.131;port=3306;user id=game;password=uu5!^%jg;initial catalog=taiwan_cain;sslmode=none;max pool size=2;Charset=latin1;";

                IFreeSql<MySqlFlag> fsql1 = new FreeSqlBuilder().UseConnectionString(DataType.MySql, connectionString)
                .UseMonitorCommand(cmd => Debug.WriteLine($"Sql：{cmd.CommandText}"))
                .Build<MySqlFlag>();
                return fsql1;
            };

            Func<IServiceProvider, IFreeSql<SqliteFlag>> fsqlSqlite = r =>
            {
                string localFolder = ApplicationData.Current.LocalFolder.Path;
                string sqlitePath = System.IO.Path.Combine(localFolder, "database.sqlite");

                IFreeSql<SqliteFlag> fsql2 = new FreeSqlBuilder().UseConnectionString(DataType.Sqlite, $"Data Source={sqlitePath};")
                .UseAdoConnectionPool(true)
                .UseMonitorCommand(cmd => Debug.WriteLine($"Sql：{cmd.CommandText}"))
                .Build<SqliteFlag>();
                return fsql2;
            };
            services.AddSingleton<ISqlSugarClient>(provider =>
            {
                string connectionString = "Server=192.168.200.131;Database=taiwan_cain;User Id=game;Password=uu5!^%jg;";
                var db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = connectionString,
                    DbType = DbType.MySql,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.Attribute
                });

                // 配置 SQL 监控
                db.Aop.OnLogExecuting = (sql, pars) =>
                {
                    Debug.WriteLine($"Sql：{sql}");
                };

                return db;
            });
            services.AddSingleton<IFreeSql<MySqlFlag>>(fsqlMysql);
            services.AddSingleton<IFreeSql<SqliteFlag>>(fsqlSqlite);
            services.AddSingleton<IDatabaseService, DatabaseService>();// 注册动态数据库服务
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


    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        await App.GetService<IActivationService>().ActivateAsync(args);
    }
}
