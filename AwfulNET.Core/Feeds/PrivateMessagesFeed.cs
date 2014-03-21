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
    public class PrivateMessagesFeed : CommonFeed<IEnumerable<PrivateMessageFolderFeed>>
    {
        [IgnoreDataMember]
        public IForumAccessToken Token
        {
            get
            {
                AccessTokenMessage message = new AccessTokenMessage();
                NotificationService.Default.Notify(this, message);
                return message.Token;
            }
        }

        private List<PrivateMessageFolderFeed> feeds;

        public PrivateMessagesFeed() : base() 
        {
            feeds = new List<PrivateMessageFolderFeed>(); 
        }

        protected override async Task<IEnumerable<PrivateMessageFolderFeed>> 
            GetContentAsync(bool refresh)
        {
            // always refresh this guy
            var folders = await Token.GetPrivateMessageFoldersAsync();
            feeds.Clear(); 
            folders.ForEach(item => feeds.Add(new PrivateMessageFolderFeed(item)));
            return feeds;
        }

        public PrivateMessageMetadata GetItemById(string id)
        {
            var item = feeds.SelectMany(feed => feed.Items)
                .Where(i => i.PrivateMessageId.Equals(id))
                .SingleOrDefault();

            return item;
        }
    }

    [DataContract]
    public class PrivateMessageFolderFeed : CommonFeed<PrivateMessageMetadataCollection>
    {
        [IgnoreDataMember]
        public IForumAccessToken Token
        {
            get 
            {
                AccessTokenMessage message = new AccessTokenMessage();
                NotificationService.Default.Notify(this, message);
                return message.Token;
            }
        }

        private PrivateMessageMetadataCollection items;
        [IgnoreDataMember]
        public PrivateMessageMetadataCollection Items { get { return items; } }

        public PrivateMessageFolderFeed(PrivateMessageMetadataCollection items)
        {
            this.items = items;
        }

        public PrivateMessageFolderFeed(PrivateMessageFolderMetadata metadata)
        {
            this.items = new PrivateMessageMetadataCollection(metadata);
        }

        protected override async Task<PrivateMessageMetadataCollection> GetContentAsync(bool refresh)
        {
            // only refresh if the items are empty, or a refresh is called
            if (items.Count == 0 || refresh)
                await items.RefreshAsync(Token);

            return items;
        }

        public override string ToString()
        {
            return this.items.FolderName;
        }
    }
}