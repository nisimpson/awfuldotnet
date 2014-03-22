using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwfulNET.Core.Feeds;
using AwfulNET.Common;
using AwfulNET.Views;
using System.IO;

namespace AwfulNET.DataModel
{
    public class PrivateMessageFolderIndex : AwfulDataGroupBase
    {
        private PrivateMessagesFeed feed;
        private IDisposable unsubscriber;
       
        public PrivateMessageFolderIndex() : base(false, false)
        {
            feed = new PrivateMessagesFeed();
            unsubscriber = feed.SubscribeAsync(OnNext, OnError, OnCompleted);
        }

        private void OnNext(IEnumerable<PrivateMessageFolderFeed> obj)
        {
           
            Task<IEnumerable<PrivateMessageGroup>>.Run(() => ProcessFolders(obj)).ContinueWith(task =>
                {
                    this.Items.Clear();
                    foreach(var item in task.Result)
                    {
                        this.Items.Add(item);
                    }
                    
                    this.ItemsSource = this.Items;
                    this.IsBusy = false;
                    this.SetOnItemsReady(true);

                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void OnError(Exception obj)
        {
            this.IsBusy = false;
            SetOnItemsReady(false);
            NotificationService.Default.Notify<DialogMessage>(this, new DialogMessage(obj.Message, "Oops! Something went wrong."));
            Items.Clear();
        }

        private void OnCompleted()
        {
            this.IsBusy = false;
            SetOnItemsReady(true);
        }

        private IEnumerable<PrivateMessageGroup> ProcessFolders(IEnumerable<PrivateMessageFolderFeed> items)
        {
            List<PrivateMessageGroup> groups = new List<PrivateMessageGroup>();
            foreach (var item in items)
                groups.Add(new PrivateMessageGroup(item));

            return groups;
        }

        protected override async Task OnSelectedAsyncCore(object state, IProgress<string> progress)
        {
            if (!this.IsBusy && this.Items.Count == 0)
            {
                this.IsBusy = true;
                this.ReportProgress(progress, "Loading index...");
                await this.feed.UpdateAsync();
            }
            else { SetOnItemsReady(true); }
        }

        public override bool CanRefresh()
        {
            return !this.IsBusy;
        }

        protected override Task OnRefreshAsyncCore(object state, IProgress<string> progress)
        {
            return this.OnSelectedAsync(state, progress);
        }
    }

    public class PrivateMessageGroup : AwfulDataGroupBase
    {
        private readonly PrivateMessageFolderFeed feed;
        private readonly IDisposable unsubscriber;

        public PrivateMessageGroup(PrivateMessageFolderFeed feed) : base(false, false)
        {
            this.feed = feed;
            this.unsubscriber = this.feed.SubscribeAsync(OnNext, OnError, OnCompleted);
            this.Title = this.feed.Items.FolderName;
            this.DataType = "Folder";
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
            NotificationService.Default.Notify<DialogMessage>(this, new DialogMessage(obj.Message, "Oops! Something went wrong."));
            this.Items.Clear();
        }

        private void OnNext(PrivateMessageMetadataCollection obj)
        {
            this.IsBusy = false;
            SetOnItemsReady(true);
            Task<IEnumerable<PrivateMessageItem>>.Run(() => ProcessCollection(obj)).ContinueWith(task =>
                {
                    var token = this.feed.Token;
                    this.Items.Clear();
                    foreach (var item in task.Result)
                    {
                        this.Items.Add(item);
                        item.Group = this;
                        item.Metadata.RefreshAsync(token).ContinueWith(
                            t => UpdatePrivateMessageItem(item, t),
                            TaskScheduler.FromCurrentSynchronizationContext());
                    }

                    this.ItemsSource = this.Items;

                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private IEnumerable<PrivateMessageItem> ProcessCollection(PrivateMessageMetadataCollection items)
        {
            List<PrivateMessageItem> result = new List<PrivateMessageItem>();
            int count = 0;
            foreach (var item in items)
                result.Add(new PrivateMessageItem(item) { Index = count++ });

            return result;
        }

        public void UpdatePrivateMessageItem(PrivateMessageItem item, Task<PrivateMessageMetadata> task)
        {
            item.UpdateModel(task.Result);
        }
        
        protected override async Task OnSelectedAsyncCore(object state, IProgress<string> progress)
        {
            if (!this.IsBusy && this.Items.Count == 0)
            {
                this.IsBusy = true;
                this.ReportProgress(progress, "Loading messages...");
                await this.feed.PullAsync();
            }
            else { SetOnItemsReady(true); }
        }

        public override bool CanRefresh()
        {
            return !this.IsBusy;
        }

        protected override async Task OnRefreshAsyncCore(object state, IProgress<string> progress)
        {
           if (CanRefresh())
           {
               this.IsBusy = true;
               this.ReportProgress(progress, "Refreshing folder...");
               await this.feed.UpdateAsync();
           }
           else { SetOnItemsReady(true); }
        }
    }

    public class PrivateMessageItem : CommonDataModel, 
        IWebViewModel<string>,
        IPaginationViewModelWithProgress<string>
    {
        private bool isBusy = false;
        private PrivateMessageMetadata metadata;
        
        public PrivateMessageItem(PrivateMessageMetadata metadata) 
            : base(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null)
        {
            this.DataType = "PrivateMessage";
            UpdateModel(metadata);
        }

        public PrivateMessageMetadata Metadata { get { return this.metadata; } }

        public int Index { get; set; }

        private string FormatDescription(PrivateMessageMetadata metadata)
        {
            // grab the inner text from the message; strip any new lines.
            if (string.IsNullOrEmpty(metadata.RawText))
                return "loading preview...";

            string result = metadata.RawText.Replace("\t", "");
            result = result.Replace("\n", " ");
            result = result.Replace("\r", " ");

            return result;
        }

        public void UpdateModel(PrivateMessageMetadata metadata)
        {
            this.metadata = metadata;
            this.Title = metadata.Subject;
            this.UniqueID = metadata.PrivateMessageId;
            this.Subtitle = metadata.From;
            this.Description = FormatDescription(metadata);
            this.SetImage(this.FormatIconImageSource(metadata));
        }

        private const string ICON_BASE = "http://raw.github.com/Awful/thread-tags/master/";
        private string FormatIconImageSource(PrivateMessageMetadata metadata)
        {
            if (string.IsNullOrEmpty(metadata.IconUri))
                return "AppBar/mail.png";

            string filename = Path.GetFileName(metadata.IconUri);
            filename = filename.Replace(Path.GetExtension(filename), ".png");
            return ICON_BASE + filename;
        }

        #region IWebViewModel<string>

        public Task OnScriptNotifyAsync(object state, string value)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            tcs.SetResult(true);
            return tcs.Task;
        }

        public Task OnScriptNotifyAsync(object state, IProgress<string> progress, string value)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            tcs.SetResult(true);
            return tcs.Task;
        }

        public async Task OnSelectedAsync(object state, IProgress<string> progress)
        {
            if (!isBusy)
            {
                IPrivateMessageView view = state as IPrivateMessageView;
                if (view == null)
                {
                    (state as IApplicationPage).Navigate(
                        new Uri("/Views/PM/PrivateMessagePage.xaml?id=" + this.UniqueID, UriKind.RelativeOrAbsolute));
                }
                else
                {
                    this.isBusy = true;
                    await LoadContentAsync(state, progress);
                    this.isBusy = false;
                }
            }
        }

        private async Task LoadContentAsync(object state, IProgress<string> progress, bool refresh = false)
        {
            // report progress
            progress.Report("Loading content...");

            if (refresh)
            {
                // grab access token
                AccessTokenMessage message = new AccessTokenMessage();
                NotificationService.Default.Notify<AccessTokenMessage>(this, message);
                
                // refresh the metadata in order to grab the body
                var result = await this.metadata.RefreshAsync(message.Token);
                UpdateModel(result);
            }

            // serialize metadata
            string json = await JsonHelper.SerializeObjectAsync(this.metadata);

            // present private message content to webview
            await (state as IWebViewPage).InvokeScriptAsync("viewMessage", json);

            // hide progress
            progress.Report(null);
        }

        // No context menus here.
        public bool OnContextMenuOpening(string type, IContextMenu menu, object state, IProgress<string> progress)
        {
            return false;
        }

        // No context menus here.
        public Task<bool> OnContextMenuOpeningAsync(string type, IContextMenu menu, object state, IProgress<string> progress)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            tcs.SetResult(false);
            return tcs.Task;
        }

        public bool CanRefresh()
        {
            return !this.isBusy;
        }

        public async Task OnRefreshAsync(object state, IProgress<string> progress)
        {
            if (CanRefresh())
            {
                this.isBusy = true;
                await LoadContentAsync(state, progress, true);
                this.isBusy = false;
            }
        }

        #endregion

        #region IPaginationViewModelWithProgress<string>

        public async Task<bool> GoToNextAsync(object state, IProgress<string> progress)
        {
            try
            {
                int currentIndex = this.Index;
                var nextItem = this.Group.Items[currentIndex + 1] as PrivateMessageItem;
                await nextItem.OnSelectedAsync(state, progress);
                (state as IPrivateMessageView).SetContentAsActive(nextItem);
                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> GoToPrevAsync(object state, IProgress<string> progress)
        {
            try
            {
                int currentIndex = this.Index;
                var nextItem = this.Group.Items[currentIndex - 1] as PrivateMessageItem;
                await nextItem.OnSelectedAsync(state, progress);
                (state as IPrivateMessageView).SetContentAsActive(nextItem);
                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> GoToPageAsync(int pageNumber, object state, IProgress<string> progress)
        {
            try
            {
                var nextItem = this.Group.Items[pageNumber] as PrivateMessageItem;
                await nextItem.OnSelectedAsync(state, progress);
                (state as IPrivateMessageView).SetContentAsActive(nextItem);
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool CanGoToNext()
        {
            return this.Index + 1 < this.Group.Items.Count;
        }

        public bool CanGoToPrev()
        {
            return this.Index - 1 >= 0;
        }

        public int? CurrentPage
        {
            get { return this.Index; }
        }

        public int LastPage
        {
            get { return this.Group.Items.Count - 1; }
        }

        #endregion
    }
}