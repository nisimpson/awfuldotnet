using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Rest
{
    interface IForumAccessToken
    {
        /// <summary>
        /// Gets the name of the account associated with this token.
        /// </summary>
        string Username { get; }

        /// <summary>
        /// Gets the account status of this token. If false, this token has public access only.
        /// </summary>
        bool IsActiveAccount { get; }

        #region Miscellaneous

        Task<UserFeatures> GetUserFeaturesAsync();
        Task<UserSettings> GetUserSettingsAsync();
        Task<IEnumerable<TagMetadata>> GetSmiliesAsync();
        Task<bool> SaveUserSettingsAsync(UserSettings settings);

        #endregion

        #region Forum Index, Individual Forum Handling

        Task<IEnumerable<ForumMetadata>> GetForumListAsync();
        Task<IThreadForm> GetThreadReplyFormAsync(string threadid);
        Task<ForumPageMetadata> GetBookmarkPageAsync(int pagenumber = 1);
        Task<ForumPageMetadata> GetForumPageAsync(string forumid, int pagenumber = 1, FilterTagMetadata filter = null);
        Task<bool> ClearAllMarkedPostsAsync(string threadid);

        #endregion

        #region Thread Handling

        Task<ThreadPageMetadata> GetThreadPageAsync(string threadid, int pagenumber = 1);
        Task<ThreadPageMetadata> GetThreadPageAsync(Uri pageUri);
        Task<ThreadPageMetadata> GetLastPostAsync(string threadid);
        Task<ThreadPageMetadata> GetNewPostAsync(string threadid);
        Task<string> QuoteAsync(string postid);
        Task<IThreadForm> BeginEditPostAsync(string postid);
        Task<ThreadFormResponse> SubmitAsync(IThreadForm form);
        Task<bool> RateAsync(string threadid, int rating);
        Task<bool> MarkAsReadAsync(string threadid, string threadindex);
        Task<ThreadPageMetadata> RefreshAsync(string threadid, int pagenumber);
        Task<bool> AddToBookmarkAsync(string threadid);
        Task<bool> RemoveFromBookmarkAsync(string threadid);

        #endregion

        #region Private Message Handling

        Task<PrivateMessageMetadata> RefreshAsync(string privatemessageid);
        Task<IPrivateMessageRequest> CreateNewPrivateMessageAsync();
        Task<IPrivateMessageRequest> GetReplyRequestAsync(string privatemessageid);
        Task<IPrivateMessageRequest> GetForwardRequestAsync(string privatemessageid);
        Task<bool> SendMessageAsync(IPrivateMessageRequest request);
        Task<IEnumerable<PrivateMessageFolderMetadata>> GetPrivateMessageFoldersAsync(bool loadInbox = true);
        Task<PrivateMessageFolderMetadata> RefreshPrivateMessageFolderAsync(string folderid);
        Task<bool> DeletePrivateMessageAsync(string privateMessageId, string folderId);
        Task<bool> MoveAllPrivateMessagesAsync(IEnumerable<KeyValuePair<string, string>> pairs, string destinationFolderId);
        Task<bool> MovePrivateMessageAsync(string privatemessageid, string srcfolderid, string dstfolderid);
        Task<PrivateMessageFolderEditor> EditPrivateMessageFoldersAsync();
        Task<bool> SaveChangesAsync(PrivateMessageFolderEditor editor);

        #endregion

        #region New Thread Creation

        Task<INewThreadRequest> BeginNewThreadAsync(string forumId);
        Task<bool> SubmitAsync(INewThreadRequest request);
        Task<string> PreviewAsync(INewThreadRequest request);

        #endregion
    }
}
