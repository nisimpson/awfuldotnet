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

namespace AwfulNET.Common
{
    public partial class LoggingOverlay : UserControl
    {
        public LoggingOverlay()
        {
            InitializeComponent();
            LoggingOverlayViewModel context = new LoggingOverlayViewModel();
            this.DataContext = context;
        }
    }

    public class LoggingOverlayViewModel : BindableBase
    {
        public WPLogger Context { get; private set; }

        public LoggingOverlayViewModel()
        {
            Context = App.Log;
        }
    }
}
