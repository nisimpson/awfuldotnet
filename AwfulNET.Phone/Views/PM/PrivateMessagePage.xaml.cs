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

namespace AwfulNET.Phone.Views.PM
{
    public partial class PrivateMessagePage : WebViewAwarePage, IPrivateMessageView
    {
        private ProgressToken progress;
        private PrivateMessageGroup group;
        private PrivateMessageItem viewmodel;
        private MainDataModel mainDataModel;

        public PrivateMessagePage()
        {
            InitializeComponent();
            progress = new SystemTrayProgressToken();
            mainDataModel = App.Main;
            VisualStateManager.GoToState(this, "Normal", false);
        }

        protected override void OnInitializingWebView()
        {
            InitializeWebView(this.Browser);
        }

        protected override async Task<IWebViewModel<string>> CreateWebViewModelAsync(NavigationEventArgs e)
        {
            PrivateMessageItem selected = null;
            if (NavigationContext.QueryString.ContainsKey("id"))
            {
                if (mainDataModel.Messages.Items.Count == 0)
                    await mainDataModel.Messages.OnSelectedAsync(this, this.progress);

                selected = mainDataModel.GetPrivateMessageByID(NavigationContext.QueryString["id"]);
                this.viewmodel = selected;
                this.group = this.viewmodel.Group as PrivateMessageGroup;
            }

            return selected;
        }

        public void NotifyAppBarCommands()
        {
            (this.Resources["prevCommand"] as EventCommand).RaiseCanExecuteChanged();
            (this.Resources["nextCommand"] as EventCommand).RaiseCanExecuteChanged();
        }

        protected override void OnSelectionChanged(Exception error)
        {
            base.OnSelectionChanged(error);
            if (error == null)
            {
                NotifyAppBarCommands();
                VisualStateManager.GoToState(this, "DetailsView", true);
                this.ApplicationBar.IsVisible = true;
            }
        }

        #region AppBar Event handlers

        private async void GoToPrevPage(object sender, ExecuteEventArgs args)
        {
            int index = this.group.Items.IndexOf(this.viewmodel) - 1;
            this.viewmodel = this.group.Items[index] as PrivateMessageItem;
            await this.InvokeAndNotifyOnError(this.viewmodel.OnSelectedAsync(this, this.progress));
            NotifyAppBarCommands();
        }

        private async void GoToNextPage(object sender, ExecuteEventArgs args)
        {
            int index = this.group.Items.IndexOf(this.viewmodel) + 1;
            this.viewmodel = this.group.Items[index] as PrivateMessageItem;
            await this.InvokeAndNotifyOnError(this.viewmodel.OnSelectedAsync(this, this.progress));
            NotifyAppBarCommands();
        }

        private void OnAppBarCanExecute(object sender, CanExecuteEventArgs args)
        {
            args.CanExecute = false;
            if (this.viewmodel != null)
                args.CanExecute = true;
        }

        private void CanGoToPrevPage(object sender, CanExecuteEventArgs args)
        {
            OnAppBarCanExecute(sender, args);
            args.CanExecute = args.CanExecute && this.viewmodel.CanGoToPrev();
        }

        private void CanGoToNextPage(object sender, CanExecuteEventArgs args)
        {
            OnAppBarCanExecute(sender, args);
            args.CanExecute = args.CanExecute && this.viewmodel.CanGoToNext();
        }

        #endregion
    }
}