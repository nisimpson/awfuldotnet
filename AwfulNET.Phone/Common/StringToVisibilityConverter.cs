using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
#if !WINDOWS_PHONE
using Windows.UI.Xaml;
#endif

namespace AwfulNET.Common
{
    /// <summary>
    /// PageValue converter that translates true to <see cref="Visibility.Visible"/> and false to
    /// <see cref="Visibility.Collapsed"/>.
    /// </summary>
    public sealed class StringToVisibility : CommonValueConverter
    {
        protected override object Convert(object value, Type targetType, object parameter, ILanguageInfo languageInfo)
        {
            return (value is string && string.IsNullOrEmpty((string)value)) ? Visibility.Collapsed : Visibility.Visible;
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, ILanguageInfo languageInfo)
        {
            throw new NotImplementedException();
        }
    }
}
