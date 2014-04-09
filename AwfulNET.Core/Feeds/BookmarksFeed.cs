
using AwfulNET.Core.Common;
using AwfulNET.Core.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Feeds
{
    [DataContract]
    public class BookmarksFeed : ForumThreadsFeed
    {
        public BookmarksFeed() : base() { }

        protected override Task<ThreadMetadataCollection> OnItemsCreated(ThreadMetadataCollection collection)
        {
            // we're going to sort later.
            //collection.Sort(CompareThreadByWeightScore.Instance);
            return base.OnItemsCreated(collection);
        }

        protected override Task<ForumPageMetadata> GetMetadataAsync(int page)
        {
            var token = this.GetToken();
            return token.GetBookmarkPageAsync(page);
        }
    }
}