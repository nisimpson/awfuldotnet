using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace AwfulNET.Common
{
    public sealed class WinRTHttpClient : IHttpClient
    {
        private static HttpClient client = new HttpClient();

        public Task<string> GetStringAsync(Uri uri)
        {
            return client.GetStringAsync(uri);
        }

        public Task<string> GetStringAsync(string uri)
        {
            return client.GetStringAsync(uri);
        }
    }
}
