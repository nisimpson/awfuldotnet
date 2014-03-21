using System;
using System.Linq;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Net;

using AwfulNET.Core.Rest;

namespace AwfulNET.Core.Parsing
{
    public static class PrivateMessageParser
    {
        private const string NEW_MESSAGE_AUTHOR = "author";
        private const string NEW_MESSAGE_POSTBODY = "postbody";
        private const string NEW_MESSAGE_TOUSER = "touser";
        private const string NEW_MESSAGE_TITLE = "title";
        private const string NEW_MESSAGE_MESSAGE = "message";
        private const string NEW_MESSAGE_FOWARD = "forward";
        private const string NEW_MESSAGE_POSTICON = "posticon";
        private const string NEW_MESSAGE_INPUT_TAG = "input";
        private const string NEW_MESSAGE_ICON_TAG = "div";

        private const string NEW_MESSAGE_UNKNOWN_AUTHOR = "Mystery Goon?";
        private const string NEW_MESSAGE_PRIVATEMESSAGEID = "privatemessageid";

        private const string PRIVATE_MESSAGE_ICON_NEW = "newpm.gif";
        private const string PRIVATE_MESSAGE_ICON_READ = "pm.gif";
        private const string PRIVATE_MESSAGE_ICON_CANCELLED = "trashcan.gif";
        private const string PRIVATE_MESSAGE_ICON_REPLIED = "pmreplied.gif";
        private const string PRIVATE_MESSAGE_ICON_FORWARDED = "pmforwarded.gif";

        private const string PRIVATE_MESSAGE_UNKNOWN_AUTHOR = "Unknown Author";
        private const string PRIVATE_MESSAGE_UNKNOWN_TITLE = "Unknown Title";

        private const string PRIVATE_MESSAGE_EMPTY_FOLDER_TEXT = "There are no messages to display in this folder for this time period.";

        #region public methods

        /// <summary>
        /// TODO: ADD SUMMARY.
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static ICollection<PrivateMessageFolderMetadata> ParseFolderList(HtmlDocument doc)
        {
            List<PrivateMessageFolderMetadata> folders = new List<PrivateMessageFolderMetadata>();
            // get select option nodes
            var top = doc.DocumentNode;
            var selectNode = top.Descendants("select")
                .Where(node => node.GetAttributeValue("name", string.Empty).Equals("folderid"))
                .FirstOrDefault();

            if (selectNode != null)
            {
                var optionNodes = selectNode.Descendants("option");
                foreach (var option in optionNodes)
                {
                    try
                    {
                        PrivateMessageFolderMetadata folder = new PrivateMessageFolderMetadata();
                        folder.Messages = new List<PrivateMessageMetadata>();
                        string name = option.NextSibling.InnerText.Trim();
                        string value = option.GetAttributeValue("value", string.Empty);
                        folder.FolderId = value;
                        folder.Name = name;
                        folders.Add(folder);
                    }
                    catch (Exception) { }
                }
            }
            return folders;
        }
        /// <summary>
        /// Parses the html from SA's new message web page for a collection of valid message tags.
        /// </summary>
        /// <param name="doc">The html document.</param>
        /// <returns>A collection of valid private message icons.</returns>
        public static ICollection<TagMetadata> ParseNewPrivateMessageIcons(HtmlDocument doc)
        {
            var top = doc.DocumentNode;
            var iconArray = top.Descendants(NEW_MESSAGE_ICON_TAG)
                .Where(node => node.GetAttributeValue("class", string.Empty).Equals(NEW_MESSAGE_POSTICON))
                .ToArray();

            List<TagMetadata> result = new List<TagMetadata>();
            foreach (var icon in iconArray)
            {
                var inputNode = icon.Descendants(NEW_MESSAGE_INPUT_TAG).FirstOrDefault();
                var imgNode = icon.Descendants("img").FirstOrDefault();

                if (inputNode == null && imgNode == null)
                    result.Add(TagMetadata.NoTag);

                else
                {
                    string iconValue = inputNode.GetAttributeValue("value", string.Empty);
                    string iconuri = string.Empty;
                    string title = string.Empty;

                    iconuri = imgNode.GetAttributeValue("src", string.Empty);
                    title = imgNode.GetAttributeValue("alt", string.Empty);
                    result.Add(new TagMetadata() { Title = title, Value = iconValue, TagUri = iconuri });
                }
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static IList<PrivateMessageMetadata> ParseMessageList(HtmlDocument doc)
        {
            List<PrivateMessageMetadata> messages = new List<PrivateMessageMetadata>();
            var top = doc.DocumentNode;
            var messagesNode = top.Descendants("table").FirstOrDefault();
            var messageTable = messagesNode.Descendants("tr").ToArray();

            // remove last element from the table
            messageTable[messageTable.Length - 1] = null;

            // remove first element from the table
            messageTable[0] = null;

            foreach (var item in messageTable)
            {

                if (item != null && string.IsNullOrEmpty(item.GetAttributeValue("class", string.Empty)) == true)
                {
                    if (item.InnerText.Contains(PRIVATE_MESSAGE_EMPTY_FOLDER_TEXT)) break;
                    var message = new PrivateMessageMetadata();
                    var rows = item.Descendants("td").ToArray();
                    var statusNode = rows[0];
                    message.Status = GetMessageStatusFromNode(statusNode);
                    // thread tag
                    var tagNode = rows.SingleOrDefault(row => row.GetAttributeValue("class", string.Empty).Contains("icon"));
                    message.IconUri = GetMessageIconUriFromNode(tagNode);
                    // title node has our subject and message id
                    var titleNode = rows[2];
                    message.Subject = GetMessageTitleFromNode(titleNode);
                    message.PrivateMessageId = GetMessageIDFromNode(titleNode);
                    // author node is next <td>
                    var authorNode = rows[3];
                    message.From = GetMessageAuthorFromNode(authorNode);
                    // postmark node is next <td>
                    var postmarkNode = rows[4];
                    message.PostDate = GetPostMarkFromNode(postmarkNode);
                    messages.Add(message);
                }
            }

            return messages;
        }
        /// <summary>
        /// Parses the html from SA's new message page and constructs a private message request
        /// object.
        /// </summary>
        /// <param name="doc">The html document.</param>
        /// <returns>A private message request, which can be sent or discarded.</returns>
        public static PrivateMessageRequest ParseNewPrivateMessageFormDocument(HtmlDocument doc)
        {
            var pmRequest = new PrivateMessageRequest();
            var top = doc.DocumentNode;
            var inputArray = top.Descendants("input").ToArray();

            string toUser = GetInputValue(inputArray, NEW_MESSAGE_TOUSER);
            string title = GetInputValue(inputArray, NEW_MESSAGE_TITLE);
            string forward = GetInputValue(inputArray, NEW_MESSAGE_FOWARD);

            var messageNode = top.Descendants("textarea")
                .Where(node => node.GetAttributeValue("name", string.Empty).Equals(NEW_MESSAGE_MESSAGE))
                .SingleOrDefault();

            string message = messageNode == null ? string.Empty : messageNode.InnerText;

            pmRequest.Body = message;
            pmRequest.To = toUser;
            pmRequest.Subject = title;
            pmRequest.IsForward = forward != string.Empty;
            pmRequest.TagOptions = ParseFormTagOptions(doc);

            return pmRequest;
        }

        private static List<TagMetadata> ParseFormTagOptions(HtmlDocument doc)
        {
            var tagNodes = doc.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", string.Empty).Equals("posticon"));

            var list = new List<TagMetadata>() { TagMetadata.NoTag };

            list.AddRange(tagNodes.Select(node => ParseTag(node)));
            return list;
        }

        private static TagMetadata ParseTag(HtmlNode node)
        {
            TagMetadata tag = new TagMetadata();
            var imgNode = node.Descendants("img").FirstOrDefault();
            if (imgNode != null)
            {
                tag.TagUri = imgNode.GetAttributeValue("src", string.Empty);
                tag.Title = imgNode.GetAttributeValue("alt", string.Empty);
            }

            var inputNode = node.Descendants("input").FirstOrDefault();
            if (inputNode != null)
                tag.Value = inputNode.GetAttributeValue("value", string.Empty);

            return tag;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static PrivateMessageMetadata ParsePrivateMessageDocument(HtmlDocument doc)
        {
            var pm = new PrivateMessageMetadata();
            var top = doc.DocumentNode;

            // **** PARSE BODY *****
            var postBodyNode = top.Descendants("td")
                .Where(node => node.GetAttributeValue("class", string.Empty).Equals(NEW_MESSAGE_POSTBODY))
                .SingleOrDefault();

            if (postBodyNode != null)
            {
                pm.RawHtml = postBodyNode.InnerHtml;
                pm.RawText = postBodyNode.InnerText;
            }

            // ***** PARSE AUTHOR *****
            var authorNode = top.Descendants("dt")
                .Where(node => node.GetAttributeValue("class", string.Empty).Equals(NEW_MESSAGE_AUTHOR))
                .FirstOrDefault();

            pm.From = authorNode == null ? NEW_MESSAGE_UNKNOWN_AUTHOR : authorNode.InnerText;

            // ***** PARSE MESSAGE ID *****
            var messageIdNode = top.Descendants(NEW_MESSAGE_INPUT_TAG)
                .Where(node => node.GetAttributeValue("name", string.Empty).Equals(NEW_MESSAGE_PRIVATEMESSAGEID))
                .FirstOrDefault();

            int id = 0;
            if (messageIdNode != null)
            {
                string value = messageIdNode.GetAttributeValue("value", string.Empty);
                int.TryParse(value, out id);
            }
            pm.PrivateMessageId = id.ToString();

            // ***** PARSE SUBJECT *****
            var subjectNode = top.Descendants("div")
                .Where(node => node.GetAttributeValue("class", string.Empty).Equals("breadcrumbs"))
                .FirstOrDefault();

            if (subjectNode != null)
            {
                string subject = subjectNode.ParseTitleFromBreadcrumbsNode();
                pm.Subject = subject;
            }

            // ***** PARSE POST MARK *****
            var postmarkNode = top.Descendants("td")
                .Where(node => node.GetAttributeValue("class", string.Empty)
                    .Equals("postdate"))
                .FirstOrDefault();

            if (postmarkNode != null)
            {
                string postmark = postmarkNode.InnerText;
                try { pm.PostDate = Convert.ToDateTime(postmark); }
                catch (Exception) { pm.PostDate = DateTime.Parse(postmark, System.Globalization.CultureInfo.InvariantCulture); }
            }

            return pm;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlDocument"></param>
        /// <returns></returns>
        public static PrivateMessageFolderMetadata ParsePrivateMessageFolder(HtmlDocument htmlDocument)
        {
            PrivateMessageFolderMetadata folder = null;
            var top = htmlDocument.DocumentNode;
            var currentFolderNode = top.Descendants("div")
                .Where(node => node.GetAttributeValue("class", string.Empty).Equals("breadcrumbs"))
                .FirstOrDefault();

            if (currentFolderNode != null)
            {
                
                // *************************************************************
                // THIS IS CURRENTLY BROKEN ON SA -- THE TITLE OF THE FOLDER IS *NOT* WHAT'S DISPLAYED ON THE BREADCRUMBS //
                string name = currentFolderNode.ParseTitleFromBreadcrumbsNode();
                // *************************************************************
                var idString = GetInputValue(top.Descendants("input").ToArray(), "thisfolder");
                
                folder = new PrivateMessageFolderMetadata() { FolderId = idString };

                var messages = ParseMessageList(htmlDocument);
                folder.Messages = messages;

                foreach (var message in messages)
                {
                    message.FolderId = folder.FolderId;   
                }
            }

            return folder;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlDocument"></param>
        /// <returns></returns>
        public static PrivateMessageFolderEditor ParseEditFolderPage(HtmlDocument htmlDocument)
        {
            PrivateMessageFolderEditor request = null;
            var top = htmlDocument.DocumentNode;
            var inputArray = top.Descendants("input");
            if (inputArray != null)
            {
                request = new PrivateMessageFolderEditor();
                int highest = 0;
                var highestNode = inputArray
                    .Where(node => node.GetAttributeValue("name", string.Empty).Equals("highest"))
                    .FirstOrDefault();

                if (highestNode != null) { int.TryParse(highestNode.GetAttributeValue("value", string.Empty), out highest); }
                request.HighestIndex = highest;

                var folderArray = inputArray.Where(node => node.GetAttributeValue("name", string.Empty).Contains("folderlist"));
                if (folderArray != null)
                {
                    int maxFolderListIndex = 0;
                    foreach (var item in folderArray)
                    {
                        string keyString = item.GetAttributeValue("name", string.Empty);
                        string value = item.GetAttributeValue("value", string.Empty);
                        keyString = keyString.Replace("folderlist", string.Empty);
                        keyString = keyString.Replace("[", string.Empty);
                        keyString = keyString.Replace("]", string.Empty);

                        int key = 0;
                        int.TryParse(keyString, out key);
                        request.FolderTable.Add(key, value);
                        maxFolderListIndex = Math.Max(maxFolderListIndex, key);
                    }

                    request.NewFolderFieldIndex = maxFolderListIndex;
                }
            }

            return request;
        }

        #endregion

        #region private methods

        private static string GetInputValue(IList<HtmlNode> nodes, string name)
        {
            string value = null;
            var valueNode = nodes.Where(node => node.GetAttributeValue("name", string.Empty).Equals(name))
                .SingleOrDefault();

            value = valueNode == null ? string.Empty : valueNode.GetAttributeValue("value", string.Empty);
            return value;
        }

        private static string GetMessageIconUriFromNode(HtmlNode node)
        {
            // grab the image tag
            HtmlNode img = node.Descendants("img").FirstOrDefault();
            if (img != null)
            {
                var src = img.GetAttributeValue("src", string.Empty);
                return src;
            }

            return null;
        }

        private static DateTime? GetPostMarkFromNode(HtmlNode node)
        {
            if (node != null)
            {
                // expecting something like 'Apr 23, 2009 at 18:43'
                string nodetext = node.InnerText;
                // so let's remove the ' at '
                nodetext = nodetext.Replace(" at ", " ");
                DateTime value;
                DateTime.TryParse(nodetext, out value);
                return new DateTime?(value);
            }

            else { return null; }
        }

        private static string GetMessageAuthorFromNode(HtmlNode node)
        {
            string result = PRIVATE_MESSAGE_UNKNOWN_AUTHOR;
            if (node != null) { result = node.InnerText; }
            return result;
        }

        private static string GetMessageTitleFromNode(HtmlNode node)
        {
            string result = string.Empty;
            try
            {
                var linkNode = node.Descendants("a").FirstOrDefault();
                if (linkNode != null) { result = linkNode.InnerText; }

            }
            catch (Exception) { result = PRIVATE_MESSAGE_UNKNOWN_TITLE; }
            return WebUtility.HtmlDecode(result);
        }

        private static string GetMessageIDFromNode(HtmlNode node)
        {
            int id = -1;
            try
            {
                var idNode = node.Descendants("a").FirstOrDefault();
                if (idNode != null)
                {
                    string link = idNode.GetAttributeValue("href", string.Empty);
                    string idString = link.Split('=').LastOrDefault();
                    int.TryParse(idString, out id);
                }
            }
            catch (Exception) { id = -1; }
            return id.ToString();
        }

        private static PrivateMessageMetadata.MessageStatus GetMessageStatusFromNode(HtmlNode node)
        {
            var status = PrivateMessageMetadata.MessageStatus.Unknown;
            try
            {
                // assuming there is a <tr> with a <td><img></td> ...

                var imgNode = node.Descendants("img").FirstOrDefault();
                status = imgNode == null
                    ? PrivateMessageMetadata.MessageStatus.Unknown
                    : GetMessageStatusFromImage(imgNode.GetAttributeValue("src", string.Empty));

            }
            catch (Exception) { }
            return status;
        }

        private static PrivateMessageMetadata.MessageStatus GetMessageStatusFromImage(string src)
        {
            var tokens = src.Split('/');
            var result = PrivateMessageMetadata.MessageStatus.Unknown;
            var fileName = tokens.LastOrDefault();
            if (fileName != null)
            {
                switch (fileName)
                {
                    case PRIVATE_MESSAGE_ICON_NEW:
                        result = PrivateMessageMetadata.MessageStatus.New;
                        break;

                    case PRIVATE_MESSAGE_ICON_READ:
                        result = PrivateMessageMetadata.MessageStatus.Read;
                        break;

                    case PRIVATE_MESSAGE_ICON_REPLIED:
                        result = PrivateMessageMetadata.MessageStatus.Replied;
                        break;

                    case PRIVATE_MESSAGE_ICON_FORWARDED:
                        result = PrivateMessageMetadata.MessageStatus.Forwarded;
                        break;

                    case PRIVATE_MESSAGE_ICON_CANCELLED:
                        result = PrivateMessageMetadata.MessageStatus.Cancelled;
                        break;
                }
            }

            return result;
        }

        #endregion
    }
}
