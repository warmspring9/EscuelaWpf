using System;
using System.Globalization;
using System.Windows;
using EscuelaWPF.Core;

namespace EscuelaWPF
{
    /// <summary>
    /// A converter that takes in a <see cref="BaseViewModel"/> and returns the specific UI control
    /// that should bind to it/>
    /// </summary>
    public class PopupContentConverter : BaseValueConverter<PopupContentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is AddGroupModalViewModel BasePopup)
                return new VerticalBaseMenuControl { DataContext = BasePopup.Content };
            else
                return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
