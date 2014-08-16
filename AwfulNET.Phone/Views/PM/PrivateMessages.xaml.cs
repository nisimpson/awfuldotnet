using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AwfulNET.DataModel;
using AwfulNET.Views;
using AwfulNET.Common;
using System.Windows.Input;
using System.Threading.Tasks;

namespace AwfulNET.Phone.Views.PM
{
    public partial class PrivateMessages : PhoneApplicationPage, IApplicationPage
    {
        private bool isNewInstance = false;
        private readonly PrivateMessagesViewModel context = null;
        private readonly RelayCommand sync;
        private readonly RelayCommand showFolders;
        private readonly RelayCommand showCurrent;
        private readonly RelayCommand newCommand;

        public PrivateMessages()
        {
            InitializeComponent();
            context = new PrivateMessagesViewModel();

            sync = new RelayCommand(OnSync, CanSync);
            context.SyncCommand = sync;

            showFolders = new RelayCommand(ShowAllFolders);
            context.ShowFoldersCommand = showFolders;

            showCurrent = new RelayCommand(ShowCurrentFolderView);
            context.ShowCurrentFolderCommand = showCurrent;

            newCommand = new RelayCommand(NavigateToNewMessageView);
            context.NewCommand = newCommand;

            this.DataContext = context;
            isNewInstance = true;
        }

        private void NavigateToNewMessageView()
        {
            NavigationService.Navigate(new Uri("/Views/PM/NewMessageView.xaml", UriKind.RelativeOrAbsolute));
        }

        private bool isCurrentFolderView = true;
        private void ShowCurrentFolderView()
        {
            this.isCurrentFolderView = true;
            this.context.HideAllFolders();
        }

        private bool isSyncing = false;
        private bool CanSync()
        {
            return !isSyncing && context.CanRefresh();
        }

        private async void OnSync()
        {
            isSyncing = true;
            sync.RaiseCanExecuteChanged();
            await context.OnRefreshAsync(this, IProgressFactory.GenerateProgressToken());
            isSyncing = false;
            sync.RaiseCanExecuteChanged();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (this.isNewInstance)
            {
                this.isSyncing = true;
                sync.RaiseCanExecuteChanged();
                await context.OnSelectedAsync(this, IProgressFactory.GenerateProgressToken());
                this.isSyncing = false;
                sync.RaiseCanExecuteChanged();
                isNewInstance = false;
            }
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (!isCurrentFolderView)
            {
                ShowCurrentFolderView();
                e.Cancel = true;
            }

            base.OnBackKeyPress(e);
        }

        private async void currentItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (element != null)
            {
                CommonDataModel item = element.DataContext as CommonDataModel;
                switch(item.DataType)
                {
                    case MainDataModel.DATATYPE_FOLDER:
                        await ShowPrivateMessageFolder(item);
                        break;

                    case MainDataModel.DATATYPE_PM:
                        ShowPrivateMessage(item);
                        break;

                    default:
                        throw new InvalidOperationException("Unknown data type: " + item.DataType);
                }
            }
        }

        private void ShowPrivateMessage(CommonDataModel item)
        {
            (item as IContentViewModel).OnSelectedAsync(this, IProgressFactory.GenerateProgressToken());
        }

        private async Task ShowPrivateMessageFolder(CommonDataModel item)
        {
            ShowCurrentFolderView();
            context.SetCurrentFolder(item as PrivateMessageGroup);
            isSyncing = true;
            sync.RaiseCanExecuteChanged();
            await context.OnSelectedAsync(this, IProgressFactory.GenerateProgressToken());
            isSyncing = false;
            sync.RaiseCanExecuteChanged();
        }

        public void ShowAllFolders()
        {
            this.isCurrentFolderView = false;
            context.ShowAllFolders();
        }

        public void Navigate(Uri uri)
        {
            NavigationService.Navigate(uri);
        }

        private void ContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            ContextMenu menu = sender as ContextMenu;
            IContentViewModel content = menu.DataContext as IContentViewModel;
            AwfulContextMenu toMenu = new AwfulContextMenu();
            bool isOpen = content.OnContextMenuOpening("item", toMenu, this, IProgressFactory.GenerateProgressToken());
            if (isOpen)
            {
                var menuItems = toMenu.ToContextMenu(menu);
                menu.IsOpen = true;
            }
            else
            {
                menu.IsOpen = false;
            }
        }
    }

    public sealed class PrivateMessagesViewModel : CommonDataModel, IListViewModel
    {
        public enum States
        {
            CurrentFolder = 0,
            AllFolders,
            Hide
        }

        private readonly PrivateMessageFolderIndex index;
        private PrivateMessageGroup currentFolder;
        public PrivateMessagesViewModel()
        {
            this.Title = "PRIVATE MESSAGES";
            this.Subtitle = string.Empty;
            this.index = App.Main.Messages;
        }

        public ICommand SyncCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand ShowFoldersCommand { get; set; }
        public ICommand ShowCurrentFolderCommand { get; set; }

        private States currentState = States.CurrentFolder;
        public States CurrentState
        {
            get { return currentState; }
            set { SetProperty(ref currentState, value); }
        }

        private IListViewModel source;
        public IListViewModel Source { get { return this.source; } set { SetProperty(ref this.source, value); } }

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
            get { return null; }
        }

        public bool HasMoreItems
        {
            get { return false; }
        }

        private bool showContent = true;
        public bool ShowContent
        {
            get { return this.showContent; }
            set { if (SetProperty(ref this.showContent, value))
                OnPropertyChanged("ShowEmpty");
            }
        }

        public bool ShowEmpty { get { return !ShowContent; } }

        private string emptyText = string.Empty;
        public string EmptyText
        {
            get { return this.emptyText; }
            set { SetProperty(ref this.emptyText, value); }
        }

        public void SetCurrentFolder(PrivateMessageGroup folder)
        {
            this.currentFolder = folder;
            this.CurrentState = States.CurrentFolder;
            this.Subtitle = folder.Title.ToLower();
            this.Source = folder;
        }

        internal void HideAllFolders()
        {
            SetCurrentFolder(this.currentFolder);
        }

        public void ShowAllFolders()
        {
            this.CurrentState = States.AllFolders;
            this.Subtitle = "folders";
            this.Source = index;
        }

        public async System.Threading.Tasks.Task OnSelectedAsync(object state, IProgress<string> progress)
        {
            if (currentFolder == null)
            {
                // load up our forums (inbox included)
                await this.index.OnSelectedAsync(state, progress);

                try
                {
                    SetCurrentFolder(this.index.Items[0] as PrivateMessageGroup);
                }
                catch (Exception)
                {
                    // if we get here, then there was a problem loading the inbox.
                    this.EmptyText = index.EmptyText;
                    this.ShowContent = index.ShowContent;
                    this.CurrentState = States.Hide;
                    return;
                }
            }

            try { await this.currentFolder.OnSelectedAsync(state, progress); }
            catch (Exception)
            {
                this.EmptyText = this.currentFolder.EmptyText;
                this.ShowContent = this.currentFolder.ShowContent;
            }
        }

        public bool OnContextMenuOpening(string type, IContextMenu menu, object state, IProgress<string> progress)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<bool> OnContextMenuOpeningAsync(string type, IContextMenu menu, object state, IProgress<string> progress)
        {
            throw new NotImplementedException();
        }

        public bool CanRefresh()
        {
            if (CurrentState == States.AllFolders)
                return index.CanRefresh();

            if (this.currentFolder != null)
                return this.currentFolder.CanRefresh();

            return false;
        }

        public System.Threading.Tasks.Task OnRefreshAsync(object state, IProgress<string> progress)
        {
            if (CurrentState == States.AllFolders)
                return index.OnRefreshAsync(state, progress);

            return this.currentFolder.OnRefreshAsync(state, progress);
        }

        public System.Collections.IEnumerable ItemsSource
        {
            get { throw new NotImplementedException(); }
        }
    }
}