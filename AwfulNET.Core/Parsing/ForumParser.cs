using System;
using System.Linq;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Net;
using AwfulNET.Core.Common;


namespace AwfulNET.Core.Parsing
{
    public static class ForumParser
    {
        #region Forum Parsing

        public static bool UseWhitelist { get; set; }

        private static readonly List<string> ForumBlacklist = new List<string>()
        {
            "Main",
            "Discussion",
            "The Finer Arts",
            "The Community",
            "Archives",
            "The Crackhead Clubhouse",
            "Retarded Forum for Assholes",
        };

        private static readonly List<string> ForumWhitelist = new List<string>()
        {
            "Pet Island"
        };


        public static IEnumerable<ForumMetadata> ParseShallowForumList(HtmlDocument doc)
        {
            List<ForumMetadata> forums = new List<ForumMetadata>(100);
            if (doc == null)
                return forums;

            try
            {
                var parent = doc.DocumentNode;

                var title = parent.Descendants("title").FirstOrDefault();
                if (title != null && title.InnerText.ToLower().Contains("banned"))
                    throw new BannedAccountException("Cannot parse forums using a banned account.");

                // get all unique links off the page with hrefs containing "forumdisplay.php"
                // and with nonempty class attributes
                var forumAnchors = parent.Descendants("a")
                    .Where(anchor =>
                        anchor.GetAttributeValue("href", string.Empty).Contains("forumdisplay.php") && 
                        !anchor.GetAttributeValue("class", "empty").Equals("empty"))
                    .Distinct(new GenericEqualityComparer<HtmlNode>(
                        (node1, node2) => node1.Attributes["href"].Value == node2.Attributes["href"].Value,
                        (node) => node.Attributes["href"].GetHashCode()))
                    .ToList();

                foreach(var anchor in forumAnchors)
                {
                    // expected href: forumdisplay.php?forumid=<id>
                    if (!string.IsNullOrEmpty(anchor.InnerText))
                    {
                        string href = anchor.Attributes["href"].Value;
                        string forumID = href.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries)[1];
                        string forumTitle = WebUtility.HtmlDecode(anchor.InnerText);
                        ForumMetadata forum = new ForumMetadata() { ForumID = forumID, ForumName = forumTitle };
                        forum.Category = forum.GetGroup();
                        forums.Add(forum);
                    }
                }

            }
            catch (BannedAccountException bae) { throw bae; }
            catch (Exception) { }
            return forums;
        }

        public static IEnumerable<ForumMetadata> ParseForumList(HtmlDocument doc)
        {
            List<ForumMetadata> forums = new List<ForumMetadata>(100);
            
            if (doc == null)
                return forums;

            var parent = doc.DocumentNode;

            var title = parent.Descendants("title").FirstOrDefault();
            if (title != null && title.InnerText.ToLower().Contains("banned"))
                throw new BannedAccountException("Cannot parse forums using a banned account.");
           
            var selectNode = parent.Descendants("select")
                .Where(node => node.GetAttributeValue("name", "").Equals("forumid"))
                .FirstOrDefault();

            if (selectNode != null)
            {
                var forumNodes = selectNode.Descendants("option").ToArray();

                foreach (var node in forumNodes)
                {
                    var forum = CreateForumMetadata(node);
                    if (forum != null)
                        forums.Add(forum);
                }
            }

            return forums.RepairForumList();      
        }

        private static IEnumerable<ForumMetadata> RepairForumList(this List<ForumMetadata> forums)
        {
            // enumerate through the collection and fix parent / child relationships
            var enumerator = forums.GetEnumerator();
            ForumMetadata parent = null;
            while(enumerator.MoveNext())
            {
                bool isParent = enumerator.Current.LevelCount == 2;
                // if the forum is a parent (top level) forum,
                // set the forum group of the following forums
                // to that of itself, until we reach another parent
                if (isParent)
                    parent = enumerator.Current;

                if (parent != enumerator.Current)
                {
                    enumerator.Current.Category = parent.Category;
                }
            }
            return forums;
        }

        private static ForumMetadata CreateForumMetadata(HtmlNode node)
        {
            ForumMetadata result = null;

            var value = node.Attributes["value"].Value;
            int id = -1;

            // instantiate only if the forum has a valid id
            if (int.TryParse(value, out id) && id > -1)
            {
                result = new ForumMetadata() { ForumID = value }
                    .ParseForumName(node)
                    .ParseForumLevelCount(node)
                    .ParseForumGroup();
            }

            return result;
        }

        private static ForumMetadata ParseForumGroup(this ForumMetadata data)
        {
            if (data != null)
                data.Category = data.GetGroup();

            return data;
        }

        private static ForumMetadata ParseForumName(this ForumMetadata data, HtmlNode node)
        {
            if (data != null)
            {
                string name = node.NextSibling.InnerText;
                name = WebUtility.HtmlDecode(name);
                if (name != String.Empty)
                {
                    name = name.Replace("-", "");
                    name = name.Trim();
                    data.ForumName = name;
                }

                if (UseWhitelist && !ForumWhitelist.Contains(name))
                    data = null;

                else if (ForumBlacklist.Contains(name))
                    data = null;
            }

            return data;
        }

        private static ForumMetadata ParseForumLevelCount(this ForumMetadata data, HtmlNode node)
        {
            if (data != null)
            {
                string name = node.NextSibling.InnerText;
                name = WebUtility.HtmlDecode(name);
                if (name != String.Empty)
                {
                    var tokens = name.Split(' ');
                    var countToken = tokens[0];
                    int count = countToken.Length;
                    data.LevelCount = count;
                }
            }
           
            return data;
        }

        /// <summary>
        /// Parses forum descriptions from home page (http://forums.somethingawful.com).
        /// </summary>
        /// <param name="forums">A collection of existing forum metadata</param>
        /// <param name="doc">The html from the aformentioned page.</param>
        /// <returns>The specified collection, with descriptions mapped to their respective forums.</returns>
        public static IEnumerable<ForumMetadata> ParseForumDescription(this IEnumerable<ForumMetadata> forums,
            HtmlDocument doc)
        {
            // first, place each forum into a dictionary, with the name as the key, and the forum as the value.
            var forumMap = forums.ToDictionary<ForumMetadata, string>(forum => forum.ForumName);

            // next, build a collection of html nodes containing description information.
            var descriptionNodes = doc.DocumentNode.Descendants("tr")
                .Where(node => node.GetAttributeValue("class", string.Empty).Contains("forum_"));

            // last, map descriptions to their respective forums.
            foreach (var node in descriptionNodes)
            {
                HtmlNode titleNode = node.Descendants("a").Where(n => n.GetAttributeValue("class", string.Empty).Equals("forum"))
                    .FirstOrDefault();

                if (titleNode != null)
                {
                    string title = titleNode.InnerText;
                    ForumMetadata forum = null;
                    if (forumMap.TryGetValue(title, out forum))
                    {
                        string description = titleNode.GetAttributeValue("title", string.Empty);
                        forum.ForumDescription = description;
                    }
                }
            }

            return forums;
        }

        #endregion

        public static ForumPageMetadata ParseForumPage(HtmlDocument doc)
        {
            var top = doc.DocumentNode;
            var page = new ForumPageMetadata();
            int pageNumber = -1;

            // check for a possible ban
            var title = top.Descendants("title").FirstOrDefault();
            if (title != null && title.InnerText.ToLower().Contains("banned"))
                throw new BannedAccountException("Cannot parse using a banned account.");

            // first, let's find the forum id
            var formNode = top.Descendants("form")
                .Where(node => node.GetAttributeValue("id", "").Equals("ac_timemachine"))
                .FirstOrDefault();

            if (formNode != null)
            {
                string idString = formNode.GetAttributeValue("action", "");
                // strip undesiriable stuff off
                idString = idString.Replace("/forumdisplay.php?", "");
                idString = idString.Split('=').Last();
                page.ForumID = idString;
            }

            // then, let's find the page number
            var pageNumberNode = top.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "").Equals("curpage"))
                .FirstOrDefault();

            if (pageNumberNode != null)
            {
                var pageNumberText = pageNumberNode.InnerText;
                if (!int.TryParse(pageNumberText, out pageNumber)) { pageNumber = -1; }
            }

            page.PageNumber = pageNumber;

            HandleMaxPages(page, top);
            HandleThreads(page, top);
            HandleFilters(page, top);
            return page;
        }

        private static void HandleFilters(ForumPageMetadata page, HtmlNode top)
        {
            var tagsListNode = top.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                    .Equals("thread_tags"))
                .FirstOrDefault();

            if (null != tagsListNode)
            {
                var filterNodes = tagsListNode.Descendants("a").ToList();
                var filters = new List<FilterTagMetadata>(filterNodes.Count) { FilterTagMetadata.NoFilter };
                page.Filters = filters;
                foreach (var filterNode in filterNodes)
                {
                    string href = filterNode.GetAttributeValue("href", string.Empty);
                    string title = filterNode.FirstChild.GetAttributeValue("title", string.Empty);
                    string src = filterNode.FirstChild.GetAttributeValue("src", string.Empty);
                    FilterTagMetadata filter = new FilterTagMetadata()
                    {
                        FilterUri = WebUtility.HtmlDecode(href),
                        Title = WebUtility.HtmlDecode(title),
                        TagUri = WebUtility.HtmlDecode(src)
                    };

                    filters.Add(filter);
                }
            }
        }

        private static void HandleMaxPages(ForumPageMetadata page, HtmlNode node)
        {
            var maxPagesNode = node.Descendants("div")
                .Where(n => n.GetAttributeValue("class", "").Contains("pages"))
                .FirstOrDefault();

            if (maxPagesNode == null)
            {
                //Logger.AddEntry("AwfulForumPage - Could not parse maxPagesNode.");
                page.PageCount = 1;
            }
            else
            {
                page.PageCount = ExtractMaxForumPages(maxPagesNode);
                //Logger.AddEntry(string.Format("AwfulForumPage - maxPagesNode parsed. Value: {0}", page.Parent.TotalPages));
            }
        }

        private static int ExtractMaxForumPages(HtmlNode node)
        {
            int max = 1;
            var selectNodes = node.Descendants("option").ToArray();
            if (null != selectNodes)
            {
                var lastPageNode = selectNodes.LastOrDefault();
                if (null != lastPageNode)
                {
                    string value = selectNodes.Last().GetAttributeValue("value", "1");
                    int.TryParse(value, out max);
                }
            }
            return max;
        }

        private static void HandleThreads(ForumPageMetadata page, HtmlNode node)
        {
            var forumThreadsTable = node.Descendants("table")
                   .Where(n => n.Id.Equals("forum")).FirstOrDefault();

            // do we have any thread items to parse?
            if (forumThreadsTable != null)
            {
                var threadList = forumThreadsTable.Descendants("tbody").First();
                var threadsInfo = threadList.Descendants("tr");
                page.Threads = GenerateThreadData(page, threadsInfo);
            }
            else { page.Threads = new List<ThreadMetadata>(); }
        }

        // TODO: Remember to sort thread data by new posts
        private static IList<ThreadMetadata> GenerateThreadData(ForumPageMetadata page, IEnumerable<HtmlNode> threadsInfo)
        {
            //Logger.AddEntry("AwfulForumPage - Generating thread data...");

            List<ThreadMetadata> data = new List<ThreadMetadata>();
            foreach (var node in threadsInfo)
            {
                var thread = ThreadParser.ParseThread(node);
                data.Add(thread);
            }

            return data;
        }

      
    }
}
