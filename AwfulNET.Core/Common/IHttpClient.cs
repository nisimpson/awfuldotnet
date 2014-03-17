using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Common
{
    public interface IHttpClient
    {
        Task<string> GetStringAsync(Uri uri);
        Task<string> GetStringAsync(string uri);
    }
}
