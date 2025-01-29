using Microsoft.UI.Xaml.Data;

namespace DofGMTool.Helpers;

public class IntSpeedConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is int intSpeed)
        {
            int a = intSpeed / 10;
            return $"{a} %";
        }
        return "0 %";
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
