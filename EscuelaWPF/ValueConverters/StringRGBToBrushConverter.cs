using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace EscuelaWPF
{
    /// <summary>
    /// A converter that takes in a rgb string and returns a <see cref="Brush"/>
    /// </summary>
    public class StringRGBToBrushConverter : BaseValueConverter<StringRGBToBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (SolidColorBrush)new BrushConverter().ConvertFrom($"#{value}");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
