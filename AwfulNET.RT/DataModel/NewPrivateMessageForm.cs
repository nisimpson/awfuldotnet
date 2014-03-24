using AwfulNET.Common;
using AwfulNET.Core.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AwfulNET.RT.DataModel
{
    public class NewPrivateMessageForm : BindableBase
    {
        public NewPrivateMessageForm() { }

        public void UpdateView(IPrivateMessageRequest request)
        {
            this.request = request;
            this.To = string.IsNullOrEmpty(request.To) ? string.Empty : request.To;
            this.Subject = string.IsNullOrEmpty(request.Subject) ? string.Empty : request.Subject;
            this.Message = string.IsNullOrEmpty(request.Body) ? string.Empty : request.Body;
        }

        private IPrivateMessageRequest request;

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

        public ICommand SubmitCommand { get; set; }

        public async Task<bool> SubmitAsync(IProgress<string> progress)
        {
            this.IsEnabled = false;
            bool success = false;
            try
            {
                request.To = this.to;
                request.Subject = this.subject;
                request.Body = this.message;

                AccessTokenMessage token = new AccessTokenMessage();
                NotificationService.Default.Notify(this, token);
                success = await request.SubmitAsync(token.Token);
            }

            catch (Exception) { success = false; }
            finally { this.IsEnabled = true; progress.Report(null); }
            return success;
        }
    }
}
