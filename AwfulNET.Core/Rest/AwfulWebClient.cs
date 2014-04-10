
using AwfulNET.Core.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET
{
    public class AwfulWebClient
    {
        public const int DefaultTimeoutInMilliseconds = 60000;
        private const string BASE_URL = "http://forums.somethingawful.com";
        private const string BASE_LOGIN_URL = "https://forums.somethingawful.com";
        private const string COOKIE_DOMAIN_URL = "http://fake.forums.somethingawful.com";
        private const string DOMAIN_FIX = ".somethingawful.com";
        private const string LOGIN_URL = "http://forums.somethingawful.com/account.php?";
        public ForumAccessToken CurrentUser { get; private set; }

        private AwfulWebClient(ForumAccessToken metadata, HttpClient client) {
            this.CurrentUser = metadata;
            this.CurrentUser.Client = client;
        }

        private AwfulWebClient(ForumAccessToken metadata)
        {
            this.CurrentUser = metadata;
            this.CurrentUser.Client = CreateHttpClient(CreateHttpClientHandler(metadata.Cookies));
        }

        internal static HttpClient CreateHttpClient(List<Cookie> cookies)
        {
            return CreateHttpClient(CreateHttpClientHandler(cookies));
        }

        private static HttpClientHandler CreateHttpClientHandler(List<Cookie> cookies)
        {
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler()
            {
                CookieContainer = cookieContainer,
                UseCookies = true,
                AllowAutoRedirect = true,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            if (cookies != null)
            {
                var uri = new Uri(COOKIE_DOMAIN_URL, UriKind.Absolute);
                foreach (var cookie in cookies)
                    cookieContainer.Add(uri, cookie);
            }

            return handler;
        }

        private static HttpClient CreateHttpClient(HttpClientHandler handler)
        {
            var client = new HttpClient(handler) { 
                BaseAddress = new Uri(BASE_URL, UriKind.Absolute),
                Timeout = TimeSpan.FromSeconds(30)
            };

            client.DefaultRequestHeaders.AcceptEncoding.Clear();
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("sdch"));
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-US"));
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en"));
            client.DefaultRequestHeaders.UserAgent.Clear();
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Chrome", "31.0.1650.63"));
            client.DefaultRequestHeaders.CacheControl = CacheControlHeaderValue.Parse("max-age=0");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xhtml+xml"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/webp"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            return client;
        }

        public static async Task<ForumAccessToken> AuthenticateAsync(string username, string password)
        {
            var handler = CreateHttpClientHandler(null);
            var loginClient = CreateHttpClient(handler);
            loginClient.BaseAddress = new Uri(BASE_LOGIN_URL, UriKind.Absolute);

            HttpContent content = new FormUrlEncodedContent(
                new KeyValuePair<string,string>[]{
                    new KeyValuePair<string, string>("action", "login"),
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("next", "/")
                });

            string postData = await content.ReadAsStringAsync();
            postData = postData.Replace("!", "%21");

            content = new StringContent(postData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            content.Headers.Add("Origin", "http://forums.somethingawful.com");
         
            var response = await loginClient.PostAsync("/account.php", content);
            response.EnsureSuccessStatusCode();
            
            ForumAccessToken user = new ForumAccessToken();
            user.Username = username;

            // extract cookies
            var cookieUri = new Uri(COOKIE_DOMAIN_URL, UriKind.Absolute);
            var cookieCollection = handler.CookieContainer.GetCookies(cookieUri);
            user.Cookies = new List<Cookie>(cookieCollection.Count);

            // fix domain issue -> .forums.somethingawful.com to forums.somethingawful.com
            foreach (Cookie cookie in cookieCollection)
            {
                var fixedCookie = new Cookie(
                    cookie.Name,
                    cookie.Value,
                    "/",
                    DOMAIN_FIX);

                user.Cookies.Add(fixedCookie);
                handler.CookieContainer.Add(new Uri(BASE_URL), fixedCookie);
            }

            AwfulWebClient awc = new AwfulWebClient(user, loginClient);
            return user;
        }
    }
}
