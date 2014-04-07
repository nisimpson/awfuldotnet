using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AwfulNET
{
    [DataContract]
    public class ThreadMetadata : IEquatable<ThreadMetadata>
    {
        public const int NO_UNREAD_POSTS_POSTCOUNT = -1;

        public enum BookmarkColorCategory
        {
            Unknown = 0,
            Category0,
            Category1,
            Category2
        }

        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string ThreadID { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public int ReplyCount { get; set; }
        [DataMember]
        public int PageCount { get; set; }
        [DataMember]
        public int NewPostCount { get; set; }
        [DataMember]
        public bool ShowPostCount { get; set; }
        [DataMember]
        public bool IsNew { get; set; }
        [DataMember]
        public bool IsClosed { get; set; }
        [DataMember]
        public bool IsSticky { get; set; }
        [DataMember]
        public bool IsBookmarked { get; set; }
        [DataMember]
        public int Rating { get; set; }
        [DataMember]
        public DateTime? LastUpdated { get; set; }
        [DataMember]
        public string IconUri { get; set; }
        [DataMember]
        public BookmarkColorCategory ColorCategory { get; set; }
        [DataMember]
        public DateTime KilledByDate { get; set; }
        [DataMember]
        public string KilledBy { get; set; }

        public bool Equals(ThreadMetadata other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(other, this)) return true;
            return this.ThreadID.Equals(other.ThreadID);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ThreadMetadata))
                return false;

            return Equals(obj as ThreadMetadata);
        }

        public override int GetHashCode()
        {
            return this.ThreadID.GetHashCode();
        }
    }

    public class ThreadMetadataCollection : List<ThreadMetadata>
    {
        public string ForumID { get; internal set; }
        public int PageNumber { get; internal set; }

        public ThreadMetadataCollection(ForumPageMetadata metadata) : base()
        {
            foreach (var item in metadata.Threads)
                Add(item);
        }

        public ThreadMetadataCollection() : base() { }
    }
}
