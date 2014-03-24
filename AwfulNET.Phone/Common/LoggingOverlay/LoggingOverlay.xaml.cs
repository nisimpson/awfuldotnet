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

namespace AwfulNET.Common
{
    public partial class LoggingOverlay : UserControl
    {
        public LoggingOverlay()
        {
            InitializeComponent();
            LoggingOverlayViewModel context = new LoggingOverlayViewModel();
            context.Context.Entries.CollectionChanged += Entries_CollectionChanged;
            this.DataContext = context;
        }

        void Entries_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            IList<LogEntry> list = sender as IList<LogEntry>;
            try { this.logEntryListView.ScrollTo(list.Last()); }
            catch (Exception) { }
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
