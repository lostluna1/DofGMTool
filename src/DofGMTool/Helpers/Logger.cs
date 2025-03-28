using Windows.Storage;
using Windows.System;

namespace DofGMTool.Helpers;

public sealed class Logger
{
    private static readonly Lazy<Logger> lazy = new(() => new Logger());

    public static Logger Instance => lazy.Value;

    private StorageFolder? logFolder;

    private Logger()
    {
        // 初始化日志文件夹
        _ = InitializeAsync();
    }

    private async Task InitializeAsync()
    {
        try
        {
            // 获取应用程序的本地存储文件夹
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            // 创建或获取日志文件夹
            logFolder = await localFolder.CreateFolderAsync("DofGMTool\\Logs", CreationCollisionOption.OpenIfExists);
        }
        catch (Exception ex)
        {
            // 捕获并处理异常，以防止影响主流程
            System.Diagnostics.Debug.WriteLine($"Logger 初始化失败: {ex.Message}");
            // 根据需要，您可以将异常信息保存到内存或其他地方
            logFolder = null;
        }
    }

    public async Task WriteLogAsync(string message, string fileName = "log.txt")
    {
        try
        {
            // 确保日志文件夹已初始化
            if (logFolder == null)
            {
                await InitializeAsync();
                if (logFolder == null)
                {
                    // 如果仍然无法初始化日志文件夹，直接返回，不影响主流程
                    return;
                }
            }

            // 创建或获取日志文件
            StorageFile logFile = await logFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);

            // 写入日志内容
            string logMessage = $"[{DateTime.Now}] {message}\n";
            await FileIO.AppendTextAsync(logFile, logMessage);
        }
        catch (Exception ex)
        {
            // 捕获并处理异常，以防止影响主流程
            System.Diagnostics.Debug.WriteLine($"写入日志失败: {ex.Message}");
            // 根据需要，您可以将异常信息保存到内存或其他地方
        }
    }

    public async Task OpenLogFolderAsync()
    {
        try
        {
            // 确保日志文件夹已初始化
            if (logFolder == null)
            {
                await InitializeAsync();
                if (logFolder == null)
                {
                    // 如果无法初始化日志文件夹，抛出异常供调用方处理
                    throw new Exception("日志文件夹未能初始化");
                }
            }

            // 打开日志文件夹
            bool isSuccess = await Launcher.LaunchFolderAsync(logFolder);
            if (!isSuccess)
            {
                throw new Exception("无法打开日志文件夹");
            }
        }
        catch (Exception ex)
        {
            // 捕获并处理异常，抛出供调用方处理
            System.Diagnostics.Debug.WriteLine($"打开日志文件夹失败: {ex.Message}");
            throw new Exception($"无法打开日志文件夹: {ex.Message}");
        }
    }
}
