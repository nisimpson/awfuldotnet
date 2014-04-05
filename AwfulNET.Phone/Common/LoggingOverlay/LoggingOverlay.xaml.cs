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
using AwfulNET.Phone.Common;
using AwfulNET.Phone;
using AwfulNET.Core.Common;
using Microsoft.Phone.Tasks;
using System.Threading.Tasks;

namespace AwfulNET.Common
{
    public partial class LoggingOverlay : UserControl
    {
        LoggingOverlayViewModel context;
        public LoggingOverlay()
        {
            InitializeComponent();
            context = new LoggingOverlayViewModel();
            context.Context.Entries.CollectionChanged += Entries_CollectionChanged;
            this.DataContext = context;

            this.DoubleTap += LayoutRoot_DoubleTap;
            this.Tap += LoggingOverlay_Tap;
        }

        void LoggingOverlay_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            IList<LogEntry> list = context.Context.Entries as IList<LogEntry>;
            FrameworkElement selector = this.logEntryListView as FrameworkElement;
            try
            {
                UpdateLayout();
                (selector as LongListSelector).ScrollTo(list.Last());

            }
            catch (Exception) { }
        }

        void LayoutRoot_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            try
            {
                var email = new EmailComposeTask();
                email.To = "bootlegrobot@outlook.com";
                email.Subject = "Awful. (Hotfix): " + App.CurrentAccount.Username;
                email.Body = context.Context.WriteAsString();
                email.Show();
            }
            catch (Exception) { }
        }

        void Entries_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           
        }
    }

    public class LoggingOverlayViewModel : BindableBase
    {
        public WPLogger Context { get; private set; }

        public LoggingOverlayViewModel()
        {
            if (this.IsInDesignMode())
            {
                Context = new WPLogger();
                Context.AddEntry(Core.Common.LogLevel.INFO, "This is a designer log entry.");
                Context.AddEntry(Core.Common.LogLevel.INFO, "This is also a fake entry.");
            }

            else { Context = App.Log; }
        }
    }
}
