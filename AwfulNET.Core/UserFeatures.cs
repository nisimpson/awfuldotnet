using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core
{
    public class UserFeatures
    {
        public string Username { get; private set; }
        public bool HasPlatinum { get; private set; }
        public bool HasArchives { get; private set; }
        public bool HasNoAds { get; private set; }

        private UserFeatures() { }

        internal UserFeatures(
            string username,
            bool hasPlatinum,
            bool hasArchives,
            bool hasNoAds)
        {
            this.Username = username;
            this.HasPlatinum = hasPlatinum;
            this.HasArchives = hasArchives;
            this.HasNoAds = hasNoAds;
        }

        internal static UserFeatures FromHtmlDocument(HtmlDocument html)
        {
            UserFeatures features = new UserFeatures();

            // grab <div class="standard"> node
            HtmlNode standardDiv = html.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", string.Empty)
                    .Equals("standard"))
                .FirstOrDefault();

            features.ParseUsername(standardDiv)
                .ParseFeatures(standardDiv);

            return features;
        }

        private UserFeatures ParseUsername(HtmlNode node)
        {
            try
            {
                // grab user name
                HtmlNode userNameNode = node.Descendants("h2").FirstOrDefault();
                this.Username = userNameNode.InnerText
                    .Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries)[1]
                    .Trim();
            }
            catch (Exception) { }
            return this;
        }

        private const string PLATINUM_KEY = "Platinum Upgrade";
        private const string ARCHIVES_KEY = "Archives Upgrade";
        private const string NOADS_KEY = "No-Ads Upgrade";

        private UserFeatures ParseFeatures(HtmlNode node)
        {
            try
            {
                var featuresNode = node.Descendants("dl")
                    .Where(value => value.GetAttributeValue("class", string.Empty)
                        .Equals("features"))
                    .FirstOrDefault();

                this.HasPlatinum = ParseFeature(featuresNode, PLATINUM_KEY);
                this.HasArchives = ParseFeature(featuresNode, ARCHIVES_KEY);
                this.HasNoAds = ParseFeature(featuresNode, NOADS_KEY);
            }
            catch (Exception) { }
            return this;
        }

        private static bool ParseFeature(HtmlNode node, string innerText)
        {
            var featureNode = node.Descendants("dt")
                .Where(value => node.InnerText.Equals(innerText))
                .FirstOrDefault();

            if (featureNode == null)
                return false;

            bool enabled = featureNode.GetAttributeValue("enabled", false);
            return enabled;
        }
    }
}
