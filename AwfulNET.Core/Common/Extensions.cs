using AwfulNET.Common;
using AwfulNET.Core;
using AwfulNET.Core.Common;
using AwfulNET.Core.Rest;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AwfulNET
{
    public static class Extensions
    {
        public static IDisposable SubscribeAsync<T>(this IObservable<T> observable,
            Action<T> next,
            Action<Exception> error = null,
            Action completed = null)
        {
            RelayObserver<T> observer = new RelayObserver<T>(next, error, completed);
            return observable.Subscribe(observer);
        }

        public static Task<IForumAccessToken> LoadAccessTokenFromStorage(
            this IStorageModel storage,
            string username)
        {
            return storage.LoadFromStorageAsync<IForumAccessToken>(username + ".dat");
        }

        public static Task SaveToStorageAsync(this IForumAccessToken token, IStorageModel storage)
        {
            string filename = string.Format("{0}.dat", token.Username);
            return storage.SaveToStorageAsync(filename, token);
        }

        public static IDisposable Subscribe<T>(this IObserver<T> observer,
            List<IObserver<T>> observers)
        {
            if (observer != null && !observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber<T>(observer, observers);
        }

        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
                action(item);
        }

        public static Task<TResult> ToApm<TResult>(this Task<TResult> task, AsyncCallback callback, object state)
        {
            if (task.AsyncState == state)
            {
                if (callback != null)
                {
                    task.ContinueWith(delegate { callback(task); },
                        CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default);
                }
                return task;
            }

            var tcs = new TaskCompletionSource<TResult>(state);
            task.ContinueWith(delegate
            {
                if (task.IsFaulted) tcs.TrySetException(task.Exception.InnerExceptions);
                else if (task.IsCanceled) tcs.TrySetCanceled();
                else tcs.TrySetResult(task.Result);

                if (callback != null) callback(tcs.Task);

            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default);
            return tcs.Task;
        }

        internal static void LoadAndFixHtml(this HtmlDocument doc, string html)
        {
            string fixedHtml = FixHTML(html);
            doc.LoadHtml(html);
        }

        internal static string FixHTML(string html)
        {
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

            //sample malformed HTML
            string fixedHtml = string.Empty;
            System.IO.MemoryStream fixedHtmlStream;

            //Debug.WriteLine(string.Format("Bad HTML: {0}", html));
            htmlDoc.LoadHtml(html);

            //ParseErrors holds a list of Errors
            Debug.WriteLine(string.Format("Loaded HTML has {0} error(s)",
                                            htmlDoc.ParseErrors.Count()));

            //Viewing more details of errors if any
            foreach (var e in htmlDoc.ParseErrors.ToList())
            {
                Debug.WriteLine(string.Format(" Line: {0}  \n Code: {1} \n Reason: {2} \n",
                                                e.Line, e.Code, e.Reason));
            }

            using (fixedHtmlStream = new System.IO.MemoryStream())
            {
                //Write to memory stream on save where internally, call is made to fix HTML.
                //Method's overloaded and can write to filestream...
                htmlDoc.Save(fixedHtmlStream);
                fixedHtml = ConvertToString(fixedHtmlStream);
            }

            //Debug.WriteLine(string.Format("Fixed HTML: {0}", fixedHtml));
            return fixedHtml;
        }

        internal static string ConvertToString(System.IO.Stream stream)
        {
            string contents = string.Empty;

            using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
            {
                stream.Position = 0;
                contents = reader.ReadToEnd();
            }

            return contents;
        }

        public static string Sanitize(this string text)
        {
            text = text.Replace("\r", String.Empty);
            text = text.Replace("\n", String.Empty);
            text = text.Replace("\t", String.Empty);

            text = WebUtility.HtmlDecode(text);
            return text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="innerText"></param>
        /// <returns></returns>
        public static string SanitizeDateTimeHTML(this string innerText)
        {
            string value = innerText.Replace("\t", "");
            value = value.Replace("&iquest;", "");
            value = value.Replace("\n", "");
            value = value.Replace("#", "");
            value = value.Replace("?", "");
            return value;
        }

        public static string ParseTitleFromBreadcrumbsNode(this HtmlAgilityPack.HtmlNode node)
        {
            string value = string.Empty;
            try
            {
                var breadcrumbs = node.InnerText.Replace("&gt;", "|").Split('|');
                value = breadcrumbs.Last().Trim();
            }
            catch (Exception) { value = "Unknown Value"; }
            return value;
        }

        public static async Task<ThreadFormResponse> ReplyAsync(this ThreadMetadata thread,
            string message,
            IForumAccessToken token,
            bool parseUrl = true,
            bool addToBookmarks = true)
        {
            // http://forums.somethingawful.com/newreply.php?action=newreply&threadid=3545394
            // STEP 1: LOAD NEW POST FORM
            var form = await token.GetThreadReplyFormAsync(thread.ThreadID);
            form.Message = message;
            form.ParseUrls = true;
            form.BookmarkThread = true;
            var response = await form.SubmitAsync(token);
            return response;
        }

        
        private static async Task<HttpContent> GetContentAsync(this HttpClient client,
            string endpoint)
        {
            NetworkDetectionMessage networkStatus = new NetworkDetectionMessage() { IsNetworkActive = true };
            NotificationService.Default.Notify<NetworkDetectionMessage>(client, networkStatus);
            if (!networkStatus.IsNetworkActive)
                throw new WebException("The request failed. Please check your connection settings and try again.", 
                    WebExceptionStatus.RequestCanceled);

            var result = await client.GetAsync(endpoint, HttpCompletionOption.ResponseContentRead);
            result.EnsureSuccessStatusCode();
            return result.Content;
        }

        internal static async Task<HttpResponseMessage> GetAsyncEx(this HttpClient client, string requestUri)
        {
            NetworkDetectionMessage networkStatus = new NetworkDetectionMessage() { IsNetworkActive = true };
            NotificationService.Default.Notify<NetworkDetectionMessage>(client, networkStatus);
            if (!networkStatus.IsNetworkActive)
                throw new WebException("The request failed. Please check your connection settings and try again.",
                    WebExceptionStatus.RequestCanceled);
            

            HttpResponseMessage result = null;
            try 
            {
                Logger.Default.AddEntry(LogLevel.INFO, "[GetAsyncEx] " + requestUri);
                Logger.Default.AddEntry(LogLevel.INFO, "[GetAsyncEx] HttpClient.GetAsync");
                result = await client.GetAsync(requestUri, HttpCompletionOption.ResponseContentRead); 
            }
            catch (Exception ex) 
            { 
                var timeout = new TimeoutException("The request timed out.", ex);
                Logger.Default.AddEntry(LogLevel.WARNING, timeout);
            }

            Logger.Default.AddEntry(LogLevel.INFO, "[GetAsyncEx] Completed.");
            return result;
        }

        internal static async Task<HtmlDocument> ToHtmlAsync(this HttpResponseMessage message)
        {
            HtmlDocument doc = null;
            doc = await message.Content.GetHtmlAsync();
            return doc;
        }

        internal static async Task<HtmlDocument> GetHtmlAsync(this HttpClient client,
            string endpoint)
        {
            NetworkDetectionMessage networkStatus = new NetworkDetectionMessage() { IsNetworkActive = true };
            NotificationService.Default.Notify<NetworkDetectionMessage>(client, networkStatus);
            if (!networkStatus.IsNetworkActive)
                throw new WebException("The request failed. Please check your connection settings and try again.", 
                    WebExceptionStatus.RequestCanceled);

            try 
            { 
                HttpContent content = await client.GetContentAsync(endpoint);
                return await content.GetHtmlAsync();
            }

            catch (Exception ex) { throw ex; }
        }

        private static async Task<HtmlDocument> GetHtmlAsync(this HttpContent content)
        {
            HtmlDocument doc = null;
            var western = new Windows1252Encoding();
            var utf8 = Encoding.UTF8;
            string html = null;
            try
            {
                var bytes = await content.ReadAsByteArrayAsync();
                Logger.Default.AddEntry(LogLevel.INFO, "[GetHtml] Converting html content into Win1252...");
                html = western.GetString(bytes, 0, bytes.Length);
                Logger.Default.AddEntry(LogLevel.INFO, "[GetHtml] Html character length: " + html.Length);
                Logger.Default.AddEntry(LogLevel.INFO, "[GetHtml] Completed.");
            }
            catch (Exception ex) 
            {
                Logger.Default.AddEntry(LogLevel.WARNING, ex);
                throw ex; 
            }

            Logger.Default.AddEntry(LogLevel.INFO, "[GetHtml] Creating html document...");
            doc = new HtmlDocument();
            doc.LoadHtml(html);
            Logger.Default.AddEntry(LogLevel.INFO, "[GetHtml] Disposing content resource...");
            content.Dispose();
            Logger.Default.AddEntry(LogLevel.INFO, "[GetHtml] Completed.");
            return doc;
        }

        internal static void AddOrUpdateValue<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] = value;
            else
                dictionary.Add(key, value);
        }

        internal static TValue GetValueOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue defaultValue = default(TValue))
        {
            TValue value = defaultValue;
            if (dictionary.TryGetValue(key, out value))
                return value;

            return defaultValue;
        }
    }

    public static class MetadataExtensions
    {
        public static async Task RefreshAsync(this PrivateMessageMetadataCollection collection,
            IForumAccessToken token)
        {
            var refresh = await collection.Folder.RefreshAsync(token);
            if (null != refresh)
            {
                collection.Clear();
                collection.AddRange(refresh.Messages);
            }
        }

        public static Task<ThreadFormResponse> SubmitAsync(this IThreadForm form, IForumAccessToken token)
        {
            return token.SubmitAsync(form);
        }

        public static ThreadMetadata ToThreadMetadata(this ThreadPageMetadata page)
        {
            ThreadMetadata thread = new ThreadMetadata()
            {
                Title = page.ThreadTitle,
                ThreadID = page.ThreadID,
                PageCount = page.LastPage,
                IsBookmarked = page.IsBookmarked
            };
            return thread;
        }

        public static Task<ThreadPageMetadata> GetThreadPageAsync(
            this ThreadMetadata thread, int pageNumber, IForumAccessToken token)
        {
            return token.GetThreadPageAsync(thread.ThreadID, pageNumber);
        }

        public static Task<ThreadPageMetadata> GetLastPostAsync(
            this ThreadMetadata thread, IForumAccessToken token)
        {
            return token.GetLastPostAsync(thread.ThreadID);
        }

        public static Task<ThreadPageMetadata> GetNewPostAsync(
            this ThreadMetadata thread, IForumAccessToken token)
        {
            return token.GetNewPostAsync(thread.ThreadID);
        }

        public static Task<string> QuoteAsync(this ThreadPostMetadata post,
            IForumAccessToken token)
        {
            return token.QuoteAsync(post.PostID);
        }

        public static Task<bool> RateAsync(this ThreadMetadata thread,
            int rating, IForumAccessToken token)
        {
            return token.RateAsync(thread.ThreadID, rating);
        }

        public static Task<bool> MarkAsReadAsync(this ThreadPostMetadata post,
            IForumAccessToken token)
        {
            return token.MarkAsReadAsync(post.PostID, post.ThreadIndex);
        }

        public static Task<ThreadPageMetadata> RefreshAsync(this ThreadPageMetadata page,
            IForumAccessToken token)
        {
            return token.RefreshAsync(page.ThreadID, page.PageNumber);
        }

        public enum BookmarkOptions { Add, Remove }

        public static Task<bool> SetBookmarkAsync(this ThreadMetadata thread, BookmarkOptions option, IForumAccessToken token)
        {
            if (option == BookmarkOptions.Add)
                return token.AddToBookmarkAsync(thread.ThreadID);

            return token.RemoveFromBookmarkAsync(thread.ThreadID);
        }

        public static async Task<PrivateMessageMetadata> RefreshAsync(this PrivateMessageMetadata message,
            IForumAccessToken token)
        {
            var result = await token.RefreshAsync(message.PrivateMessageId);
            result.FolderId = message.FolderId;
            return result;
        }

        public static Task<ForumPageMetadata> RefreshAsync(this ForumPageMetadata page, IForumAccessToken token)
        {
            return token.GetForumPageAsync(page.ForumID, page.PageNumber);
        }

        public static Task<ForumPageMetadata> GetForumPageAsync(
            this ForumMetadata forum, IForumAccessToken token, int pagenumber = 1)
        {
            return token.GetForumPageAsync(forum.ForumID, pagenumber);
        }

        public static Task<ForumPageMetadata> GetFilteredForumPageAsync(this ForumMetadata forum, FilterTagMetadata metadata,
            IForumAccessToken token)
        {
            return token.GetForumPageAsync(forum.ForumID, 1, metadata);
        }

        public static Task<bool> ClearAllMarkedPostsAsync(this ThreadMetadata thread, IForumAccessToken token)
        {
            return token.ClearAllMarkedPostsAsync(thread.ThreadID);
        }

        public static Task<ThreadPageMetadata> GetThreadPageAsync(this Uri uri, IForumAccessToken token)
        {
            return token.GetThreadPageAsync(uri);
        }

        public static Task<IPrivateMessageRequest> GetReplyRequestAsync(this PrivateMessageMetadata message,
            IForumAccessToken token)
        {
            return token.GetReplyRequestAsync(message.PrivateMessageId);
        }

        public static Task<IPrivateMessageRequest> GetForwardRequestAsync(this PrivateMessageMetadata message,
            IForumAccessToken token)
        {
            return token.GetForwardRequestAsync(message.PrivateMessageId);
        }

        public static Task<bool> SubmitAsync(this IPrivateMessageRequest request,
            IForumAccessToken token)
        {
            return token.SendMessageAsync(request);
        }

        public static Task<PrivateMessageFolderMetadata> RefreshAsync(this PrivateMessageFolderMetadata folder,
            IForumAccessToken token)
        {
            return token.RefreshPrivateMessageFolderAsync(folder.FolderId);
        }

        public static async Task<bool> DeleteAllAsync(this IEnumerable<PrivateMessageMetadata> messages,
            IForumAccessToken token)
        {
            List<Task> tasks = new List<Task>();
            foreach (var message in messages)
                tasks.Add(token.DeletePrivateMessageAsync(message.PrivateMessageId, message.FolderId));

            bool success = false;
            await Task.WhenAll(tasks);
            success = true;
            return success;
        }

        public static Task<bool> DeleteAsync(this PrivateMessageMetadata message,
            IForumAccessToken token)
        {
            return DeleteAllAsync(new List<PrivateMessageMetadata>() { message }, token);
        }

        public static Task<bool> MoveAllAsync(this IEnumerable<PrivateMessageMetadata> messages,
            PrivateMessageFolderMetadata folder,
            IForumAccessToken token)
        {
            var pairs = messages.Select(pair => new KeyValuePair<string, string>(pair.PrivateMessageId, pair.FolderId));
            return token.MoveAllPrivateMessagesAsync(pairs, folder.FolderId);
        }

        public static Task<bool> MoveAsync(this PrivateMessageMetadata message, PrivateMessageFolderMetadata folder,
            IForumAccessToken token)
        {
            return token.MovePrivateMessageAsync(message.PrivateMessageId, message.FolderId, folder.FolderId);
        }

        public static Task<bool> SubmitAsync(this PrivateMessageFolderEditor editor,
            IForumAccessToken token)
        {
            return token.SaveChangesAsync(editor);
        }

        public static Task<INewThreadRequest> CreateNewThreadAsync(this ForumMetadata forum,
            IForumAccessToken token)
        {
            return token.BeginNewThreadAsync(forum.ForumID);
        }

        public static Task<bool> SubmitAsync(this INewThreadRequest request,
            IForumAccessToken token)
        {
            return token.SubmitAsync(request);
        }

        public static Task<string> PreviewAsync(this INewThreadRequest request,
            IForumAccessToken token)
        {
            return token.PreviewAsync(request);
        }
        
    }
}
