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
        void SetPostForm(MessagePostModel model, bool navigateToReplyView);
        void SetPagination(IPaginationViewModelWithProgress<string> viewmodel);
        void NotifyAppBarCommands();
    }
}
