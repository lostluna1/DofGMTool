using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;

namespace DofGMTool.Helpers;
public class NewlineToBreakConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is string text)
        {
            // 替换 \n 为换行符
            text = text.Replace("\\n", "\n");
            // 替换两个百分号为一个百分号
            text = text.Replace("%%", "%");
            return text;
        }
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

