using AwfulNET.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Views
{
    interface IPrivateMessageView : IWebViewPage
    {
        void NotifyAppBarCommands();
    }
}
