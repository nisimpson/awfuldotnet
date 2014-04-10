using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwfulNET;
using AwfulNET.Core;
using AwfulNET.Core.Common;

namespace System.Net.Http
{
    public interface IHttpRequestBuilder
    {
        void AddParameter(string name, object value);
        void AddParameter(string name, Func<string> toString);
        Task<HttpResponseMessage> SendRequestAsync(HttpClient client);
    }

    public class HttpGetRequestBuilder : IHttpRequestBuilder
    {
        private Dictionary<string, string> keyValues;
        private StringBuilder builder;
        private string endpoint;

        public HttpGetRequestBuilder(string endpoint)
        {
            keyValues = new Dictionary<string, string>();
            this.endpoint = endpoint;
            string format = endpoint[0] == '/' ? "{0}" : "/{0}";
            builder = new StringBuilder();
            builder.AppendFormat(format, endpoint);
        }

        public void AddParameter(string name, object value)
        {
            if (keyValues.Count == 0)
            {
                keyValues.Add(name, value.ToString());
                builder.AppendFormat("?{0}={1}",
                    name,
                    WebUtility.UrlEncode(value.ToString()));
            }
            else
            {
                if (keyValues.ContainsKey(name))
                    keyValues[name] = value.ToString();
                else
                    keyValues.Add(name, value.ToString());

                builder.AppendFormat("&{0}={1}",
                    name,
                    WebUtility.UrlEncode(value.ToString()));
            }
        }

        public override string ToString()
        {
            return builder.ToString();
        }

        public async Task<HttpResponseMessage> SendRequestAsync(HttpClient client)
        {
            Logger.Default.AddEntry(LogLevel.INFO, "[HttpGet] Sending request...");
            var result = await client.GetAsyncEx(builder.ToString());
            Logger.Default.AddEntry(LogLevel.INFO, "[HttpGet] Completed.");
            return result;
        }

        public void AddParameter(string name, Func<string> toString)
        {
            AddParameter(name, toString());
        }
    }

    public class HttpPostRequestBuilder : IHttpRequestBuilder
    {
        protected List<KeyValuePair<string, string>> pairs;
        string endpoint;
       

        public HttpPostRequestBuilder(string endpoint)
        {
            pairs = new List<KeyValuePair<string, string>>();
            this.endpoint = endpoint;
            if (endpoint[0] != '/')
                endpoint = "/" + endpoint;
        }

        public void AddParameter(string name, object value)
        {
            AddParameter(name, value, false);
        }

        public void AddParameter(string name, object value, bool encode)
        {
            string param = value.ToString();
            if (encode)
            {
                param = WebUtility.UrlEncode(param);
            }

            pairs.Add(new KeyValuePair<string, string>(name, param));
        }

        public virtual async Task<HttpResponseMessage> SendRequestAsync(HttpClient client)
        {
            /// For some reason formurlencodedcontent won't encode
            /// exclamation points, it's annoying as hell.
            HttpContent content = new FormUrlEncodedContent(pairs);
            string value = await content.ReadAsStringAsync();
            return await client.PostAsync(endpoint, content);
        }

        public void AddParameter(string name, Func<string> toString)
        {
            AddParameter(name, toString());
        }


        public Task<HtmlDocument> GetHtmlAsync(HttpClient client)
        {
            throw new NotImplementedException();
        }
    }

    public class MultipartPostRequestBuilder : HttpPostRequestBuilder
    {
        Windows1252Encoding westernEncoding = new Windows1252Encoding();
        private string endpoint;
        public MultipartPostRequestBuilder(string endpoint) : base(endpoint) { this.endpoint = endpoint; }

        public override async Task<HttpResponseMessage> SendRequestAsync(HttpClient client)
        {
            MultipartFormDataContent content = new MultipartFormDataContent(Guid.NewGuid().ToString());
            foreach(var pair in pairs)
            {
                var bytes = Encoding.UTF8.GetBytes(pair.Value);
                bytes = Encoding.Convert(Encoding.UTF8, westernEncoding, bytes);
                string encoded = westernEncoding.GetString(bytes, 0, bytes.Length);
                content.Add(new StringContent(encoded, westernEncoding), pair.Key);
            }

            return await client.PostAsync(endpoint, content);
        }
    }

    internal static class HttpPostRequestExtensions
    {
        public static async Task<HtmlDocument> GetHtmlAsync(this IHttpRequestBuilder builder, HttpClient client)
        {
            var result = await builder.SendRequestAsync(client);
            if (result.StatusCode == HttpStatusCode.NoContent)
                throw new HttpRequestException("404 Not Found");

            //result.EnsureSuccessStatusCode();
            HtmlDocument doc = await result.ToHtmlAsync();
            return doc;
        }

        public static async Task<bool> SendAndConfirmAsync(this IHttpRequestBuilder builder, HttpClient client)
        {
            bool success = false;
            try { var result = await builder.SendRequestAsync(client); result.EnsureSuccessStatusCode(); success = true; }
            catch (Exception) { success = false; }
            return success;
        }
    }
}
