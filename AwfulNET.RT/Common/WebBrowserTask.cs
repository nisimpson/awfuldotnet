using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace AwfulNET.WinRT
{
    public class WebBrowserTask
    {
        public Uri Uri { get; set; }
        public void Show()
        {
            var exec = Launcher.LaunchUriAsync(this.Uri);
        }
    }
}
