using Microsoft.UI.Xaml.Data;

namespace DofGMTool.Helpers;

public class WeightToKgConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is int weightInGrams)
        {
            double weightInKg = weightInGrams / 1000.0;
            return $"{weightInKg:F1} kg";
        }
        return "0 kg";
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
