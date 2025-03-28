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
        // ��ʼ����־�ļ���
        _ = InitializeAsync();
    }

    private async Task InitializeAsync()
    {
        try
        {
            // ��ȡӦ�ó���ı��ش洢�ļ���
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            // �������ȡ��־�ļ���
            logFolder = await localFolder.CreateFolderAsync("DofGMTool\\Logs", CreationCollisionOption.OpenIfExists);
        }
        catch (Exception ex)
        {
            // ���񲢴����쳣���Է�ֹӰ��������
            System.Diagnostics.Debug.WriteLine($"Logger ��ʼ��ʧ��: {ex.Message}");
            // ������Ҫ�������Խ��쳣��Ϣ���浽�ڴ�������ط�
            logFolder = null;
        }
    }

    public async Task WriteLogAsync(string message, string fileName = "log.txt")
    {
        try
        {
            // ȷ����־�ļ����ѳ�ʼ��
            if (logFolder == null)
            {
                await InitializeAsync();
                if (logFolder == null)
                {
                    // �����Ȼ�޷���ʼ����־�ļ��У�ֱ�ӷ��أ���Ӱ��������
                    return;
                }
            }

            // �������ȡ��־�ļ�
            StorageFile logFile = await logFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);

            // д����־����
            string logMessage = $"[{DateTime.Now}] {message}\n";
            await FileIO.AppendTextAsync(logFile, logMessage);
        }
        catch (Exception ex)
        {
            // ���񲢴����쳣���Է�ֹӰ��������
            System.Diagnostics.Debug.WriteLine($"д����־ʧ��: {ex.Message}");
            // ������Ҫ�������Խ��쳣��Ϣ���浽�ڴ�������ط�
        }
    }

    public async Task OpenLogFolderAsync()
    {
        try
        {
            // ȷ����־�ļ����ѳ�ʼ��
            if (logFolder == null)
            {
                await InitializeAsync();
                if (logFolder == null)
                {
                    // ����޷���ʼ����־�ļ��У��׳��쳣�����÷�����
                    throw new Exception("��־�ļ���δ�ܳ�ʼ��");
                }
            }

            // ����־�ļ���
            bool isSuccess = await Launcher.LaunchFolderAsync(logFolder);
            if (!isSuccess)
            {
                throw new Exception("�޷�����־�ļ���");
            }
        }
        catch (Exception ex)
        {
            // ���񲢴����쳣���׳������÷�����
            System.Diagnostics.Debug.WriteLine($"����־�ļ���ʧ��: {ex.Message}");
            throw new Exception($"�޷�����־�ļ���: {ex.Message}");
        }
    }
}
