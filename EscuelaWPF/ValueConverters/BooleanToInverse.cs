using System;
using System.Globalization;
using System.Windows;

namespace EscuelaWPF
{
    /// <summary>
    /// A converter that takes in a boolean and returns its inverse
    /// </summary>
    public class BooleanToInverse : BaseValueConverter<BooleanToInverse>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !(bool)value;

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}

