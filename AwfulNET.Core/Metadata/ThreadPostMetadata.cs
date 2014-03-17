using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AwfulNET
{
    [DataContract]
    public class ThreadPostMetadata
    {
        #region Properties

        [DataMember]
        public DateTime PostDate { get; set; }
        [DataMember]
        public Uri PostIconUri { get; set; }
        [DataMember]
        public bool ShowIcon { get; set; }
        [DataMember]
        public string UserID { get; set; }
        [DataMember]
        public string PostID { get; set; }
        [DataMember]
        public string ThreadID { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public PostType AuthorType { get; set; }
        [DataMember]
        public string PostBody { get; set; }
        [DataMember]
        public int PageIndex { get; set; }
        [DataMember]
        public string ThreadIndex { get; set; }
        [DataMember]
        public bool IsNew { get; set; }
        [DataMember]
        public bool IsIgnored { get; set; }
        [DataMember]
        public Uri MarkPostUri { get; set; }

        public enum PostType
        {
            Standard,
            Administrator,
            Moderator,
            OriginalPoster
        }

        [DataMember]
        public bool IsEditable { get; set; }
        [DataMember]
        public int ThreadPageNumber { get; set; }

        #endregion
    }
}
