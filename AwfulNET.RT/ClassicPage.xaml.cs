using AwfulNET.Common;
using AwfulNET.Core.Common;
using AwfulNET.DataModel;
using AwfulNET.RT.Common;
using AwfulNET.Views;
using AwfulNET.WinRT.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Split Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234234

namespace AwfulNET.RT
{
    /// <summary>
    /// A page that displays a group title, a list of items within the group, and details for
    /// the currently isNotAList item.
    /// </summary>
    public sealed partial class ClassicPage : Page, 
        IWebViewPage, IThreadViewPage
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private ClassicPageViewModel viewModelWrapper;
        private TaskCompletionSource<bool> domReady;
        private IProgress<string> progress;
       
        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public ClassicPage()
        {
            this.InitializeComponent();

            // Setup the navigation helper
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;

            // listen for the user activating settings
            SettingsPane.GetForCurrentView().CommandsRequested += OnSettingsPaneCommandsRequested;
           
            // Setup the logical page navigation components that allow
            // the page to only show one pane at a time.
            this.navigationHelper.GoBackCommand = new RelayCommand(() => this.GoBack(), () => this.CanGoBack());
            this.itemListView.SelectionChanged += itemListView_SelectionChanged;

            // Start listening for progress report changes
            this.progress = new LoadingToken();
            LoadingToken.ReportProgress += LoadingToken_ReportProgress;

            // Initialize Wrapper
            this.viewModelWrapper = new ClassicPageViewModel(this, this.defaultViewModel, this.progress);

            // Initialize the webview
            this.domReady = new TaskCompletionSource<bool>();
            this.itemDetailPanel.IsHitTestVisible = false;
            this.itemDetail.DOMContentLoaded += webView_DOMContentLoaded;
            this.itemDetail.ScriptNotify += itemDetail_ScriptNotify;
            this.itemDetail.NavigationStarting += itemDetail_NavigationStarting;
            this.itemDetail.Navigate(new Uri("ms-appx-web:///webview/webview.html", UriKind.Absolute));

            // Start listening for Window size changes 
            // to change from showing two panes to showing a single pane
            Window.Current.SizeChanged += Window_SizeChanged;
            this.InvalidateVisualState();
        }

        void OnSettingsPaneCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            App.OnSettingsPaneCommandsRequested(sender, args);

            // Add logout command to settings
            SettingsCommand logoutCommand = new SettingsCommand("GeneralSettings", "Logout",
                new UICommandInvokedHandler(OnLogoutCommandInvoked));

            args.Request.ApplicationCommands.Add(logoutCommand);
        }

        private async void OnLogoutCommandInvoked(IUICommand command)
        {
            MessageDialog confirmLogout = new MessageDialog("Are you sure you want to logout?", "We're sad to see you go. :(");
            UICommand ok = new UICommand("Yep");
            UICommand cancel = new UICommand("Nah");
            
            confirmLogout.DefaultCommandIndex = 0;
            confirmLogout.CancelCommandIndex = 1;
            
            confirmLogout.Commands.Add(ok);
            confirmLogout.Commands.Add(cancel);
            
            IUICommand selected = await confirmLogout.ShowAsync();
            if (selected == ok)
            {
                var settings = SettingsModelFactory.GetSettingsModel();
                App.UserContext.Logout(settings);
                await new MessageDialog("Logout successful. Restart Awful to complete.").ShowAsync();
            }
        }

        private void onToastNotify(INotification<ToastMessage> obj)
        {
            ToastGenerator.ShowToast(obj.Value.Message);
        }

        void itemDetail_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine(args.Uri.ToString());
        }

        /// <summary>
        /// Invoked when the webview calls the window.external.notify function.
        /// </summary>
        /// <param name="sender">The webview presenting the DOM.</param>
        /// <param name="e">
        /// Event data containing values passed as parameters of the javascript function.
        /// </param>
        private void itemDetail_ScriptNotify(object sender, NotifyEventArgs e)
        {
            string value = e.Value;
            switch (value)
            {
                case "showLoading":
                    this.loadingRing.IsActive = true;
                    break;

                case "hideLoading":
                    this.loadingRing.IsActive = false;
                    break;

                default:
                    IWebViewModel<string> item = this.itemListView.SelectedItem as IWebViewModel<string>;
                    if (item != null)
                    {
                        Task.Delay(10).ContinueWith(async t =>
                            {
                                    string err = null;
                                    try { await item.OnScriptNotifyAsync(this, this.progress, e.Value); }
                                    catch (Exception ex) { err = ex.Message; }
                                    finally { progress.Report(null); }
                                    if (!string.IsNullOrEmpty(err))
                                        await new MessageDialog(err, "Oops, something went wrong.").ShowAsync();
                                
                            }, TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    break;
            }
        }

        private async void InvokeAndNotifyOnError(Action action)
        {
            MessageDialog errorDialog = null;

            try { action(); }
            catch (Exception ex)
            {
                errorDialog = new MessageDialog(ex.Message, "Oops, something went wrong.");
            }

            if (errorDialog != null)
                await errorDialog.ShowAsync();
        }

        /// <summary>
        /// Invoked when the webview's DOM is fully loaded. All javascript libraries included
        /// on the current page's markup are ready to be used.
        /// </summary>
        /// <param name="sender">The webview containing the DOM</param>
        /// <param name="args">Event data containing the sender's current state.</param>
        private void webView_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
            this.domReady.SetResult(true);
        }

        void LoadingToken_ReportProgress(object sender, ProgressReportArgs args)
        {
            if (args.Message == null)
                this.loadingRing.IsActive = false;
            else
                this.loadingRing.IsActive = true;
        }

        void itemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.UsingLogicalPageNavigation())
            {
                this.navigationHelper.GoBackCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private async void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            // TODO: Assign a bindable group to Me.DefaultViewModel("Group")
            // TODO: Assign a collection of bindable items to Me.DefaultViewModel("Items")
            
            if (e.PageState == null)
            {
                await this.domReady.Task;
                await this.viewModelWrapper.ViewAsync(App.Main);

                // When this is a new page, select the first item automatically unless logical page
                // navigation is being used (see the logical page navigation #region below.)
                if (!this.UsingLogicalPageNavigation() && this.itemsViewSource.View != null)
                {
                    this.itemsViewSource.View.MoveCurrentToFirst();
                    this.itemListView.SelectedItem = null;
                }
            }
            else
            {
                // Restore the previously saved state associated with this page
                if (e.PageState.ContainsKey("SelectedItem") && this.itemsViewSource.View != null)
                {
                    // TODO: Invoke Me.itemsViewSource.View.MoveCurrentTo() with the isNotAList
                    //       item as specified by the value of pageState("SelectedItem")

                }
            }
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            if (this.itemsViewSource.View != null)
            {
                // TODO: Derive a serializable navigation parameter and assign it to
                //       pageState("SelectedItem")

            }
        }

        #region Logical page navigation

        // The split page isdesigned so that when the Window does have enough space to show
        // both the list and the dteails, only one pane will be shown at at time.
        //
        // This is all implemented with a single physical page that can represent two logical
        // pages.  The code below achieves this goal without making the user aware of the
        // distinction.

        private const int MinimumWidthForSupportingTwoPanes = 801;

        /// <summary>
        /// Invoked to determine whether the page should act as one logical page or two.
        /// </summary>
        /// <returns>True if the window should show act as one logical page, false
        /// otherwise.</returns>
        private bool UsingLogicalPageNavigation()
        {
            return Window.Current.Bounds.Width < MinimumWidthForSupportingTwoPanes;
        }

        /// <summary>
        /// Invoked with the Window changes size
        /// </summary>
        /// <param name="sender">The current Window</param>
        /// <param name="e">Event data that describes the new size of the Window</param>
        private void Window_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            foreach (var item in this.groupHeaders)
                item.Width = e.Size.Width;

            this.InvalidateVisualState();
        }

        /// <summary>
        /// Invoked when an item within the list is isNotAList.
        /// </summary>
        /// <param name="sender">The GridView displaying the isNotAList item.</param>
        /// <param name="e">Event data that describes how the selection was changed.</param>
        private void ItemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Invalidate the view state when logical page navigation is in effect, as a change
            // in selection may cause a corresponding change in the current logical page.  When
            // an item is isNotAList this has the effect of changing from displaying the item list
            // to showing the isNotAList item's details.  When the selection is cleared this has the
            // opposite effect.
            if (this.UsingLogicalPageNavigation()) this.InvalidateVisualState();
        }

        private bool CanGoBack()
        {
            if (this.UsingLogicalPageNavigation() && this.itemListView.SelectedItem != null)
            {
                return true;
            }
            else
            {
                return this.navigationHelper.CanGoBack();
            }
        }
        private void GoBack()
        {
            //if (this.UsingLogicalPageNavigation() && this.itemListView.SelectedItem != null)
            if (this.UsingLogicalPageNavigation() && !viewModelWrapper.IsListActive)
            {
                // When logical page navigation is in effect and there's a isNotAList item that
                // item's details are currently displayed.  Clearing the selection will return to
                // the item list.  From the user's point of view this is a logical backward
                // navigation.
                //this.itemListView.SelectedItem = null;
                viewModelWrapper.IsListActive = true;
                InvalidateVisualState();
            }
            else
            {
                this.navigationHelper.GoBack();
            }
        }

        private void InvalidateVisualState()
        {
            var visualState = DetermineVisualState();
            VisualStateManager.GoToState(this, visualState, false);
            this.navigationHelper.GoBackCommand.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Invoked to determine the name of the visual state that corresponds to an application
        /// view state.
        /// </summary>
        /// <returns>The name of the desired visual state.  This is the same as the name of the
        /// view state except when there is a isNotAList item in portrait and snapped views where
        /// this additional logical page is represented by adding a suffix of _Detail.</returns>
        private string DetermineVisualState()
        {
            if (!UsingLogicalPageNavigation())
                return "PrimaryView";

            // Update the back button's enabled state when the view state changes
            // var logicalPageBack = this.UsingLogicalPageNavigation() && this.itemListView.SelectedItem != null;
            var logicalPageBack = this.UsingLogicalPageNavigation() && !viewModelWrapper.IsListActive;
            return logicalPageBack ? "SinglePane_Detail" : "SinglePane";
        }

        #endregion

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void logoButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implement Modern Page.
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.GoBack();
        }

        #region IThreadViewPage

        public void SetPostForm(MessagePostModel model, bool navigateToReplyView)
        {
            this.viewModelWrapper.SetPostForm(model, navigateToReplyView);
            model.WhileBusy = NotifyProgress;
            model.OnFailure = NotifyFailureAndTryAgain;
            model.OnSuccess = NotifySuccessAndGoBack;
        }

        private void NotifyProgress(bool isBusy)
        {
            if (isBusy)
            {
                this.replyFlyout.Content.IsHitTestVisible = false;
                this.loadingRing.IsActive = true;
            }
            else
            {
                this.replyFlyout.Content.IsHitTestVisible = true;
                this.loadingRing.IsActive = false;
            }
        }

        private async void NotifyFailureAndTryAgain(Exception ex)
        {
            await new MessageDialog(ex.Message, "Oops, something went wrong").ShowAsync();
        }

        private void NotifySuccessAndGoBack()
        {
            ToastGenerator.ShowToast("You made a post. High five!");
            this.viewModelWrapper.PostForm = this.viewModelWrapper.PostForm.Reset();
            this.replyFlyout.Hide();
        }

        public void SetPagination(IPaginationViewModelWithProgress<string> viewmodel)
        {
            this.viewModelWrapper.SetPagination(viewmodel);
        }

        public void NotifyAppBarCommands()
        {
            this.viewModelWrapper.NotifyContentCommands();
        }

        #endregion IThreadViewPage

        #region IWebViewPage

        public object InvokeScript(string functionName, params string[] args)
        {
            if (!itemDetailPanel.IsHitTestVisible)
            {
                itemDetailPanel.IsHitTestVisible = true;
                itemDetail.Opacity = 1.0;
            }

            return this.itemDetail.InvokeScriptAsync(functionName, args).GetResults();
        }

        public async Task<object> InvokeScriptAsync(string functionName, params string[] args)
        {
            if (!itemDetailPanel.IsHitTestVisible)
            {
                itemDetailPanel.IsHitTestVisible = true;
                itemDetail.Opacity = 1.0;
            }

            var result = await this.itemDetail.InvokeScriptAsync(functionName, args);
            return result;
        }

        public void Navigate(Uri uri)
        {
            // ignore navigation; all app functionality is handled on one page.
        }

        #endregion IWebViewPage

        private void AttachReplyFlyoutEvents()
        {
            this.replyFlyout.Opened += (o, a) => { this.isPostFormVisible = true; };
            this.replyFlyout.Closed += (o, a) => { this.isPostFormVisible = false; };
        }

        private bool isPostFormVisible = false;
        public bool IsPostFormVisible
        {
            get { return this.isPostFormVisible; }
            set
            {
                if (!isPostFormVisible && value)
                {
                    this.replyFlyout.ShowAt(this.replyButton);
                }
            }
        }

        private async void itemListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            IContentViewModel content = e.ClickedItem as IContentViewModel;
            if (content != null)
            {
                bool isNotAList = await this.viewModelWrapper.ViewAsync(content);
                if (isNotAList)
                {
                    // show as highlighted item in items list
                    this.itemListView.SelectedItem = content;

                    // clear tabs
                    this.viewModelWrapper.Threads.Clear();
                    this.viewModelWrapper.Threads.Add(content as ThreadDataItem);
                }
                else
                {
                    // deselect items in items list
                    this.itemListView.SelectedItem = null;
                }

                // redraw the visual state (for logical page navigation)
                InvalidateVisualState();
            }
        }

        internal void AdjustListView(IListViewModel list)
        {
            if (list == null)
                return;

            if (list.IsJumpList)
            {
                itemsViewSource.IsSourceGrouped = true;
            }
            else
            {
                itemsViewSource.IsSourceGrouped = false;
            }

            itemListView.SelectedItem = null;
            if (refreshListCommand != null)
                refreshListCommand.RaiseCanExecuteChanged();
        }

        private EventCommand refreshListCommand;
        private void OnCanRefresh(object sender, CanExecuteEventArgs args)
        {
            refreshListCommand = sender as EventCommand;
            args.CanExecute = false;
            if (this.viewModelWrapper != null)
            {
                var dir = this.viewModelWrapper.CurrentDirectory;
                if (dir != null)
                    args.CanExecute = dir.CanRefresh();
            }
        }

        private async void OnRefreshListExecute(object sender, ExecuteEventArgs args)
        {
            var dir = this.viewModelWrapper.CurrentDirectory;
            if (dir != null)
                await dir.OnRefreshAsync(this, this.progress);
        }

        private void OnBottomAppBarOpened(object sender, object e)
        {
            var appBar = sender as CommandBar;
            appBar.PrimaryCommands.Clear();
            appBar.SecondaryCommands.Clear();

            if (!viewModelWrapper.IsListActive)
            {
                this.SelectBottomAppBar(itemListView.SelectedItem as ICommonDataModel);
            }

            else { this.BottomAppBar.IsOpen = false; }
        }

        private void OnBottomAppBarClosed(object sender, object e)
        {
            var appBar = sender as CommandBar;
            appBar.PrimaryCommands.Clear();
            appBar.SecondaryCommands.Clear();
        }

        private async void OnItemRightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            IContentViewModel content = element.DataContext as IContentViewModel;
            if(content != null)
            {
                // detach the appbar opening event.
                this.BottomAppBar.Opened -= OnBottomAppBarOpened;

                AwfulContextMenu menu = new AwfulContextMenu();
                var hasMenu = await content.OnContextMenuOpeningAsync("item", menu, this, this.progress);

                if (hasMenu)
                {
                    var itemContextBar = menu.ToAppBarButtonContainer(true);
                    EventHandler<object> opened = null;
                    opened = new EventHandler<object>((obj, args) =>
                    {
                        this.BottomAppBar.Opened -= opened;
                        this.BottomAppBar.Opened += OnBottomAppBarOpened;
                    });

                    this.SelectBottomAppBar(itemContextBar);
                    this.BottomAppBar.Opened += opened;
                    this.BottomAppBar.IsOpen = true;
                }

                else
                {
                    this.BottomAppBar.Opened += OnBottomAppBarOpened;
                    this.BottomAppBar.IsOpen = false;
                }
            }
        }

        private void OnItemHolding(object sender, HoldingRoutedEventArgs e)
        {
            OnItemRightTapped(sender, null);
        }

        private void SelectBottomAppBar(AppBarButtonContainer container)
        {
            try
            {
                CommandBar bottomBar = this.BottomAppBar as CommandBar;

                foreach (ICommandBarElement item in container.PrimaryCommands)
                    bottomBar.PrimaryCommands.Add(item);

                foreach (ICommandBarElement item in container.SecondaryCommands)
                    bottomBar.SecondaryCommands.Add(item);
            }
            catch (Exception) { }
        }

        private void SelectBottomAppBar(ICommonDataModel data)
        {
            // ...grab the data type of the object
            string type = data.DataType;

            // then select the commandBar applicable to this type
            switch (type)
            {
                case MainDataModel.DATATYPE_THREAD:
                    ApplyThreadContextAppBar();
                    break;

                // if we didn't provide a data type above, don't allow the app bar to open.
                default:
                    SelectBottomAppBar(new AppBarButtonContainer());
                    break;
            }
        }

        private void ApplyThreadContextAppBar()
        {
            var threadBar = this.Resources["ThreadCommandBar"] as AppBarButtonContainer;
            SelectBottomAppBar(threadBar);
        }

        #region ThreadCommandBar Events

        private void jumpToPageMenu_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button.Flyout != null)
                button.Flyout.ShowAt(button);
        }

        private async void scrollTopMenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            await this.itemDetail.InvokeScriptAsync("scrollToTop", new string[] { });
        }

        private async void scrollToBottomMenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            await this.itemDetail.InvokeScriptAsync("scrollToBottom", new string[] { });
        }

        private void rateThreadButton_Click(object sender, RoutedEventArgs e)
        {
            ThreadDataItem thread = this.itemListView.SelectedItem as ThreadDataItem;
            if (thread == null)
                throw new InvalidOperationException("Expected selected item to be data type: thread.");

            Button button = sender as Button;
            AwfulContextMenu menu = new AwfulContextMenu();
            var hasRate = thread.OnContextMenuOpening("rate", menu, this, this.progress);
            
            if (!hasRate)
                throw new InvalidOperationException("Expected thread to generate rate context menu.");

            MenuFlyout flyout = menu.ToMenuFlyout();
            button.Flyout = flyout;
            flyout.ShowAt(button);
        }

        #endregion ThreadCommandBar Events

        public void OnNewThreadCreated(ThreadPageMetadata threadPage)
        {
            Task.Delay(10).ContinueWith(task =>
            {
                AccessTokenMessage message = new AccessTokenMessage();
                NotificationService.Default.Notify(this, message);
                var tab = new ThreadDataItemFromPage(threadPage, message.Token);
                this.viewModelWrapper.Threads.Add(tab);
                this.viewModelWrapper.CurrentThread = tab;

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void threadTabsButton_Click(object sender, RoutedEventArgs e)
        {
            AppBarButton button = sender as AppBarButton;
            button.Flyout.ShowAt(sender as FrameworkElement);
        }

        private void OnRemoveTabClick(object sender, RoutedEventArgs e)
        {
            ThreadDataItem item = (sender as Button).DataContext as ThreadDataItem;
            if (item != null)
            {
                this.viewModelWrapper.Threads.Remove(item);

                // if all tabs have been deleted, go back to previous page.
                if (this.viewModelWrapper.Threads.Count == 0)
                    this.threadTabsButton.IsEnabled = false;

                // if the current tab is the one being removed, then set the first tab as current
                else if (this.viewModelWrapper.CurrentThread == null)
                {
                    this.viewModelWrapper.CurrentThread = this.viewModelWrapper.Threads.First();
                }
            }
        }

        private List<FrameworkElement> groupHeaders = new List<FrameworkElement>();
        private void OnGroupHeaderBorderLoaded(object sender, RoutedEventArgs e)
        {
            FrameworkElement border = sender as FrameworkElement;
            border.Unloaded += OnGroupHeaderBorderUnloaded;
            groupHeaders.Add(border);
        }

        private void OnGroupHeaderBorderUnloaded(object sender, RoutedEventArgs e)
        {
            FrameworkElement border = sender as FrameworkElement;
            groupHeaders.Remove(border);
        }
    }

    public sealed class ClassicPageViewModel : BindableBase
    {
        private ObservableDictionary pageViewModel;
        private ClassicPage page;
        private Stack<IListViewModel> history = new Stack<IListViewModel>();
        private IProgress<string> progress;
        private AwfulViewPageNavigator pageNav;
        
        private RelayCommand goUpCommand;
        private RelayCommand nextCommand;
        private RelayCommand prevCommand;
        private RelayCommand bookmarkCommand;
        private RelayCommand refreshCommand;

        private ObservableCollection<ThreadDataItem> threads = new ObservableCollection<ThreadDataItem>();
        public ObservableCollection<ThreadDataItem> Threads
        {
            get { return this.threads; }
        }

        private ThreadDataItem currentThread = null;
        public ThreadDataItem CurrentThread
        {
            get
            {
                return currentThread;
            }
            set
            {
                if (SetProperty(ref this.currentThread, value))
                {
                    ViewContentAsync(value);
                }
            }
        }

        public bool EnableTabs { get { return this.threads.Count > 1; } }

        private MessagePostModel postForm;
        public MessagePostModel PostForm { get { return this.postForm; }
            set
            {
                postForm = value;
                pageViewModel["PostForm"] = value;
            }
        }

        private IListViewModel currentDirectory;
        public IListViewModel CurrentDirectory
        {
            get { return this.currentDirectory; }
            set
            {
                if (SetProperty(ref currentDirectory, value))
                {
                    pageViewModel["CurrentDirectory"] = value;
                    //pageViewModel["Items"] = value != null ? value.ItemsSource : null;
                    goUpCommand.RaiseCanExecuteChanged();
                    page.AdjustListView(value);
                }
            }
        }

        private IContentViewModel currentContent;

        public ClassicPageViewModel(ClassicPage page, 
            ObservableDictionary defaultViewModel, 
            IProgress<string> progress)
        {
            this.page = page;
            this.pageViewModel = defaultViewModel;
            this.progress = progress;
            this.pageNav = new AwfulViewPageNavigator(page, progress);
            this.IsListActive = true;

            nextCommand = new RelayCommand(GoToNextPage, CanGoToNextPage);
            prevCommand = new RelayCommand(GoToPrevPage, CanGoToPrevPage);
            refreshCommand = new RelayCommand(RefreshContent, CanRefreshContent);
            bookmarkCommand = new RelayCommand(BookmarkContent, CanBookmarkContent);
            goUpCommand = new RelayCommand(GoUp, CanGoUp);

            this.threads.CollectionChanged += (o, a) => { OnPropertyChanged("EnableTabs"); };

            pageViewModel["Context"] = this;
            pageViewModel["Threads"] = this.threads;
            pageViewModel["PageNav"] = this.pageNav;
            pageViewModel["NextCommand"] = this.nextCommand;
            pageViewModel["PrevCommand"] = this.prevCommand;
            pageViewModel["RefreshCommand"] = this.refreshCommand;
            pageViewModel["BookmarkCommand"] = this.bookmarkCommand;
            pageViewModel["GoUpCommand"] = this.goUpCommand;            
        }

        private bool CanGoUp()
        {
            return history.Count > 1;
        }

        private bool CanBookmarkContent()
        {
            return this.currentContent is ThreadDataItem;
        }

        private async void BookmarkContent()
        {
            var thread = this.currentContent as ThreadDataItem;
            if (thread != null)
                await thread.ToggleBookmarksAsync(this.progress);
        }

        private bool CanRefreshContent()
        {
            if (this.currentContent != null)
                return this.currentContent.CanRefresh();

            return false;
        }

        private void RefreshContent()
        {
            if (this.currentContent != null)
                this.currentContent.OnRefreshAsync(this.page, this.progress).ContinueWith(task =>
                    NotifyContentCommands(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private bool CanGoToNextPage()
        {
            var pagination = this.currentContent as IPaginationViewModelWithProgress<string>;
            if (pagination != null)
                return pagination.CanGoToNext();

            return false;
        }

        private void GoToNextPage()
        {
            var pagination = this.currentContent as IPaginationViewModelWithProgress<string>;
            pagination.GoToNextAsync(this.page, this.progress).ContinueWith(task =>
                {
                    if (this.currentContent is ArticleDataItem)
                    {
                        this.currentContent = (this.currentContent as ArticleDataItem).NextItem;
                    }

                    NotifyContentCommands();
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private bool CanGoToPrevPage()
        {
            var pagination = this.currentContent as IPaginationViewModelWithProgress<string>;
            if (pagination != null)
                return pagination.CanGoToPrev();

            return false;
        }

        private void GoToPrevPage()
        {
            var pagination = this.currentContent as IPaginationViewModelWithProgress<string>;
            pagination.GoToPrevAsync(this.page, this.progress).ContinueWith(task =>
            {
                if (this.currentContent is ArticleDataItem)
                {
                    this.currentContent = (this.currentContent as ArticleDataItem).PrevItem;
                }
                NotifyContentCommands();

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public Task<bool> ViewAsync(IContentViewModel content)
        {
            if (content is IListViewModel)
                return ViewListAsync(content as IListViewModel);

            return ViewContentAsync(content);
        }

        public void SetPostForm(MessagePostModel model, bool showPostForm)
        {
            this.PostForm = model;
            page.IsPostFormVisible = showPostForm;
        }
        
        public void SetPagination(IPaginationViewModelWithProgress<string> pagination)
        {
            this.pageNav.SetNavigable(pagination);
        }

        private async Task<bool> ViewListAsync(IListViewModel list)
        {
            await list.OnSelectedAsync(this.page, this.progress);
            this.IsListActive = true;
            history.Push(list);
            CurrentDirectory = list;
            return false;
        }

        private async Task<bool> ViewContentAsync(IContentViewModel content)
        {
            if (content == null)
                return false;

            this.currentContent = content;
            await content.OnSelectedAsync(this.page, this.progress);
            this.IsListActive = false;
            NotifyContentCommands();
            return true;
        }

        public void NotifyContentCommands()
        {
            nextCommand.RaiseCanExecuteChanged();
            prevCommand.RaiseCanExecuteChanged();
            bookmarkCommand.RaiseCanExecuteChanged();
            refreshCommand.RaiseCanExecuteChanged();
        }

        void GoUp()
        {
            history.Pop();
            this.CurrentDirectory = null;
            this.CurrentDirectory = history.Peek();
        }

        public bool IsListActive { get; set; }
    }
}
