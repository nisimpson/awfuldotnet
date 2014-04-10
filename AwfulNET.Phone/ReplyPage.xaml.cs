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
using System.Windows.Input;
using Microsoft.Phone.Tasks;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using AwfulNET.Core.Common;

namespace AwfulNET.Phone
{
    public partial class ReplyPage : PhoneApplicationPage
    {
        private ProgressIndicator progress;
        private ProgressIndicator Progress
        {
            get
            {
                if (progress == null)
                {
                    progress = new ProgressIndicator();
                    SystemTray.ProgressIndicator = progress;
                }

                return progress;
            }
        }

        private bool isNewInstance = false;
        private bool isReplySuccessful = false;

        public ReplyPage()
        {
            InitializeComponent();
            ReplyPageViewModel.Instance.SubmitFormCommand = new RelayCommand(SubmitAsync);
            this.DataContext = ReplyPageViewModel.Instance;
            this.isNewInstance = true;
        }

        private void SubmitAsync()
        {
            // hack: ensure the textbox control is synchronized. sometimes the text value is
            // not assigned properly until then.
            if (this.textBoxControl.SyncText())
                ReplyPageViewModel.Instance.PostForm.SubmitCommand.Execute(null);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (this.isNewInstance)
            {
                ReplyPageViewModel.Instance.PostForm.GoBackCommand = new RelayCommand(() => 
                {
                    this.isReplySuccessful = false;
                    this.NavigationService.GoBack(); 
                });
                ReplyPageViewModel.Instance.PostForm.OnSuccess = this.NotifySuccessAndGoBack;
                ReplyPageViewModel.Instance.PostForm.OnFailure = this.NotifyFailureAndTryAgain;
                ReplyPageViewModel.Instance.PostForm.WhileBusy = this.NotifyProgress;
                this.isNewInstance = false;
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.IsNavigationInitiator)
            {
                if (!this.isReplySuccessful)
                    ReplyPageViewModel.Instance.Cancel();
            }
        }

        private void NotifyProgress(bool isBusy)
        {
            if(isBusy)
            {
                this.ContentPanel.IsHitTestVisible = false;
                Progress.IsIndeterminate = true;
                Progress.Text = "Please wait...";
                Progress.IsVisible = true;
            }
            else
            {
                this.ContentPanel.IsHitTestVisible = true;
                Progress.IsVisible = false;
                Progress.IsIndeterminate = false;
                Progress.Text = string.Empty;
            }
        }

        private void NotifyFailureAndTryAgain(Exception ex)
        {
            string msg = ex.Message;

#if DEBUG
            msg = string.Format("{0}\n\n{1}", ex.Message, ex.StackTrace);
#endif

            Logger.Default.AddEntry(LogLevel.WARNING, ex);
            MessageBox.Show(ex.Message, "Oops, something went wrong.", MessageBoxButton.OK);
        }

        private void NotifySuccessAndGoBack()
        {
            MessageBox.Show("You made a post. High five!", "Success!", MessageBoxButton.OK);
            ReplyPageViewModel.Instance.PostForm = ReplyPageViewModel.Instance.PostForm.Reset();
            this.isReplySuccessful = true;
            this.NavigationService.GoBack();
        }
    }

    public sealed class ReplyPageViewModel : BindableBase
    {
        public static ReplyPageViewModel Instance { get; private set; }
        static ReplyPageViewModel() { Instance = new ReplyPageViewModel(); }

        private ReplyPageViewModel()
        {
            uploadCommand = new RelayCommand(UploadImageAsync);
            clearTextCommand = new RelayCommand(ClearText);
        }

        private void ClearText()
        {
            this.PostForm.Message = string.Empty;
        }

        private void UploadImageAsync()
        {
            ChoosePhotoAsync().ContinueWith(
                async task => { if (task.IsCompleted) { await OnPhotoResult(task.Result); } }, 
                TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async Task OnPhotoResult(PhotoResult result)
        {
          if (result.TaskResult == TaskResult.OK)
          {
              var request = ImgurUploader.ImgurUploadRequest.CreateUploadRequest(result, ImgurUploader.ImgurLinkType.Normal);
              var progress = new SystemTrayProgressToken();
              progress.Report("Please wait...");
              var response = await request.UploadAsync();
              progress.Report(null);
              if (response.HasError)
              {
                  NotificationService.Default.Notify<DialogMessage>(this,
                      new DialogMessage("The image upload failed. Please try again later.", "Oops, something went wrong."));
                  
                  //await CommonMessageBox.ShowAsync("The image upload failed. Please try again later.", "Oops, something went wrong.");
              }
              else
              {
                  response.CreateResult().ToClipboard();
                  NotificationService.Default.Notify<ToastMessage>(this,
                      new ToastMessage("Image link posted to clipboard.", "Success"));
                  
                  //await CommonMessageBox.ShowAsync("Image link posted to clipboard.", "Success!");
              }
          }
        }

        private Task<PhotoResult> ChoosePhotoAsync()
        {
            PhotoChooserTask pct = new PhotoChooserTask();
            pct.ShowCamera = true;
            TaskCompletionSource<PhotoResult> tcs = new TaskCompletionSource<PhotoResult>();
            EventHandler<PhotoResult> completed = null;
            completed = new EventHandler<PhotoResult>((o, result) =>
            {
                pct.Completed -= completed;
                tcs.SetResult(result);
            });
            pct.Completed += completed;
            pct.Show();
            return tcs.Task;
        }

        private MessagePostModel postForm;
        public MessagePostModel PostForm
        {
            get { return this.postForm; }
            set { this.SetProperty(ref this.postForm, value); }
        }

        private RelayCommand uploadCommand;
        public ICommand UploadCommand
        {
            get { return uploadCommand; }
        }

        private RelayCommand clearTextCommand;
        public ICommand ClearTextCommand { get { return clearTextCommand; } }

        private ICommand submitFormCommand;
        public ICommand SubmitFormCommand
        {
            get { return this.submitFormCommand; }
            set { this.SetProperty(ref this.submitFormCommand, value); }
        }

        private string title = string.Empty;
        public string Title
        {
            get { return this.title; }
            set { this.SetProperty(ref this.title, value); }
        }

        internal void Cancel()
        {
            PostForm = PostForm.Reset();
        }
    }
}