using System;
using System.Linq;
using HtmlAgilityPack;
using System.Net;

using AwfulNET.Core.Common;
using System.Diagnostics;
using System.Collections.Generic;

namespace AwfulNET.Core.Parsing
{
    public static class PostParser
    {
        private const string POST_ID_ATTRIBUTE = "id";
        private const string POST_INDEX_ATTRIBUTE = "data-idx";

        public static ThreadPostMetadata ParsePost(HtmlNode postNode)
        {
            ThreadPostMetadata post = new ThreadPostMetadata()
                .ParseIsIgnored(postNode)
                .ParseIconAndAvatarText(postNode)
                .ParseAuthor(postNode)
                .ParseContent(postNode)
                .ParsePostDate(postNode)
                .ParsePostID(postNode)
                .ParseUserID(postNode)
                .ParsePostThreadIndexAndMarkUrl(postNode)
                .ParseIsEditable(postNode)
                .ParseHasSeen(postNode);

            return post;
        }

        private static ThreadPostMetadata ParseIsIgnored(this ThreadPostMetadata post, HtmlNode postNode)
        {
            post.IsIgnored = false;
            var classAttribute = postNode.GetAttributeValue("class", string.Empty);
            if (classAttribute.ToLower().Contains("ignored"))
                post.IsIgnored = true;

            return post;
        }

        private static ThreadPostMetadata ParseIsEditable(this ThreadPostMetadata post, HtmlNode postNode)
        {
            var postbuttons = postNode.Descendants("ul")
                .Where(node => node.GetAttributeValue("class", string.Empty).Equals("postbuttons"))
                .SingleOrDefault();

            if (postbuttons != null)
            {
                var editButton = postbuttons.Descendants("img")
                    .Where(node => node.GetAttributeValue("alt", string.Empty).Contains("Edit"))
                    .SingleOrDefault();

                post.IsEditable = editButton != null;
            }

            return post;
        }

        private static ThreadPostMetadata ParseContent(this ThreadPostMetadata post, HtmlNode postNode)
        {
            var content = postNode.Descendants("td")
                .Where(node => node.GetAttributeValue("class", "")
                    .Equals("postbody"))
                .FirstOrDefault();

            if (content == null)
                throw new ArgumentException("Content should not be null");

            // convert td node to div node
            content.Name = "div";

            // add edited by class to span; malformed html...
            var editedBy = content.Descendants("span")
                .Where(n => 
                    n.PreviousSibling != null &&
                    n.PreviousSibling.Name.Equals("p"))
                .FirstOrDefault();

            if (editedBy != null)
            {
                // remove malformed <p> tag
                editedBy.PreviousSibling.Remove();

                // change editedby to <p> tag
                editedBy.SetAttributeValue("class", "editedby");
                editedBy.Name = "p";
            }

            // remove comments
            var comments = content.Descendants("#comment").ToArray();
            foreach (var comment in comments)
                comment.Remove();

            // reform text nodes
            var text = content.Descendants("#text").ToArray();
            foreach (var textNode in text)
            {
                // remove empty white space
                if (string.IsNullOrWhiteSpace(textNode.InnerText))
                    textNode.Remove();
            }

            post.PostBody = content.OuterHtml;
            return post;
        }

        private static ThreadPostMetadata ParseIconAndAvatarText(this ThreadPostMetadata post, HtmlNode postNode)
        {
            var titleNode = postNode.Descendants()
                .Where(node => node.GetAttributeValue("class", string.Empty).Contains("title"))
                .FirstOrDefault();

            if (titleNode != null)
            {
                // post avatar image
                var uriNode = titleNode.Descendants("img").FirstOrDefault();
                post.PostIconUri = uriNode == null
                    ? null
                    : new Uri(uriNode.GetAttributeValue("src", string.Empty), UriKind.Absolute);
                post.ShowIcon = post.PostIconUri == null ? false : true;

                // post avatar text
                var avatarTextNode = titleNode.DescendantsAndSelf()
                    .Where(node => !string.IsNullOrWhiteSpace(node.InnerText))
                    .FirstOrDefault();

                post.PostAvatarText = avatarTextNode == null
                    ? string.Empty
                    : avatarTextNode.InnerText.Trim();
            }

            return post;
        }

        private static ThreadPostMetadata ParseUserID(this ThreadPostMetadata post, HtmlNode postNode)
        {
            var userIDNode = postNode.Descendants()
                .Where(node => node.GetAttributeValue("class", "").Contains("userid"))
                .FirstOrDefault();

            if (userIDNode != null)
            {
                string value = userIDNode.GetAttributeValue("class", "");
                value = value.Replace("userinfo userid-", "");
                post.UserID = value;
            }

            return post;
        }

        private static ThreadPostMetadata ParsePostDate(this ThreadPostMetadata post, HtmlNode postNode)
        {
            var postDateNode = postNode.Descendants()
              .Where(node => node.GetAttributeValue("class", "").Equals("postdate"))
              .FirstOrDefault();

            var postDateString = postDateNode == null ? string.Empty : postDateNode.InnerText;

            try
            {
                post.PostDate = postDateNode == null ? default(DateTime) :
                    Convert.ToDateTime(postDateString.SanitizeDateTimeHTML());
            }

            catch (Exception)
            {
                post.PostDate = DateTime.Parse(postDateString.SanitizeDateTimeHTML(), System.Globalization.CultureInfo.InvariantCulture);
            }

            return post;
        }

        private static ThreadPostMetadata ParseHasSeen(this ThreadPostMetadata post, HtmlNode postNode)
        {
            var hasSeenMarker = postNode.Descendants("tr")
                .Where(node => node.GetAttributeValue("class", "").Contains(Constants.LASTREAD_FLAG))
                .FirstOrDefault();

            var hasNotSeenMarker = postNode.Descendants("img")
            .Where(node => node.GetAttributeValue("src", "")
                .Equals(Constants.NEWPOST_GIF_URL)).FirstOrDefault();

            bool firstGuess = hasSeenMarker != null;
            bool secondGuess = hasNotSeenMarker == null;

            post.IsNew = !(firstGuess || secondGuess);
            return post;
        }

        private static ThreadPostMetadata ParseAuthor(this ThreadPostMetadata post, HtmlNode postNode)
        {
            var authorNode = postNode.Descendants().FirstOrDefault(node => (node.GetAttributeValue("class", "").Equals("author")) ||
                                                                           (node.GetAttributeValue("class", "").Equals("author platinum")) ||
                                                                           (node.GetAttributeValue("class", "").Equals("author op")) ||
                                                                           (node.GetAttributeValue("title", "").Equals("Administrator")) ||
                                                                           (node.GetAttributeValue("title", "").Equals("Moderator")));

            if (authorNode != null)
            {
                var type = authorNode.GetAttributeValue("title", "");
                switch (type)
                {
                    case "Administrator":
                        post.AuthorType = ThreadPostMetadata.PostType.Administrator;
                        break;

                    case "Moderator":
                        post.AuthorType = ThreadPostMetadata.PostType.Moderator;
                        break;
                    case "Platinum User":
                        post.AuthorType = ThreadPostMetadata.PostType.Platinum;
                        break;
                    default:
                        post.AuthorType = ThreadPostMetadata.PostType.Standard;
                        break;
                }

                post.Author = authorNode.InnerText;
            }

            else
            {
                post.Author = "AwfulPoster";
                post.AuthorType = ThreadPostMetadata.PostType.Standard;
            }

            return post;
        }

        private static ThreadPostMetadata ParsePostThreadIndexAndMarkUrl(this ThreadPostMetadata post, HtmlNode postNode)
        {
            var seenUrlNode = postNode.Descendants("a")
                .Where(node => node.GetAttributeValue("class", "").Contains(MARK_THREAD_CLASS_ID))
                .FirstOrDefault();

            if (seenUrlNode != null)
            {
                // make sure the string is in the right format so the uri class can parse correctly.
                var nodeValue = seenUrlNode.GetAttributeValue("href", "");
                post.MarkPostUri = new Uri(string.Format("http://forums.somethingawful.com{0}", 
                    WebUtility.HtmlDecode(nodeValue)), UriKind.Absolute);
            }

            post.ThreadIndex = postNode.GetAttributeValue(POST_INDEX_ATTRIBUTE, string.Empty);
            return post;
        }

        private static ThreadPostMetadata ParsePostID(this ThreadPostMetadata post, HtmlNode postNode)
        {
            string idValue = postNode.GetAttributeValue(POST_ID_ATTRIBUTE, "");

            string result = null;

            if (idValue != null)
            {
                string postID = idValue.Replace("post", "");
                result = postID;
            }

            post.PostID = result;
            return post;
        }

        public const string MARK_THREAD_CLASS_ID = "lastseen_icon";
    }
}
