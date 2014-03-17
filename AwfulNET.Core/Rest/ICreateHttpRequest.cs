using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace AwfulNET.Core.Rest
{
    public interface ICreateHttpRequestBuilder
    {
        IHttpRequestBuilder CreateHttpRequestBuilder();
    }
}
