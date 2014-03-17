using AwfulNET.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AwfulNET.Views
{
    public interface IPaginationViewModel
    {
        Task<bool> GoToNextAsync(object state);
        Task<bool> GoToPrevAsync(object state);
        Task<bool> GoToPageAsync(int pageNumber, object state);
        bool CanGoToNext();
        bool CanGoToPrev();
        int? CurrentPage { get; }
        int LastPage { get; }
    }

    public interface IPaginationViewModelWithProgress<T>
    {
        Task<bool> GoToNextAsync(object state, IProgress<T> progress);
        Task<bool> GoToPrevAsync(object state, IProgress<T> progress);
        Task<bool> GoToPageAsync(int pageNumber, object state, IProgress<T> progress);
        bool CanGoToNext();
        bool CanGoToPrev();
        int? CurrentPage { get; }
        int LastPage { get; }
    }

    public interface IContentViewModel
    {
        string Title { get; }
        object Content { get; }

        Task OnSelectedAsync(object state, IProgress<string> progress);
        bool OnContextMenuOpening(string type, IContextMenu menu, object state, IProgress<string> progress);
        Task<bool> OnContextMenuOpeningAsync(string type, IContextMenu menu, object state, IProgress<string> progress);
        bool CanRefresh();
        Task OnRefreshAsync(object state, IProgress<string> progress);
    }

    public interface IListViewModel : IContentViewModel
    {
        string UniqueID { get; }
        string EmptyText { get; }
        IEnumerable ItemsSource { get; }
        bool IsJumpList { get; }
        bool IsVirtualList { get; }
        ICommand LoadMoreItemsCommand { get; }
        bool HasMoreItems { get; }
    }

    public interface IWebViewModel<TProgress> : IContentViewModel
    {
        Task OnScriptNotifyAsync(object state, string value);
        Task OnScriptNotifyAsync(object state, IProgress<TProgress> progress, string value);
    }

    public interface IApplicationPage
    {
        void Navigate(Uri uri);
    }

    public interface IWebViewPage : IApplicationPage
    {
        object InvokeScript(string functionName, params string[] args);
        Task<object> InvokeScriptAsync(string functionName, params string[] args);
    }
}