
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Rest
{
    public interface INewThreadRequest : ICreateHttpRequestBuilder
    {
        string ForumId { get; }
        ICollection<TagMetadata> Tags { get; }
        bool IsPreview { get; set; }
        string FormKey { get; }
        string FormCookie { get; }
        string Title { get; set; }
        string Text { get; set; }
        TagMetadata SelectedTag { get; set; }
    }

    public class NewThreadRequest : INewThreadRequest
    {
        public string ForumId { get; set; }
        public ICollection<TagMetadata> Tags { get; set; }
        public string FormKey { get; set; }
        public string FormCookie { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public TagMetadata SelectedTag { get; set; }
        public bool IsPreview { get; set; }

        #region Command Thread Strings

        private const string THREAD_FORUMID_KEY = "forumid";
        private const string THREAD_ACTION_KEY = "action";
        private const string THREAD_ACTION_VALUE = "postthread";
        private const string THREAD_FORMKEY_KEY = "formkey";
        private const string THREAD_FORMCOOKIE_KEY = "form_cookie";
        private const string THREAD_SUBJECT_KEY = "subject";
        private const string THREAD_ICONID_KEY = "iconid";
        private const string THREAD_MESSAGE_KEY = "message";
        private const string THREAD_PARSEURL_KEY = "parseurl";
        private const string THREAD_PARSEURL_VALUE = "yes";

        #endregion

        #region Send Thread Strings

        private const string SEND_THREAD_SUBMIT_KEY = "submit";
        private const string SEND_THREAD_SUBMIT_VALUE = "Submit New Thread";

        #endregion

        #region Preview Thread Strings

        private const string PREVIEW_THREAD_SUBMIT_KEY = "preview";
        private const string PREVIEW_THERAD_SUBMIT_VALUE = "Preview Post";

        #endregion

        #region Html scraping 

        public static NewThreadRequest ParseNewThreadRequest(HtmlAgilityPack.HtmlDocument doc)
        {
            HtmlAgilityPack.HtmlNode parent = doc.DocumentNode;
            NewThreadRequest request = SetRequestFormInfo(parent);

            var icons = parent.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("posticon"));

            request.Tags = new List<TagMetadata>(30);
            request.Tags.Add(TagMetadata.NoTag);

            foreach (var icon in icons)
            {
                try
                {
                    var inputNode = icon.Descendants("input").SingleOrDefault();
                    var imgNode = icon.Descendants("img").SingleOrDefault();

                    string title = imgNode.GetAttributeValue("alt", "");
                    string value = inputNode.GetAttributeValue("value", "");
                    string uri = imgNode.GetAttributeValue("src", "");

                    request.Tags.Add(new TagMetadata()
                        {
                            Title = title,
                            Value = value,
                            TagUri = uri
                        });
                }

                catch (Exception ex)
                {
                    Core.Common.Logger.Default.AddEntry(Common.LogLevel.WARNING, ex);
                }
            }

            request.SelectedTag = TagMetadata.NoTag;
            return request;
        }

        private static NewThreadRequest SetRequestFormInfo(HtmlAgilityPack.HtmlNode root)
        {
            NewThreadRequest data = new NewThreadRequest();
            var formNodes = root.Descendants("input").ToArray();

            var formKeyNode = formNodes
                .Where(node => node.GetAttributeValue("name", "").Equals(THREAD_FORMKEY_KEY))
                .FirstOrDefault();

            var formCookieNode = formNodes
                .Where(node => node.GetAttributeValue("name", "").Equals(THREAD_FORMCOOKIE_KEY))
                .FirstOrDefault();

            try
            {
                data.FormKey = formKeyNode.GetAttributeValue("value", "");
                data.FormCookie = formCookieNode.GetAttributeValue("value", "");
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Could not parse newReply form data.");
            }

            return data;
        }

        #endregion

        public System.Net.Http.IHttpRequestBuilder CreateHttpRequestBuilder()
        {
            var request = new HttpPostRequestBuilder("newthread.php");
            request.AddParameter(THREAD_FORUMID_KEY, ForumId);
            request.AddParameter(THREAD_ACTION_KEY, THREAD_ACTION_VALUE);
            request.AddParameter(THREAD_FORMCOOKIE_KEY, FormCookie);
            request.AddParameter(THREAD_FORMKEY_KEY, FormKey);
            request.AddParameter(THREAD_SUBJECT_KEY, Title);
            request.AddParameter(THREAD_ICONID_KEY, SelectedTag.Value);
            request.AddParameter(THREAD_MESSAGE_KEY, Text);
            request.AddParameter(THREAD_PARSEURL_KEY, THREAD_PARSEURL_VALUE);

            request.AddParameter(IsPreview ? PREVIEW_THREAD_SUBMIT_KEY : SEND_THREAD_SUBMIT_KEY,
                IsPreview ? PREVIEW_THERAD_SUBMIT_VALUE : SEND_THREAD_SUBMIT_VALUE);

            return request;
        }
    }
}
