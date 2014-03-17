using AwfulNET.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace AwfulNET.RT.Common
{
    public class ImageVisibilityConverter : CommonValueConverter
    {
        protected override object Convert(object value, Type targetType, object parameter, ILanguageInfo languageInfo)
        {
            ImageSource source = value as ImageSource;
            if (source == null)
                return Visibility.Collapsed;
            else
            {
                return Visibility.Visible;
            }
        }

        protected override object ConvertBack(object value, Type targetType, object parameter, ILanguageInfo languageInfo)
        {
            throw new NotImplementedException();
        }
    }
}
