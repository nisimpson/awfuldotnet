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
using AwfulNET.Core.Rest;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Phone.Tasks;
using AwfulNET.DataModel;

namespace AwfulNET.Phone.Views.PM
{
    public partial class NewMessageView : PhoneApplicationPage
    {
        private readonly NewMessageViewModel context;
        private readonly MainDataModel main;
        private bool isNewInstance = false;
        private IProgress<string> progress;
        public NewMessageView()
        {
            InitializeComponent();
            main = App.Main;
            progress = IProgressFactory.GenerateProgressToken();
            context = new NewMessageViewModel();
            context.CancelCommand = new RelayCommand(() => CancelMessage());
            context.SendCommand = new RelayCommand(() => SubmitMessage(progress));
            this.DataContext = context;
            this.isNewInstance = true;
        }

        private void SubmitMessage(IProgress<string> progress)
        {
            context.SubmitAsync(progress).ContinueWith(task =>
                {
                    bool result = task.Result;
                    if (result) { NavigationService.GoBack(); }

                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void CancelMessage()
        {
            this.NavigationService.GoBack();
        }

        private async Task InitializeViewModel()
        {
             // grab query values
            var query = NavigationContext.QueryString;
            string id = query.ContainsKey("id") ? query["id"] : string.Empty;
            bool fwd = query.ContainsKey("fwd") ? true : false;

            // grab token
            AccessTokenMessage token = new AccessTokenMessage();
            NotificationService.Default.Notify(this, token);

            IPrivateMessageRequest request = null;
            progress.Report("Please wait...");
            context.IsEnabled = false;

            if (!string.IsNullOrEmpty(id))
            {
                PrivateMessageItem selected = main.GetPrivateMessageByID(id);
                request = fwd
                    ? await selected.Metadata.GetForwardRequestAsync(token.Token)
                    : await selected.Metadata.GetReplyRequestAsync(token.Token);
            }

            else { request = await token.Token.CreateNewPrivateMessageAsync(); }

            context.UpdateView(request);
            context.IsEnabled = true;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (this.isNewInstance)
            {
                try { await InitializeViewModel(); }
                finally
                {
                    progress.Report(null);
                    this.isNewInstance = false;
                }
            }
        }
    }

    public sealed class NewMessageViewModel : BindableBase
    {
        private string to = string.Empty;
        public string To
        {
            get { return this.to; }
            set { SetProperty(ref this.to, value); }
        }

        private string subject = string.Empty;
        public string Subject
        {
            get { return this.subject; }
            set { SetProperty(ref this.subject, value); }
        }

        private string message = string.Empty;
        public string Message
        {
            get { return this.message; }
            set { SetProperty(ref this.message, value); }
        }

        private bool isEnabled = true;
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetProperty(ref this.isEnabled, value); }
        }

        private IPrivateMessageRequest request;
        public NewMessageViewModel()
        {
            UploadCommand = new RelayCommand(() => UploadImageAsync());
            ClearCommand = new RelayCommand(() => ClearMessageText());
        }

        public void UpdateView(IPrivateMessageRequest request)
        {
            this.request = request;
            this.To = string.IsNullOrEmpty(request.To) ? string.Empty : request.To;
            this.Subject = string.IsNullOrEmpty(request.Subject) ? string.Empty : request.Subject;
            this.Message = string.IsNullOrEmpty(request.Body) ? string.Empty : request.Body;
        }

        private void ClearMessageText()
        {
            this.Message = string.Empty;
        }

        public async Task<bool> SubmitAsync(IProgress<string> progress)
        {
            bool result = false;
            var confirm = MessageBox.Show("Send message?", "Confirm", MessageBoxButton.OKCancel);
            if (confirm == MessageBoxResult.OK)
            {
                try
                {
                    this.IsEnabled = false;
                    this.request.To = this.To;
                    this.request.Subject = this.Subject;
                    this.request.Body = this.Message;

                    progress.Report("Sending message...");
                    AccessTokenMessage tokenRequest = new AccessTokenMessage();
                    NotificationService.Default.Notify(this, tokenRequest);
                    result = await request.SubmitAsync(tokenRequest.Token);

                    if (!result)
                        throw new Exception("We could not send your message at this time. Please try again later.");

                    DialogMessage success = new DialogMessage("Message sent!", "Hooray!");
                    NotificationService.Default.Notify(this, success);
                }

                catch (Exception ex)
                {
                    DialogMessage error = new DialogMessage(ex.Message, "Oops! Something went wrong.");
                    NotificationService.Default.Notify(this, error);
                    result = false;
                }

                finally
                {
                    this.IsEnabled = true;
                    progress.Report(null);
                }
            }
            return result;
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

        public ICommand SendCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand UploadCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }
    }
}