using Microsoft.UI.Xaml.Data;

namespace DofGMTool.Helpers;

public class EnumDescriptionConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is Enum enumValue)
        {
            return EnumHelper.GetEnumDescription(enumValue);
        }
        return value.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
