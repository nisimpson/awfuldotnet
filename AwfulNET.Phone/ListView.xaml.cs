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

namespace AwfulNET.Phone
{
    public partial class ListView : PhoneApplicationPage, IApplicationPage
    {
        private ProgressToken Progress { get { return App.Current.Resources["progressToken"] as ProgressToken; } }
        private bool isNewInstance = false;
        private IListViewModel viewmodel;
        private MainDataModel mainDataModel;

        public ListView()
        {
            InitializeComponent();
            mainDataModel = App.Main;
            isNewInstance = true;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (this.isNewInstance)
            {
                if (NavigationContext.QueryString.ContainsKey("id"))
                {
                    IListViewModel selected = mainDataModel.GetListDataByID(
                        NavigationContext.QueryString["id"]);

                    this.viewmodel = selected;
                    this.DataContext = this.viewmodel;
                    await this.viewmodel.OnSelectedAsync(this, this.Progress);
                    NotifyCommands();
                }

                this.isNewInstance = false;
            }
        }

        private void itemsListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // only process item tap events
        }

        //bool scrollToTop = false;
        private void itemsListView_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            scrollToTop = false;
            LongListSelector list = sender as LongListSelector;
            INotifyCollectionChanged collection = list.ItemsSource as INotifyCollectionChanged;
            if (collection != null)
            {
                
                collection.CollectionChanged += (obj, args) =>
                {
                    if (args.Action == NotifyCollectionChangedAction.Add &&
                        !scrollToTop)
                    {
                        scrollToTop = true;
                        list.ScrollTo(list.ItemsSource[0]);
                    }
                };
                
            }
            */
        }

        private async void listItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // TODO: Add event handler implementation here.
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

        private void NotifyCommands()
        {
            (this.Resources["refreshCommand"] as EventCommand).RaiseCanExecuteChanged();
        }

        private void OnRefreshCommandCanExecute(object sender, CanExecuteEventArgs args)
        {
            args.CanExecute = false;
            if (this.viewmodel != null)
                args.CanExecute = this.viewmodel.CanRefresh();
        }

        private async void OnRefreshCommandExecute(object sender, ExecuteEventArgs args)
        {
            await this.viewmodel.OnRefreshAsync(this, this.Progress);
            NotifyCommands();
        }

        public void Navigate(Uri uri)
        {
            NavigationService.Navigate(uri);
        }
    }
}