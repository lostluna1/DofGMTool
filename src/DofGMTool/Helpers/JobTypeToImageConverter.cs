using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media.Imaging;

namespace DofGMTool.Helpers;

public partial class JobTypeToImageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is sbyte job)
        {
            return job switch
            {
                0 => new BitmapImage(new Uri("ms-appx:///Assets/defaultfaces/0.png")),
                1 => new BitmapImage(new Uri("ms-appx:///Assets/defaultfaces/1.png")),
                2 => new BitmapImage(new Uri("ms-appx:///Assets/defaultfaces/2.png")),
                3 => new BitmapImage(new Uri("ms-appx:///Assets/defaultfaces/3.png")),
                4 => new BitmapImage(new Uri("ms-appx:///Assets/defaultfaces/4.png")),
                5 => new BitmapImage(new Uri("ms-appx:///Assets/defaultfaces/5.png")),
                6 => new BitmapImage(new Uri("ms-appx:///Assets/defaultfaces/6.png")),
                7 => new BitmapImage(new Uri("ms-appx:///Assets/defaultfaces/7.png")),
                8 => new BitmapImage(new Uri("ms-appx:///Assets/defaultfaces/8.png")),
                9 => new BitmapImage(new Uri("ms-appx:///Assets/defaultfaces/9.png")),
                10 => new BitmapImage(new Uri("ms-appx:///Assets/defaultfaces/10.png")),

                _ => new BitmapImage(new Uri("ms-appx:///Assets/baidu_tieba_dof.jpg")),
            };
        }
        return new BitmapImage(new Uri("ms-appx:///Assets/baidu_tieba_dof.jpg"));
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
