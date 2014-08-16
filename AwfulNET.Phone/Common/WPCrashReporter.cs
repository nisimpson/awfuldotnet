using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AwfulNET.Phone.Common
{
    public class WPCrashReporter
    {
        private const string CRASH_MESSAGE = "The application suffered a fatal crash and will now close. Do you want to send crash information to the author?";

        public static void Report(Exception ex)
        {
            if (ex == null)
                return;

            var response = MessageBox.Show(CRASH_MESSAGE, "Ouch. :(", MessageBoxButton.OKCancel);
            if (response == MessageBoxResult.OK)
            {
                StringBuilder builder = new StringBuilder();
                BuildExceptionMessage(ex, builder);
                builder.AppendLine("[InnerException]:");
                BuildExceptionMessage(ex.InnerException, builder);
                SendEmail(builder);
            }
        }

        private static void SendEmail(StringBuilder builder)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.To = "bootlegrobot.outlook.com";
            email.Subject = string.Format("Error report - Awful.");
            email.Body = builder.ToString();
            try { email.Show(); }
            catch (Exception) { }
        }

        private static StringBuilder BuildExceptionMessage(Exception ex, StringBuilder builder)
        {
            if (ex == null)
                return builder;

            builder.AppendLine();
            builder.AppendLine(string.Format("[ExceptionType]: {0}", ex.GetType()));
            builder.AppendLine(string.Format("[ExceptionMessage]: {0}", ex.Message));
            builder.AppendLine(string.Format("[StackTrace]: {0}", ex.StackTrace));
            if(ex.Data != null && ex.Data.Count != 0)
            {
                builder.AppendLine("[Data]:");
                foreach(var key in ex.Data.Keys)
                {
                    builder.AppendLine(string.Format("{0} -> {1}", key, ex.Data[key]));
                }
            }
            return builder;
        }
    }
}
