using System;
using System.Linq;
using HtmlAgilityPack;
using System.Net;

using AwfulNET.Core.Common;

namespace AwfulNET.Core.Parsing
{
    public static class ThreadParser
    {
        private const string THREAD_ID_ATTRIBUTE = "id";

        public static ThreadMetadata ParseThread(HtmlNode node)
        {
            ThreadMetadata thread = new ThreadMetadata()
                .ParseThreadID(node)
                .ParseThreadSeen(node)
                .ParseThreadTitleAndUrl(node)
                .ParseThreadAuthor(node)
                .ParseReplies(node)
                .ParseRating(node)
                .ParseSticky(node)
                .ParseColorCategory(node)
                .ParseKilledBy(node)
                .ParseIconUri(node);

            thread.LastUpdated = DateTime.Now;
            return thread;
        }

        private const string COLOR_CATEGORY0 = "bm0";
        private const string COLOR_CATEGORY1 = "bm1";
        private const string COLOR_CATEGORY2 = "bm2";

        private const string LASTPOST_CLASS = "lastpost";
        private const string LASTPOST_DATE = "date";
        private const string LASTPOST_AUTHOR = "author";

        // Parses the killed by (last post) author and post date of the thread.
        private static ThreadMetadata ParseKilledBy(this ThreadMetadata thread, HtmlNode node)
        {
            try
            {
                HtmlNode lastpost = node.Descendants()
                    .Where(n => n.GetAttributeValue("class", string.Empty).Equals(LASTPOST_CLASS))
                    .FirstOrDefault();

                HtmlNode date = lastpost.Descendants()
                    .Where(n => n.GetAttributeValue("class", string.Empty).Equals(LASTPOST_DATE))
                    .FirstOrDefault();

                HtmlNode killedBy = lastpost.Descendants()
                    .Where(n => n.GetAttributeValue("class", string.Empty).Equals(LASTPOST_AUTHOR))
                    .FirstOrDefault();

                DateTime killedByDate = default(DateTime);
                DateTime.TryParse(date.InnerText, out killedByDate);

                 thread.KilledBy = WebUtility.HtmlDecode(killedBy.InnerText.Trim());
                 thread.KilledByDate = killedByDate;
            }

            catch (Exception ex)
            {
                Logger.Default.AddEntry(LogLevel.INFO, "[KilledBy] Parse killed by failed. Setting default values and skipping.");
                Logger.Default.AddEntry(LogLevel.WARNING, ex);

                thread.KilledBy = "Unknown";
                thread.KilledByDate = DateTime.Now;
            }

            return thread;
        }

        private static ThreadMetadata ParseColorCategory(this ThreadMetadata thread, HtmlNode node)
        {
            // code block example: <td class="star bm0">
            var colorNode = node.Descendants("td").Where(aNode => aNode.GetAttributeValue("class", "")
              .Contains("star")).FirstOrDefault();

            if (colorNode != null)
            {
                thread.IsBookmarked = true;

                try
                {
                    string colorValue = colorNode.GetAttributeValue("class", "");
                    string categoryToken = colorValue.Split(new char[] { ' ' })[1];
                    thread.ColorCategory = ConvertColorValueToBookmarkCategory(categoryToken);
                }
                catch (Exception)
                {
                    thread.ColorCategory = ThreadMetadata.BookmarkColorCategory.Unknown;
                }
            }

            return thread;
        }

        private static ThreadMetadata.BookmarkColorCategory ConvertColorValueToBookmarkCategory(string value)
        {
            ThreadMetadata.BookmarkColorCategory category = default(ThreadMetadata.BookmarkColorCategory);
            switch (value)
            {
                case COLOR_CATEGORY0:
                    category = ThreadMetadata.BookmarkColorCategory.Category0;
                    break;

                case COLOR_CATEGORY1:
                    category = ThreadMetadata.BookmarkColorCategory.Category1;
                    break;

                case COLOR_CATEGORY2:
                    category = ThreadMetadata.BookmarkColorCategory.Category2;
                    break;

                default:
                    category = ThreadMetadata.BookmarkColorCategory.Unknown;
                    break;
            }

            return category;
        }

        private static ThreadMetadata ParseSticky(this ThreadMetadata thread, HtmlNode node)
        {
            var stickyNode = node.Descendants("td").Where(aNode => aNode.GetAttributeValue("class", "")
                .Contains("sticky")).FirstOrDefault();

            thread.IsSticky = stickyNode != null;
            return thread;
        }

        private static ThreadMetadata ParseIconUri(this ThreadMetadata thread, HtmlNode node)
        {
            var iconNode = node.Descendants("td")
                .Where(n => n.GetAttributeValue("class", "")
                    .Contains("icon")).FirstOrDefault();

            if (iconNode != null)
            {
                var imageNode = iconNode.Descendants("img").FirstOrDefault();
                if (imageNode != null)
                    thread.IconUri = imageNode.Attributes["src"].Value;
            }

            return thread;
        }

        private static ThreadMetadata ParseRating(this ThreadMetadata thread, HtmlNode node)
        {
            var ratingNode = node.Descendants("td")
                .Where(parent => parent.GetAttributeValue("class", "").Contains("rating"))
                .FirstOrDefault();

            if (ratingNode != null)
                ratingNode = ratingNode.Element("img");

            if (ratingNode == null)
                thread.Rating = 0;

            else
            {
                string src = ratingNode.GetAttributeValue("src", "");
                var tokens = src.Split('/');
                var ratingToken = tokens[tokens.Length - 1];
                switch (ratingToken)
                {
                    case Constants.THREAD_RATING_5:
                        thread.Rating = 5;
                        break;

                    case Constants.THREAD_RATING_4:
                        thread.Rating = 4;
                        break;

                    case Constants.THREAD_RATING_3:
                        thread.Rating = 3;
                        break;

                    case Constants.THREAD_RATING_2:
                        thread.Rating = 2;
                        break;

                    case Constants.THREAD_RATING_1:
                        thread.Rating = 1;
                        break;
                }
            }

            return thread;
        }

        private static ThreadMetadata ParseThreadCount(this ThreadMetadata thread, HtmlNode node)
        {
            // locate the thread count
            var threadCountNode = node.Descendants("a")
                .Where(value => value.GetAttributeValue("class", "").Equals("count"))
                .FirstOrDefault();

            // if we found the new post count, get and set the value
            if (threadCountNode != null)
            {
                #region if we found the thread count...

                int count = -1;
                if (Int32.TryParse(threadCountNode.InnerText.Sanitize(), out count))
                {
                    thread.NewPostCount = count;
                    thread.ShowPostCount = true;
                    //Logger.AddEntry(string.Format("AwfulThread - Thread has new unread posts: {0}", count));
                }

                else
                {
                    // no new posts, set to maximum int value for low score sorting
                    thread.NewPostCount = 0;
                    thread.ShowPostCount = true;
                    
                    //Logger.AddEntry("AwfulThread - Thread has no new posts.");
                }

                if (count > 0)
                {
                    int readPostCount = thread.ReplyCount - count;
                    int postsPerPage = Constants.POSTS_PER_THREAD_PAGE;
                    int readPage = (readPostCount / postsPerPage) + (readPostCount % postsPerPage > 0 ? 1 : 0);
                    
                    //Logger.AddEntry(string.Format("AwfulThread - posts read: {0}, last page: {1}", readPostCount, thread.TotalPages));
                }

                #endregion
            }
            else
            {
                // must be a brand new thread so don't show post count.
                // Logger.AddEntry("AwfulThread - Couldn't find the threadCountNode. no new posts.");
                thread.NewPostCount = -1;
            }

            return thread;
        }

        private static ThreadMetadata ParseReplies(this ThreadMetadata thread, HtmlNode node)
        {
            var threadRepliesNode = node.Descendants("td")
                .Where(value => value.GetAttributeValue("class", "").Equals("replies"))
                .FirstOrDefault();

            try
            {
                string repliesValue = threadRepliesNode.InnerText.Sanitize();
                int replies = 0;
                if (Int32.TryParse(repliesValue, out replies))
                {
                    thread.ReplyCount = replies;
                    
                    //Logger.AddEntry(string.Format("AwfulThread - # of replies: {0}", replies));
                }

                int postsPerPage = Constants.POSTS_PER_THREAD_PAGE;

                thread.PageCount = (replies / postsPerPage) + (replies % postsPerPage > 0 ? 1 : 0);

                //Logger.AddEntry(string.Format("AwfulThread - Max Pages: {0}", thread.TotalPages));
            }

            catch (Exception)
            {
                //Logger.AddEntry(string.Format("AwfulThread - Exception thrown while parsing replies: {0}",
                //    ex.Message));
            }

            return thread;
        }

        private static ThreadMetadata ParseThreadAuthor(this ThreadMetadata thread, HtmlNode node)
        {
            var threadAuthorParentNode = node.Descendants("td")
              .Where(value => value.GetAttributeValue("class", "").Equals("author"))
              .FirstOrDefault();

            thread.Author = threadAuthorParentNode.FirstChild.InnerText;
            
            //Logger.AddEntry(string.Format("AwfulThread - Author Name: {0}", thread.Author));

            return thread;
        }

        private static ThreadMetadata ParseThreadTitleAndUrl(this ThreadMetadata thread, HtmlNode node)
        {
            // check if thread is basic thread
            var threadTitleNode = node.Descendants("a")
            .Where(value => value.GetAttributeValue("class", "").Equals("thread_title"))
            .FirstOrDefault();
           

            if (threadTitleNode != null)
            {
                var title = threadTitleNode.InnerText.Trim();
                thread.Title = WebUtility.HtmlDecode(title);
            }

            else
            {
                // check if thread is an announcement thread
                threadTitleNode = node.Descendants("td")
                   .Where(value => value.GetAttributeValue("class", "").Equals("title"))
                   .FirstOrDefault();

                if (threadTitleNode != null)
                {
                    var titleTextNode = threadTitleNode.Descendants("a").First();
                    var title = titleTextNode.InnerText.Trim();
                    thread.Title = WebUtility.HtmlDecode(title);
                }
                else
                {
                    throw new Exception("Could not parse thread title!");
                }
            }

            //Logger.AddEntry(string.Format("AwfulThread - Thread Title: {0}", thread.Title));

            //thread.PageUri = Constants.BASE_URL + "/" + threadTitleNode.GetAttributeValue("href", "");
            //Logger.AddEntry(string.Format("AwfulThread - Thread Url: '{0}'", thread.Url));

            return thread;
        }

        private static ThreadMetadata ParseThreadSeen(this ThreadMetadata thread, HtmlNode node)
        {
            // if the node is null, then we haven't seen this thread, otherwise it's been visited
            var threadSeenNode = node.DescendantsAndSelf()
               .Where(value => value.GetAttributeValue("class", "").Contains("thread seen"))
               .FirstOrDefault();

            bool seen = threadSeenNode == null ? false : true;
            thread.IsNew = !seen;

            // if thread is new, all posts are new, so don't show post count
            if (thread.IsNew)
            {
                thread.NewPostCount = -1;
                thread.ShowPostCount = false;
            }

            // else parse thread count
            else { thread = ParseThreadCount(thread, node); }

            return thread;
        }

        private static ThreadMetadata ParseThreadID(this ThreadMetadata thread, HtmlNode node)
        {
            string id = node.GetAttributeValue(THREAD_ID_ATTRIBUTE, "").Trim();
            id = id.Replace("thread", "");

            thread.ThreadID = id;
            
            //Logger.AddEntry(string.Format("AwfulThread - ThreadID: {0}", id));

            return thread;
        }
    }
}
