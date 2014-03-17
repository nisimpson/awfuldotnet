using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AwfulNET.Core.Rest;
using AwfulNET.Core;
using AwfulNET.Common;

namespace AwfulNET.Core.Feeds
{
    [DataContract]
    public class ForumsIndexFeed : CommonFeed<ForumMetadataCollection>
    {
        private IStorageModel storage; 
        private ForumMetadataCollection items;

        /// <summary>
        /// Gets the access token used by the feed.
        /// </summary>
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

        public ForumsIndexFeed(IStorageModel storage) : base() { 
            items = new ForumMetadataCollection();
            this.storage = storage;
        }

        private async Task<ForumsCache> GetForumCacheAsync()
        {
            ForumsCache forums = null;

            // first, check if we've saved them to storage
            try
            {
                forums = await storage.LoadFromStorageAsync<ForumsCache>("forums.dat");
            }

            catch (Exception)
            {
                // something went wrong. log the error and create a new cache
                forums = new ForumsCache() { Cache = new List<ForumMetadata>() };
            }

            if (forums.Cache.Count == 0)
            {
                // oops! the cache is empty.
                // let's try grabbing forums from the web.
                forums.Cache.AddRange(await Token.GetForumListAsync());
                forums.LastUpdated = DateTime.Now;

                // silently save our fresh batch to the cache.
                var save = Task.Run(() => { SaveForumCacheAsync(forums); });
            }
            
            return forums;
        }

        private Task SaveForumCacheAsync(ForumsCache cache)
        {
            return this.storage.SaveToStorageAsync("forums.dat", cache);
        }

        private async Task<ForumMetadataCollection> GetForumsFromWebAsync()
        {
            ForumMetadataCollection items = null;

            // load forums from web, and overwrite cache
            var forums = await Token.GetForumListAsync();

            // the saving process doesn't need to be waited on, so move along
            if (null != forums)
            {
                ForumsCache cache = new ForumsCache();
                cache.Cache = new List<ForumMetadata>(forums);
                cache.LastUpdated = DateTime.Now;
                items = new ForumMetadataCollection(DateTime.Now);
                items.AddRange(GroupMetadata(forums));
                var save = Task.Run(() => { SaveForumCacheAsync(cache); });
            }

            // clear the items; maybe we'll have better luck with the cache...
            else { items.Clear(); }
            return items;
        }

        protected override async Task<ForumMetadataCollection> GetContentAsync(bool refresh)
        {
            IEnumerable<ForumMetadata> forums = null;

            // if we are refreshing, fetch from the web by default
            if (refresh)
            {
                items = await GetForumsFromWebAsync();
            }

            else if (items.Count == 0)
            {
                try
                {
                    // if we're here, then let's try loading from cache
                    if (forums == null)
                    {
                        var cache = await GetForumCacheAsync();

                        // if the cache fails for reason, go out to the web and fetch
                        if (cache.Cache.Count == 0)
                        {
                            items = await GetForumsFromWebAsync();
                            return items;
                        }

                        else
                        {
                            forums = cache.Cache;
                            items = new ForumMetadataCollection(cache.LastUpdated);
                        }
                    }

                    // group up our view items according to forum data
                    items.AddRange(GroupMetadata(forums));

                    return items;
                }
                catch (Exception ex) { throw new ArgumentException("Error while retrieving forums.", ex); }
            }

            return items;
        }

        private IEnumerable<ForumMetadata> GroupMetadata(IEnumerable<ForumMetadata> metadata)
        {
            /**************************************************************************************
             * forums are divided into several groups:
             *
             * 1) categories    (main, discussion, etc.)
             * 2) subforums     (GBS -> GBS, FYAD, Front Page)
             *
             * In order to represent this relationship in the view, forum items will be grouped
             * by subforum name, and these groups are separated by category name.
             **************************************************************************************/

            // enumerator for iterating
            var enumerator = metadata.GetEnumerator();

            // the current parent forum (i.e. forums with a level count of 1)
            ForumMetadata parent = null;

            // storage for the result
            List<ForumMetadata> result = new List<ForumMetadata>();

            // for group sorting
            int weight = 0;

            ForumMetadataGroup group = null;

            while (enumerator.MoveNext())
            {
                // declare our item
                ForumMetadata item = enumerator.Current;

                // set the parent if it is null, or if we are back at the top level
                if ((parent == null) || 
                    (parent.LevelCount == enumerator.Current.LevelCount))
                {
                    parent = enumerator.Current;
                    group = new ForumMetadataGroup(parent.ForumName, weight);
                    group.Description = parent.ForumDescription;
                    weight++;
                }

                // set the category (store in the Information property)
                item.Category = parent.Category;

                // set the group to the parent's name
                item.Group = group;

                // add item to storage
                result.Add(item);
            }

            return result;
        }

        #region ForumsCache

        [DataContract]
        public class ForumsCache
        {
            [DataMember]
            public DateTime LastUpdated { get; set; }

            [DataMember]
            public List<ForumMetadata> Cache { get; set; }
        }

        #endregion
    }
}