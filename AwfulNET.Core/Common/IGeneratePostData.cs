using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Common
{
    internal interface IPostRequest
    {
        Task<HttpResponseMessage> PostAsync(HttpClient client);
    }
}