using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AwfulNET.Views;
using AwfulNET.Common;
using AwfulNET.DataModel;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace AwfulNET.Phone
{
    public partial class PivotView : PhoneApplicationPage, IApplicationPage
    {
        PivotViewModel viewmodel;
        bool isNewInstance = false;
        ProgressToken Progress { get { return this.Resources["progressToken"] as ProgressToken; } }
        EventCommand RefreshCommand { get { return this.Resources["refreshCommand"] as EventCommand; } }

        public PivotView()
        {
            InitializeComponent();
            isNewInstance = true;
            VisualStateManager.GoToState(this, "Hidden", false);
            viewmodel = new PivotViewModel(App.Main);
            this.DataContext = viewmodel;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (this.isNewInstance)
            {
                this.NavigationService.RemoveBackEntry();
                this.ApplicationBar.IsVisible = false;
                await viewmodel.OnSelectedAsync(this, this.Progress);
                VisualStateManager.GoToState(this, "Normal", true);
                this.ApplicationBar.IsVisible = true;
                this.isNewInstance = false;
            }
        }

        private void itemsListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // only process item tap events
        }

        private async void listItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            IContentViewModel content = element.DataContext as IContentViewModel;
            if (content != null)
                await content.OnSelectedAsync(this, this.Progress);
        }

        private void itemContextMenu_Opened(object sender, System.Windows.RoutedEventArgs e)
        {
            var menu = sender as ContextMenu;
            IContentViewModel content = menu.DataContext as IContentViewModel;
            if (content != null)
            {
                var wrapper = new AwfulContextMenu();
                var isOpen = content.OnContextMenuOpening("item", wrapper, this, this.Progress);
                if (isOpen)
                    wrapper.ToContextMenu(menu);

                menu.IsOpen = isOpen;
            }
        }

        private async void mainPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                var element = e.AddedItems[0] as FrameworkElement;
                IContentViewModel content = element.DataContext as IContentViewModel;
                if (content != null)
                {
                    this.RefreshCommand.RaiseCanExecuteChanged();
                    await content.OnSelectedAsync(this, this.Progress);
                    this.RefreshCommand.RaiseCanExecuteChanged();
                }
            }
        }

        #region IApplicationPage Implementation

        public void Navigate(Uri uri)
        {
            this.NavigationService.Navigate(uri);
        }

        #endregion

        private async void OnRefreshCommandExecuteRaised(object sender, ExecuteEventArgs args)
        {
            var pivotItem = this.mainPivot.SelectedItem as FrameworkElement;
            var viewmodel = pivotItem.DataContext as IContentViewModel;
            if (viewmodel != null)
                await viewmodel.OnRefreshAsync(this, this.Progress);
        }

        private void OnRefreshCommandCanExecuteRaised(object sender, CanExecuteEventArgs args)
        {
            args.CanExecute = false;

            if (this.mainPivot != null)
            {
                var pivotItem = this.mainPivot.SelectedItem as FrameworkElement;
                var viewmodel = pivotItem.DataContext as IContentViewModel;
                if (viewmodel != null)
                    args.CanExecute = viewmodel.CanRefresh();
            }
        }

        private void itemsListView_Loaded(object sender, RoutedEventArgs e)
        {
            
            LongListSelector list = sender as LongListSelector;
            INotifyCollectionChanged collection = list.ItemsSource as INotifyCollectionChanged;
            if (collection != null)
            {
                bool scrollToTop = false;
                NotifyCollectionChangedEventHandler collectionChanged = null;
                collectionChanged = new NotifyCollectionChangedEventHandler((obj, args) =>
                    {
                        (obj as INotifyCollectionChanged).CollectionChanged -= collectionChanged;
                        if (args.Action == NotifyCollectionChangedAction.Add &&
                            !scrollToTop)
                        {
                            scrollToTop = true;
                            try { list.ScrollTo(list.ItemsSource[0]); }
                            catch (Exception) { }
                        }
                    });
                collection.CollectionChanged += collectionChanged;
            }
        }

        private void OnLogoutCommandExecuted(object sender, ExecuteEventArgs args)
        {
            var response = MessageBox.Show("Are you sure you want to logout?", "Logout?", MessageBoxButton.OKCancel);
            if (response == MessageBoxResult.OK)
            {
                App.UserContext.Logout(new WPSettingsModel());
                MessageBox.Show("Restart the application to complete.", "Logout Complete.", MessageBoxButton.OK);
            }
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

    public sealed class PivotViewModel : BindableBase, IListViewModel
    {
        private IEnumerable<IListViewModel> itemsSource;
        private IListViewModel articles;
        private IListViewModel bookmarks;
        private IListViewModel forums;
        private IListViewModel favorites;

        public object Articles { get { return articles; } }
        public object Bookmarks { get { return bookmarks; } }
        public object Forums { get { return forums; } }
        public object Favorites { get { return favorites; } }

        public PivotViewModel(MainDataModel main)
        {
            this.articles = main.Articles;
            this.bookmarks = main.Bookmarks;
            this.forums = main.Forums;
            this.favorites = main.Pinned;

            itemsSource = new IListViewModel[]
            {
                this.bookmarks,
                this.favorites,
                this.forums,
                this.articles
            };
        }

        #region IListViewModel Implementation

        public System.Collections.IEnumerable ItemsSource
        {
            get { return itemsSource; }
        }

        public bool HasMoreItems { get { return false; } }

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
            get { throw new NotImplementedException(); }
        }

        public string Title
        {
            get { return App.Current.Resources["ApplicationTitle"] as string; }
        }

        public object Content
        {
            get { return this; }
        }

        // load all of our data before we let the user manipulate it.
        public async System.Threading.Tasks.Task OnSelectedAsync(object page, IProgress<string> progress)
        {
            await Task.Delay(250);
        }
        // This view model is not an item, and will never generate a context menu.
        public bool OnContextMenuOpening(string type, IContextMenu menu, object page, IProgress<string> progress)
        {
            throw new NotImplementedException();
        }
        // This view model is not an item, and will never generate a context menu.
        public System.Threading.Tasks.Task<bool> OnContextMenuOpeningAsync(string type, IContextMenu menu, object page, IProgress<string> progress)
        {
            throw new NotImplementedException();
        }
        // This view model is the root view model; items can refresh but the view model cannot.
        public bool CanRefresh()
        {
            throw new NotImplementedException();
        }
        // This view model is the root view model; items can refresh but the view model cannot.
        public System.Threading.Tasks.Task OnRefreshAsync(object page, IProgress<string> progress)
        {
            throw new NotImplementedException();
        }

        public string EmptyText
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        public string UniqueID
        {
            get { throw new NotImplementedException(); }
        }
    }
}