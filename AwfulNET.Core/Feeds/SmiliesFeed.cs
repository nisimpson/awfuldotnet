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
    public class SmiliesFeed : CommonFeed<IEnumerable<TagMetadata>>
    {
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
        private List<TagMetadata> items;

        public SmiliesFeed()
        {
            this.items = new List<TagMetadata>();
        }

        protected override async Task<IEnumerable<TagMetadata>> GetContentAsync(bool refresh)
        {
            if (items.Count == 0 || refresh)
            {
                items.Clear();
                var tags = await Token.GetSmiliesAsync();
                foreach (var tag in tags)
                    items.Add(tag);
            }

            return items;
        }
    }
}
