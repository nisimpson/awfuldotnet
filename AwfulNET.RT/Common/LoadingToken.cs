using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.RT.Common
{
    public sealed class LoadingToken : IProgress<string>
    {
        public static event ProgressReportHandler ReportProgress;

        public void Report(string value)
        {
            var handler = ReportProgress;
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
}
