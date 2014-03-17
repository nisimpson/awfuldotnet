using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if !WINDOWS_PHONE
using Windows.UI.Xaml.Data;
#else
using System.Windows.Data;
#endif

namespace AwfulNET.Common
{
    public abstract class CommonValueConverter : IValueConverter
    {
        protected abstract object Convert(object value, Type targetType, object parameter, ILanguageInfo languageInfo);
        protected abstract object ConvertBack(object value, Type targetType, object parameter, ILanguageInfo languageInfo);

#if !WINDOWS_PHONE
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return Convert(value, targetType, parameter, new WinRTLanguageInfo(language));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ConvertBack(value, targetType, parameter, new WinRTLanguageInfo(language));
        }
#else
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Convert(value, targetType, parameter, new WPLanguageInfo(culture));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ConvertBack(value, targetType, parameter, new WPLanguageInfo(culture));
        }
#endif
    }

    public interface ILanguageInfo
    {
        string GetLanguage();
    }


#if !WINDOWS_PHONE

    public sealed class WinRTLanguageInfo : ILanguageInfo
    {
        private string language;
        public WinRTLanguageInfo(string language) { this.language = language; }

        public string GetLanguage()
        {
            return this.language;
        }
    }
#else
    public sealed class WPLanguageInfo : ILanguageInfo
    {
        System.Globalization.CultureInfo info;
        public WPLanguageInfo(System.Globalization.CultureInfo info) { this.info = info; }

        public string GetLanguage()
        {
            return info.TwoLetterISOLanguageName;
        }
    }
#endif
}
