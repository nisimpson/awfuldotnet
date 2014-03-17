using AwfulNET.Common;
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
    public class ForumThreadsFeed : CommonFeed<ThreadMetadataCollection>
    {
        private static Dictionary<string, ForumThreadsFeed> threadTable;

        static ForumThreadsFeed() { threadTable = new Dictionary<string, ForumThreadsFeed>(); }

        [IgnoreDataMember]
        public ForumAccessToken Token
        {
            get 
            {
                AccessTokenMessage message = new AccessTokenMessage();
                NotificationService.Default.Notify(this, message);
                return message.Token;
            }
        }

        private ThreadMetadataCollection items;

        [DataMember]
        public int CurrentPage { get; set; }
        [DataMember]
        public int PageCount { get; set; }
        [DataMember]
        public string ForumID { get; set; }

        internal ForumThreadsFeed()
            : base()
        {
            this.CurrentPage = 0;
            this.PageCount = 1;
            this.items = new ThreadMetadataCollection();
        }

        public ForumThreadsFeed(string forumId) : this()
        {
            this.ForumID = forumId;
            
            if (threadTable.ContainsKey(forumId))
            {
                var feed = threadTable[forumId];
                this.CurrentPage = feed.CurrentPage;
                this.PageCount = feed.PageCount;
                this.items = feed.items;
            }

            else
            {
                this.CurrentPage = 0;
                this.PageCount = 1;
                this.items = new ThreadMetadataCollection();
                threadTable.Add(this.ForumID, this);
            }
        }

        protected ForumAccessToken GetToken() { return this.Token; }

        protected virtual async Task<ForumPageMetadata> GetMetadataAsync(int page)
        {
            ForumMetadata forum = new ForumMetadata() { ForumID = this.ForumID };
            var result = await forum.GetForumPageAsync(Token, page);
            return result;
        }

        protected virtual Task<ThreadMetadataCollection> OnItemsCreated(
            ThreadMetadataCollection collection)
        {
            // don't do anything here.
            TaskCompletionSource<ThreadMetadataCollection> tcs = 
                new TaskCompletionSource<ThreadMetadataCollection>();

            tcs.SetResult(collection);
            return tcs.Task;
        }

        protected async override Task<ThreadMetadataCollection> GetContentAsync(bool refresh)
        {
            // if we are refreshing, set the currentPage to zero.
            if (refresh) { this.CurrentPage = 0; }

            // if the current page equals the page count, send null (completion).
            if (CurrentPage == PageCount)
                return null;

            // if we aren't refreshing, load more bookmarks from the next page.
            var newPage = this.CurrentPage + 1;
            var metadata = await GetMetadataAsync(newPage);

            try
            {
                this.items.Clear();
                metadata.Threads.ForEach(item => { items.Add(item); });
                this.CurrentPage = newPage;
                this.PageCount = metadata.PageCount;
            }
            catch (Exception ex) { throw new ArgumentException("Error retreiving threads.", ex); }

            // sort by score
            items = await OnItemsCreated(items);
            items.PageNumber = this.CurrentPage;
            items.ForumID = metadata.ForumID;
            return items;
        }
    }
}
