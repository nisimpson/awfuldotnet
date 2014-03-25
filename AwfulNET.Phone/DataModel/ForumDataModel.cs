using AwfulNET.Common;
using AwfulNET.Core;
using AwfulNET.Core.Common;
using AwfulNET.Core.Feeds;
using AwfulNET.Core.Rest;
using AwfulNET.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AwfulNET.DataModel
{
    public class ForumsIndexGroup :
        AwfulDataGroupBase
    {
        private ForumsIndexFeed feed;
        private readonly Dictionary<ForumCategory, ICommonDataGroup> categories;
        private Func<ForumsIndexFeed> createFeed;
        private PinnedForumsGroup pinned;

        public PinnedForumsGroup Pinned { get { return this.pinned; } }

        public ForumsIndexGroup() : base(true, false)
        {   
            this.UniqueID = "forums";
            this.pinned = new PinnedForumsGroup(this);
            
            this.categories = new Dictionary<ForumCategory, ICommonDataGroup>();
            this.categories.Add(ForumCategory.MAIN, CreateCategory(ForumCategory.MAIN));
            this.categories.Add(ForumCategory.DISCUSSION, CreateCategory(ForumCategory.DISCUSSION));
            this.categories.Add(ForumCategory.ARTS, CreateCategory(ForumCategory.ARTS));
            this.categories.Add(ForumCategory.COMMUNITY, CreateCategory(ForumCategory.COMMUNITY));
            this.categories.Add(ForumCategory.ARCHIVES, CreateCategory(ForumCategory.ARCHIVES));
            this.categories.Add(ForumCategory.OTHER, CreateCategory(ForumCategory.OTHER));
        }
 
        public ForumsIndexGroup(ForumsIndexFeed feed, PinnedForumsGroup pinned) : this() {
            this.createFeed = () => feed;
        }

        public ForumsIndexGroup(PinnedForumsGroup pinned, Func<ForumsIndexFeed> feedDelegate) : this()
        {
            this.createFeed = feedDelegate;
        }

        #region Common Members

        private void ThreadDataGroup_PinChanged(object sender, EventArgs e)
        {
            ThreadDataGroup group = sender as ThreadDataGroup;
            if (group.IsPinned)
            {
                // if the group is pinned, add it the pinned items group
                pinned.Items.Add(group);
                // and add them to the profile
            }
            else
            {
                pinned.Items.Remove(group);
            }
        }

        private void InitializeFeed(ForumsIndexFeed feed)
        {
            this.feed = feed;
            this.feed.SubscribeAsync(OnNext, OnError, OnCompleted);
        }

        private ICommonDataGroup CreateCategory(ForumCategory category)
        {
            var group = new CommonDataGroup();
            group.Title = category.ToString().ToLower();
            return group;
        }

        private void OnCompleted()
        {
            this.IsBusy = false;
            SetOnItemsReady(true);
        }

        private void OnError(Exception obj)
        {
            this.IsBusy = false;
            SetOnItemsReady(false);
            NotificationService.Default.Notify<DialogMessage>(this,
                new DialogMessage("An error occurred while loading the forums.",
                    "Oops, something went wrong."));

            this.Items.Clear();
        }

        private void OnNext(ForumMetadataCollection obj)
        {
            // release awaiter
            this.IsBusy = false;
            SetOnItemsReady(true);

            Task<IEnumerable<ThreadDataGroup>>.Run(() => { return ProcessForums(obj); })
                .ContinueWith(task =>
                    {
                        OnProcessForumsCompleted(task.Result);
                    }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void OnProcessForumsCompleted(IEnumerable<ThreadDataGroup> enumerable)
        {
            this.Items.Clear();
            this.pinned.Items.Clear();

            foreach (var item in enumerable)
            {
                // add item to pins group, if applicable
                if (item.IsPinned)
                    pinned.Items.Add(item);

                // add item to forums group
                Items.Add(item);
            }

            // attach listener to pin changes
            ThreadDataGroup.PinChanged += ThreadDataGroup_PinChanged;

            // notify view of changes
            NotifyItemsSourceChanged();
        }

        private IEnumerable<ThreadDataGroup> ProcessForums(ForumMetadataCollection obj)
        {
            List<ThreadDataGroup> list = new List<ThreadDataGroup>(obj.Count);
            foreach (var metadata in obj)
            {
                PinnedForumQuery query = new PinnedForumQuery(metadata.ForumID);
                NotificationService.Default.Notify(this, query);

                // categorize each forum
                ThreadDataGroup forum = new ThreadDataGroup(
                    metadata, 
                    query.IsPinned);

                forum.Group = categories[metadata.Category];
                forum.DataType = MainDataModel.DATATYPE_FORUM;

                // add to this collection
                list.Add(forum);
            }

            return list;
        }

        #endregion

        #region IListViewModel

        public override bool CanRefresh()
        {
            return !this.IsBusy;
        }

        private void NotifyItemsSourceChanged()
        {
            this.ItemsSource = JumpListDataModel<ICommonDataModel>.CreateGroups(
                  this.Items,
                  item => item.Group.ToString());
        }

        private async Task LoadAsync(Func<Task> requestAsync, IProgress<string> progress)
        {
            this.IsBusy = true;
           
            // detach listener to pin changes
            ThreadDataGroup.PinChanged -= ThreadDataGroup_PinChanged;
            ReportProgress(progress, "Loading forums...");

            if (this.feed == null)
            {
                ReportProgress(progress, "Creating forums index feed...");
                this.feed = this.createFeed();
                this.InitializeFeed(feed);
            }
            
            await requestAsync();
            this.IsBusy = false;
            ReportProgress(progress, null);
        }

        protected override async Task OnSelectedAsyncCore(object state, IProgress<string> progress)
        {
            if (!this.IsBusy && this.Items.Count == 0)
                await LoadAsync(() =>
                {
                    if (this.feed == null)
                    {
                        ReportProgress(progress, "Creating forums index feed...");
                        this.feed = this.createFeed();
                        this.InitializeFeed(feed);
                    }
                    return this.feed.PullAsync();
                }, progress);
            else
            {
                SetOnItemsReady(true);
            }
        }

        protected override async Task OnRefreshAsyncCore(object state, IProgress<string> progress)
        {
            if (!this.IsBusy)
                await this.LoadAsync(() =>
                    {
                        if (this.feed == null)
                        {
                            ReportProgress(progress, "Creating forums index feed...");
                            this.feed = this.createFeed();
                            this.InitializeFeed(feed);
                        }
                        ReportProgress(progress, "Refreshing forums index...");
                        return this.feed.UpdateAsync();
                    }, progress);
            else
            {
                SetOnItemsReady(true);
            }
        }

        #endregion IListViewModel
    }

    public class PinnedForumsGroup :
        AwfulDataGroupBase
    {  
        private ForumsIndexGroup forumsIndex;
        private bool isNewInstance = false;
      
        public PinnedForumsGroup(ForumsIndexGroup forumsIndex) : base(false, false, true)
        {
            this.forumsIndex = forumsIndex;
            this.isNewInstance = true;
        }

        #region IListViewModel Implementation

        protected override async Task OnSelectedAsyncCore(object state, IProgress<string> progress)
        {
            if (this.isNewInstance)
            {
                EmptyText = "Please wait...";
                await forumsIndex.OnSelectedAsync(state, progress);
                this.ItemsSource = this.Items;
                EmptyText = "Long press your favorite forum and select 'pin to favorites'.";
                this.isNewInstance = false;
            }

             this.SetOnItemsReady(true);
        }

        public override bool CanRefresh()
        {
            return false;
        }

        protected override Task OnRefreshAsyncCore(object state, IProgress<string> progress)
        {
            throw new NotImplementedException("Item is not refreshable.");
        }

        #endregion IListViewModel
    }

    public sealed class PinnedForumQuery
    {
        public string UniqueID { get; private set; }
        public bool IsPinned { get; set; }
        public PinnedForumQuery(string uniqueID)
        {
            this.UniqueID = uniqueID;
            this.IsPinned = false;
        }
    }

    [DataContract]
    [Obsolete("This class is deprecated. Use the UserAccount object for user favorite information.", true)]
    public class PinnedForumsProfile
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        [Obsolete("This property is obsolete. Please use the PinnedForums property instead.", true)]
        public List<string> PinnedForumIDs { get; set; }

        private List<ForumMetadata> pinnedForums;
        [DataMember]
        public List<ForumMetadata> PinnedForums
        {
            get
            {
                if (this.pinnedForums == null)
                    this.pinnedForums = new List<ForumMetadata>();

                return this.pinnedForums;
            }
            set { this.pinnedForums = value; }
        }

        public PinnedForumsProfile()
        {
            this.Username = string.Empty;
            this.PinnedForums = new List<ForumMetadata>();
        }


        public void PinForum(ForumMetadata forum)
        {
            if (!ContainsForum(forum))
                PinnedForums.Add(forum);
        }

        private bool ContainsForum(ForumMetadata forum)
        {
            var contains = PinnedForums.Contains(forum, new GenericEqualityComparer<ForumMetadata>(
               (x, y) => x.ForumID.Equals(y.ForumID),
               (x) => x.ForumID.GetHashCode()));

            return contains;
        }

        public bool UnpinForum(ForumMetadata forum)
        {
            var pinned = PinnedForums.Where(x => x.ForumID.Equals(forum.ForumID)).SingleOrDefault();
            if (pinned != null)
                return PinnedForums.Remove(pinned);

            return false;
        }

        public bool IsPinned(ForumMetadata forum)
        {
            return ContainsForum(forum);
        }

        [Obsolete]
        public Task SaveAsync(IStorageModel storage)
        {
            return storage.SaveToStorageAsync(string.Format("{0}_pins.dat", this.Username),
                this);
        }

        [Obsolete]
        public static async Task<PinnedForumsProfile> LoadAsync(IStorageModel storage, string username)
        {
            PinnedForumsProfile profile = null;
            try
            {
                
                profile = await storage.LoadFromStorageAsync<PinnedForumsProfile>(
                    string.Format("{0}_pins.dat", username));
                 
            }
            
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                profile = new PinnedForumsProfile() { Username = username };
            }
            
            return profile;
        }
    }
}
