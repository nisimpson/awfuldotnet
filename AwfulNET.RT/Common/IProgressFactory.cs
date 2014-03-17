using AwfulNET.RT.Common;
using AwfulNET.WinRT.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Common
{
    public class IProgressFactory
    {
        public static IProgress<string> GenerateProgressToken()
        {
            return new LoadingToken();
        }
    }
}
