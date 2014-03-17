using AwfulNET.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Views
{
    public interface IThreadViewPage : IWebViewPage
    {
        void SetPostForm(MessagePostModel model, bool navigateToReplyView);
        void SetPagination(IPaginationViewModelWithProgress<string> viewmodel);
        void NotifyAppBarCommands();
        void OnNewThreadCreated(ThreadPageMetadata threadPage);
    }
}
