using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Rest
{
    internal class ThreadReplyForm : ThreadForm
    {
        private string formKey;
        private string formCookie;
        private string threadid;
        private const string ACTION = "postreply";
        private const string SUBMIT = "Submit Reply";
        private const string PREVIEW = "Preview Reply";

        private ThreadReplyForm()
        {
            BookmarkThread = true;
            ParseUrls = true;
        }

        public static ThreadReplyForm FromHtmlDocument(HtmlDocument doc)
        {
            ThreadReplyForm form = new ThreadReplyForm();
            string body = doc.DocumentNode
                .Descendants("textarea")
                .FirstOrDefault()
                .InnerText;

            var inputs = doc.DocumentNode
                .Descendants("input")
                .ToDictionary<HtmlNode, string>(node => node.GetAttributeValue("name", node.ToString()));

            form.threadid = inputs["threadid"].GetAttributeValue("value", null);
            form.formKey = inputs["formkey"].GetAttributeValue("value", null);
            form.formCookie = inputs["form_cookie"].GetAttributeValue("value", null);
            form.Message = body;
            return form;
        }

        public override IHttpRequestBuilder CreateHttpRequestBuilder()
        {
            HttpPostRequestBuilder builder = new HttpPostRequestBuilder("newreply.php");
            builder.AddParameter("action", ACTION);
            builder.AddParameter("threadid", threadid);
            builder.AddParameter("formkey", formKey);
            builder.AddParameter("form_cookie", formCookie);
            builder.AddParameter("message", Message);

            if (BookmarkThread)
                builder.AddParameter("bookmark", "yes");

            if (ParseUrls)
                builder.AddParameter("parseurl", "yes");

            builder.AddParameter("submit", SUBMIT);
            return builder;
        }
    }

    internal class ThreadReplyResponse : ThreadFormResponse
    {
        public ThreadReplyResponse(IThreadForm form, bool success)
            : base(form, success) { }

        public override Task<ThreadPageMetadata> LoadRedirectPageAsync()
        {
            throw new NotImplementedException();
        }
    }

}
