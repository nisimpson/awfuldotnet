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

        public SmileyTagGroup() : base()
        {
            this.unsubscriber = feed.SubscribeAsync(OnNext, OnError, OnCompleted);
        }

        private void OnCompleted()
        {
            this.isBusy = false;
        }

        private void OnError(Exception obj)
        {
            this.isBusy = false;
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
                    ImagePath = item.TagUri
                };

                Items.Add(model);
                model.Group = this;
            }

            this.isBusy = false;
        }

        private string empty = string.Empty;
        public string EmptyText
        {
            get { return empty; }
            set { SetProperty(ref this.empty, value); }
        }

        public System.Collections.IEnumerable ItemsSource
        {
            get { return this.Items; }
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
    }

}
