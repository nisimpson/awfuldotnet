using AwfulNET.Core.Parsing;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Rest
{
    public sealed class MockForumAccessToken : IForumAccessToken
    {
        private readonly IMockHtmlGenerator sample;

        public MockForumAccessToken(IMockHtmlGenerator sample) { this.sample = sample; }
        public MockForumAccessToken() : this(new DefaultMockHtmlGenerator()) { }

        /// <summary>
        /// Gets or sets the delay before a request is initiated. 
        /// If null, requests are instantaneous.
        /// </summary>
        public int? DelayInMilliseconds { get; set; }

        public string Username
        {
            get { return "MockToken"; }
        }

        public bool IsActiveAccount
        {
            get { return true; }
        }

        private async Task<T> ToTask<T>(T value)
        {
            if (DelayInMilliseconds.HasValue)
                await Task.Delay(DelayInMilliseconds.Value);

            return value;
        }

        private HtmlDocument CreateHtmlDocument(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            return doc;
        }

        public Task<UserFeatures> GetUserFeaturesAsync()
        {
            UserFeatures features = new UserFeatures("MockToken", true, true, true);
            return ToTask(features);
        }

        public Task<UserSettings> GetUserSettingsAsync()
        {
            UserSettings settings = UserSettings.FromHtmlDocument(CreateHtmlDocument(sample.GenerateMockUserSettingsHtml()));
            return ToTask(settings);
        }

        public Task<IEnumerable<TagMetadata>> GetSmiliesAsync()
        {
            var smilies = SmileyParser.ParseSmiliesFromHtml(CreateHtmlDocument(sample.GenerateMockSmiliesHtml()));
            return ToTask(smilies as IEnumerable<TagMetadata>);
        }

        public Task<bool> SaveUserSettingsAsync(UserSettings settings)
        {
            return ToTask(true);
        }

        public Task<IEnumerable<ForumMetadata>> GetForumListAsync()
        {
            var forums = ForumParser.ParseForumList(CreateHtmlDocument(sample.GenerateMockForumIndexHtml()));
            return ToTask(forums as IEnumerable<ForumMetadata>);
        }

        public Task<IThreadForm> GetThreadReplyFormAsync(string threadid)
        {
            ThreadReplyForm form = ThreadReplyForm.FromHtmlDocument(CreateHtmlDocument(sample.GenerateMockThreadReplyForm()));
            return ToTask<IThreadForm>(form);
        }

        public Task<ForumPageMetadata> GetBookmarkPageAsync(int pagenumber = 1)
        {
            ForumPageMetadata page = ForumParser.ParseForumPage(CreateHtmlDocument(sample.GenerateMockBookmarksHtml()));
            return ToTask(page);
        }

        public Task<ForumPageMetadata> GetForumPageAsync(string forumid, int pagenumber = 1, FilterTagMetadata filter = null)
        {
            ForumPageMetadata page = ForumParser.ParseForumPage(CreateHtmlDocument(sample.GenerateMockForumPageHtml()));
            return ToTask(page);
        }

        public Task<bool> ClearAllMarkedPostsAsync(string threadid)
        {
            return ToTask(true);
        }

        public Task<ThreadPageMetadata> GetThreadPageAsync(string threadid, int pagenumber = 1)
        {
            ThreadPageMetadata page = ThreadPageParser.ParseThreadPage(CreateHtmlDocument(sample.GenerateMockThreadPageHtml()));
            return ToTask(page);
        }

        public Task<ThreadPageMetadata> GetThreadPageAsync(Uri pageUri)
        {
            return GetThreadPageAsync(string.Empty);
        }

        public Task<ThreadPageMetadata> GetLastPostAsync(string threadid)
        {
            return GetThreadPageAsync(string.Empty);
        }

        public Task<ThreadPageMetadata> GetNewPostAsync(string threadid)
        {
            return GetThreadPageAsync(string.Empty);
        }

        public Task<string> QuoteAsync(string postid)
        {
            return ToTask("This is a sample quote generated from a mock token.");
        }

        public Task<IThreadForm> BeginEditPostAsync(string postid)
        {
            PostEditForm form = PostEditForm.FromHtmlDocument(postid,
                CreateHtmlDocument(sample.GenerateMockEditFormHtml()));

            return ToTask<IThreadForm>(form);
        }

        private string GenerateMockEditFormHtml()
        {
            throw new NotImplementedException("Create sample edit form html");
        }

        public Task<ThreadFormResponse> SubmitAsync(IThreadForm form)
        {
            ThreadReplyResponse response = new ThreadReplyResponse(form, true);
            return ToTask<ThreadFormResponse>(response);
        }

        public Task<bool> RateAsync(string threadid, int rating)
        {
            return ToTask(true);
        }

        public Task<bool> MarkAsReadAsync(string threadid, string threadindex)
        {
            return ToTask(true);
        }

        public Task<ThreadPageMetadata> RefreshAsync(string threadid, int pagenumber)
        {
            return GetThreadPageAsync(string.Empty);
        }

        public Task<bool> AddToBookmarkAsync(string threadid)
        {
            return ToTask(true);
        }

        public Task<bool> RemoveFromBookmarkAsync(string threadid)
        {
            return ToTask(true);
        }

        public Task<PrivateMessageMetadata> RefreshAsync(string privatemessageid)
        {
            PrivateMessageMetadata data = PrivateMessageParser.ParsePrivateMessageDocument(
                CreateHtmlDocument(sample.GenerateMockPrivateMessageHtml()));

            // randomize id
            data.PrivateMessageId = Guid.NewGuid().ToString("N");

            return ToTask(data);
        }
        
        public Task<IPrivateMessageRequest> CreateNewPrivateMessageAsync()
        {
            PrivateMessageRequest value = new PrivateMessageRequest();
            value.Body = "This is a sample private message request, generated from a mock token.";
            value.PrivateMessageId = "0";
            value.IsForward = false;
            value.Subject = "Mock Private Message";
            return ToTask<IPrivateMessageRequest>(value);
        }

        public Task<IPrivateMessageRequest> GetReplyRequestAsync(string privatemessageid)
        {
            return CreateNewPrivateMessageAsync();
        }

        public async Task<IPrivateMessageRequest> GetForwardRequestAsync(string privatemessageid)
        {
            var message = await CreateNewPrivateMessageAsync();
            (message as PrivateMessageRequest).IsForward = true;
            return message;
        }

        public Task<bool> SendMessageAsync(IPrivateMessageRequest request)
        {
            return ToTask(true);
        }

        public Task<IEnumerable<PrivateMessageFolderMetadata>> GetPrivateMessageFoldersAsync(bool loadInbox = true)
        {
            var folders = PrivateMessageParser.ParseFolderList(CreateHtmlDocument(sample.GenerateMockFolderListHtml()));
            return ToTask<IEnumerable<PrivateMessageFolderMetadata>>(folders);
        }

        public Task<PrivateMessageFolderMetadata> RefreshPrivateMessageFolderAsync(string folderid)
        {
            PrivateMessageFolderMetadata folder = PrivateMessageParser.ParsePrivateMessageFolder(
                CreateHtmlDocument(sample.GenerateMockPrivateMessageFolderHtml()));
            return ToTask(folder);
        }

        public Task<bool> DeletePrivateMessageAsync(string privateMessageId, string folderId)
        {
            return ToTask(true);
        }

        public Task<bool> MoveAllPrivateMessagesAsync(IEnumerable<KeyValuePair<string, string>> pairs, string destinationFolderId)
        {
            return ToTask(true);
        }

        public Task<bool> MovePrivateMessageAsync(string privatemessageid, string srcfolderid, string dstfolderid)
        {
            return ToTask(true);
        }

        public Task<PrivateMessageFolderEditor> EditPrivateMessageFoldersAsync()
        {
            PrivateMessageFolderEditor editor = PrivateMessageParser.ParseEditFolderPage(
                CreateHtmlDocument(sample.GenerateMockEditFolderHtml()));

            return ToTask(editor);
        }

        public Task<bool> SaveChangesAsync(PrivateMessageFolderEditor editor)
        {
            return ToTask(true);
        }

        public Task<INewThreadRequest> BeginNewThreadAsync(string forumId)
        {
            var request = NewThreadRequest.ParseNewThreadRequest(CreateHtmlDocument(sample.GenerateMockNewThreadRequestHtml()));
            return ToTask<INewThreadRequest>(request);
        }

        public Task<bool> SubmitAsync(INewThreadRequest request)
        {
            return ToTask(true);
        }

        public Task<string> PreviewAsync(INewThreadRequest request)
        {
            return ToTask("This preview was generated by a mock forum access token.");
        }
    }
}
