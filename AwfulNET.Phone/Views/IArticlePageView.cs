using AwfulNET.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Views
{
    public interface IArticlePageView : IWebViewPage
    {
        void NotifyAppBarCommands();
    }
}
