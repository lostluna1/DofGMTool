using Microsoft.UI.Xaml.Data;

namespace DofGMTool.Helpers;

public partial class UInt64ToDoubleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is ulong ulongValue)
        {
            return (double)ulongValue;
        }
        return 0.0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (value is double doubleValue)
        {
            return (ulong)doubleValue;
        }
        return 0UL;
    }
}
