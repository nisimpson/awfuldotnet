
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AwfulNET.Core.Common
{
    internal class ThreadPageConverter : HtmlConverter<ThreadPageMetadata>
    {
        public static readonly ThreadPageConverter Instance;
        public static bool ShowAvatars { get; set; }
        public static string MarkReadLabel { get; set; }
        public static string QuoteLabel { get; set; }
        public static string MarkUnreadLabel { get; set; }
        public static string EditLabel { get; set; }
        public static bool IsDarkTheme { get; set; }
        public static string DarkImagePrefix { get; set; }
        public static string LightImagePrefix { get; set; }

        static ThreadPageConverter()
        {
            Instance = new ThreadPageConverter();

            // set defaults
            ShowAvatars = true;
            MarkReadLabel = "seen";
            MarkUnreadLabel = "unseen";
            QuoteLabel = "quote";
            EditLabel = "edit";
            DarkImagePrefix = "img/dark";
            LightImagePrefix = "img/light";
        }

        private ThreadPageConverter() : base() { }

        public override string ConvertToHtml(ThreadPageMetadata page)
        {
            return SaveAndFormatPage(page, ShowAvatars);
        }

        public const string MARK_OPTION = "seen";
        public const string UNMARK_OPTION = "unseen";
        public const string EDIT_OPTION = "edit";
        public const string QUOTE_OPTION = "quote";

        private string SaveAndFormatPage(ThreadPageMetadata result, bool showAvatars)
        {
            // build html for rendering on screen
            StringBuilder pageBuilder = new StringBuilder();
            HtmlDocument doc = new HtmlDocument();

            // prev posts will be used when marking current post as unread
            ThreadPostMetadata prev = null;

            foreach (var post in result.Posts)
            {
                // the parent node
                HtmlNode postNode = doc.CreateElement("div");
                postNode.SetAttributeValue("class", post.IsNew ? "post" : "post seen");
                postNode.SetAttributeValue("id", "post" + post.PostID);

                // only show avatars if desired and avatar exists
                if (showAvatars && post.PostIconUri != null)
                {
                    // begin avatar node
                    HtmlNode avatarNode = doc.CreateElement("div");
                    avatarNode.SetAttributeValue("class", "avatar");
                    HtmlNode imageNode = doc.CreateElement("img");
                    imageNode.SetAttributeValue("src", post.PostIconUri.AbsoluteUri);
                    avatarNode.AppendChild(imageNode);
                    postNode.AppendChild(avatarNode);
                    // end avatar node
                }

                // begin info node (post author, post date)
                HtmlNode infoNode = doc.CreateElement("div");
                infoNode.SetAttributeValue("class", "info");

                HtmlNode userNode = doc.CreateElement("div");
                userNode.SetAttributeValue("class", "user");
                userNode.SetAttributeValue("id", post.PostID + "-" + "user");
                userNode.AppendChild(doc.CreateTextNode(post.Author));
                infoNode.AppendChild(userNode);

                HtmlNode dateNode = doc.CreateElement("div");
                dateNode.SetAttributeValue("class", "date");
                dateNode.AppendChild(doc.CreateTextNode(post.PostDate.ToString()));
                infoNode.AppendChild(dateNode);
                postNode.AppendChild(infoNode);
                // end info node

                // begin option button toggle node (toggles post options on the view)
                HtmlNode optionButtonNode = doc.CreateElement("img");
                optionButtonNode.SetAttributeValue("class", "option-button button");
                optionButtonNode.SetAttributeValue("src", string.Format("{0}/{1}",
                    IsDarkTheme ? DarkImagePrefix : LightImagePrefix,
                    "select.png"));
                postNode.AppendChild(optionButtonNode);

                // begin post option buttons node
                HtmlNode optionsNode = doc.CreateElement("ul");
                optionsNode.SetAttributeValue("class", "options chrome");
                var markButton = CreateOptionButton(MarkReadLabel, "mark-read.png", doc, post.PostID, MARK_OPTION);
                markButton.Attributes.Add("data-thread", post.ThreadID);
                markButton.Attributes.Add("data-index", post.ThreadIndex);
                optionsNode.AppendChild(markButton);

                if (prev != null)
                {
                    // use the post id of the prev post, and mark that as seen
                    var unmarkButton = CreateOptionButton(MarkUnreadLabel, "mark-unread.png", doc, prev.PostID, UNMARK_OPTION);
                    unmarkButton.Attributes.Add("data-thread", prev.ThreadID);
                    unmarkButton.Attributes.Add("data-index", prev.ThreadIndex);
                    optionsNode.AppendChild(unmarkButton);
                }

                optionsNode.AppendChild(CreateOptionButton(QuoteLabel, "quote.png",
                    doc, post.PostID, QUOTE_OPTION));

                if (post.IsEditable)
                {
                    optionsNode.AppendChild(CreateOptionButton(EditLabel, "edit.png", doc,
                        post.PostID, EDIT_OPTION));
                }
                // end post option buttons node

                postNode.AppendChild(optionsNode);
                // end option buttion node

                // begin post content node
                HtmlNode contentNode = doc.CreateElement("div");
                contentNode.SetAttributeValue("class", "content");

                contentNode.AppendChild(HtmlNode.CreateNode(post.PostBody));
                postNode.AppendChild(contentNode);
                // end post content node

                // mark this post as the previous post
                prev = post;

                // mark smilies as necessary
                var smilies = postNode.Descendants("img").ToList();
                foreach (var item in smilies)
                {
                    string src = item.GetAttributeValue("src", string.Empty);
                    if (src.Contains("i.somethingawful.com"))
                        item.SetAttributeValue("class", "smiley");
                }

                pageBuilder.AppendLine(postNode.OuterHtml);
            }

            return pageBuilder.ToString();
        }

        private HtmlNode CreateOptionButton(
            string title,       // the button label
            string src,         // the icon source
            HtmlDocument doc,   // DOM object to create the element
            string postID,      // the post id
            string tag)         // the button tag (for function id)
        {
            HtmlNode li = doc.CreateElement("li");

            HtmlNode img = doc.CreateElement("img");
            img.SetAttributeValue("id", tag + postID);
            img.SetAttributeValue("class", "button");
            img.SetAttributeValue("src", string.Format("{0}/{1}", IsDarkTheme ? DarkImagePrefix 
                : LightImagePrefix, src));
            li.AppendChild(img);

            HtmlNode div = doc.CreateElement("div");
            div.AppendChild(doc.CreateTextNode(title));
            li.AppendChild(div);

            return li;
        }

    }
}
