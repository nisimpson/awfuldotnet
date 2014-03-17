using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace AwfulNET.RT.Common
{
    public static class ToastGenerator
    {
        public static void ShowToast(string message)
        {
            var notifier = ToastNotificationManager.CreateToastNotifier();
            var template = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);

            var element = template.GetElementsByTagName("text")[0];
            element.AppendChild(template.CreateTextNode(message));

            var toast = new ToastNotification(template);
            notifier.Show(toast);
        }

        public static void ShowScheduledToast(string message, DateTimeOffset on)
        {
            var notifier = ToastNotificationManager.CreateToastNotifier();
            var template = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);

            var element = template.GetElementsByTagName("text")[0];
            element.AppendChild(template.CreateTextNode("message"));

            var scheduledToast = new ScheduledToastNotification(template, on);
            notifier.AddToSchedule(scheduledToast);
        }
    }
}

