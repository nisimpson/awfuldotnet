using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Common
{
    public class ProgressToken : IProgress<string>
    {
        public event ProgressReportHandler ProgressReport;

        public void Report(string value)
        {
            var handler = ProgressReport;
            if (handler != null)
                handler(this, new ProgressReportArgs(value));
        }
    }

    public delegate void ProgressReportHandler(object sender, ProgressReportArgs args);

    public sealed class ProgressReportArgs : EventArgs
    {
        public string Message { get; private set; }
        public ProgressReportArgs(string message) { this.Message = message; }
    }

    public sealed class SystemTrayProgressToken : ProgressToken
    {
        public SystemTrayProgressToken()
        {
            this.ProgressReport += SystemTrayProgressToken_ProgressReport;
        }

        void SystemTrayProgressToken_ProgressReport(object sender, ProgressReportArgs args)
        {
            var indicator = Microsoft.Phone.Shell.SystemTray.ProgressIndicator;
            if (indicator == null)
            {
                indicator = new Microsoft.Phone.Shell.ProgressIndicator();
                Microsoft.Phone.Shell.SystemTray.ProgressIndicator = indicator;
            }

            if (args.Message == null)
            {
                indicator.IsVisible = false;
                indicator.IsIndeterminate = false;
                indicator.Text = null;
            }
            else
            {
                indicator.IsIndeterminate = true;
                indicator.IsVisible = true;
                indicator.Text = args.Message;
            }
        }
    }
}
