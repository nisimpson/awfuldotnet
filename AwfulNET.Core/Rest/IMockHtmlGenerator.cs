using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Rest
{
    public interface IMockHtmlGenerator
    {
        string GenerateMockNewThreadRequestHtml();
        string GenerateMockEditFolderHtml();
        string GenerateMockFolderListHtml();
        string GenerateMockUserSettingsHtml();
        string GenerateMockSmiliesHtml();
        string GenerateMockForumIndexHtml();
        string GenerateMockThreadReplyForm();
        string GenerateMockBookmarksHtml();
        string GenerateMockForumPageHtml();
        string GenerateMockThreadPageHtml();
        string GenerateMockPrivateMessageHtml();
        string GenerateMockPrivateMessageFolderHtml();
        string GenerateMockEditFormHtml();
    }

    /// <summary>
    /// A mock html source for unit testing. A single source will
    /// be used for all request types.
    /// </summary>
    public sealed class MockHtmlGenerator : DefaultMockHtmlGenerator
    {
        private readonly string source = string.Empty;
        public MockHtmlGenerator(string source) : base() { this.source = source; }

        #region Mock Html - Large!

        public override string GenerateMockEditFormHtml()
        {
            return source;
        }

        public override string GenerateMockNewThreadRequestHtml()
        {
            return source;
        }
        public override string GenerateMockEditFolderHtml()
        {
            return source;
        }
        public override string GenerateMockFolderListHtml()
        {
            return source;
        }
        public override string GenerateMockUserSettingsHtml()
        {
            return source;
        }
        public override string GenerateMockSmiliesHtml()
        {
            return source;
        }
        public override string GenerateMockForumIndexHtml()
        {
            return source;
        }
        public override string GenerateMockThreadReplyForm()
        {
            return source;
        }
        public override string GenerateMockBookmarksHtml()
        {
            return source;
        }
        public override string GenerateMockForumPageHtml()
        {
            return source;
        }
        public override string GenerateMockThreadPageHtml()
        {
            return source;
        }
        public override string GenerateMockPrivateMessageHtml()
        {
            return source;
        }
        public override string GenerateMockPrivateMessageFolderHtml()
        {
            return source;
        }

        #endregion
    }

    /// <summary>
    /// The default mock html source. Provides sample html for all user request scenarios.
    /// </summary>
    public class DefaultMockHtmlGenerator : IMockHtmlGenerator
    {
        #region Mock Html - Large!

        public virtual string GenerateMockEditFormHtml()
        {
            throw new NotImplementedException("Create new edit form html.");
        }

        public virtual string GenerateMockNewThreadRequestHtml()
        {
            throw new NotImplementedException("Create new thread request html.");
        }
        public virtual string GenerateMockEditFolderHtml()
        {
            throw new NotImplementedException("Create sample edit folder page html.");
        }
        public virtual string GenerateMockFolderListHtml()
        {
            throw new NotImplementedException("Create sample folder list html.");
        }
        public virtual string GenerateMockUserSettingsHtml()
        {
            throw new NotImplementedException("paste user settings html here.");
        }
        public virtual string GenerateMockSmiliesHtml()
        {
            throw new NotImplementedException("Add smilies html here.");
        }
        public virtual string GenerateMockForumIndexHtml()
        {
            throw new NotImplementedException("Add page from https://forums.somethingawful.com/forumdisplay.php?forumid=1 here.");
        }
        public virtual string GenerateMockThreadReplyForm()
        {
            throw new NotImplementedException("Add sample thread form html here.");
        }
        public virtual string GenerateMockBookmarksHtml()
        {
            throw new NotImplementedException("Create sample bookmark list html here.");
        }
        public virtual string GenerateMockForumPageHtml()
        {
            throw new NotImplementedException("Create sample forum page.");
        }
        public virtual string GenerateMockThreadPageHtml()
        {
            throw new NotImplementedException("Create sample thread page html.");
        }
        public virtual string GenerateMockPrivateMessageHtml()
        {
            throw new NotImplementedException("Create sample public virtual message html");
        }
        public virtual string GenerateMockPrivateMessageFolderHtml()
        {
            throw new NotImplementedException("Create pm folder html.");
        }

        #endregion
    }
}
