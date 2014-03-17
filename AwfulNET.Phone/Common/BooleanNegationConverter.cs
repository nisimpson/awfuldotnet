using System;

namespace AwfulNET.Common
{
    /// <summary>
    /// PageValue converter that translates true to false and vice versa.
    /// </summary>
    public sealed class BooleanNegationConverter : CommonValueConverter
    {
        protected override object Convert(object value, Type targetType, object parameter, ILanguageInfo languageInfo)
        {
            return !(value is bool && (bool)value);
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, ILanguageInfo languageInfo)
        {
            return !(value is bool && (bool)value);
        }
    }
}
