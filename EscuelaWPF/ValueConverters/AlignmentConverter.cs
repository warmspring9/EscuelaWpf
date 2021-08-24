﻿using System;
using System.Globalization;
using System.Windows;

namespace EscuelaWPF.ValueConverters
{
    public class AlignmentConverter : BaseValueConverter<AlignmentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (HorizontalAlignment)value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
