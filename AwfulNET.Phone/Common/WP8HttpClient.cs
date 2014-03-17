using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Common
{
    public sealed class WP8HttpClient : IHttpClient
    {
        public Task<string> GetStringAsync(Uri uri)
        {
            HttpClient client = new HttpClient();
            return client.GetStringAsync(uri);
        }

        public Task<string> GetStringAsync(string uri)
        {
            HttpClient client = new HttpClient();
            return client.GetStringAsync(uri);
        }
    }
}
