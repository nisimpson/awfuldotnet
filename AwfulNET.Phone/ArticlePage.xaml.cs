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
using System.Threading.Tasks;
using AwfulNET.DataModel;
using AwfulNET.Views;
using System.Runtime.Serialization;

namespace AwfulNET.Phone
{
    public partial class ArticlePage : WebViewAwarePage, IArticlePageView
    {
        private ProgressToken progress;
        private ArticleDataGroup group;
        private ArticleDataItem viewmodel;
        private MainDataModel mainDataModel;

        public ArticlePage()
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

        protected override async Task<Views.IWebViewModel<string>> CreateWebViewModelAsync(NavigationEventArgs e)
        {
            ArticleDataItem selected = null;
            if (NavigationContext.QueryString.ContainsKey("id"))
            {
                if (mainDataModel.Articles.Items.Count == 0)
                    await mainDataModel.Articles.OnSelectedAsync(this, this.progress);

                selected = mainDataModel.GetArticleDataByID(NavigationContext.QueryString["id"]); 
                this.viewmodel = selected;
                this.group = this.viewmodel.Group as ArticleDataGroup;
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
            this.viewmodel = this.group.Items[index] as ArticleDataItem;
            await this.InvokeAndNotifyOnError(this.viewmodel.OnSelectedAsync(this, this.progress));
            NotifyAppBarCommands();
        }

        private async void GoToNextPage(object sender, ExecuteEventArgs args)
        {
            int index = this.group.Items.IndexOf(this.viewmodel) + 1;
            this.viewmodel = this.group.Items[index] as ArticleDataItem;
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