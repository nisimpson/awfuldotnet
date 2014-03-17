using AwfulNET.Core.Common;
using AwfulNET.WinRT.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Common
{
    public class SettingsModelFactory
    {
        public static ISettingsModel GetSettingsModel()
        {
            return new WinRTSettingsModel();
        }
    }
}
