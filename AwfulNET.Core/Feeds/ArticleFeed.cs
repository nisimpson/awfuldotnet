using AwfulNET.Common;
using AwfulNET.Core;
using QDFeedParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Feeds
{
    [DataContract]
    public class ArticleFeed : CommonFeed<IEnumerable<FrontPageArticle>>
    {
        public static ArticleFeed Instance;
        private List<FrontPageArticle> items;

        static ArticleFeed() { Instance = new ArticleFeed(); }

        public ArticleFeed() : base() 
        { 
            items = new List<FrontPageArticle>();
        }

        protected override async Task<IEnumerable<FrontPageArticle>> GetContentAsync(bool refresh)
        {
            // refresh if specified or the article collection is empty
            if (refresh || items.Count == 0)
            {
                NetworkDetectionMessage networkStatus = new NetworkDetectionMessage() { IsNetworkActive = true };
                NotificationService.Default.Notify<NetworkDetectionMessage>(this, networkStatus);
                if (!networkStatus.IsNetworkActive)
                    throw new WebException("The request failed. Please check your connection settings and try again.",
                        WebExceptionStatus.RequestCanceled);

                IEnumerable<FrontPageArticle> feeds = null;
                try { feeds = await FrontPageArticle.GetFrontPageAsync(); }
                catch (Exception ex) { throw ex; }
                items.Clear();
                items.AddRange(feeds);
            }

            return items;
        }
    }
}
