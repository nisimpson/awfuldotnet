using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwfulNET.Core.Feeds;
using AwfulNET.Common;
using AwfulNET.Views;
using System.IO;
using AwfulNET.Core.Rest;

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
            this.DataType = MainDataModel.DATATYPE_FOLDER;
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
                result.Add(new PrivateMessageItem(item, feed.Token) { Index = count++ });

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
        private bool imageSet = false;
        private bool statusSet = false;
        private IForumAccessToken myToken;
        private PrivateMessageMetadata metadata;
        private readonly WebViewScriptRequestHandler requestHandler;
        
        public PrivateMessageItem(PrivateMessageMetadata metadata, IForumAccessToken token) 
            : base(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, null)
        {
            this.DataType = MainDataModel.DATATYPE_PM;
            this.myToken = token;
            this.requestHandler = new WebViewScriptRequestHandler();
            this.requestHandler.AddEndpoint("item", OnThreadRequest);
            this.requestHandler.AddEndpoint("thread", OnThreadRequest);
            UpdateModel(metadata);
        }

        public PrivateMessageMetadata Metadata { get { return this.metadata; } }

        private string date = string.Empty;
        public string Date
        {
            get { return this.date; }
            set { SetProperty(ref this.date, value); }
        }

        private string status = string.Empty;
        public string Status
        {
            get { return this.status; }
            set
            {
                if (SetProperty(ref this.status, value))
                    OnPropertyChanged("IsOld");
            }
        }

        public bool IsOld { get { return this.status == "OLD"; } }

        public int Index { get; set; }

        private string FormatDescription(PrivateMessageMetadata metadata)
        {
            // grab the inner text from the message; strip any new lines.
            if (string.IsNullOrEmpty(metadata.RawText))
                return "loading preview...";

            string result = metadata.RawText.Replace("\t", string.Empty);
            result = result.Replace("\n", " ");
            result = result.Replace("\r", string.Empty);

            return result;
        }

        public void UpdateModel(PrivateMessageMetadata metadata)
        {
            this.metadata = metadata;
            this.Title = metadata.Subject;
            this.UniqueID = metadata.PrivateMessageId;
            this.Subtitle = metadata.From;
            this.Description = FormatDescription(metadata);
            this.Date = FormatDate(metadata);

            if (!statusSet)
            {
                this.Status = FormatStatus(metadata);
                statusSet = true;
            }

            if (!imageSet)
                this.SetImage(this.FormatIconImageSource(metadata));
        }

        private string FormatStatus(PrivateMessageMetadata metadata)
        {
            switch(metadata.Status)
            {
                case PrivateMessageMetadata.MessageStatus.Cancelled:
                    return "X";

                case PrivateMessageMetadata.MessageStatus.Forwarded:
                    return "FWD:";

                case PrivateMessageMetadata.MessageStatus.New:
                    return "NEW";

                case PrivateMessageMetadata.MessageStatus.Read:
                    return "OLD";

                case PrivateMessageMetadata.MessageStatus.Replied:
                    return "RE:";

                case PrivateMessageMetadata.MessageStatus.Unknown:
                    return "?";
            }

            return null;
        }

        private string FormatDate(PrivateMessageMetadata metadata)
        {
            return string.Format("{0} {1}",
                metadata.PostDate.Value.ToShortDateString(), metadata.PostDate.Value.ToShortTimeString());
        }

        private const string ICON_BASE = "http://raw.github.com/Awful/thread-tags/master/";
        private string FormatIconImageSource(PrivateMessageMetadata metadata)
        {
            if (string.IsNullOrEmpty(metadata.IconUri))
                return "AppBar/mail.png";

            string filename = Path.GetFileName(metadata.IconUri);
            filename = filename.Replace(Path.GetExtension(filename), ".png");
            imageSet = true;
            return ICON_BASE + filename;
        }

        #region WebViewHandler

        // Open new item page.
        private async Task OnThreadRequest(string scriptValue, string endpoint, dynamic json, IWebViewPage page)
        {
            int count = json.args;
            Task<ThreadPageMetadata> task = null;
            switch (count)
            {
                case 1:
                    string threadid = json.threadId;
                    task = this.myToken.GetNewPostAsync(threadid);
                    break;
                case 2:
                    task = OnThreadRequest(endpoint, json, page);
                    break;

                case 3:
                    string thread = json.thread;
                    int pageNumber = json.page;
                    task = this.myToken.GetThreadPageAsync(thread, pageNumber);
                    break;
            }

            // creating a progress token on the spot, would rather have it passed in as a parameter...
            var progress = IProgressFactory.GenerateProgressToken();
            progress.Report("Please wait...");

            ThreadPageMetadata threadPage = await task;

            progress.Report(null);

            // make sure we're out of the invokescript scope
            (page as IPrivateMessageView).OnNavigateToThreadPage(threadPage);

        }

        // Loads a thread page with the target url.
        private Task<ThreadPageMetadata> OnThreadRequest(string endpoint, dynamic json, IWebViewPage page)
        {
            string type = json.type;
            Task<ThreadPageMetadata> task = null;
            switch (type)
            {
                case "url":
                    string url = json.url;
                    task = this.myToken.GetThreadPageAsync(new Uri(url, UriKind.RelativeOrAbsolute));
                    break;
            }

            return task;
        }

        #endregion WebViewHandler

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

        public bool OnContextMenuOpening(string type, IContextMenu menu, object state, IProgress<string> progress)
        {
            bool open = false;
            if (type.Equals("item"))
            {  
                AwfulContextMenuItem reply = new AwfulContextMenuItem();
                reply.Header = "reply";
                reply.Command = new RelayCommand(() => { ShowNewMessageForm(state); });
                reply.Icon = "MailReply";
                menu.Items.Add(reply);

                AwfulContextMenuItem fwd = new AwfulContextMenuItem();
                fwd.Header = "forward";
                fwd.Command = new RelayCommand(() => { ShowNewMessageForm(state, true); });
                fwd.Icon = "MailForward";
                menu.Items.Add(fwd);

                AwfulContextMenuItem delete = new AwfulContextMenuItem();
                delete.Header = "delete...";
                delete.Command = new RelayCommand(async () => { await DeleteMessageAsync(state, progress); });
                delete.Icon = "MailDelete";
                menu.Items.Add(delete);

                open = true;
            }

            return open;
        }

        public Task<bool> OnContextMenuOpeningAsync(string type, IContextMenu menu, object state, IProgress<string> progress)
        {
            return Task.Run(() => OnContextMenuOpening(type, menu, state, progress));
        }

        private void ShowNewMessageForm(object state, bool isForward = false)
        {
            (state as IApplicationPage)
                .Navigate(new Uri(string.Format("/Views/PM/NewMessageView.xaml?id={0}{1}",
                    this.UniqueID, isForward ? "&fwd=true" : string.Empty), 
                    UriKind.RelativeOrAbsolute));
        }

        private async Task DeleteMessageAsync(object state, IProgress<string> progress)
        {
            ConfirmDialogMessage confirm = new ConfirmDialogMessage("Are you sure?", "Delete Message");
            NotificationService.Default.Notify(this, confirm);
            bool result = await confirm.ConfirmAsync;
            if (result)
            {
                bool success = false;
                progress.Report("Deleting message...");
                try { success = await metadata.DeleteAsync(this.myToken); }
                catch (Exception)
                {
                    success = false;
                    DialogMessage dialog = new DialogMessage("The request could not be made at this time. Please try again later.", "Oops! Something went wrong.");
                    NotificationService.Default.Notify(this, dialog);
                }
                finally { progress.Report(null); }

                if (success)
                {
                    PrivateMessageGroup group = this.Group as PrivateMessageGroup;
                    await group.OnRefreshAsync(state, progress);
                    progress.Report(null);
                }
            }
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