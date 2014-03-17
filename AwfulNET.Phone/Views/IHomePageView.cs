using AwfulNET.Common;
using AwfulNET.DataModel;
using Microsoft.Phone.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AwfulNET.Views
{
    [Obsolete("", true)]
    public interface IHomePageView
    {
        void SelectItem(IHomePageContent content);
        void SelectItem(IHomePageList list);
        void SelectItem(IHomePageJumpList jumpList);
        Task<bool> InvokeWebViewScriptAsync(string function, string[] args);
        void SetPostForm(MessagePostModel form, bool p);
        void SetNavigable(IHomePageNavigable navigable);
        void NotifyAllCommands();
        void NotifyProgress(string progress);
        void SetPostFormText(string quote);
    }
    [Obsolete("", true)]
    public interface IHomePageViewModel
    {
        IEnumerable ItemsSource { get; set; }
        IHomePageItem SelectedItem { get; set; }
        HomePageItemType ItemType { get; set; }
        string Title { get; set; }

        ICommand PrevCommand { get; set; }
        ICommand NextCommand { get; set; }
        ICommand GoBackCommand { get; set; }
        ICommand RefreshCommand { get; set; }
        ICommand ReplyCommand { get; set; }
        ICommand JumpToPageCommand { get; set; }
        ICommand RateCommand { get; set; }
        ICommand BookmarkCommand { get; set; }
        ICommand LogoutCommand { get; set; }
        ICommand ScrollToTopCommand { get; set; }
        ICommand ScrollToBottomCommand { get; set; }

        MessagePostModel PostForm { get; set; }
    }
    [Obsolete("", true)]
    public enum HomePageItemType
    {
        List = 0,
        Article,
        Thread,
        Reply
    }
    [Obsolete("", true)]
    public interface IHomePageItem
    {
        string Title { get; }

        /// <summary>
        /// Invoke when this has been selected as the active item.
        /// </summary>
        /// <param name="view">The current view.</param>
        /// <returns>True if the selection is confirmed. False otherwise.</returns>
        Task<bool> OnSelectedAsync(IHomePageView view);
    }
    [Obsolete("", true)]
    public interface IHomePageContextMenu
    {
        bool OnContextMenuOpened(string type, IContextMenu menu, IHomePageView view);
    }
    [Obsolete("", true)]
    public interface IHomePageList : IHomePageItem
    {
        IEnumerable<ICommonDataModel> ItemsSource { get; }
    }
    [Obsolete("", true)]
    public interface IHomePageVirtualList : IHomePageList
    {
        Task<bool> LoadMoreItemsAsync(IHomePageView view);
        bool HasMoreItems { get; }
        string LoadMoreItemsStatus { get; }

        event EventHandler LoadCompleted;
    }
    [Obsolete("", true)]
    public interface IHomePageJumpList : IHomePageItem
    {
        IEnumerable<IList<ICommonDataModel>> ItemsSource { get; }
        event EventHandler ItemsSourceChanged;
    }
    [Obsolete("", true)]
    public interface IHomePageContent : IHomePageItem
    {
        bool IsReplyEnabled { get; }
        bool CanToggleBookmarks { get; }
        bool IsMoreOptionsEnabled { get; }
        HomePageItemType ItemType { get; }
        Task<bool> ToggleBookmarksAsync(IHomePageView view);
    }
    [Obsolete("", true)]
    internal interface IHomePageScriptNotify
    {
        Task<bool> OnWebViewScriptNotifyAsync(NotifyEventArgs args, IHomePageView view);
    }
    [Obsolete("", true)]
    public interface IHomePageNavigable 
    {
        int? CurrentPage { get; }
        int LastPage { get; }
        bool CanGoToNext();
        bool CanGoToPrev();
        Task<bool> GoToNextAsync(IHomePageView view);
        Task<bool> GoToPrevAsync(IHomePageView view);
        Task<bool> GoToPageAsync(int pageNumber, IHomePageView view);
    }
    [Obsolete("", true)]
    internal interface IHomePageRefreshable
    {
        Task<bool> RefreshAsync(IHomePageView view);
        bool CanRefresh();
    }
}
