using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace EscuelaWPF
{
    /// <summary>
    /// Value Converter that permits direct xaml usage
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Private Members
        /// <summary>
        /// A single static instance of this value converter
        /// </summary>
        private static T mConverter;

        #endregion
        #region Instance methods
        /// <summary>
        /// Provides a static instance of the value converter 
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ??= new T();
        }

        #endregion
        #region Value Converter Methods
        /// <summary>
        /// A method to convert one type to another 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// A method to convert the type back to its original type.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}
