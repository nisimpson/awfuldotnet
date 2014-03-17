using AwfulNET.Core.Common;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core
{
    public class UserSettings : IPostRequest, Core.Rest.ICreateHttpRequestBuilder
    {
        private Dictionary<string, bool> SettingsTable = new Dictionary<string, bool>();

        private UserSettings() { }

        public static UserSettings FromHtmlDocument(HtmlDocument doc)
        {
            UserSettings cpSettings = new UserSettings();

            // grab list of all radio type nodes that are checked
            var options = doc.DocumentNode.Descendants("input")
                .Where(node => node.GetAttributeValue("type", "").Equals("radio") &&
                    node.Attributes.Contains("checked"))
                .ToList();

            // set initiali values
            foreach (var option in options)
            {
                string name = option.GetAttributeValue("name", "");
                string value = option.GetAttributeValue("value", "");
                cpSettings.SettingsTable.AddOrUpdateValue(name, ResponseToBool(value));
            }

            return cpSettings;
        }

        private static string BoolToResponse(bool value)
        {
            return value ? "yes" : "no";
        }

        private static bool ResponseToBool(string value)
        {
            return value == "yes" ? true : false;
        }

        #region Constants

        private const string SUBMIT = "Submit Modifications";
        private const string INVISIBLE_MODE = "invisible";
        private const string COOKIE_USER = "cookieuser";
        private const string SHOW_EMAIL = "showemail";
        private const string BOOKMARK_OWN_POSTS = "bookmark_own_posts";
        private const string COLOR_SEEN = "color_seen";
        private const string THREADS_HIGHLIGHT_SEEN = "threads_highlight_seen";
        private const string THREADS_COLORIZE_BOOKMARKS = "threads_colorize_bookmarks";
        private const string SHOW_SEEN_ICON = "show_seen_icon";
        private const string THREADS_STAR_BUTTONS = "threads_star_buttons";
        private const string ALLOW_MAIL = "allowmail";
        private const string RECEIVE_PM = "receivepm";
        private const string EMAIL_ON_PM = "emailonpm";
        private const string PM_POPUP = "pmpopup";
        private const string THREADS_HIGHLIGHT_OP = "threads_highlight_op";
        private const string JS_ONLOAD_POSTJUMP = "js_onload_postjump";
        private const string SHOW_SIGNATURES = "showsignatures";
        private const string SHOW_AVATARS = "showavatars";
        private const string SHOW_IMAGES = "showimages";
        private const string SHOW_VIDEO = "showvideo";
        private const string SHOW_SMILIES = "showsmilies";
        private const string ADV_POST_DISABLED = "adv_post_disabled";

        #endregion

        #region Properties

        public bool InvisbleMode
        {
            get
            {
                return SettingsTable.GetValueOrDefault(INVISIBLE_MODE);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(INVISIBLE_MODE, value);
            }
        }

        public bool AutomaticLogin
        {
            get
            {
                return SettingsTable.GetValueOrDefault(COOKIE_USER);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(COOKIE_USER, value);
            }
        }

        public bool AllowEmail
        {
            get
            {
                return SettingsTable.GetValueOrDefault(SHOW_EMAIL);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(SHOW_EMAIL, value);
            }
        }

        public bool BookmarkRepliedThreads
        {
            get
            {
                return SettingsTable.GetValueOrDefault(BOOKMARK_OWN_POSTS);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(BOOKMARK_OWN_POSTS, value);
            }
        }

        public bool MarkOldPostsInColor
        {
            get
            {
                return SettingsTable.GetValueOrDefault(COLOR_SEEN);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(COLOR_SEEN, value);
            }
        }

        public bool ColorizeThreadsByBookmark
        {
            get
            {
                return SettingsTable.GetValueOrDefault(THREADS_COLORIZE_BOOKMARKS);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(THREADS_COLORIZE_BOOKMARKS, value);
            }
        }

        public bool ShowMarkAsReadIcon
        {
            get
            {
                return SettingsTable.GetValueOrDefault(SHOW_SEEN_ICON);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(SHOW_SEEN_ICON, value);
            }
        }

        public bool ShowBookmarkStarButtons
        {
            get
            {
                return SettingsTable.GetValueOrDefault(THREADS_STAR_BUTTONS);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(THREADS_STAR_BUTTONS, value);
            }
        }

        public bool AllowEmailFromModAdmin
        {
            get
            {
                return SettingsTable.GetValueOrDefault(ALLOW_MAIL);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(ALLOW_MAIL, value);
            }
        }

        public bool EnableMessaging
        {
            get
            {
                return SettingsTable.GetValueOrDefault(RECEIVE_PM);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(RECEIVE_PM, value);
            }
        }

        public bool NewMessageEmailNotify
        {
            get
            {
                return SettingsTable.GetValueOrDefault(EMAIL_ON_PM);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(EMAIL_ON_PM, value);
            }
        }

        public bool NewMessageEmailPopup
        {
            get
            {
                return SettingsTable.GetValueOrDefault(PM_POPUP);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(PM_POPUP, value);
            }
        }

        public bool HightlightThreadOP
        {
            get
            {
                return SettingsTable.GetValueOrDefault(THREADS_HIGHLIGHT_OP);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(THREADS_HIGHLIGHT_OP, value);
            }
        }

        public bool AdjustPagePositionToRequestedPost
        {
            get
            {
                return SettingsTable.GetValueOrDefault(JS_ONLOAD_POSTJUMP);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(JS_ONLOAD_POSTJUMP, value);
            }
        }

        public bool ShowUserSignature
        {
            get
            {
                return SettingsTable.GetValueOrDefault(SHOW_SIGNATURES);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(SHOW_SIGNATURES, value);
            }
        }

        public bool ShowUserAvatar
        {
            get
            {
                return SettingsTable.GetValueOrDefault(SHOW_AVATARS);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(SHOW_AVATARS, value);
            }
        }

        public bool ShowImages
        {
            get
            {
                return SettingsTable.GetValueOrDefault(SHOW_IMAGES);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(SHOW_IMAGES, value);
            }
        }

        public bool ShowVideo
        {
            get
            {
                return SettingsTable.GetValueOrDefault(SHOW_VIDEO);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(SHOW_VIDEO, value);
            }
        }

        public bool ShowSmilies
        {
            get
            {
                return SettingsTable.GetValueOrDefault(SHOW_SMILIES);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(SHOW_SMILIES, value);
            }
        }

        public bool DisableAdvancedPostingFeatures
        {
            get
            {
                return SettingsTable.GetValueOrDefault(ADV_POST_DISABLED);
            }
            set
            {
                SettingsTable.AddOrUpdateValue(ADV_POST_DISABLED, value);
            }
        }

        #endregion

        public Task<System.Net.Http.HttpResponseMessage> PostAsync(System.Net.Http.HttpClient client)
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            foreach (var key in SettingsTable.Keys)
                parameters.Add(new KeyValuePair<string, string>(key, BoolToResponse(SettingsTable[key])));

            parameters.Add(new KeyValuePair<string, string>("submit", SUBMIT));
            var postData = new System.Net.Http.FormUrlEncodedContent(parameters);

            return client.PostAsync("member.php", postData);
        }

        public System.Net.Http.IHttpRequestBuilder CreateHttpRequestBuilder()
        {
            var request = new System.Net.Http.HttpPostRequestBuilder("member.php");
            foreach (var key in SettingsTable.Keys)
                request.AddParameter(key, BoolToResponse(SettingsTable[key]));

            request.AddParameter("submit", SUBMIT);
            return request;
        }
    }
}
