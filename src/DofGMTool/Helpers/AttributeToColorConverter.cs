

using Microsoft.UI;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;

namespace DofGMTool.Helpers;
public partial class AttributeToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is string element)
        {
            return element switch
            {
                "火属性" => new SolidColorBrush(Colors.Red),
                "暗属性" => new SolidColorBrush(Colors.Purple),
                "冰属性" or "水属性" => new SolidColorBrush(Colors.CornflowerBlue),
                "光属性" => new SolidColorBrush(Colors.LightSkyBlue),
                _ => new SolidColorBrush(Colors.Black),
            };
        }
        return new SolidColorBrush(Colors.Black); // 默认颜色
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}