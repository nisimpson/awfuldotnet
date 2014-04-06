using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwfulNET.Core.Feeds;
using AwfulNET.Core.Rest;
using AwfulNET.Common;
using System.IO;
using System.Windows;
using AwfulNET.Views;
using Microsoft.CSharp.RuntimeBinder;
#if WINDOWS_PHONE
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;
using AwfulNET.Core.Common;
#else
using AwfulNET.WinRT;
#endif

namespace AwfulNET.DataModel
{
    public class ThreadDataGroup : AwfulDataGroupBase,
        IPinnableDataModel
    {
        private ForumThreadsFeed feed;
        private IDisposable unsubscriber;
        private int currentPage;

        protected ThreadDataGroup(ForumThreadsFeed feed)
            : base(false, true)
        {
            InitializeFeed(feed);
            InitializeLoadMoreItemsCommand();
            this.UniqueID = Guid.NewGuid().ToString();
        }

        public ThreadDataGroup(ForumMetadata forum, bool isPinned)
            : this(new ForumThreadsFeed(forum.ForumID))
        {
            this.UniqueID = forum.ForumID;
            this.Metadata = forum;
            this.Title = forum.ForumName;
            this.Subtitle = forum.ForumDescription;
            this.isPinned = isPinned;
        }

        #region IObserver

        private void OnError(Exception obj)
        {
            this.IsBusy = false;
            SetOnItemsReady(false);

            // clear our items.
            this.Items.Clear();

            // handle error.
            HandleError(obj);
        }

        // Handle any processing of the thread metadata list here (i.e. sorting)
        protected virtual IEnumerable<ThreadMetadata> ProcessThreadCollection(ThreadMetadataCollection obj)
        {
            return obj;
        }

        private IEnumerable<ICommonDataModel> ProcessItems(ThreadMetadataCollection obj)
        {
            var processed = ProcessThreadCollection(obj);

            foreach (var item in processed)
            {
                ThreadDataItem data = new ThreadDataItem(item, this.feed.Token);
                data.Group = this;
                this.Items.Add(data);
            }

            return this.Items;
        }

        private async void OnNext(ThreadMetadataCollection obj)
        {
            this.IsBusy = false;
            SetOnItemsReady(true);

            // is this batch of threads from the first page?
            // if so, then clear out our items.
            if (obj.PageNumber == 1)
            {
                ItemsSource = null;
                Items.Clear();
                DisableCollectionChanged();
                await Task.Run(() => { ProcessItems(obj); });
                EnableCollectionChanged();
                this.ItemsSource = Items;
            }

            else { ProcessItems(obj); }

            this.currentPage = obj.PageNumber;
            this.HasMoreItems = true;
            this.LoadMoreItemsStatus = "more...";

            this.loadMoreItemsCommand.RaiseCanExecuteChanged();
        }

        private void OnCompleted()
        {
            this.IsBusy = false;
            this.HasMoreItems = false;
            this.LoadMoreItemsStatus = "-";
        }

        #endregion IObserver

        #region Common Members

        protected void InitializeFeed(ForumThreadsFeed feed)
        {
            if (feed != null)
            {
                this.feed = feed;
                this.unsubscriber = this.feed.SubscribeAsync(OnNext, OnError, OnCompleted);
            }
        }

        private void HandleError(Exception obj)
        {
            NotificationService.Default.Notify<DialogMessage>(this,
                new DialogMessage(obj.Message, "Oops, something went wrong."));
        }

        #endregion Common Members

        #region IHomePageVirtualList Implementation

        private bool hasMoreItems = false;
        public override bool HasMoreItems
        {
            get { return this.hasMoreItems; }
            protected set
            {
                if (SetProperty(ref this.hasMoreItems, value))
                    this.loadMoreItemsCommand.RaiseCanExecuteChanged();
            }
        }

        private string loadMoreItemsStatus = string.Empty;
        public string LoadMoreItemsStatus
        {
            get { return this.loadMoreItemsStatus; }
            protected set { SetProperty(ref this.loadMoreItemsStatus, value); }
        }

        #endregion

        #region IPinnableDataModel Implementation

        private bool isPinned = false;
        public bool IsPinned
        {
            get { return isPinned; }
            set
            {
                if (SetProperty(ref this.isPinned, value))
                {
                    OnPinChanged(this);
                }
            }
        }

        public static event EventHandler PinChanged;
        protected virtual void OnPinChanged(ThreadDataGroup group)
        {
            var handler = PinChanged;
            if (handler != null)
                handler(group, EventArgs.Empty);
        }

        #endregion IPinnableDataModel Implementation

        #region IListViewModel Implementation

        public override bool CanRefresh()
        {
            return !this.IsBusy;
        }

        private RelayCommand<IProgress<string>> loadMoreItemsCommand;
        public override System.Windows.Input.ICommand LoadMoreItemsCommand
        {
            get { return this.loadMoreItemsCommand; }
        }

        private void InitializeLoadMoreItemsCommand()
        {
            loadMoreItemsCommand = new RelayCommand<IProgress<string>>(LoadMoreItemsAsync, CanLoadMoreItems);
        }

        // It's safe to load more items when we're not busy and have more items to load
        private bool CanLoadMoreItems(IProgress<string> arg)
        {
            return !this.IsBusy && this.HasMoreItems;
        }

        private async void LoadMoreItemsAsync(IProgress<string> obj)
        {
            if (this.feed != null)
            {
                this.IsBusy = true;
                this.loadMoreItemsCommand.RaiseCanExecuteChanged();
                ReportProgress(obj, "Loading next page...");
                this.LoadMoreItemsStatus = "please wait...";

                await this.feed.PullAsync();
                ReportProgress(obj, null);
            }
        }

        protected override async Task OnSelectedAsyncCore(object page, IProgress<string> progress)
        {
            var navigateToListView = await OnSelectedAsync(page, progress, this.feed);

            // navigate to a page with a list view if need be
            if (navigateToListView)
                (page as IApplicationPage).Navigate(new Uri("/ListView.xaml?id=" + this.UniqueID, UriKind.RelativeOrAbsolute));
        }

        protected virtual async Task<bool> OnSelectedAsync(object page, IProgress<string> progress, ForumThreadsFeed feed)
        {
            if (!this.IsBusy && this.Items.Count == 0)
            {
                this.IsBusy = true;
                this.loadMoreItemsCommand.RaiseCanExecuteChanged();
                progress.Report("Loading threads...");
                await feed.PullAsync();
                progress.Report(null);
            }

            SetOnItemsReady(true);
            return true;
        }

        public override bool OnContextMenuOpening(string type, IContextMenu menu, object page, IProgress<string> progress)
        {
            AwfulContextMenuItem pinToggle = new AwfulContextMenuItem();
            pinToggle.Header = this.isPinned ? "unpin from favorites" : "pin to favorites";
            pinToggle.Icon = this.isPinned ? "UnPin" : "Pin";
            pinToggle.Command = new RelayCommand(() => { this.IsPinned = !this.IsPinned; });
            menu.Items.Clear();
            menu.Items.Add(pinToggle);
            return true;
        }

        public override Task<bool> OnContextMenuOpeningAsync(string type, IContextMenu menu, object page, IProgress<string> progress)
        {
            // remember, this is running on a background item.
            return Task<bool>.Run(() => this.OnContextMenuOpening(type, menu, page, progress));
        }

        protected override async Task OnRefreshAsyncCore(object page, IProgress<string> progress)
        {
            if (!this.IsBusy)
            {
                this.IsBusy = true;
                progress.Report("Refreshing threads...");
                await this.feed.UpdateAsync();
                progress.Report(null);
            }
        }

        #endregion

        public ForumMetadata Metadata { get; private set; }
    }

    public sealed class BookmarkDataGroup : ThreadDataGroup
    {
        private readonly BookmarksFeed bookmarksFeed;

        public enum SortStyle
        {
            Awful = 0,
            Classic
        }

        private SortStyle sortStyle = SortStyle.Awful;
        public SortStyle SortingStyle
        {
            get { return this.sortStyle; }
            set
            {
                if (SetProperty(ref this.sortStyle, value))
                    this.SortItems(value);
            }
        }

        private RelayCommand toggleStyleCommand = null;
        public RelayCommand ToggleStyleCommand { get { return this.toggleStyleCommand; } }

        public BookmarkDataGroup(BookmarksFeed feed)
            : base(feed)
        {
            this.bookmarksFeed = feed;
            this.toggleStyleCommand = new RelayCommand(ToggleStyle);
        }

        private void ToggleStyle()
        {
            if (this.sortStyle == SortStyle.Awful)
                this.SortingStyle = SortStyle.Classic;
            else
                this.SortingStyle = SortStyle.Awful;
        }

        private void SortItems(SortStyle value)
        {
            IOrderedEnumerable<ICommonDataModel> sorted = null;
            if (value == SortStyle.Awful)
            {
                sorted = this.Items.OrderBy((model) => { return (model as ThreadDataItem).Thread; },
                    CompareThreadByNewPost.Instance);
            }
            else
            {
                sorted = this.Items.OrderBy((model) => { return (model as ThreadDataItem).Thread; },
                    CompareThreadByKilledByDate.Instance);
            }

            this.Items.Clear();
            foreach (var item in sorted)
                this.Items.Add(item);
        }

        protected override IEnumerable<ThreadMetadata> ProcessThreadCollection(ThreadMetadataCollection obj)
        {
            if (this.SortingStyle == SortStyle.Awful)
                obj.Sort(CompareThreadByNewPost.Instance);
            else
                obj.Sort(CompareThreadByKilledByDate.Instance);

            return obj;
        }

        protected override void OnPinChanged(ThreadDataGroup group)
        {
            // do nothing, as bookmarks cannot be pinned.
        }

        // No need to override the async version, as this method will be invoked.
        public override bool OnContextMenuOpening(string type, IContextMenu menu, object page, IProgress<string> progress)
        {
            return false;
        }

        protected override async Task<bool> OnSelectedAsync(object page, IProgress<string> progress, ForumThreadsFeed feed)
        {
            if (feed == null)
            {
                progress.Report("Creating bookmarks feed...");
                feed = this.bookmarksFeed;

                // feed will no longer be null after this call (assuming createFeedAsync was successful)
                this.InitializeFeed(feed);
                progress.Report(null);
            }

            bool value = await base.OnSelectedAsync(page, progress, feed);
            SetOnItemsReady(true);
            return false;   // return false because we don't want to navigate to list view.
        }
    }

    public class ThreadDataItem : CommonDataModel,
            IWebViewModel<string>,
            IPaginationViewModelWithProgress<string>
    {
        private ThreadMetadata thread;
        private IForumAccessToken myToken;
        private int currentPage = 0;
        private ThreadPageMetadata currentPageMetadata;
        private bool isBusy = false;
        private WebViewScriptRequestHandler requestHandler;

        private IEnumerable<ThreadPostMetadata> currentPagePosts = null;
        public IEnumerable<ThreadPostMetadata> CurrentPagePosts
        {
            get { return this.currentPagePosts; }
            set { SetProperty(ref this.currentPagePosts, value); }
        }
        
        public string NewPostCount
        {
            get
            {
                return this.thread.NewPostCount > 0 ?
                    this.thread.NewPostCount.ToString() :
                    string.Empty;
            }
        }

        private bool isRead = false;
        public bool IsRead
        {
            get { return this.isRead; }
            set { SetProperty(ref this.isRead, value); }
        }

        public bool IsReady
        {
            get { return !this.isBusy; }
        }

        protected bool IsBusy
        {
            get { return this.isBusy; }
            set
            {
                if (SetProperty(ref isBusy, value))
                    OnPropertyChanged("IsReady");
            }
        }

        public ThreadMetadata Thread { get { return this.thread; } }

        public ThreadDataItem(ThreadMetadata thread, IForumAccessToken token)
            : base()
        {
            this.myToken = token;
            this.thread = thread;
            this.UniqueID = thread.ThreadID;
            this.Title = thread.Title;
            this.Subtitle = FormatSubtitle(thread);
            this.Description = FormatDescription(thread);
            this.DataType = MainDataModel.DATATYPE_THREAD;
            this.SetImage(FormatIconImageSource(thread));

            // initialize webview request handler
            requestHandler = new WebViewScriptRequestHandler();
            requestHandler.AddEndpoint("echo", ShowMessageBox);
            requestHandler.AddEndpoint("item", OnThreadRequest);
            requestHandler.AddEndpoint("mark", OnMarkRequest);
            requestHandler.AddEndpoint("quote", OnQuoteRequest);
            requestHandler.AddEndpoint("edit", OnEditRequest);
            requestHandler.AddEndpoint("image", OnImageRequest);
            requestHandler.AddEndpoint("url", OnUrlNavigate);
            requestHandler.AddEndpoint("unignore", OnPostUnignore);
            requestHandler.AddEndpoint("thread", OnThreadRequest);
        }

        #region Common Members

        private const string ICON_BASE = "http://raw.github.com/Awful/thread-tags/master/";
        private string FormatIconImageSource(ThreadMetadata thread)
        {
            if (string.IsNullOrEmpty(thread.IconUri))
                return null;

            string filename = Path.GetFileName(thread.IconUri);
            filename = filename.Replace(Path.GetExtension(filename), ".png");
            return ICON_BASE + filename;
        }

        private string FormatSubtitle(ThreadMetadata metadata)
        {
            return metadata.Author;
        }

        private string FormatDescription(ThreadMetadata metadata)
        {
            // rated 4 <> 299 new posts
            StringBuilder builder = new StringBuilder();
            if (metadata.Rating != 0)
            {
                builder.AppendFormat("\u2605 {0}", metadata.Rating);
                builder.Append(" " + "\u2022" + " ");
            }

            /* Post count information won't be shown in the description.
             * Let's remove it later.
             * 
            if (!metadata.IsNew)
            {
                builder.Append(metadata.NewPostCount > 0 ?
                    string.Format("{0} new {1}", metadata.NewPostCount,
                    metadata.NewPostCount > 1 ? "posts \u2022 " : "post \u2022 ") :
                    "no new posts " + "\u2022" + " ");
            }
            */

            builder.AppendFormat("{0} {1}",
                   metadata.PageCount,
                   metadata.PageCount == 1 ? "page" : "pages");

            return builder.ToString();
        }

        protected async Task<bool> LoadPageAsync(ThreadPageMetadata threadPage, IThreadViewPage page)
        {
            bool success = false;
            IsBusy = true;
            page.NotifyAppBarCommands();
            try
            {
                this.currentPageMetadata = threadPage;
                var result = await page.InvokeScriptAsync("showLoadingRing", new string[] { });
                string json = await JsonHelper.SerializeObjectAsync(threadPage);
                result = await page.InvokeScriptAsync("viewThreadPage", new string[] { json });
                this.thread.PageCount = threadPage.LastPage;
                this.thread.IsBookmarked = threadPage.IsBookmarked;
                this.thread.Title = threadPage.ThreadTitle;
                this.CurrentPage = threadPage.PageNumber;
                this.LastPage = threadPage.LastPage;
                this.CurrentPagePosts = threadPage.Posts;
                MessagePostModel form = new MessagePostModel(this.thread);
                form.SubmitCommand = new RelayCommand(async () => { await SubmitFormAsync(form, this.myToken); });
                page.SetPostForm(form, false);
                page.SetPagination(this);
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
                throw ex;
            }
            return success;
        }

        private async Task SubmitFormAsync(MessagePostModel form, IForumAccessToken token)
        {
            ConfirmDialogMessage confirm = new ConfirmDialogMessage("Are you sure?", "Submit Post");
            NotificationService.Default.Notify<ConfirmDialogMessage>(this, confirm);
            bool confirmed = await confirm.ConfirmAsync;
            if (confirmed)
                await form.SubmitAsync(token);
        }

        #endregion

        #region WebViewRequestHandler

        private async Task OnPostUnignore(string scriptValue, string endpoint, dynamic json, IWebViewPage page)
        {
            // grab our values
            string postID = json.id;
            string url = json.url;
            var task = this.myToken.GetThreadPageAsync(new Uri(url, UriKind.RelativeOrAbsolute));

            // create universal progress token
            var progress = IProgressFactory.GenerateProgressToken();
            progress.Report("Unignoring post...");

            // load page
            var threadPage = await task;
            progress.Report(null);
            ThreadPostMetadata post = threadPage.Posts[0];
            string content = post.PostBody;

            // set a delay here - we want to ensure the invoke script call is made outside the script notify event.
            var delay = Task.Delay(10).ContinueWith(t =>
            {
                // call the set post content javascript function
                page.InvokeScript("setPostContent", new string[] { post.PostID, content });
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        // Opens up a web browser to the target url.
        private Task OnUrlNavigate(string scriptValue, string endpoint, dynamic json, IWebViewPage page)
        {
            string url = json.url;
            
            // only navigate to urls with https and http.
            if (url.IndexOf("http") == 0)
            {
                Uri uri = new Uri(url, UriKind.Absolute);
                WebBrowserTask task = new WebBrowserTask();
                task.Uri = uri;
                try { task.Show(); }
                catch (Exception) { }
            }

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            tcs.SetResult(true);
            return tcs.Task;
        }

        // Opens up a web browser to the target image url.
        private Task OnImageRequest(string scriptValue, string endpoint, dynamic json, IWebViewPage page)
        {
            string url = json.source;
            Uri uri = new Uri(url, UriKind.Absolute);
            WebBrowserTask task = new WebBrowserTask();
            task.Uri = uri;
            try { task.Show(); }
            catch (Exception) { }

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            tcs.SetResult(true);
            return tcs.Task;
        }

        private string DoNothing(object arg) { return string.Empty; }

        // Prepares UI for post edit.
        private async Task OnEditRequest(string scriptValue, string endpoint, dynamic json, IWebViewPage page)
        {
            string postID = json.postId;
            var form = await this.myToken.BeginEditPostAsync(postID);

            var threadPage = page as IThreadViewPage;
            MessagePostModel bindable = new MessagePostModel(form, this.thread);
            bindable.SubmitCommand = new RelayCommand(async () => { await SubmitFormAsync(bindable, this.myToken); });
            threadPage.SetPostForm(bindable, true);
        }

        // Prepares UI for post quote.
        private async Task OnQuoteRequest(string scriptValue, string endpoint, dynamic json, IWebViewPage page)
        {
            string postID = json.postId;
            string quote = await this.myToken.QuoteAsync(postID);
            var threadPage = page as IThreadViewPage;
            MessagePostModel form = new MessagePostModel(this.thread);
            form.Message = quote;
            form.SubmitCommand = new RelayCommand(async () => { await SubmitFormAsync(form, this.myToken); });
            threadPage.SetPostForm(form, true);
        }

        // Marks post as read.
        private async Task OnMarkRequest(string scriptValue, string endpoint, dynamic json, IWebViewPage page)
        {
            string threadID = json.threadId;
            string threadIndex = json.postThreadIndex;
            bool success = await this.myToken.MarkAsReadAsync(threadID, threadIndex);
            string message = success ? "Post marked as read." : "Post mark request failed.";
            NotificationService.Default.Notify<ToastMessage>(this, new ToastMessage(message));
        }

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

            if (this.thread.ThreadID.Equals(threadPage.ThreadID))
                await this.LoadPageAsync(threadPage, page as IThreadViewPage);
            else
            {
                // make sure we're out of the invokescript scope
                (page as IThreadViewPage).OnNewThreadCreated(threadPage);
            }
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

        // Opens a dialog window with the specified message.
        private Task ShowMessageBox(string scriptValue, string endpoint, dynamic json, IWebViewPage page)
        {
            string message = string.Empty;
            try { message = json.value; }
            // just print a string respresentation if we parse wrong.
            catch (RuntimeBinderException) { message = json.ToString(); }

            DialogMessage dialog = new DialogMessage(message, string.Empty);
            NotificationService.Default.Notify<DialogMessage>(this, dialog);
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            tcs.SetResult(true);
            return tcs.Task;
        }

        #endregion WebViewRequestHandler

        #region IWebViewModel<string>

        public bool CanRefresh()
        {
            return !this.isBusy;
        }

        public Task OnSelectedAsync(object state, IProgress<string> progress)
        {
            return OnSelectedAsync(state, progress, this.CurrentPage.GetValueOrDefault(0));
        }

        protected virtual async Task OnSelectedAsyncCore(object state, IProgress<string> progress, int? pageNumber)
        {
            Task<ThreadPageMetadata> loadThread = null;
            if (pageNumber.Value == 0)
                loadThread = thread.IsNew ?
                    thread.GetThreadPageAsync(1, this.myToken) :
                    thread.GetNewPostAsync(this.myToken);

            else if (pageNumber.Value == -1)
                loadThread = thread.GetLastPostAsync(this.myToken);
            else if (currentPageMetadata == null || pageNumber.Value != currentPageMetadata.PageNumber)
                loadThread = thread.GetThreadPageAsync(pageNumber.Value, this.myToken);
            else
            {
                var tcs = new TaskCompletionSource<ThreadPageMetadata>();
                tcs.SetResult(this.currentPageMetadata);
                loadThread = tcs.Task;
            }

            this.IsBusy = true;
            (state as IThreadViewPage).NotifyAppBarCommands();
            progress.Report("Loading item...");

            try { await LoadPageAsync(await loadThread, state as IThreadViewPage); }
            catch (Exception ex) { throw ex; }
            finally
            {
                progress.Report(null);
                this.IsBusy = false;
                (state as IThreadViewPage).NotifyAppBarCommands();
                this.IsRead = true;
            }
        }

        public Task OnSelectedAsync(object state, IProgress<string> progress, int? pageNumber)
        {
            // if we aren't already on the web view page navigate to it.
            if (!(state is IWebViewPage))
            {
                string uri = string.Format("/ThreadPage.xaml?id={0}&page={1}",
                    this.UniqueID, pageNumber.HasValue ? pageNumber.Value : 0);

                (state as IApplicationPage).Navigate(new Uri(uri, UriKind.RelativeOrAbsolute));
                return new TaskCompletionSource<bool>().Task;
            }
            else
            {
                return OnSelectedAsyncCore(state, progress, pageNumber);
            }
        }

        public bool OnContextMenuOpening(string type, IContextMenu menu, object state, IProgress<string> progress)
        {
            bool showMenu = true;
            switch (type)
            {
                case "item":
                    PopulateItemContextMenu(menu, state, progress);
                    break;

                case "rate":
                    PopulateRateContextMenu(menu);
                    break;

                default:
                    throw new InvalidOperationException("unknown context menu: " + type);
            }

            return showMenu;
        }

        private void PopulateRateContextMenu(IContextMenu menu)
        {
            menu.Items.Clear();
            for (int i = 0; i < 5; i++)
            {
                int rating = i + 1;
                AwfulContextMenuItem item = new AwfulContextMenuItem();
                item.Header = "Rate " + rating;
                item.Command = new RelayCommand<int>(async (value) =>
                {
                    ToastMessage toast = null;
                    try
                    {
                        bool result = await this.thread.RateAsync(value, this.myToken);
                        toast = new ToastMessage("Go hog wild!",
                            string.Format("You rated this item '{0}'", value));
                    }
                    catch (Exception ex)
                    {
                        toast = new ToastMessage(ex.Message, "Oops, something went wrong.");
                    }

                    NotificationService.Default.Notify<ToastMessage>(this, toast);
                });
                item.CommandParameter = rating;
                menu.Items.Add(item);
            }
        }

        public async Task<bool> ToggleBookmarksAsync(IProgress<string> progress)
        {
            bool result = false;
            if (this.thread.IsBookmarked)
            {
                progress.Report("Removing bookmark...");
                result = await this.thread.SetBookmarkAsync(MetadataExtensions.BookmarkOptions.Remove, this.myToken);
                this.thread.IsBookmarked = result ? false : this.thread.IsBookmarked;
            }
            else
            {
                progress.Report("Adding bookmark...");
                result = await this.thread.SetBookmarkAsync(MetadataExtensions.BookmarkOptions.Add, this.myToken);
                this.thread.IsBookmarked = result ? true : this.thread.IsBookmarked;
            }

            progress.Report(null);
            return result;
        }

        private void PopulateItemContextMenu(IContextMenu menu, object state, IProgress<string> progress)
        {
            AwfulContextMenuItem bookmark = new AwfulContextMenuItem();
            bookmark.Command = new RelayCommand(async () => await ToggleBookmarksAsync(progress));
            bookmark.Header = "toggle bookmark";
            bookmark.Icon = "Favorite";

            AwfulContextMenuItem firstPage = new AwfulContextMenuItem();
            firstPage.Command = new RelayCommand(async () => await GoToPageAsync(1, state, progress));
            firstPage.Header = "go to first page";
            firstPage.Icon = "Previous";

            AwfulContextMenuItem lastPage = new AwfulContextMenuItem();
            lastPage.Command = new RelayCommand(async () => await GoToPageAsync(-1, state, progress));
            lastPage.Header = "go to last page";
            lastPage.Icon = "Next";

            menu.Items.Clear();
            menu.Items.Add(bookmark);
            menu.Items.Add(firstPage);
            menu.Items.Add(lastPage);
        }

        public Task<bool> OnContextMenuOpeningAsync(string type, IContextMenu menu, object state, IProgress<string> progress)
        {
            return Task<bool>.Run(() => OnContextMenuOpening(type, menu, state, progress));
        }

        public Task OnRefreshAsync(object state, IProgress<string> progress)
        {
            this.currentPageMetadata = null;
            return this.OnSelectedAsync(state, progress);
        }

        public Task OnScriptNotifyAsync(object state, IProgress<string> progress, string value)
        {
            // make sure we are out of the WebBrowser.ScriptNotify scope.
            return this.requestHandler.OnWebViewScriptNotify(value, state as IWebViewPage);
        }

        [Obsolete("Please use OnScriptNotifyAsync(object, IProgress<string>, string).", true)]
        public Task OnScriptNotifyAsync(object state, string value)
        {
            throw new NotSupportedException("Please add an IProgress parameter to this method.");
        }

        #endregion IWebViewModel<string>

        #region IPaginationWithProgress<string>

        public int? CurrentPage
        {
            get { return this.currentPage; }
            protected set
            {
                this.currentPage = value.GetValueOrDefault(0);
                OnPropertyChanged();
            }
        }

        public int LastPage
        {
            get;
            private set;
        }

        public bool CanGoToNext()
        {
            int next = this.CurrentPage.Value + 1;
            return next <= this.LastPage;
        }

        public bool CanGoToPrev()
        {
            int prev = this.CurrentPage.Value - 1;
            return prev > 0;
        }


        public async Task<bool> GoToNextAsync(object state, IProgress<string> progress)
        {
            this.CurrentPage = this.CurrentPage + 1;
            await this.OnSelectedAsync(state, progress, this.CurrentPage);
            (state as IWebViewPage).SetContentAsActive(this);
            return true;
        }

        public async Task<bool> GoToPrevAsync(object state, IProgress<string> progress)
        {
            this.CurrentPage = this.CurrentPage - 1;
            await this.OnSelectedAsync(state, progress, this.CurrentPage);
            (state as IWebViewPage).SetContentAsActive(this);
            return true;
        }

        public async Task<bool> GoToPageAsync(int pageNumber, object state, IProgress<string> progress)
        {
            await this.OnSelectedAsync(state, progress, pageNumber);
            (state as IWebViewPage).SetContentAsActive(this);
            return true;
        }

        #endregion IPaginationWithProgress<string>
    }

    public sealed class ThreadDataItemFromPage : ThreadDataItem
    {
        private ThreadPageMetadata page;
        private bool isFirstInstance = false;
        public ThreadDataItemFromPage(ThreadPageMetadata page, IForumAccessToken token)
            : base(page.ToThreadMetadata(), token)
        {
            this.page = page;
            this.isFirstInstance = true;
            this.CurrentPage = page.PageNumber;
        }

        protected override async Task OnSelectedAsyncCore(object state, IProgress<string> progress, int? pageNumber)
        {
            if (this.isFirstInstance)
            {
                IsBusy = true;
                (state as IThreadViewPage).NotifyAppBarCommands();
                progress.Report("Loading new page...");

                try
                {
                    await LoadPageAsync(page, state as IThreadViewPage);
                    isFirstInstance = false;
                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    IsBusy = false;
                    (state as IThreadViewPage).NotifyAppBarCommands();
                    progress.Report(null);
                }
            }
            else
            {
                await base.OnSelectedAsyncCore(state, progress, pageNumber);
            }
        }
    }
}