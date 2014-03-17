using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Common
{
    [Obsolete("This class is obsolete. Use Awful.Common.NotificationService to send notification messages and let platforms handle implementation.", true)]
    public class CommonMessageBox
    {
        public static void Show(string message, string caption)
        {
#if WINDOWS_PHONE
            
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            System.Windows.MessageBox.Show(message, caption, System.Windows.MessageBoxButton.OK);
            
#else

            var dialog = new Windows.UI.Popups.MessageDialog(message, caption);
            var task = dialog.ShowAsync().AsTask();
            var command = task.Result;
#endif
        }

        public static Task ShowAsync(string message, string caption)
        {
            #if WINDOWS_PHONE
            
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            System.Windows.MessageBox.Show(message, caption, System.Windows.MessageBoxButton.OK);
            tcs.SetResult(true);
            return tcs.Task;
            
            #else
            
            var dialog = new Windows.UI.Popups.MessageDialog(message, caption);
            return dialog.ShowAsync().AsTask();
            
            #endif
        }

        public static async Task<bool> ConfirmAsync(string message, string caption)
        {
#if WINDOWS_PHONE
            var task = new TaskCompletionSource<bool>();
            var result = System.Windows.MessageBox.Show(message, caption, System.Windows.MessageBoxButton.OKCancel);
            task.SetResult(result == System.Windows.MessageBoxResult.OK);
            return await task.Task;
#else
            bool result = false;
            var dialog = new Windows.UI.Popups.MessageDialog(message, caption);
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("OK", (cmd) => {result = true; }));
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Cancel", (cmd) => { result = false; }));
            await dialog.ShowAsync();
            return result;
#endif
        }
    }
}
