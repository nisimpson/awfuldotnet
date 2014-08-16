using AwfulNET.Core.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Common
{
    public sealed class AccessTokenMessage
    {
        public IForumAccessToken Token { get; set; }
        public AccessTokenMessage()
        {
            this.Token = null;
        }
    }

    public sealed class NetworkDetectionMessage
    {
        public bool IsNetworkActive { get; set; }
        public NetworkDetectionMessage() { IsNetworkActive = true; }
    }

    public sealed class ToastMessage
    {
        public string Message { get; private set; }
        public string Caption { get; private set; }

        public ToastMessage(string message, string caption = null) { this.Message = message; this.Caption = caption; }
    }

    public sealed class BusyMessage
    {
        public string Message { get; private set; }
        public BusyMessage(string message) { this.Message = message; }
    }

    public class DialogMessage
    {
        public string Message { get; private set; }
        public string Caption { get; private set; }

        public DialogMessage(string message, string caption = null)
        {
            this.Message = message;
            this.Caption = caption;
        }
    }

    public sealed class ConfirmDialogMessage : DialogMessage
    {
        private TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
        public Task<bool> ConfirmAsync
        {
            get { return tcs.Task; }
        }

        public ConfirmDialogMessage(string message, string caption = null) : base(message, caption) { }

        public void Confirm(bool value) { tcs.SetResult(value); }
    }
}
