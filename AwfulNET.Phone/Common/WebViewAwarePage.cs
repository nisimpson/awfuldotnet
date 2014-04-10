using AwfulNET.Core.Common;
using AwfulNET.Phone;
using AwfulNET.Views;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;

namespace AwfulNET.Common
{
    public class WebViewAwarePage : PhoneApplicationPage, IWebViewPage
    {
        private const string SHOW_LOADING = "showLoading";
        private const string HIDE_LOADING = "hideLoading";
        private const string DOM_READY = "domready";
        private bool isDomReady = false;

        private bool cancelWebViewNavigation;
        private readonly ProgressToken progress;
        private readonly TaskCompletionSource<bool> domReady;
        private bool isNewInstance = false;
        private WebBrowser webview;
        protected IWebViewModel<string> ViewModel { get; set; }

        public WebViewAwarePage() : base()
        {
            this.isNewInstance = true;
            this.isDomReady = false;
            domReady = new TaskCompletionSource<bool>();
            progress = new SystemTrayProgressToken();
        }

        protected virtual void InitializeWebView(WebBrowser webview)
        {
            this.webview = webview;
            webview.Loaded += Browser_Loaded;
            webview.Navigating += Browser_Navigating;
            webview.NavigationFailed += Browser_NavigationFailed;
            webview.LoadCompleted += Browser_LoadCompleted;
            webview.ScriptNotify += Browser_ScriptNotify;
            webview.IsScriptEnabled = true;
            webview.Navigate(new Uri("/webview/webview.html", UriKind.RelativeOrAbsolute));
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (this.isNewInstance)
            {
                this.ViewModel = await CreateWebViewModelAsync(e);
                if (this.ViewModel != null)
                {
                    this.DataContext = this.ViewModel;
                    OnInitializingWebView();
                }

                this.isNewInstance = false;
            }
        }

        protected virtual void OnInitializingWebView()
        {
            throw new InvalidOperationException("Override me and initialize your webview using the InitializeWebView method.");
        }

        protected virtual async Task OnDomReady()
        {
            this.isDomReady = true;
            // enable phone mode (different animations, etc.)
            webview.InvokeScript("enablePhoneMode");
            // set the theme (dark or light)
            webview.InvokeScript("setTheme", IsLightTheme() ? "light" : string.Empty);
            Exception error = null;

            try
            {
                await this.OnViewModelSelectedAsync(this, this.progress, this.ViewModel);
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show("Could not load the requested page. Please try again later.", 
                    "Oops, something went wrong.", MessageBoxButton.OK);

                error = ex;
            }
            catch (Exception ex) {

                string msg = ex.Message;

#if DEBUG
                msg = string.Format("{0}\n\n{1}", ex.Message, ex.StackTrace);
#endif

                MessageBox.Show(msg, "Oops, something went wrong.", MessageBoxButton.OK);
                error = ex;
            }
            finally { 
                HideLoading();
                OnSelectionChanged(error);
            }
        }

        protected virtual Task OnViewModelSelectedAsync(IWebViewPage page, IProgress<string> progress, 
            IWebViewModel<string> viewmodel)
        {
            return viewmodel.OnSelectedAsync(page, progress);
        }

        protected virtual void OnSelectionChanged(Exception error) { }

        private bool IsLightTheme()
        {
            SolidColorBrush background = App.Current.Resources["PhoneBackgroundBrush"] as SolidColorBrush;
            if (background != null)
            {
                var color = background.Color;
                return color.R.Equals(255) && color.G.Equals(255) && color.B.Equals(255);
            }

            return false;
        }

        protected virtual Task<IWebViewModel<string>> CreateWebViewModelAsync(NavigationEventArgs e) 
        {
            throw new NotImplementedException("Derived classes must override this function.");
        }

        #region Script Notification

        private async void Browser_ScriptNotify(object sender, NotifyEventArgs e)
        {
            switch (e.Value)
            {
                case SHOW_LOADING:
                    ShowLoading();
                    break;

                case HIDE_LOADING:
                    HideLoading();
                    break;

                case DOM_READY:
                    var delay = Task.Delay(10).ContinueWith(task => 
                    { var run = OnDomReady(); }, 
                    TaskScheduler.FromCurrentSynchronizationContext());
                    break;

                default:
                    await InvokeAndNotifyOnError(this.ViewModel.OnScriptNotifyAsync(this, this.progress, e.Value));
                    break;
            }

#if DEBUG
            // show the passed in value
            MessageBox.Show(e.Value, "Script Notify", MessageBoxButton.OK);
#endif
        }

        protected virtual async Task InvokeAndNotifyOnError(Task task)
        {
            try { await task; }
            catch (Exception ex)
            {
                HideLoading();

                string msg = ex.Message;

#if DEBUG
                msg = string.Format("{0}\n\n{1}", ex.Message, ex.StackTrace);
#endif

                MessageBox.Show(msg, "Oops, something went wrong.", MessageBoxButton.OK);
                Logger.Default.AddEntry(LogLevel.WARNING, ex);
            }
        }

        private void HideLoading()
        {
            progress.Report(null);
        }

        private void ShowLoading()
        {
            progress.Report(string.Empty);
        }

        #endregion Script Notification

        private void Browser_Loaded(object sender, RoutedEventArgs e) { }

        private void Browser_Navigating(object sender, NavigatingEventArgs e)
        {
            if (this.cancelWebViewNavigation)
            {
                string uri = e.Uri.ToString();
                // show webbrowsertask if http[s] link
                // this is a hack until I solve the actual problem.
                // why are http links not captured in javascript? Particularly links hidden in spoilers...
                if (uri.Contains("http"))
                {
                    e.Cancel = true;
                    WebBrowserTask web = new WebBrowserTask();
                    web.Uri = e.Uri;
                    try { web.Show(); }
                    catch (Exception) { }
                }

                // cancel the navigation if we have an empty hash
                else if (uri.LastIndexOf("#") == uri.Length - 1) { }
            }
        }

        // Handle navigation failures.
        private void Browser_NavigationFailed(object sender, System.Windows.Navigation.NavigationFailedEventArgs e)
        {
            MessageBox.Show("Navigation to this page failed, check your internet connection");
        }

        // Handle DOM Readiness.
        private void Browser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            this.cancelWebViewNavigation = true;
        }

        #region IWebViewPage

        public object InvokeScript(string functionName, params string[] args)
        {
            return this.webview.InvokeScript(functionName, args);
        }

        public Task<object> InvokeScriptAsync(string functionName, params string[] args)
        {
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
            try { tcs.SetResult(this.webview.InvokeScript(functionName, args)); }
            catch (Exception ex) { tcs.SetException(ex); }
            return tcs.Task;
        }

        public void Navigate(Uri uri)
        {
            this.NavigationService.Navigate(uri);
        }

        public void SetContentAsActive(IContentViewModel content) { }

        #endregion IWebViewPage
    }
}
