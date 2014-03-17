using QDFeedParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core
{
    [DataContract]
    public class FrontPageArticle
    {
        public const string FRONT_PAGE_RSS_URI = "http://www.somethingawful.com/rss/news.rss.xml";

        public FrontPageArticle() { }

        private FrontPageArticle(IFeedItem item) : this()
        {
            this.Title = item.Title;
            this.Author = item.Author;
            this.Categories = item.Categories;
            this.Content = item.Content;
            this.DatePublished = item.DatePublished;
            this.Id = item.Id;
            this.Link = item.Link;
        }

        private static async Task<IFeed> CreateFeedAsync()
        {
            var factory = new HttpFeedFactory();
            IFeed feed = null;
            try
            {
                feed = await factory.CreateFeedAsync(new Uri(FRONT_PAGE_RSS_URI));
            }

            catch (Exception ex) { throw ex; }
            return feed;
        }

        public static async Task<IEnumerable<FrontPageArticle>> GetFrontPageAsync()
        {
            List<FrontPageArticle> items = new List<FrontPageArticle>();

            IFeed feed = null;
            try { feed = await CreateFeedAsync(); }
            catch (Exception ex) { throw ex; }
            foreach (var item in feed.Items)
                items.Add(new FrontPageArticle(item));

            return items;
        }

        [DataMember]
        public string Title
        {
            get;
            set;
        }

        [DataMember]
        public string Author
        {
            get;
            set;
        }

        [DataMember]
        public string Id
        {
            get;
            set;
        }

        [DataMember]
        public string Link
        {
            get;
            set;
        }

        [DataMember]
        public DateTime DatePublished
        {
            get;
            set;
        }

        [DataMember]
        public string Content
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public IList<string> Categories
        {
            get;
            private set;
        }
    }

    internal class MyHttpFeedFactory : HttpFeedFactory
    {
        private static async Task<FeedTuple> StaticDownloadXmlAsync(Uri feedUri)
        {
            FeedTuple tuple = null;
            string content = null;
            HttpClient client = new HttpClient();
            content = await client.GetStringAsync(feedUri);
            tuple = new FeedTuple() { FeedUri = feedUri, FeedContent = content };
            return tuple;
        }

        public override IAsyncResult BeginDownloadXml(Uri feeduri, AsyncCallback callback)
        {
            return DownloadXmlAsync(feeduri).ToApm(callback, null);
        }

        public override FeedTuple EndDownloadXml(IAsyncResult asyncResult)
        {
            return ((Task<FeedTuple>)asyncResult).Result;
        }
    }
}
