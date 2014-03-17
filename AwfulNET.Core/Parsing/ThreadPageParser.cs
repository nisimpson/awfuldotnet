using System;
using System.Linq;
using HtmlAgilityPack;
using System.Net;
using System.Collections.Generic;


namespace AwfulNET.Core.Parsing
{
    public static class ThreadPageParser
    {
        private const string THREAD_POST_HTML_ELEMENT = "table";
        private const string THREAD_POST_HTML_ATTRIBUTE = "class";
        private const string THREAD_POST_HTML_VALUE = "post";

        private const string THREAD_PAGE_NUMBER_ELEMENT_1 = "select";
        private const string THREAD_PAGE_NUMBER_ATTRIBUTE_1 = "data-url";
        private const string THREAD_PAGE_NUMBER_VALUE_1 = "showthread.php";
        private const string THREAD_PAGE_NUMBER_ELEMENT_2 = "option";
        private const string THREAD_PAGE_NUMBER_ATTRIBUTE_2 = "selected";
        private const string THREAD_PAGE_NUMBER_VALUE_2 = "selected";
        private const string THREAD_PAGE_NUMBER_ATTRIBUTE_3 = "value";

        /*
        public static ThreadPageMetadata ParseThreadPage(string threadID)
        {
            ThreadPageMetadata data = null;
            string uri = string.Format("http://forums.somethingawful.com/forumdisplay.php?threadid={0}&goto=newpost", threadID);
            return data;
        }

        public static ThreadPageMetadata ParseThreadPage(string threadID, int pageNumber)
        {
            ThreadPageMetadata data = null;
            string uri = string.Format("http://forums.somethingawful.com/forumdisplay.php?threadid={0}&pagenumber={1}", threadID,
                pageNumber);
            return data;
        }
        */

        internal static ThreadPageMetadata ParseThreadPage(HtmlDocument document)
        {
            return ProcessThreadPage(document.DocumentNode);
        }

        /*
        public static ThreadPageMetadata ParseThreadPage(Uri threadPageUri)
        {
            var client = new AwfulWebClient();
            var htmlDoc = client.FetchHtml(threadPageUri.AbsoluteUri);
            return ParseThreadPage(htmlDoc);
        }
        */

        private static ThreadPageMetadata ProcessThreadPage(HtmlNode top)
        {
            // first, let's generate data about the thread
            ThreadPageMetadata page = new ThreadPageMetadata()
                .ProcessParent(top)
                .ParsePageNumberAndMaxPages(top)
                .ParsePostTable(top)
                .ParseIsThreadBookmarked(top)
                .ParseTargetPostIndex();

            return page;
        }

        private static ThreadPageMetadata ParseIsThreadBookmarked(this ThreadPageMetadata page,
            HtmlNode node)
        {
            // <img src="http://fi.somethingawful.com/images/buttons/button-unbookmark.png" 
            // alt="Unbookmark" 
            // class="thread_bookmark unbookmark" 
            // title="Unbookmark thread">

            var bookmarkIconNode = node.Descendants("img")
                .Where(n => n.GetAttributeValue("class", string.Empty)
                    .Contains("thread_bookmark"))
                    .FirstOrDefault();

            if (bookmarkIconNode != null)
            {
                string value = bookmarkIconNode.GetAttributeValue("class", string.Empty);

                if (value.ToLower().Contains("unbookmark"))
                    page.IsBookmarked = true;
                else
                    page.IsBookmarked = false;
            }

            return page;
        }

        private static ThreadPageMetadata ParseTargetPostIndex(this ThreadPageMetadata page)
        {
            // the following is horribly inefficient, but easy to code and adds
            // a negligible cost penalty.

            var targetPost = page.Posts
                .Where(post => post.IsNew)
                .FirstOrDefault();

            if (targetPost != null)
            {
                var list = page.Posts.ToList();
                page.TargetPostIndex = list.IndexOf(targetPost).ToString();
            }

            return page;
        }

        private static ThreadPageMetadata ParsePostTable(this ThreadPageMetadata page, HtmlNode top)
        {
            var postArray = top.Descendants(THREAD_POST_HTML_ELEMENT)
                .Where(tables => tables.GetAttributeValue(THREAD_POST_HTML_ATTRIBUTE, "").Contains(THREAD_POST_HTML_VALUE))
                .ToArray();

            if (page.Posts == null) { page.Posts = new ThreadPostMetadata[postArray.Length]; }

            int index = 0;

            foreach (var postNode in postArray)
            {
                ThreadPostMetadata post = PostParser.ParsePost(postNode);
                post.ThreadID = page.ThreadID;
                post.ThreadPageNumber = page.PageNumber;
                post.PageIndex = index + 1;
                page.Posts[index] = post;
                index++;
            }

            // check if there is at least one post on the page. If not, there was a parsing error.
            if (page.Posts[0] == null)
                throw new Exception("Parse Error: Could not parse the posts on this page.");

            return page;
        }

        private static ThreadPageMetadata ParsePageNumberAndMaxPages(this ThreadPageMetadata page, HtmlNode top)
        {
            // now, let's parse page number
            
            int pageNumber = -1;
            int lastPage = -1;

            var currentPageNode = top.Descendants(THREAD_PAGE_NUMBER_ELEMENT_1)
                .Where(node => node.GetAttributeValue(THREAD_PAGE_NUMBER_ATTRIBUTE_1, "").Contains(THREAD_PAGE_NUMBER_VALUE_1))
                .FirstOrDefault();

            if (currentPageNode != null)
            {
                var currentPageOptions = currentPageNode.Descendants(THREAD_PAGE_NUMBER_ELEMENT_2);

                var currentPageOption = currentPageOptions
                    .Where(node => node.GetAttributeValue(THREAD_PAGE_NUMBER_ATTRIBUTE_2, "").Equals(THREAD_PAGE_NUMBER_VALUE_2))
                    .FirstOrDefault();

                var lastPageOption = currentPageOptions.LastOrDefault();

                if (currentPageOption != null)
                    int.TryParse(currentPageOption.GetAttributeValue(THREAD_PAGE_NUMBER_ATTRIBUTE_3, ""), out pageNumber);

                if (lastPageOption != null)
                    int.TryParse(lastPageOption.GetAttributeValue(THREAD_PAGE_NUMBER_ATTRIBUTE_3, ""), out lastPage);

                page.PageNumber = pageNumber;
                page.LastPage = lastPage;
            }

            else
            {
                // set page number
                page.PageNumber = 1;
                page.LastPage = 1;
            }

           

            return page;
        }

        private static ThreadPageMetadata ProcessParent(this ThreadPageMetadata page, HtmlNode top)
        {
            var titleNode = top.Descendants("span")
                .Where(node => node.GetAttributeValue("class", string.Empty)
                    .Equals("mainbodytextlarge"))
                    .FirstOrDefault();

            if (titleNode != null)
            {
                var threadNode = titleNode.Descendants()
                    .Where(node => node.GetAttributeValue("class", "").Equals("bclast"))
                    .FirstOrDefault();

                if (threadNode != null)
                {
                    string idString = threadNode.GetAttributeValue("href", "");
                    idString = idString.Split('=')[1];
                    string title = WebUtility.HtmlDecode(threadNode.InnerText);

                    page.ThreadTitle = title;
                    page.ThreadID = idString;
                }

                var navNodes = titleNode.Descendants("a")
                    .Where(node => node.GetAttributeValue("href", string.Empty).Contains("forumdisplay.php"))
                    .ToList();

                if (navNodes != null && navNodes.Count != 0)
                {
                    // parent forum is second to last link
                    var parent = navNodes[navNodes.Count - 1];
                    page.ParentForum = WebUtility.HtmlDecode(parent.InnerText).Trim();
                    string href = parent.GetAttributeValue("href", string.Empty);
                    var tokens = href.Split('=');
                    page.ParentForumId = tokens[1];
                }
            }

            return page;
        }
    }
}
