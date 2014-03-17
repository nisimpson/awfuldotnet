using AwfulNET.Core;
using AwfulNET.Core.Feeds;
using AwfulNET.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Runtime.Serialization;
using AwfulNET.Common;
using System.Windows;
using System.Net;

namespace AwfulNET.DataModel
{
    /// <summary>
    /// Binding class for all front page articles gathered from SomethingAwful's RSS feed.
    /// </summary>
    [DataContract]
    public class ArticleDataGroup : AwfulDataGroupBase, 
        IObserver<IEnumerable<FrontPageArticle>>
    {
        // our front page article data source.
        private static ArticleFeed frontPageFeed = new ArticleFeed();

        // a binding for showing progress during async
        private bool isLoading;
        [IgnoreDataMember]
        public bool IsLoading
        {
            get { return this.isLoading; }
            set { SetProperty(ref isLoading, value); }
        }

        public ArticleDataGroup()
            : base(false, false)                       
        {
            // initialize and subscribe
            this.UniqueID = "articles";
            frontPageFeed = ArticleFeed.Instance;
            frontPageFeed.Subscribe(this);
        }

        #region Common Members

        public async Task RefreshAsync()
        {
            if (!this.IsBusy)
            {
                this.IsBusy = true;
                await frontPageFeed.UpdateAsync();
            }
        }

        private void OnLoadContextImagePathAwaiting(Task<Action<ArticleDataItem>> task, object state)
        {
            // ... and apply it to the item's image path once done.
            // this is done asynchronously because we want the processing
            // to be done in the background and the image loading
            // to take place on the UI item.
            ArticleDataItem item = state as ArticleDataItem;
            if (item != null && task.Status == TaskStatus.RanToCompletion)
                task.Result(item);
        }

        #endregion

        #region IObserver Implementation

        public void OnError(Exception error)
        {
            this.IsBusy = false;
            SetOnItemsReady(false);

            // notify ui
            NotificationService.Default.Notify<DialogMessage>(this,
                new DialogMessage("The news feed failed to load. Tap refresh to try again.",
                    "Oops, something went wrong."));


            // clear out our items
            this.Items.Clear();
        }

        public void OnCompleted() { this.IsBusy = false; }
        
        public void OnNext(IEnumerable<FrontPageArticle> value)
        {
            this.IsBusy = false;
           
            // clear out our items
            this.Items.Clear();

            // enter loop:
            foreach (var article in value)
            {
                // create a new article data item,
                ArticleDataItem item = new ArticleDataItem(article);

                // add it to this group,
                item.Group = this;

                // and add it to our items list.
                this.Items.Add(item);

                // now find a nice representative image for our article...
                Task.Run(() => item.LoadArticleAsync()).ContinueWith(
                    OnLoadContextImagePathAwaiting,
                    item,
                    TaskScheduler.FromCurrentSynchronizationContext());
            }

            SetOnItemsReady(true);
            this.ItemsSource = this.Items;
        }

        #endregion IObserver Implementation

        #region IListViewModel Implementation

        public override bool CanRefresh()
        {
            return true;
        }

        public override bool HasMoreItems { get { return false; } }

        public override System.Windows.Input.ICommand LoadMoreItemsCommand
        {
            get { return null; }
        }

        protected override async Task OnSelectedAsyncCore(object page, IProgress<string> progress)
        {
            if (!this.IsBusy && this.Items.Count == 0)
            {
                ReportProgress(progress, "loading articles...");
                await this.RefreshAsync();
                ReportProgress(progress, null);
            }
        }

        protected override async Task OnRefreshAsyncCore(object page, IProgress<string> progress)
        {
           if (!this.IsBusy) 
           {
               ReportProgress(progress, "Refreshing articles...");
               await this.RefreshAsync();
               ReportProgress(progress, null);
           }
        }

        #endregion
    }

    /// <summary>
    /// Binding class for a front page article.
    /// </summary>
    [DataContract]
    public class ArticleDataItem : CommonDataModel, 
        IContentViewModel,
        IPaginationViewModelWithProgress<string>,
        IWebViewModel<string>
    {
        // a refrence to our data
        private FrontPageArticle article;
        [DataMember]
        public FrontPageArticle Article
        {
            get { return this.article; }
            set { this.article = value; }
        }

        // a static httpclient for grabbing web info.
#if WINDOWS_PHONE
        private static IHttpClient WebClient = new WP8HttpClient();
#else
        private static IHttpClient WebClient = new WinRTHttpClient();
#endif

        public ArticleDataItem()
            : base(
                string.Empty,               // uniqueId
                string.Empty,               // title
                string.Empty,               // subtitle
                string.Empty,               // description
                string.Empty,               // image path
                string.Empty,               // content
                null) { }

        public ArticleDataItem(FrontPageArticle article)
            : this()
        {
            this.article = article;
            this.UniqueID = article.Id;
            this.Title = article.Title;
            this.DataType = MainDataModel.DATATYPE_ARTICLE;
            this.Subtitle = FormatSubtitle(article);
            this.Description = article.Content;
        }

        #region Common Members

        private string FormatSubtitle(FrontPageArticle article)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(article.Author);
            //builder.AppendLine(article.DatePublished.ToString());
            return builder.ToString();
        }

        /// <summary>
        /// Asyncronously loads an image from the article to serve as the
        /// backing image for the item. Usually, this will be the first image
        /// found on the page.
        /// </summary>
        /// <returns></returns>
        public async Task<string> LoadArticleImageAsync()
        {
            // first, download the html from the link location
            string html = await WebClient.GetStringAsync(this.article.Link);

            // load it into an htmldocument object (for easy parsing)
            HtmlDocument articlePage = new HtmlDocument();
            articlePage.LoadHtml(html);

            // let's use linq to find the first relevant image:
            HtmlNode imageCaptionElement = articlePage.DocumentNode.Descendants("img")
                .Where(node => node.GetAttributeValue("class", string.Empty)
                    .Contains("imgcap"))
                    .FirstOrDefault();

            string src = string.Empty;

            // if we found it, extract the src and return it
            if (imageCaptionElement != null)
            {
                src = imageCaptionElement.GetAttributeValue("src", string.Empty);
            }

            return src;
        }

        /// <summary>
        /// Populates binding data with information from article web content.
        /// </summary>
        /// <returns></returns>
        public async Task<Action<ArticleDataItem>> LoadArticleAsync()
        {
            // first, download the html from the link location
            string html = await WebClient.GetStringAsync(this.article.Link);

            // load it into an htmldocument object (for easy parsing)
            HtmlDocument articlePage = new HtmlDocument();
            articlePage.LoadHtml(html);

            // grab content from the article page
            string content = string.Empty;
            HtmlNode articleContent = articlePage.DocumentNode.Descendants("div")
                .Where(div => div.GetAttributeValue("class", string.Empty)
                .Equals("organ article"))
                .FirstOrDefault();
            if (articleContent != null)
            {
                content = articleContent.OuterHtml;
            }

            // let's use linq to find the first relevant image:
            HtmlNode imageCaptionElement = articlePage.DocumentNode.Descendants("img")
                .Where(node => node.GetAttributeValue("class", string.Empty)
                    .Contains("imgcap"))
                    .FirstOrDefault();

            // if we found it, extract the src and return it
            string src = null;
            if (imageCaptionElement != null)
            {
                src = imageCaptionElement.GetAttributeValue("src", string.Empty);
            }

            Action<ArticleDataItem> applyBindings = new Action<ArticleDataItem>((item) =>
            {
                if (src != null) { item.SetImage(src); }
                item.Content = content;
            });

            return applyBindings;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("'{0}' by {1} ({2})",
                this.Title,
                this.Subtitle,
                this.Description);

            return builder.ToString();
        }

        #endregion

        public bool CanRefresh() { return true; }

        #region IPaginationViewModelWithProgress<string>

        public ArticleDataItem NextItem
        {
            get
            {
                int index = this.Group.Items.IndexOf(this);
                index = index + 1;
                return index == this.Group.Items.Count ? null : this.Group.Items[index] as ArticleDataItem;
            }
        }

        public ArticleDataItem PrevItem
        {
            get
            {
                int index = this.Group.Items.IndexOf(this);
                index = index - 1;
                return index < 0 ? null : this.Group.Items[index] as ArticleDataItem;
            }
        }

        /// <summary>
        /// Returns false if the last article of the group is isNotAList,
        /// true otherwise.
        public bool CanGoToNext()
        {
            int index = this.Group.Items.IndexOf(this);
            return (index + 1) != this.Group.Items.Count;
        }

        /// <summary>
        /// Returns false if the first article of the group is isNotAList,
        /// true otherwise.
        public bool CanGoToPrev()
        {
            int index = this.Group.Items.IndexOf(this);
            return index > 0;
        }

        public int? CurrentPage { get { return this.Group.Items.IndexOf(this); } }

        public int LastPage
        {
            get { return this.Group.Items.Count; }
        }

        #endregion IPaginationViewModelWithProgress<string>

        #region IContentViewModel

        /// <summary>
        /// Invokes the DOM JavaScript function for displaying article content.
        /// </summary>
        private async Task<object> LoadArticleAsync(ICommonDataModel item, IWebViewPage page)
        {
            string json = await JsonHelper.SerializeObjectAsync(item);
            var result = await page.InvokeScriptAsync("viewArticle", new string[] { json });
            return result;
        }

        /// <summary>
        /// Invokes the DOM JavaScript function for displaying other articles.
        /// </summary>
        private Task LoadArticleAsync(int index, object state, IProgress<string> progress)
        {
            ArticleDataGroup group = this.Group as ArticleDataGroup;
            ArticleDataItem item = group.Items[index] as ArticleDataItem;
            return item.OnSelectedAsync(state, progress);
        }

        public async Task OnSelectedAsync(object state, IProgress<string> progress)
        {
            var webView = state as IWebViewPage;
            if (webView == null)
            {
                (state as IApplicationPage).Navigate(new Uri("/ArticlePage.xaml?id=" + this.UniqueID, UriKind.RelativeOrAbsolute));
            }
            else
            {
                await LoadArticleAsync(this, webView);
            }
        }

        public bool OnContextMenuOpening(string type, IContextMenu menu, object state, IProgress<string> progress)
        {
            return false;
        }

        public Task<bool> OnContextMenuOpeningAsync(string type, IContextMenu menu, object state, IProgress<string> progress)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            tcs.SetResult(false);
            return tcs.Task;
        }

        public Task OnRefreshAsync(object state, IProgress<string> progress)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IPaginationWithProgress<string>

        public async Task<bool> GoToNextAsync(object state, IProgress<string> progress)
        {
            if (this.CanGoToNext())
            {
                // get the index of this article
                int index = this.Group.Items.IndexOf(this);
                await LoadArticleAsync(index + 1, state, progress);
                return true;
            }

            return false;
        }

        public async Task<bool> GoToPrevAsync(object state, IProgress<string> progress)
        {
            if (this.CanGoToPrev())
            {
                // get the index of this article
                int index = this.Group.Items.IndexOf(this);
                await LoadArticleAsync(index - 1, state, progress);
                return true;
            }

            return false;
        }

        public async Task<bool> GoToPageAsync(int pageNumber, object state, IProgress<string> progress)
        {
            await LoadArticleAsync(pageNumber, state, progress);
            return true;
        }

        #endregion IPaginationWithProgress<string>

        public Task OnScriptNotifyAsync(object state, string value)
        {
            throw new NotImplementedException();
        }

        public Task OnScriptNotifyAsync(object state, IProgress<string> progress, string value)
        {
            throw new NotImplementedException();
        }
    }
}