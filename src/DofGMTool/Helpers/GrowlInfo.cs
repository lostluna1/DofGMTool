using WinUICommunity;

namespace DofGMTool.Helpers;

public static class GrowlMsg
{
    public static void Show(string message, bool success, int sec = 3)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            message = "";
        }
        if (!success)
        {
            Growl.Warning(new GrowlInfo
            {
                ShowDateTime = true,
                StaysOpen = false,
                IsClosable = true,
                Title = "失败",
                Message = message,
                Token = "Test",
                WaitTime = new TimeSpan(0, 0, sec),
            });
        }
        else
        {
            Growl.Success(new GrowlInfo
            {
                ShowDateTime = true,
                StaysOpen = false,
                IsClosable = true,
                Title = "成功",
                Message = message,
                Token = "Test",
                WaitTime = new TimeSpan(0, 0, sec),
            });
        }
    }
}
