using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwfulNET.Views;
#if WINDOWS_PHONE
using Microsoft.Phone.Controls;
using System.Windows.Controls;
#else
using Windows.UI.Xaml.Controls;
#endif

namespace AwfulNET.Common
{
    internal delegate Task WebViewScriptRequest(string scriptValue, string endpoint, dynamic json, IWebViewPage page);

    internal class WebViewScriptRequestHandler
    {
        private Dictionary<string, WebViewScriptRequest> requestHandlers;

        public WebViewScriptRequestHandler()
        {
            requestHandlers = new Dictionary<string, WebViewScriptRequest>();
        }

        public void AddEndpoint(string endpoint, WebViewScriptRequest request)
        {
            if (requestHandlers.ContainsKey(endpoint))
                requestHandlers[endpoint] = request;
            else
                requestHandlers.Add(endpoint, request);
        }

        [Obsolete("This method is deprecated.")]
        public Task<Func<object, string>> OnWebViewScriptNotify(NotifyEventArgs args, IWebViewPage page)
        {
            string value = args.Value;
            dynamic obj = JsonHelper.Parse(value);
            string endpoint = obj.endpoint;
            dynamic state = obj.json;
            Task<Func<object, string>> request = requestHandlers[endpoint](value, endpoint, state, page);
            return request;
        }

        public Task OnWebViewScriptNotify(string value, IWebViewPage page)
        {
            dynamic obj = JsonHelper.Parse(value);
            string endpoint = obj.endpoint;
            dynamic state = obj.json;
            Task request = requestHandlers[endpoint](value, endpoint, state, page);
            return request;
        }
    }
}
