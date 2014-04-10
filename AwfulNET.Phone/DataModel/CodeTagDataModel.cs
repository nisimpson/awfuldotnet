using AwfulNET.Common;
using AwfulNET.Core.Feeds;
using AwfulNET.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.DataModel
{
    public class CodeTagCollection : List<CodeTagDataModel>
    {
        public CodeTagCollection Items { get { return this; } }
    }

    public class CodeTagDataModel : CommonDataModel
    {
        public string Tag { get; set; }
        public string Code { get; set; }
    }

    public class SmileyTagGroup : CommonDataGroup, IListViewModel
    {
        private static readonly SmiliesFeed feed = new SmiliesFeed();
        private IDisposable unsubscriber;
        private IProgress<string> progress;

        public SmileyTagGroup() : base()
        {
            this.unsubscriber = feed.SubscribeAsync(OnNext, OnError, OnCompleted);
        }

        private void OnCompleted()
        {
            this.isBusy = false;

            if (this.progress != null)
                this.progress.Report(null);
        }

        private void OnError(Exception obj)
        {
            this.isBusy = false;

            if (this.progress != null)
                this.progress.Report(null);

            this.Items.Clear();
            this.EmptyText = "Oops, something went wrong. Please try again later.";
        }

        private void OnNext(IEnumerable<TagMetadata> obj)
        {
            Items.Clear();
            foreach(var item in obj)
            {
                var model = new CodeTagDataModel()
                {
                    Title = item.Value,
                    Tag = item.Value,
                    Subtitle = item.Title,
                    ImagePath = item.TagUri,
                    Code = item.Value
                };

                Items.Add(model);
                model.Group = this;
            }

            this.isBusy = false;

            if (this.progress != null)
                this.progress.Report(null);

            this.ItemsSource = this.Items;
        }

        private string empty = string.Empty;
        public string EmptyText
        {
            get { return empty; }
            set { SetProperty(ref this.empty, value); }
        }

        private System.Collections.IEnumerable itemsSource;
        public System.Collections.IEnumerable ItemsSource
        {
            get { return this.itemsSource; }
            set { SetProperty(ref this.itemsSource, value); }
        }

        public bool IsJumpList
        {
            get { return false; }
        }

        public bool IsVirtualList
        {
            get { return false; }
        }

        public System.Windows.Input.ICommand LoadMoreItemsCommand
        {
            get { throw new InvalidOperationException("smiley data group is not a virtual list."); }
        }

        public bool HasMoreItems
        {
            get { return false; }
        }

        private bool isBusy = false;
        public async Task OnSelectedAsync(object state, IProgress<string> progress)
        {
           if (!this.isBusy && this.Items.Count == 0)
           {
               this.isBusy = true;
               this.progress = progress;
               this.progress.Report("fetching smilies...");
               await feed.PullAsync();
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

        public bool CanRefresh()
        {
            return false;
        }

        public Task OnRefreshAsync(object state, IProgress<string> progress)
        {
            throw new InvalidOperationException("smiley data group cannot refresh.");
        }

        internal System.Collections.IEnumerable Filter(string text)
        {
            if (string.IsNullOrEmpty(text))
                return this.Items;

            else if (this.Items.Count > 0)
            {
                var selected = this.Items
                    .Where(item => { return FilterTag(item as CodeTagDataModel, text); })
                    .ToList();

                return selected;
            }

            return null;
        }

        private bool FilterTag(CodeTagDataModel tag, string text)
        {
            text = text.ToLower();

            return tag.Title.ToLower().Contains(text) ||
                tag.Code.ToLower().Contains(text) ||
                tag.Subtitle.ToLower().Contains(text);
        }
    }

}
