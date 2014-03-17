using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Common
{
    /// <summary>
    /// A preset list of constants formed at compile-time.
    /// </summary>
    public class Constants
    {
        // A
        public const string AWFUL_COREDB_CONNECTION = "Data Source=isostore:/coredb.sdf";
        public const string AWFUL_THREAD_ID = "3460814";
        public const string AUTHOR_EMAIL = "kollasoftware@gmail.com";
        public const string ATTACHMENT_URI = "attachment.php";
        // B
        public const string BASE_URL = "http://forums.somethingawful.com";
        public const string BOOKMARK_ADD = "json=1&action=cat_toggle";
        public const string BOOKMARK_REMOVE = "json=1&action=remove";
        public const string BOOKMARK_THREAD_URI = "bookmarkthreads.php";

        // C
        public const string CONTENT_TYPE_FORM_URLENCODED = "application/x-www-form-urlencoded";

        // D
        public const string DEMARC = "##$$##";
        public const int DEFAULT_TIMEOUT_IN_MILLISECONDS = 10000;


        // E

        // F
        public const string FORUM_PAGE_URI = "forumdisplay.php";
        public const string FORUM_PAGE_QUERY = "daysprune=15&perpage=40&posticon=0sortorder=desc&sortfield=lastpost";

        // G

        // H
        public const string HIDE_IMAGE_TEXT = "[tap to show image]";
        public const string HTML_POST = "POST";
        public const string HTML_GET = "GET";

        // L
        public const string LOGIN_PAGE_URI = "account.php";
        public const string LOGIN_OPTIONS = "action=login&username={0}&password={1}";
        public const string LASTREAD_FLAG = "seen1";
        public const string LOG_DIRECTORY = "log";
        public const string LOG_TIMESTAMP_FORMAT = "yyyy.MM.dd.HHmm";
        public const string LOG_FILE_FORMAT = "yyyy.MM.dd";

        // N
        public const string NEWPOST_GIF_URL = "http://fi.somethingawful.com/style/posticon-new.gif";

        // P
        public const int POSTS_PER_THREAD_PAGE = 40;
        public const string PRIVATE_MESSAGE_URI = "private.php";
        // S
        public const string SMILEY_PREFIX_1 = "fi.somethingawful";
        public const string SMILEY_PREFIX_2 = "i.somethingawful";
        public const string SERVER_LOGIN_RESPONSE_URI = "http://forums.somethingawful.com/account.php";

        // T
        public const string THREAD_PAGE_URI = "showthread.php";
        public const string THREAD_PAGE_QUERY = "&userid=0&perpage=40&pagenumber=";
        public const string THREAD_LAST_POST = "&gotolastpost";
        public const string THREAD_ID = "threadid";
        public const string THREAD_RATING_5 = "5stars.gif";
        public const string THREAD_RATING_4 = "4stars.gif";
        public const string THREAD_RATING_3 = "3stars.gif";
        public const string THREAD_RATING_2 = "2stars.gif";
        public const string THREAD_RATING_1 = "1star.gif";
        // U
        public const string USERCP_URI = "http://forums.somethingawful.com/usercp.php";

        // W
        public const string WEB_RESPONSE_ENCODING = "iso-8859-1";
    }
}
