using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AwfulNET.Common;
using AwfulNET.DataModel;
using AwfulNET.Views;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace AwfulNET.Phone
{
    public partial class ThreadPage : WebViewAwarePage, IThreadViewPage
    {
        private ThreadPageViewModel viewmodel;
        private SystemTrayProgressToken progress;
        private MainDataModel mainDataModel;
        private bool suppressBackButton;
        private int startPage;
        private bool isNewInstance = false;
        private bool isStateLoaded = false;

        private const string THREAD_TAB_MESSAGE = "Congrats, you've unlocked thread tabs! Access the tabs menu to switch between active tabs. Pressing the back button will still return you to the home page. Enjoy! Press OK to never show this message again, or CANCEL if you need to be reminded.";
        
        public ThreadPage()
        {
            InitializeComponent();
            progress = new SystemTrayProgressToken();
            mainDataModel = App.Main;
            pageNavigator.ViewModel.CancelCommand = new RelayCommand(HidePageNavigator);
            VisualStateManager.GoToState(this, "Normal", false);
            isNewInstance = true;
        }

        private void HidePageNavigator()
        {
            this.pageNavigator.Visibility = System.Windows.Visibility.Collapsed;
            this.pageNavigator.IsHitTestVisible = false;
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (!e.IsNavigationInitiator)
                SaveState();
                
        }

        protected override void OnInitializingWebView()
        {
            InitializeWebView(this.Browser);
        }

        protected override Task<Views.IWebViewModel<string>> CreateWebViewModelAsync(NavigationEventArgs e)
        {
            string id = null;
            TaskCompletionSource<Views.IWebViewModel<string>> tcs = new TaskCompletionSource<IWebViewModel<string>>();
            if (NavigationContext.QueryString.ContainsKey("id"))
            {
                id = NavigationContext.QueryString["id"];
                int pageNumber = 0;
                if (int.TryParse(NavigationContext.QueryString["page"], out pageNumber))
                {
                    try
                    {
                        this.viewmodel = new ThreadPageViewModel(GetThread(id, pageNumber), this, this.progress);
                        tcs.SetResult(viewmodel);
                    }
                    catch (Exception)
                    {
                        tcs.SetResult(null);
                        NavigationService.GoBack();
                    }
                }
            }
            return tcs.Task;
        }

        private ThreadDataItem GetThread(string threadID, int pageNumber)
        {
            ThreadDataItem selected = null;
            try
            {
                selected = mainDataModel.GetThreadDataByID(threadID);
                this.startPage = pageNumber;
            }
            catch (Exception) { selected = null; }
            if (selected == null)
            {
                var state = LoadState();
                selected = state.ToThreadDataItem();
                this.startPage = state.CurrentPage;
            }

            return selected;
        }

        private void SaveState()
        {
            var state = PhoneApplicationService.Current.State;
            if (state.ContainsKey("ThreadPageState"))
                state["ThreadPageState"] = new ThreadPageState(this.viewmodel.CurrentThread);
            else
                state.Add("ThreadPageState", new ThreadPageState(this.viewmodel.CurrentThread));
        }

        private ThreadPageState LoadState()
        {
            var state = PhoneApplicationService.Current.State;
            if (state.ContainsKey("ThreadPageState"))
            {
                var pageState =  state["ThreadPageState"];
                isStateLoaded = true;
                return (pageState as ThreadPageState);
            }

            return null;
        }

        protected override async Task OnViewModelSelectedAsync(IWebViewPage page, IProgress<string> progress, IWebViewModel<string> viewmodel)
        {
            ThreadPageViewModel thread = viewmodel as ThreadPageViewModel;

            // add a small delay before making a web request.
            // this allows the httpclient to fullly initialize.
            await Task.Delay(10);
            await thread.OnSelectedAsync(page, progress, this.startPage);
        }

        protected override void OnSelectionChanged(Exception error)
        {
            base.OnSelectionChanged(error);

            VisualStateManager.GoToState(this, "DetailsView", true);
            this.viewmodel.CurrentState = ThreadPageViewModel.State.Details;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (suppressBackButton)
            {
                suppressBackButton = false;
                e.Cancel = true;
            }
            else if (isTabsViewVisible)
            {
                this.HideTabsView();
                e.Cancel = true;
            }
            else if (this.pageNavPanel.Visibility == System.Windows.Visibility.Visible)
            {
                this.pageNavPanel.Visibility = System.Windows.Visibility.Collapsed;
                e.Cancel = true;
            }

            base.OnBackKeyPress(e);
        }

        #region IThreadPageView

        public void NotifyAppBarCommands()
        {
            (this.Resources["scrollToTopCommand"] as EventCommand).RaiseCanExecuteChanged();
            (this.Resources["scrollToBottomCommand"] as EventCommand).RaiseCanExecuteChanged();
            (this.Resources["replyCommand"] as EventCommand).RaiseCanExecuteChanged();
            (this.Resources["rateCommand"] as EventCommand).RaiseCanExecuteChanged();
            (this.Resources["bookmarkCommand"] as EventCommand).RaiseCanExecuteChanged();
            (this.Resources["jumpToPageCommand"] as EventCommand).RaiseCanExecuteChanged();
            (this.Resources["goBackCommand"] as EventCommand).RaiseCanExecuteChanged();
            (this.Resources["prevCommand"] as EventCommand).RaiseCanExecuteChanged();
            (this.Resources["refreshCommand"] as EventCommand).RaiseCanExecuteChanged();
            (this.Resources["nextCommand"] as EventCommand).RaiseCanExecuteChanged();
            (this.Resources["tabsCommand"] as EventCommand).RaiseCanExecuteChanged();
            (this.Resources["postJumpCommand"] as EventCommand).RaiseCanExecuteChanged();
        }

        public void SetPostForm(MessagePostModel model, bool navigateToReplyView)
        {
            ReplyPageViewModel.Instance.PostForm = model;
            if (navigateToReplyView)
            {
                AccessTokenMessage message = new AccessTokenMessage();
                NotificationService.Default.Notify(this, message);
                var token = message.Token;

                if (token.IsActiveAccount)
                    this.NavigationService.Navigate(new Uri("/ReplyPage.xaml", UriKind.RelativeOrAbsolute));
                else
                    MessageBox.Show("Only registered members of SomethingAwful can reply to threads.",
                        "Sorry!",
                        MessageBoxButton.OK);
            }
        }

        public void SetPagination(IPaginationViewModelWithProgress<string> viewmodel)
        {
            this.pageNavigator.ViewModel.SetNavigable(viewmodel, this.progress, this);
        }

        public void OnNewThreadCreated(ThreadPageMetadata threadPage)
        {
            Task.Delay(10).ContinueWith(task =>
            {
                AccessTokenMessage message = new AccessTokenMessage();
                NotificationService.Default.Notify(this, message);
                var tab = new ThreadDataItemFromPage(threadPage, message.Token);
                this.viewmodel.Threads.Add(tab);
                this.tabsListView.SelectedItem = tab;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        #endregion IThreadPageView

        #region AppBar Events

        private void ShowJumpToPostView(object sender, ExecuteEventArgs args)
        {
            this.viewmodel.CurrentState = ThreadPageViewModel.State.PostJump;
            VisualStateManager.GoToState(this, "PostJumpView", true);
        }

        private void CanShowJumpToPostView(object sender, CanExecuteEventArgs args)
        {
            args.CanExecute = false;
            if (this.viewmodel != null)
                args.CanExecute = this.viewmodel.CurrentThread != null;
        }

        private void scrollToTop(object sender, ExecuteEventArgs args)
        {
            this.Browser.InvokeScript("scrollToTop");
        }

        private void scrollToBottom(object sender, ExecuteEventArgs args)
        {
            this.Browser.InvokeScript("scrollToBottom");
        }

        private void ShowRatePanel(object sender, ExecuteEventArgs args)
        {
            this.itemDetailsContextMenuPanel.Visibility = System.Windows.Visibility.Visible;
            // small delay; appbar closing animation interferes with popup animation.
            Task.Delay(10).ContinueWith(async task =>
            {
                AwfulContextMenu rateMenu = new AwfulContextMenu();
                bool isOpen = this.viewmodel.OnContextMenuOpening("rate", rateMenu, this, this.progress);
                if (isOpen)
                {
                    var popup = rateMenu.ToPopup();
                    await popup.ShowAsync();
                    this.itemDetailsContextMenuPanel.Visibility = System.Windows.Visibility.Collapsed;
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void GoToReplyPage(object sender, ExecuteEventArgs args)
        {
            AccessTokenMessage message = new AccessTokenMessage();
            NotificationService.Default.Notify(this, message);
            if (message.Token.IsActiveAccount)
                this.NavigationService.Navigate(new Uri("/ReplyPage.xaml", UriKind.RelativeOrAbsolute));
            else
                MessageBox.Show("Only registered members of SomethingAwful can reply to threads.",
                    "Sorry!",
                    MessageBoxButton.OK);
        }

        private async void ToggleBookmarks(object sender, ExecuteEventArgs args)
        {
            bool result = await InvokeAndNotifyOnError(this.viewmodel.CurrentThread.ToggleBookmarksAsync(this.progress));
            if (result)
                MessageBox.Show("Bookmark toggled.", "Success!", MessageBoxButton.OK);
        }

        private new async Task<bool> InvokeAndNotifyOnError(Task task)
        {
            bool result = true;
            try { await task; }
            catch (Exception ex)
            {
                result = false;
                MessageBox.Show(ex.Message, "Oops, Something Went Wrong.", MessageBoxButton.OK);
            }

            return result;
        }

        private void ShowNavigationPanel(object sender, ExecuteEventArgs args)
        {
            this.pageNavPanel.IsHitTestVisible = true;
            this.pageNavPanel.Visibility = System.Windows.Visibility.Visible;
        }

        private void GoBack(object sender, ExecuteEventArgs args)
        {
            this.NavigationService.GoBack();
        }

        private async void GoToPrevPage(object sender, ExecuteEventArgs args)
        {
            var task = this.viewmodel.GoToPrevAsync(this, this.progress);
            await InvokeAndNotifyOnError(task);
        }

        private async void RefreshCurrentPage(object sender, ExecuteEventArgs args)
        {
            var task = this.viewmodel.OnRefreshAsync(this, this.progress);
            await InvokeAndNotifyOnError(task);
        }

        private async void GoToNextPage(object sender, ExecuteEventArgs args)
        {
            var task = this.viewmodel.GoToNextAsync(this, this.progress);
            await InvokeAndNotifyOnError(task);
        }

        private void OnAppBarCanExecute(object sender, CanExecuteEventArgs args)
        {
            args.CanExecute = false;
            if (this.viewmodel != null)
                args.CanExecute = this.viewmodel.CurrentThread.IsReady;
        }

        private void CanGoToPrevPage(object sender, CanExecuteEventArgs args)
        {
            OnAppBarCanExecute(sender, args);
            args.CanExecute = args.CanExecute && this.viewmodel.CanGoToPrev();
        }

        private void CanRefreshCurrentPage(object sender, CanExecuteEventArgs args)
        {
            OnAppBarCanExecute(sender, args);
            args.CanExecute = args.CanExecute && this.viewmodel.CanRefresh();
        }

        private void CanGoToNextPage(object sender, CanExecuteEventArgs args)
        {
            OnAppBarCanExecute(sender, args);
            args.CanExecute = args.CanExecute && this.viewmodel.CanGoToNext();
        }

        private bool isTabsViewVisible = false;
        private void ShowTabsView(object sender, ExecuteEventArgs args)
        { 
            VisualStateManager.GoToState(this, "TabsView", true);
            this.viewmodel.CurrentState = ThreadPageViewModel.State.Tabs;
            this.isTabsViewVisible = true;
            (this.Resources["tabsCommand"] as EventCommand).RaiseCanExecuteChanged();
        }

        private void HideTabsView()
        {
            VisualStateManager.GoToState(this, "DetailsView", true);
            this.viewmodel.CurrentState = ThreadPageViewModel.State.Details;
            isTabsViewVisible = false;
            (this.Resources["tabsCommand"] as EventCommand).RaiseCanExecuteChanged();
        }

        private void CanShowTabsView(object sender, CanExecuteEventArgs e)
        {
            e.CanExecute = false;
            if (this.viewmodel != null)
            {
                e.CanExecute = this.viewmodel.Threads.Count > 1;
                if (e.CanExecute) { PromptTabViewHelpMessage(); }
            }
        }

        private bool tabMessagePrompted = false;
        private void PromptTabViewHelpMessage()
        {
            if (!tabMessagePrompted)
            {
                var settings = new WPSettingsModel();
                bool showTabsHelp = settings.GetValueOrDefault<bool>("threadTabHelpMessage", true);
                if (showTabsHelp)
                {
                    var response = MessageBox.Show(THREAD_TAB_MESSAGE, "Hey! Listen.", MessageBoxButton.OKCancel);
                    if (response == MessageBoxResult.OK)
                        settings.AddOrUpdate("threadTabHelpMessage", false);

                    settings.SaveSettings();
                    tabMessagePrompted = true;
                }
            }
        }

        private void OnShowDetailsCommandExecuted(object sender, ExecuteEventArgs args)
        {
            if (this.isTabsViewVisible)
                HideTabsView();
        }

        #endregion

        private bool cancelDetailsViewNavigation = false;
        private void OnRemoveTabClick(object sender, System.Windows.RoutedEventArgs e)
        {
            ThreadDataItem item = (sender as Button).DataContext as ThreadDataItem;
            if (item != null)
            {
                this.viewmodel.Threads.Remove(item);

                // if all tabs have been deleted, go back to previous page.
                if (this.viewmodel.Threads.Count == 0)
                    NavigationService.GoBack();

                // if the current tab is the one being removed, then set the first tab as current
                else if (this.tabsListView.SelectedItem == null)
                {
                    cancelDetailsViewNavigation = true;
                    this.tabsListView.SelectedItem = this.viewmodel.Threads.First();
                }
            }
        }

        private void postJumpItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (element != null)
            {
                ThreadPostMetadata post = element.DataContext as ThreadPostMetadata;
                this.Browser.InvokeScript("scrollToPost", post.PostID);
                this.viewmodel.CurrentState = ThreadPageViewModel.State.Details;
                VisualStateManager.GoToState(this, "DetailsView", true);
            }
        }

        #region LogicalPageNavigation

        private async void tabsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // tried using a long list selector here, but data binding the selecteditem property was a no go.
            // using a listbox instead.
            if (e.AddedItems.Count != 0)
            {
                ThreadDataItem selected = e.AddedItems[0] as ThreadDataItem;
                this.viewmodel.CurrentThread = selected;
                await this.viewmodel.OnSelectedAsync(this, this.progress);

                // unflag view state cancel if set
                if (cancelDetailsViewNavigation)
                {
                    cancelDetailsViewNavigation = false;
                }

                // go back to details view
                else if (this.viewmodel.CurrentState == ThreadPageViewModel.State.Tabs)
                    HideTabsView();
            }
        }

        #endregion LogicalPageNavigation  
    }

    [DataContract]
    public sealed class ThreadPageState
    {
        private ThreadMetadata thread;
        [DataMember]
        public ThreadMetadata Thread
        {
            get { return thread; }
            set { thread = value; }
        }

        private int currentPage = 0;
        [DataMember]
        public int CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; }
        }

        public ThreadDataItem ToThreadDataItem()
        {
            AccessTokenMessage message = new AccessTokenMessage();
            NotificationService.Default.Notify(this, message);
            ThreadDataItem result = new ThreadDataItem(thread, message.Token);
            return result;
        }

        public ThreadPageState() { }

        public ThreadPageState(ThreadDataItem item) : this() { 
            this.Thread = item.Thread;
            this.CurrentPage = item.CurrentPage.HasValue ? item.CurrentPage.Value : 0;
        }
    }

    public class ThreadPageViewModel : BindableBase, IWebViewModel<string>, IPaginationViewModelWithProgress<string>
    {
        public enum State
        {
            Normal = 0,
            Details,
            Tabs,
            PostJump
        }

        private State currentState;
        private IThreadViewPage page;
        private IProgress<string> progress;
        private ObservableCollection<ThreadDataItem> threads = new ObservableCollection<ThreadDataItem>();

        public ThreadPageViewModel(ThreadDataItem initial, IThreadViewPage page, IProgress<string> progress )
        {
            this.threads.Add(initial);
            this.currentThread = initial;
            this.page = page;
            this.progress = progress;
        }

        public State CurrentState
        {
            get { return currentState; }
            set { SetProperty(ref currentState, value); }
        }

        public IList<ThreadDataItem> Threads
        {
            get { return this.threads; }
        }

        public IList<ThreadDataItem> Items { get { return this.threads; } }

        private ThreadDataItem currentThread = null;
        public ThreadDataItem CurrentThread
        {
            get { return this.currentThread; }
            set
            {
                if (SetProperty(ref this.currentThread, value))
                {
                    OnPropertyChanged("Title");
                    OnPropertyChanged("Content");
                }
            }
        }

        public Task OnScriptNotifyAsync(object state, string value)
        {
            throw new NotSupportedException("Please use OnScriptNotifyAsync(object, IProgress<string> string) instead.");
        }

        public Task OnScriptNotifyAsync(object state, IProgress<string> progress, string value)
        {
            return CurrentThread.OnScriptNotifyAsync(state, progress, value);
        }

        public string Title
        {
            get { return CurrentThread.Title; }
        }

        public object Content
        {
            get { return CurrentThread.Content; }
        }

        public Task OnSelectedAsync(object state, IProgress<string> progress, int? pageNumber)
        {
            return CurrentThread.OnSelectedAsync(state, progress, pageNumber);
        }

        public Task OnSelectedAsync(object state, IProgress<string> progress)
        {
            return CurrentThread.OnSelectedAsync(state, progress);
        }

        public bool OnContextMenuOpening(string type, IContextMenu menu, object state, IProgress<string> progress)
        {
            return CurrentThread.OnContextMenuOpening(type, menu, state, progress);
        }

        public Task<bool> OnContextMenuOpeningAsync(string type, IContextMenu menu, object state, IProgress<string> progress)
        {
            return CurrentThread.OnContextMenuOpeningAsync(type, menu, state, progress);
        }

        public bool CanRefresh()
        {
            return CurrentThread.CanRefresh();
        }

        public Task OnRefreshAsync(object state, IProgress<string> progress)
        {
            return CurrentThread.OnRefreshAsync(state, progress);
        }

        public Task<bool> GoToNextAsync(object state, IProgress<string> progress)
        {
            return CurrentThread.GoToNextAsync(state, progress);
        }

        public Task<bool> GoToPrevAsync(object state, IProgress<string> progress)
        {
            return CurrentThread.GoToPrevAsync(state, progress);
        }

        public Task<bool> GoToPageAsync(int pageNumber, object state, IProgress<string> progress)
        {
            return CurrentThread.GoToPageAsync(pageNumber, state, progress);
        }

        public bool CanGoToNext()
        {
            return CurrentThread.CanGoToNext();
        }

        public bool CanGoToPrev()
        {
            return CurrentThread.CanGoToPrev();
        }

        public int? CurrentPage
        {
            get { return CurrentThread.CurrentPage; }
        }

        public int LastPage
        {
            get { return CurrentThread.LastPage; }
        }
    }
}