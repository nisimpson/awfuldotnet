
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace AwfulNET.Core.Rest
{
    internal class PostEditForm : ThreadForm
    {
        private string postId;
        private const string ACTION = "updatepost";

        public string PostID
        {
            get { return postId; }
            set { postId = value; }
        }

        private PostEditForm(ThreadPostMetadata post)
        {
            this.postId = post.PostID;
            ParseUrls = true;
            BookmarkThread = true;
        }

        private PostEditForm(string postId)
        {
            this.postId = postId;
            ParseUrls = true;
            BookmarkThread = true;
        }

        internal static PostEditForm FromHtmlDocument(
            string postId, HtmlAgilityPack.HtmlDocument doc)
        {
            string body = doc.DocumentNode
                .Descendants("textarea")
                .FirstOrDefault()
                .InnerText;

            var inputs = doc.DocumentNode
                .Descendants("input")
                .ToDictionary<HtmlNode, string>(node => node.GetAttributeValue("name", node.ToString()));

            string actual = inputs["postid"].GetAttributeValue("value", null);

            if (actual != postId)
                throw new InvalidOperationException("PostIds do not match!");

            PostEditForm form = new PostEditForm(postId);
            form.Message = WebUtility.HtmlDecode(body);
            return form;
        }

        public override IHttpRequestBuilder CreateHttpRequestBuilder()
        {
            HttpPostRequestBuilder builder = new MultipartPostRequestBuilder("/editpost.php");
            builder.AddParameter("action", ACTION);
            builder.AddParameter("postid", postId);
            builder.AddParameter("message", Message);
            if (BookmarkThread)
                builder.AddParameter("bookmark", "yes");
            if (ParseUrls)
                builder.AddParameter("parseurl", "yes");
            builder.AddParameter("submit", "Save Changes");
            return builder;
        }
    }

    internal class ThreadEditResponse : ThreadFormResponse
    {
        private readonly ThreadPostMetadata Post;


        public ThreadEditResponse(ThreadPostMetadata post, IThreadForm form, bool success) :
			base(form, success)
        {
            this.Post = post;
        }

        public override Task<ThreadPageMetadata> LoadRedirectPageAsync()
        {
            throw new NotImplementedException();

			/*
            ThreadMetadata thread = new ThreadMetadata() { ThreadID = Post.ThreadID };
            var page = await thread.GetThreadPageAsync(Post.ThreadPageNumber);
            page.TargetPostIndex = Post.ThreadIndex;
            return page;
            */
        }
    }
}
