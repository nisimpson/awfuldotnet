
using AwfulNET.Core.Common;
using AwfulNET.Core.Parsing;
using AwfulNET.Core.Rest;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Rest
{
    public delegate IForumAccessToken TokenDelegate();

    [DataContract]
    public class ForumAccessToken : IForumAccessToken
    {
        public const int DefaultTimeoutInMilliseconds = 60000;
        private HttpClient client;
        private const int MIN_RATING = 1;
        private const int MAX_RATING = 5;
        
        private const string NEW_MESSAGE_ACTION_VALUE = "newmessage";
        private const string MOVE_MESSAGE_ACTION_VALUE = "dostuff";
        private const string MOVE_MESSAGE_SUBMIT_VALUE = "Move";
        private const string DELETE_MESSAGE_SUBMIT_ACTION = "Delete";

        public ForumAccessToken()
        {
            this.Cookies = new List<Cookie>();
            this.Username = string.Empty;
        }

        [DataMember]
        public string Username { get; set; }
        
        [DataMember]
        public List<Cookie> Cookies { get; set; }

        private List<string> pinned = new List<string>();
        [DataMember]
        public List<string> PinnedForumIDs
        {
            get { return pinned; }
            set { pinned = value; }
        }

        [IgnoreDataMember]
        internal HttpClient Client
        {
            get
            {
                if (client == null)
                {
                    client = AwfulWebClient.CreateHttpClient(this.Cookies);
                }

                return client;
            }

            set { client = value; }
        }

        [IgnoreDataMember]
        public bool IsActiveAccount { get { return this.Cookies.Count != 0; } }

        public void AddForumToPins(ForumMetadata forum)
        {
            if (PinnedForumIDs == null)
                PinnedForumIDs = new List<string>();

            if (!PinnedForumIDs.Contains(forum.ForumID))
            {
                Logger.Default.AddEntry(LogLevel.INFO, string.Format("Adding forum {0} to pins...", forum.ForumID));
                PinnedForumIDs.Add(forum.ForumID);
                Logger.Default.AddEntry(LogLevel.INFO, "Forum added.");
            }
            else { Logger.Default.AddEntry(LogLevel.INFO, string.Format("Forum {0} is already pinned.", forum.ForumID)); }
        }

        public bool RemoveForumFromPins(ForumMetadata forum)
        {
            if (PinnedForumIDs == null)
                return false;

            Logger.Default.AddEntry(LogLevel.INFO, string.Format("Removing forum {0} from pins...", forum.ForumID));
            bool removed = PinnedForumIDs.Remove(forum.ForumID);
            if (removed)
                Logger.Default.AddEntry(LogLevel.INFO, string.Format("Forum {0} was removed.", forum.ForumID));
            else
                Logger.Default.AddEntry(LogLevel.INFO, string.Format("Forum {0} was not found in pins.", forum.ForumID));

            return removed;
        }

        public bool IsForumPinned(ForumMetadata forum)
        {
            if (PinnedForumIDs == null)
                return false;

            return PinnedForumIDs.Contains(forum.ForumID);
        }

        public override string ToString()
        {
            return string.Format("[ForumAccessToken]: {0}", this.Username);
        }

        public async Task<UserFeatures> GetUserFeaturesAsync()
        {
            Logger.Default.AddEntry(LogLevel.INFO, "Getting user features...");

            Logger.Default.AddEntry(LogLevel.INFO, "[UserFeatures] Creating endpoint...");
            var endpoint = new HttpGetRequestBuilder("member.php");

            Logger.Default.AddEntry(LogLevel.INFO, "[UserFeatures] Fetching html...");
            var doc = await endpoint.GetHtmlAsync(this.Client);

            var features = Task.Run(() => 
            {
                Logger.Default.AddEntry(LogLevel.INFO, "[UserFeatures] Parsing html...");
                var result = UserFeatures.FromHtmlDocument(doc);
                Logger.Default.AddEntry(LogLevel.INFO, "[UserFeatures] Completed.");
                return result;
            });

            return await features;
        }

        public async Task<UserSettings> GetUserSettingsAsync()
        {
            Logger.Default.AddEntry(LogLevel.INFO, "Getting user settings...");

            Logger.Default.AddEntry(LogLevel.INFO, "[UserSettings] Creating endpoint...");
            HttpGetRequestBuilder endpoint = new HttpGetRequestBuilder("member.php");
            endpoint.AddParameter("action", "editoptions");

            Logger.Default.AddEntry(LogLevel.INFO, "[UserSettings] Fetching html...");
            var doc = await endpoint.GetHtmlAsync(this.Client);

            var settings = Task.Run(() => {
                Logger.Default.AddEntry(LogLevel.INFO, "[UserSettings] Parsing html...");
                var result = UserSettings.FromHtmlDocument(doc);
                Logger.Default.AddEntry(LogLevel.INFO, "[UserSettings] Completed.");
                return result;
            });
            return await settings;
        }

        public async Task<IEnumerable<TagMetadata>> GetSmiliesAsync()
        {
            Logger.Default.AddEntry(LogLevel.INFO, "Getting smilies list...");

            List<TagMetadata> list = null;

            Logger.Default.AddEntry(LogLevel.INFO, "[GetSmilies] Creating endpoint...");
            HttpGetRequestBuilder endpoint = new HttpGetRequestBuilder("misc.php");
            endpoint.AddParameter("action", "showsmilies");

            Logger.Default.AddEntry(LogLevel.INFO, "[GetSmilies] Fetching html...");
            var doc = await endpoint.GetHtmlAsync(this.Client);
            
            var smilies = Task.Run(() =>
            {
                Logger.Default.AddEntry(LogLevel.INFO, "[GetSmilies] Parsing html...");
                var parsed = SmileyParser.ParseSmiliesFromHtml(doc);
                Logger.Default.AddEntry(LogLevel.INFO, "[GetSmilies] Completed.");
                return parsed;
            });
        
            list.AddRange(await smilies);
            return list;
        }

        public Task<bool> SaveUserSettingsAsync(UserSettings settings)
        {
            Logger.Default.AddEntry(LogLevel.INFO, "Saving user settings...");
            //var result = await settings.PostAsync(this.Client);

            Logger.Default.AddEntry(LogLevel.INFO, "[SaveUserSettings] Submitting web request async...");
            var result = settings.CreateHttpRequestBuilder().SendAndConfirmAsync(this.Client);
            return result;
        }

        public async Task<IEnumerable<ForumMetadata>> GetForumListAsync()
        {
            Logger.Default.AddEntry(LogLevel.INFO, "Getting forum list...");

            IEnumerable<ForumMetadata> result = null;
            try
            {
                if (this.Cookies.Count != 0)
                {
                    result = await GetDeepForumListAsync();
                }
            }
            catch (BannedAccountException bae) 
            {
                Logger.Default.AddEntry(LogLevel.WARNING, string.Format("Cannot get index. {0} is banned.", this.ToString()));
                Logger.Default.AddEntry(LogLevel.WARNING, bae);
                throw bae; 
            }
            catch (Exception ex) { 
                Logger.Default.AddEntry(LogLevel.WARNING, "Unknown error:");
                Logger.Default.AddEntry(LogLevel.WARNING, ex);
            }
            
            if (result == null || result.Count() == 0)
                result = await GetShallowForumListAsync();

            Logger.Default.AddEntry(LogLevel.INFO, "[GetForumsIndex] Completed.");
            return result;
        }

        private async Task<IEnumerable<ForumMetadata>> GetDeepForumListAsync()
        {
            Logger.Default.AddEntry(LogLevel.INFO, "Using deep forum list method.");

            Logger.Default.AddEntry(LogLevel.INFO, "[DeepForum] Creating endpoint...");
            var endpoint = new HttpGetRequestBuilder("forumdisplay.php");
            endpoint.AddParameter("forumid", "1");

            Logger.Default.AddEntry(LogLevel.INFO, "[DeepForum] Fetching html...");
            var doc = await endpoint.GetHtmlAsync(this.Client);

            var forumList = Task.Run(() => {
                Logger.Default.AddEntry(LogLevel.INFO, "[DeepForum] Parsing html...");
                var parsed = ForumParser.ParseForumList(doc);
                Logger.Default.AddEntry(LogLevel.INFO, "[DeepForum] Completed.");
                return parsed;
            });
            var forums = await GetForumDescriptionsAsync(await forumList, this.Client);
            return forums;
        }

        private async Task<IEnumerable<ForumMetadata>> GetShallowForumListAsync()
        {
            Logger.Default.AddEntry(LogLevel.INFO, "Using shallow forum list method.");

            Logger.Default.AddEntry(LogLevel.INFO, "[ShallowForum] Creating endpoint...");
            var endpoint = new HttpGetRequestBuilder("index.php");

            Logger.Default.AddEntry(LogLevel.INFO, "[ShallowForum] Fetching html...");
            var doc = await endpoint.GetHtmlAsync(this.Client);

            Task<IEnumerable<ForumMetadata>> forumList = Task.Run(() => {
                Logger.Default.AddEntry(LogLevel.INFO, "[ShallowForum] Parsing html...");
                var parsed = ForumParser.ParseShallowForumList(doc);
                Logger.Default.AddEntry(LogLevel.INFO, "[ShallowForum] Completed.");
                return parsed;
            });
            return await forumList;
        }

        public async Task<IThreadForm> GetThreadReplyFormAsync(string threadid)
        {
            Logger.Default.AddEntry(LogLevel.INFO, string.Format("Getting thread {0} reply form...", threadid));

            // http://forums.somethingawful.com/newreply.php?action=newreply&threadid=3545394
            HtmlDocument formDocument = null;

            Logger.Default.AddEntry(LogLevel.INFO, "[ReplyForm] Creating endpoint...");
            HttpGetRequestBuilder request = new HttpGetRequestBuilder("newreply.php");
            request.AddParameter("action", "newreply");
            request.AddParameter("threadid", threadid);

            Logger.Default.AddEntry(LogLevel.INFO, "[ReplyForm] Fetching html...");
            formDocument = await request.GetHtmlAsync(this.Client);

            Task<IThreadForm> task = Task.Run(() =>
                {
                    Logger.Default.AddEntry(LogLevel.INFO, "[ReplyForm] Parsing html...");
                    IThreadForm parsed = ThreadReplyForm.FromHtmlDocument(formDocument);
                    Logger.Default.AddEntry(LogLevel.INFO, "[ReplyForm] Completed.");
                    return parsed;
                });

            return await task;
        }

        public async Task<ForumPageMetadata> GetBookmarkPageAsync(int pagenumber = 1)
        {
            Logger.Default.AddEntry(LogLevel.INFO, string.Format("Getting bookmarks page {0}...", pagenumber));

            Logger.Default.AddEntry(LogLevel.INFO, "[GetBookmarks] Creating endpoint...");
            StringBuilder endpoint = new StringBuilder("/bookmarkthreads.php?");
            endpoint.AppendFormat("pagenumber={0}", pagenumber);

            // TODO: Use HttpGetRequestBuilder here.
            Logger.Default.AddEntry(LogLevel.INFO, "[GetBookmarks] Fetching html...");
            var htmlDoc = await this.Client.GetHtmlAsync(endpoint.ToString());

            Task<ForumPageMetadata> task = Task.Run(() =>
            {
                Logger.Default.AddEntry(LogLevel.INFO, "[GetBookmarks] Parsing html...");
                var page = ForumParser.ParseForumPage(htmlDoc);
                page.ForumID = "bookmarks";
                Logger.Default.AddEntry(LogLevel.INFO, "[GetBookmarks] Completed.");
                return page;
            });

            return await task;
        }

        public async Task<ForumPageMetadata> GetForumPageAsync(string forumID, int pagenumber = 1, FilterTagMetadata filter = null)
        {
            Logger.Default.AddEntry(LogLevel.INFO, string.Format("Getting forum {0}, page {1} with {2} filter...",
                forumID, pagenumber, filter == null ? "no" : filter.ToString()));

            Logger.Default.AddEntry(LogLevel.INFO, "[ForumPage] Creating endpoint...");
            StringBuilder endpoint = new StringBuilder("forumdisplay.php?");
            endpoint.AppendFormat("forumid={0}", forumID);
            endpoint.AppendFormat("&daysprune={0}", 15);
            endpoint.AppendFormat("&perpage={0}", 40);
            endpoint.AppendFormat("&posticon={0}", 0);
            endpoint.AppendFormat("&sortorder={0}", "desc");
            endpoint.AppendFormat("&pagenumber={0}", pagenumber);

            // TODO: Use HttpGetRequestBuilder.
            Logger.Default.AddEntry(LogLevel.INFO, "[ForumPage] Fetching html...");
            var htmlDoc = await this.Client.GetHtmlAsync(endpoint.ToString());

            Task<ForumPageMetadata> task = Task.Run(() =>
                {
                    Logger.Default.AddEntry(LogLevel.INFO, "[ForumPage] Parsing html...");
                    var parsed = ForumParser.ParseForumPage(htmlDoc);
                    Logger.Default.AddEntry(LogLevel.INFO, "[ForumPage] Completed.");
                    return parsed;
                });

            return await task;
        }

        public async Task<bool> ClearAllMarkedPostsAsync(string threadID)
        {
            Logger.Default.AddEntry(LogLevel.INFO, string.Format("Clearing all marked posts from thread {0}...", threadID));

            // TODO: Use httppostrequestbuilder.
            Logger.Default.AddEntry(LogLevel.INFO, "[ClearAllMarked] Creating endpoint...");
            StringBuilder endpoint = new StringBuilder("/threaddisplay.php?");
            FormUrlEncodedContent postData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("json", "1"),
                new KeyValuePair<string, string>("action", "resetseen"),
                new KeyValuePair<string, string>("threadid", threadID)
            });

            Logger.Default.AddEntry(LogLevel.INFO, "[ClearAllMarked] Submitting web request...");
            var result = await this.Client.PostAsync(endpoint.ToString(), postData);
            result.EnsureSuccessStatusCode();

            Logger.Default.AddEntry(LogLevel.INFO, "[ClearAllMarked] Completed.");
            return true;
        }

        public async Task<ThreadPageMetadata> GetThreadPageAsync(string threadID, int pageNumber = 1)
        {
            Logger.Default.AddEntry(LogLevel.INFO, string.Format("Getting thread {0}, page {1}...", threadID, pageNumber));

            Logger.Default.AddEntry(LogLevel.INFO, "[ThreadPage1] Creating endpoint...");
            HttpGetRequestBuilder endpoint = new HttpGetRequestBuilder("showthread.php");
            endpoint.AddParameter("threadid", threadID);
            endpoint.AddParameter("pagenumber", pageNumber);

            Logger.Default.AddEntry(LogLevel.INFO, "[ThreadPage1] Fetching html...");
            var htmlDoc = await endpoint.GetHtmlAsync(this.Client);

            Task<ThreadPageMetadata> task = Task.Run(() =>
                {
                    Logger.Default.AddEntry(LogLevel.INFO, "[ThreadPage1] Parsing html...");
                    var parsed = ThreadPageParser.ParseThreadPage(htmlDoc);
                    Logger.Default.AddEntry(LogLevel.INFO, "[ThreadPage1] Completed.");
                    return parsed;
                });

            return await task;
        }

        public async Task<ThreadPageMetadata> GetThreadPageAsync(Uri pageUri)
        {
            Logger.Default.AddEntry(LogLevel.INFO, string.Format("Getting thread page with uri '{0}'...", pageUri.ToString()));

            if (!pageUri.IsAbsoluteUri)
            {
                Logger.Default.AddEntry(LogLevel.INFO, "[ThreadPage2] Appending base uri...");
                Uri baseUri = new Uri("http://forums.somethingawful.com");
                pageUri = new Uri(baseUri, pageUri);
            }

            Logger.Default.AddEntry(LogLevel.INFO, "[ThreadPage2] Fetching html...");
            var htmlDoc = await this.Client.GetHtmlAsync(pageUri.ToString());

            Task<ThreadPageMetadata> task = Task.Run(() =>
                {
                    Logger.Default.AddEntry(LogLevel.INFO, "[ThreadPage2] Parsing html...");
                    var parsed = ThreadPageParser.ParseThreadPage(htmlDoc);
                    Logger.Default.AddEntry(LogLevel.INFO, "[ThreadPage2] Completed.");
                    return parsed;
                });

            return await task;
        }

        public async Task<ThreadPageMetadata> GetLastPostAsync(string threadID)
        {
            Logger.Default.AddEntry(LogLevel.INFO, string.Format("Getting thread {0} page with last post...", threadID));

            Logger.Default.AddEntry(LogLevel.INFO, "[LastPost] Creating endpoint...");
            HttpGetRequestBuilder endpoint = new HttpGetRequestBuilder("showthread.php");
            endpoint.AddParameter("threadid", threadID);
            endpoint.AddParameter("goto", "lastpost");

            Logger.Default.AddEntry(LogLevel.INFO, "[LastPost] Fetching html...");
            var doc = await endpoint.GetHtmlAsync(this.Client);
            var result = Task.Run(() => {
                Logger.Default.AddEntry(LogLevel.INFO, "[LastPost] Parsing html...");
                var parsed = ThreadPageParser.ParseThreadPage(doc);
                Logger.Default.AddEntry(LogLevel.INFO, "[LastPost] Completed.");
                return parsed;
            });
            return await result;
        }

        public async Task<ThreadPageMetadata> GetNewPostAsync(string threadID)
        {
            Logger.Default.AddEntry(LogLevel.INFO, string.Format("Getting thread {0} page with new post...", threadID));

            Logger.Default.AddEntry(LogLevel.INFO, "[NewPost] Creating endpoint...");
            HttpGetRequestBuilder endpoint = new HttpGetRequestBuilder("showthread.php");
            endpoint.AddParameter("threadid", threadID);
            endpoint.AddParameter("goto", "newpost");

            Logger.Default.AddEntry(LogLevel.INFO, "[NewPost] Fetching html...");
            var doc = await endpoint.GetHtmlAsync(this.Client);

            var result = Task.Run(() => {
                Logger.Default.AddEntry(LogLevel.INFO, "[NewPost] Parsing html...");
                var parsed = ThreadPageParser.ParseThreadPage(doc);
                Logger.Default.AddEntry(LogLevel.INFO, "[NewPost] Completed.");
                return parsed;
            });

            return await result;
        }

        public async Task<string> QuoteAsync(string postId)
        {
            Logger.Default.AddEntry(LogLevel.INFO, string.Format("Quoting post {0}", postId));

            Logger.Default.AddEntry(LogLevel.INFO, "[Quote] Creating endpoint...");
            HttpGetRequestBuilder endpoint = new HttpGetRequestBuilder("newreply.php");
            endpoint.AddParameter("action", "newreply");
            endpoint.AddParameter("postid", postId);

            Logger.Default.AddEntry(LogLevel.INFO, "[Quote] Fetching html...");
            var doc = await endpoint.GetHtmlAsync(this.Client);

            Logger.Default.AddEntry(LogLevel.INFO, "[Quote] Parsing html...");
            var bodyNode = doc.DocumentNode.Descendants("body").First();
            if (bodyNode.GetAttributeValue("class", string.Empty).Equals("standarderror"))
            {
                Logger.Default.AddEntry(LogLevel.WARNING, "[Quote] Experienced an error:");
                var ex = new InvalidOperationException("Only registered members can quote posts.");
                Logger.Default.AddEntry(LogLevel.WARNING, ex);
                throw ex;
            }

            string body = doc.DocumentNode.Descendants("textarea").First().InnerText;
            Logger.Default.AddEntry(LogLevel.INFO, "[Quote] Decoding html...");
            body = WebUtility.HtmlDecode(body);
            Logger.Default.AddEntry(LogLevel.INFO, "[Quote] Completed.");
            return body;
        }

        public async Task<IThreadForm> BeginEditPostAsync(string postId)
        {
            Logger.Default.AddEntry(LogLevel.INFO, string.Format("Creating edit post {0} form...", postId));

            Logger.Default.AddEntry(LogLevel.INFO, "[EditPost] Creating endpoint...");
            HttpGetRequestBuilder endpoint = new HttpGetRequestBuilder("editpost.php");
            endpoint.AddParameter("action", "editpost");
            endpoint.AddParameter("postid", postId);

            Logger.Default.AddEntry(LogLevel.INFO, "[EditPost] Fetching html...");
            var result = await endpoint.GetHtmlAsync(this.Client);

            Task<IThreadForm> task = Task.Run(() =>
                {
                    Logger.Default.AddEntry(LogLevel.INFO, "[EditPost] Parsing html...");
                    IThreadForm parsed = PostEditForm.FromHtmlDocument(postId, result);
                    Logger.Default.AddEntry(LogLevel.INFO, "[EditPost] Completed.");
                    return parsed;
                });

            return await task;
        }

        public async Task<ThreadFormResponse> SubmitAsync(IThreadForm form)
        {
            Logger.Default.AddEntry(LogLevel.INFO, "Submitting thread form...");

            Logger.Default.AddEntry(LogLevel.INFO, "[SubmitThreadForm] Creating endpoint...");
            var endpoint = form.CreateHttpRequestBuilder();

            Logger.Default.AddEntry(LogLevel.INFO, "[SubmitThreadForm] Submitting request...");
            var result = await endpoint.SendAndConfirmAsync(this.Client);

            Logger.Default.AddEntry(LogLevel.INFO, "[SubmitThreadForm] Creating response...");
            var response = new ThreadReplyResponse(form, result);
            Logger.Default.AddEntry(LogLevel.INFO, "[SubmitThreadForm] Completed.");
            return response;
        }

        public Task<bool> RateAsync(string threadid, int rating)
        {
            if (rating < MIN_RATING || rating > MAX_RATING)
                throw new ArgumentOutOfRangeException(string.Format(
                    "Rating must be between {0} and {1}.", MIN_RATING, MAX_RATING));

            HttpGetRequestBuilder endpoint = new HttpGetRequestBuilder("threadrate.php");
            endpoint.AddParameter("vote", rating);
            endpoint.AddParameter("threadid", threadid);
            return endpoint.SendAndConfirmAsync(this.Client);
        }

        public Task<bool> MarkAsReadAsync(string threadid, string threadIndex)
        {
            HttpGetRequestBuilder endpoint = new HttpGetRequestBuilder("showthread.php");
            endpoint.AddParameter("action", "setseen");
            endpoint.AddParameter("threadid", threadid);
            endpoint.AddParameter("index", threadIndex);
            return endpoint.SendAndConfirmAsync(this.Client);
        }

        public async Task<ThreadPageMetadata> RefreshAsync(string threadid, int pagenumber)
        {
            HttpGetRequestBuilder endpoint = new HttpGetRequestBuilder("showthread.php");
            endpoint.AddParameter("threadid", threadid);
            endpoint.AddParameter("pagenumber", pagenumber);
            var doc = await endpoint.GetHtmlAsync(this.Client);
            var result = Task.Run(() => { return ThreadPageParser.ParseThreadPage(doc); });
            return await result;
        }

        public Task<bool> AddToBookmarkAsync(string threadid)
        {
            HttpPostRequestBuilder endpoint = new HttpPostRequestBuilder("bookmarkthreads.php");
            endpoint.AddParameter("json", "1");
            endpoint.AddParameter("action", "cat_toggle");
            endpoint.AddParameter("threadid", threadid);
            return endpoint.SendAndConfirmAsync(this.Client);
        }

        public Task<bool> RemoveFromBookmarkAsync(string threadid)
        {
            HttpPostRequestBuilder endpoint = new HttpPostRequestBuilder("bookmarkthreads.php");
            endpoint.AddParameter("json", "1");
            endpoint.AddParameter("action", "remove");
            endpoint.AddParameter("threadid", threadid);
            return endpoint.SendAndConfirmAsync(this.Client);
        }

        public async Task<PrivateMessageMetadata> RefreshAsync(string privateMessageId)
        {
            HttpGetRequestBuilder endpoint = new HttpGetRequestBuilder("private.php");
            endpoint.AddParameter("action", "show");
            endpoint.AddParameter("privatemessageid", privateMessageId);
            var doc = await endpoint.GetHtmlAsync(this.Client);
            return PrivateMessageParser.ParsePrivateMessageDocument(doc);
        }

        public async Task<IPrivateMessageRequest> CreateNewPrivateMessageAsync()
        {
            HttpGetRequestBuilder endpoint = new HttpGetRequestBuilder("private.php");
            endpoint.AddParameter("action", "newmessage");
            var doc = await endpoint.GetHtmlAsync(this.Client);
            return PrivateMessageParser.ParseNewPrivateMessageFormDocument(doc);
        }

        public async Task<IPrivateMessageRequest> GetReplyRequestAsync(string privateMessageId)
        {
            StringBuilder endpoint = new StringBuilder("/private.php?");
            endpoint.AppendFormat("action={0}", "newmessage");
            endpoint.AppendFormat("&privatemessageid={0}", privateMessageId);
            var doc = await this.Client.GetHtmlAsync(endpoint.ToString());
            return PrivateMessageParser.ParseNewPrivateMessageFormDocument(doc);
        }

        public async Task<IPrivateMessageRequest> GetForwardRequestAsync(string privateMessageId)
        {
            StringBuilder endpoint = new StringBuilder("/private.php?");
            endpoint.AppendFormat("action={0}", "newmessage");
            endpoint.AppendFormat("&forward={0}", "true");
            endpoint.AppendFormat("&privatemessageid={0}", privateMessageId);
            var doc = await this.Client.GetHtmlAsync(endpoint.ToString());
            return PrivateMessageParser.ParseNewPrivateMessageFormDocument(doc);
        }

        public Task<bool> SendMessageAsync(IPrivateMessageRequest request)
        {
            return request.CreateHttpRequestBuilder().SendAndConfirmAsync(this.Client);
        }

        public async Task<IEnumerable<PrivateMessageFolderMetadata>> GetPrivateMessageFoldersAsync(bool loadInbox = true)
        {
            var endpoint = new HttpGetRequestBuilder("private.php");
            var doc = await endpoint.GetHtmlAsync(this.Client);
            List<PrivateMessageFolderMetadata> items = new List<PrivateMessageFolderMetadata>();
            var folders = Task.Run(() => { return PrivateMessageParser.ParseFolderList(doc); });
            items.AddRange(await folders);
            if (loadInbox)
            {
                var inbox = Task.Run(() => { return PrivateMessageParser.ParseMessageList(doc); });
                List<PrivateMessageMetadata> messages = new List<PrivateMessageMetadata>();
                messages.AddRange(await inbox);
                items[0].Messages = messages;
            }
            return items;
        }

        public async Task<PrivateMessageFolderMetadata> RefreshPrivateMessageFolderAsync(string folderId)
        {
            HttpGetRequestBuilder endpoint = new HttpGetRequestBuilder("private.php");
            endpoint.AddParameter("folderid", folderId);
            endpoint.AddParameter("daysprune", "9999");
            var doc = await endpoint.GetHtmlAsync(this.Client);
            return PrivateMessageParser.ParsePrivateMessageFolder(doc);
        }

        private async Task<bool> PrivateMessageAPICallAsync(IEnumerable<KeyValuePair<string, string>> messageKeys,
            string destinationFolderId,
            string sourceFolderId,
            string apiAction,
            string apiValue)
        {
            var endpoint = new HttpPostRequestBuilder("private.php");
            string folderId = string.Empty;
            foreach(KeyValuePair<string, string> pair in messageKeys)
            {
                folderId = pair.Value;
                string privateMessageId = pair.Key;
                endpoint.AddParameter(string.Format("privatemessage[{0}]", privateMessageId), "yes");
            }

            endpoint.AddParameter("action", MOVE_MESSAGE_ACTION_VALUE);
            endpoint.AddParameter("thisfolder", sourceFolderId);
            endpoint.AddParameter("folderid", destinationFolderId);
            endpoint.AddParameter(apiAction, apiValue);
            bool success = false;
            try { var result = await endpoint.SendRequestAsync(this.Client); result.EnsureSuccessStatusCode(); success = true; }
            catch (Exception) { success = false; }
            return success;
        }

        public Task<bool> DeletePrivateMessageAsync(string privateMessageId, string folderId)
        {
            var list = new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>(privateMessageId, folderId) };
            return PrivateMessageAPICallAsync(list, folderId, folderId, "delete", DELETE_MESSAGE_SUBMIT_ACTION);
        }

        public Task<bool> MoveAllPrivateMessagesAsync(IEnumerable<KeyValuePair<string, string>> pairs,
            string destinationFolderId)
        {
            var first = pairs.First();
            string sourceFolderId = first.Value;
            return PrivateMessageAPICallAsync(pairs, destinationFolderId, sourceFolderId, "move", MOVE_MESSAGE_SUBMIT_VALUE);
        }

        public Task<bool> MovePrivateMessageAsync(string privateMessageId, string srcFolderId, string dstFolderId)
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>(privateMessageId, srcFolderId)
            };

            return MoveAllPrivateMessagesAsync(list, dstFolderId);
        }

        public async Task<PrivateMessageFolderEditor> EditPrivateMessageFoldersAsync()
        {
            HttpGetRequestBuilder endpoint = new HttpGetRequestBuilder("private.php");
            endpoint.AddParameter("action", "editfolders");
            var doc = await endpoint.GetHtmlAsync(this.Client);
            var result = Task.Run(() => { return PrivateMessageParser.ParseEditFolderPage(doc); });
            return await result;
        }

        public Task<bool> SaveChangesAsync(PrivateMessageFolderEditor editor)
        {
            return editor.CreateHttpRequestBuilder().SendAndConfirmAsync(this.Client);
        }

        public async Task<INewThreadRequest> BeginNewThreadAsync(string forumid)
        {
            var request = new HttpGetRequestBuilder("newthread.php");
            request.AddParameter("forumid", forumid);
            var doc = await request.GetHtmlAsync(this.Client);
            var result = Task.Run(() => 
            {
                var form = NewThreadRequest.ParseNewThreadRequest(doc);
                form.ForumId = forumid;
                return form;
            });
            return await result;
        }

        public Task<bool> SubmitAsync(INewThreadRequest request)
        {
            return request.CreateHttpRequestBuilder().SendAndConfirmAsync(this.Client);
        }

        public async Task<string> PreviewAsync(INewThreadRequest request)
        {
            request.IsPreview = true;
            var doc = await request.CreateHttpRequestBuilder().GetHtmlAsync(this.Client);
            return doc.DocumentNode.OuterHtml;
        }

        private static async Task<IEnumerable<ForumMetadata>> GetForumDescriptionsAsync(IEnumerable<ForumMetadata> forums, HttpClient client)
        {
            var htmlDocument = await client.GetHtmlAsync("/");
            return forums.ParseForumDescription(htmlDocument);
        }

    }

    [Obsolete("This class is deprecated. Acquire tokens by registering for the AccessMessageToken notification.", true)]
    public static class ForumAccessTokenProvider
    {
        public static event EventHandler<ForumAccessTokenRequestArgs> TokenRequested;

        public static IForumAccessToken RequestToken(object sender)
        {
            var handler = TokenRequested;
            if (handler != null)
            {
                ForumAccessTokenRequestArgs e = new ForumAccessTokenRequestArgs();
                handler(sender, e);
                return e.Token;
            }

            return null;
        }
    }

    public class ForumAccessTokenRequestArgs : EventArgs
    {
        public IForumAccessToken Token { get; set; }
        public ForumAccessTokenRequestArgs() { }
    }
}