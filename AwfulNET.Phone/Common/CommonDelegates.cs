using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Common
{
    public delegate void SuccessDelegate();
    public delegate void FailureDelegate(Exception ex);
    public delegate void BusyDelegate(bool isBusy);
    public delegate bool CanExecuteDelegate(object state);
}
