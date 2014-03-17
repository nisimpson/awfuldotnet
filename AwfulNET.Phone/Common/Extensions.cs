using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if WINDOWS_PHONE
using System.Windows.Media;
#elif NETFX_CORE
using Windows.UI.Xaml.Media;
#else
#endif

namespace AwfulNET.Common
{
    public static class Extensions
    {
        public static string ToCSSColorValue(this SolidColorBrush brush)
        {
            // aarrggbb -> #rrbbgg format
            return string.Format("#{0}", brush.Color.ToString().Substring(3));
        }
    }

    public static class DesignerExtensions
    {
        public static bool IsInDesignMode(this object viewmodel)
        {
#if WINDOWS_PHONE
            return System.ComponentModel.DesignerProperties.IsInDesignTool;
#elif NETFX_CORE    // WINDOWS STORE
            return Windows.ApplicationModel.DesignMode.DesignModeEnabled;
#else       // WPF
            return System.ComponentModel.DesignerProperties.GetIsInDesignMode(viewmodel);
#endif
        }
    }
}
