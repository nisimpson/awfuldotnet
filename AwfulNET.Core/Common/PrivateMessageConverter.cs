
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AwfulNET.Core.Common
{
    public class PrivateMessageConverter : HtmlConverter<PrivateMessageMetadata>
    {
        public static readonly PrivateMessageConverter Instance;
        static PrivateMessageConverter() { Instance = new PrivateMessageConverter(); }

        private PrivateMessageConverter() : base() { }

        public override string ConvertToHtml(PrivateMessageMetadata metadata)
        {
            return SaveAndFormatPage(metadata);
        }

        private string SaveAndFormatPage(PrivateMessageMetadata message)
        {
            // build html for rendering on screen
            StringBuilder pageBuilder = new StringBuilder();
            HtmlDocument doc = new HtmlDocument();

            // the parent node
            HtmlNode postNode = doc.CreateElement("div");
            postNode.SetAttributeValue("class", "private-message");


            // begin post content node
            string content = string.Format("<div>{0}</div>", message.RawHtml);
            HtmlNode contentNode = HtmlNode.CreateNode(content);
            contentNode.SetAttributeValue("class", "content");
            postNode.AppendChild(contentNode);
            // end post content node

            pageBuilder.AppendLine(postNode.OuterHtml);

            return pageBuilder.ToString();
        }
    }
}
