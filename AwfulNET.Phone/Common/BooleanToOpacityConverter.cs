using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AwfulNET.Common
{
    /// <summary>
    /// PageValue converter that translates true to <see cref="Visibility.Visible"/> and false to
    /// <see cref="Visibility.Collapsed"/>.
    /// </summary>
    public sealed class BooleanToOpacityConverter : CommonValueConverter
    {
        protected override object Convert(object value, Type targetType, object parameter, ILanguageInfo languageInfo)
        {
            double percent = 100;
            if (parameter != null &&
                value is bool &&
                double.TryParse(parameter as string, out percent))
                return (bool)value ? percent / 100.0 : 1.0;

            return value;
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, ILanguageInfo languageInfo)
        {
            throw new NotImplementedException();
        }
    }
}
