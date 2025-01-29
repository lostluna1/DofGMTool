using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;

namespace DofGMTool.Helpers;

public class StringToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is int intValue && intValue == 0 || value == null)
        {
            value = string.Empty;//return string.Empty;
        }
        
        return string.IsNullOrEmpty(value?.ToString()) ? Visibility.Collapsed : Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

