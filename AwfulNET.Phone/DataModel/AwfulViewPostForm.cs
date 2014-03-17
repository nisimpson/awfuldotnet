using AwfulNET.Common;
using AwfulNET.Core.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AwfulNET.DataModel
{
    /// <summary>
    /// Bindable wrapper for IThreadForm objects.
    /// </summary>
    
    public class MessagePostModel : CommonDataModel
    {
        IThreadForm form;
        ThreadMetadata thread;
        Func<ForumAccessToken, Task<ThreadFormResponse>> submit;
        ICommand submitCommand;
        ICommand goBackCommand;
        SuccessDelegate onSuccess = MessagePostModel.DoNothing;
        FailureDelegate onFailure = MessagePostModel.DoNothing;
        BusyDelegate whileBusy = MessagePostModel.DoNothing;

        public ICommand SubmitCommand
        {
            get { return this.submitCommand; }
            set { this.SetProperty(ref this.submitCommand, value); }
        }
        public ICommand GoBackCommand
        {
            get { return this.goBackCommand; }
            set { this.SetProperty(ref this.goBackCommand, value); }
        }
        
        public SuccessDelegate OnSuccess
        {
            get { return this.onSuccess; }
            set { this.onSuccess = value; }
        }

        public FailureDelegate OnFailure
        {
            get { return this.onFailure; }
            set { this.onFailure = value; }
        }

        public BusyDelegate WhileBusy
        {
            get { return whileBusy; }
            set { whileBusy = value; }
        }

        private bool isEdit = false;
        public bool IsEdit { get { return isEdit; } }
        
        public MessagePostModel(IThreadForm form, ThreadMetadata thread) : base()
        {
            this.thread = thread;
            this.form = form;
            this.isEdit = true;
            this.message = form.Message;
            this.submit = SubmitFormAsync;
            this.Title = "Edit Post";
            this.Subtitle = thread.Title;
        }

        public MessagePostModel(ThreadMetadata thread) : base()
        {
            this.thread = thread;
            this.submit = SubmitPostAsync;
            this.Title = "New Reply";
            this.Subtitle = thread.Title;
        }

        public MessagePostModel Reset()
        {
            this.form = null;
            this.Title = "New Reply";
            this.Message = string.Empty;
            this.submit = SubmitPostAsync;
            return this;
        }
        
        private string message = string.Empty;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        public async Task<ThreadFormResponse> SubmitAsync(ForumAccessToken token)
        {
            ThreadFormResponse response = null;
            this.WhileBusy(true);

            try
            {
                response = await submit(token);
                if (response.Success)
                {
                    this.OnSuccess();
                }
                else
                    this.OnFailure(new InvalidOperationException("post submit failed."));
            }
            catch (Exception ex) { this.OnFailure(ex); }
            finally { this.WhileBusy(false); }
            return response;
        }

        private Task<ThreadFormResponse> SubmitFormAsync(ForumAccessToken token)
        {
            if (form != null)
            {
                form.Message = this.message;
                return form.SubmitAsync(token);
            }
            else
            {
                return SubmitPostAsync(token);
            }
        }

        private Task<ThreadFormResponse> SubmitPostAsync(ForumAccessToken token)
        {
            return thread.ReplyAsync(this.message, token);
        }

        private static void DoNothing() { }
        private static void DoNothing(Exception ex) { }
        private static void DoNothing(bool isBusy) { }
        private static bool DoNothing(object state) { return true; }
    }
}
