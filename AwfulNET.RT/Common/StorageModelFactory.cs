using AwfulNET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Common
{
    public class StorageModelFactory
    {
        public static IStorageModel GetStorageModel()
        {
            return WinRTStorageModel.Instance;
        }
    }
}
