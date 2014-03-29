using AwfulNET.Common;
using AwfulNET.Views;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.DataModel
{
    [DataContract]
    public abstract class AwfulDataGroupBase : CommonDataGroup, IListViewModel
    {
        public AwfulDataGroupBase(bool isJumpList, bool isVirtualList, bool showEmptyOnLoad = false)
            : base()
        {
            this.isJumpList = isJumpList;
            this.isVirtualList = isVirtualList;

            var collection = this.Items as INotifyCollectionChanged;
            if (collection != null)
            {
                collection.CollectionChanged += collection_CollectionChanged;
                isListeningForCollectionChanged = true;
                itemsAreObservable = true;
            }
            showContent = !showEmptyOnLoad;
        }

        private TaskCompletionSource<bool> onItemsReady;
        protected void SetOnItemsReady(bool value)
        {
            if (onItemsReady != null && onItemsReady.Task.Status != TaskStatus.RanToCompletion)
                onItemsReady.SetResult(value);
        }

        private bool isListeningForCollectionChanged;
        private bool itemsAreObservable = false;
        protected void DisableCollectionChanged()
        {
            if (itemsAreObservable)
            {
                (this.Items as INotifyCollectionChanged).CollectionChanged -= collection_CollectionChanged;
                isListeningForCollectionChanged = false;
            }
        }

        protected void EnableCollectionChanged()
        {
            // we don't want to attach the event handler more than once
            if (itemsAreObservable && !isListeningForCollectionChanged)
            {
                (this.Items as INotifyCollectionChanged).CollectionChanged += collection_CollectionChanged;
                isListeningForCollectionChanged = true;
            }
        }

        int count = 0;
        void collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    count++;
                    break;

                case NotifyCollectionChangedAction.Remove:
                    count--;
                    break;

                case NotifyCollectionChangedAction.Reset:
                    count = 0;
                    break;
            }

            ShowContent = count > 0;
        }

        protected void ReportProgress(IProgress<string> progress, string message)
        {
            //EmptyText = message;
            progress.Report(message);
        }

        public bool IsBusy { get; protected set; }

        private string emptyText = null;
        [DataMember]
        public string EmptyText
        {
            get { return emptyText; }
            set
            {
                SetProperty(ref emptyText, value);
            }
        }

        private bool showContent = true;
        [IgnoreDataMember]
        public bool ShowContent
        {
            get { return this.showContent; }
            private set
            {
                if (SetProperty(ref this.showContent, value))
                    OnPropertyChanged("ShowEmpty");
            }
        }

        [IgnoreDataMember]
        public bool ShowEmpty { get { return !showContent; } }

        #region IListViewModel Implementation

        private System.Collections.IEnumerable itemsSource;
        public System.Collections.IEnumerable ItemsSource
        {
            get { return itemsSource; }
            protected set
            {
                if (SetProperty(ref itemsSource, value))
                    this.ShowContent = (value != null);
            }
        }

        private readonly bool isJumpList;
        public bool IsJumpList
        {
            get { return isJumpList; }
        }

        private readonly bool isVirtualList;
        public bool IsVirtualList
        {
            get { return isVirtualList; }
        }

        public virtual System.Windows.Input.ICommand LoadMoreItemsCommand
        {
            get { return null; }
        }

        private bool hasMoreItems = false;
        public virtual bool HasMoreItems
        {
            get { return hasMoreItems; }
            protected set { SetProperty(ref hasMoreItems, value); }
        }

        public virtual async Task OnSelectedAsync(object state, IProgress<string> progress)
        {
            NetworkDetectionMessage status = new NetworkDetectionMessage() { IsNetworkActive = false };
            NotificationService.Default.Notify(this, status);
            if (!status.IsNetworkActive)
            {
                this.EmptyText = "We can't display this page at the moment. Please check your network connection and try again.";
                this.ShowContent = false;
            }

            else
            {
                //this.EmptyText = null;
                //this.ShowContent = true;
                onItemsReady = new TaskCompletionSource<bool>();
                await OnSelectedAsyncCore(state, progress);
                bool result = await onItemsReady.Task;
                ReportProgress(progress, null);
            }
        }

        protected abstract Task OnSelectedAsyncCore(object state, IProgress<string> progress);

        public virtual bool OnContextMenuOpening(string type, Common.IContextMenu menu, object state, IProgress<string> progress)
        {
            return false;
        }

        public virtual Task<bool> OnContextMenuOpeningAsync(string type, Common.IContextMenu menu, object state, IProgress<string> progress)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            tcs.SetResult(OnContextMenuOpening(type, menu, state, progress));
            return tcs.Task;
        }

        public abstract bool CanRefresh();

        protected abstract Task OnRefreshAsyncCore(object state, IProgress<string> progress);

        public async Task OnRefreshAsync(object state, IProgress<string> progress)
        {
            NetworkDetectionMessage status = new NetworkDetectionMessage() { IsNetworkActive = false };
            NotificationService.Default.Notify(this, status);
            if (!status.IsNetworkActive)
            {
                this.EmptyText = "We can't display this page at the moment. Please check your network connection and try again.";
                this.ShowContent = false;
            }
            else
            {
                this.EmptyText = null;
                this.ShowContent = true;
                onItemsReady = new TaskCompletionSource<bool>();
                await OnRefreshAsyncCore(state, progress);
                await onItemsReady.Task;
            }
        }

        #endregion IListViewModel Implementation
    }
}