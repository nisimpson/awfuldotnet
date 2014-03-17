using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AwfulNET
{
    [DataContract]
    public class ForumMetadata
    {
        [DataMember]
        public string ForumName { get; set; }
        [DataMember]
        public string ForumDescription { get; set; }
        [DataMember]
        public string ForumID { get; set; }
        [DataMember]
        public ForumCategory Category { get; set; }
        [DataMember]
        public ForumMetadataGroup Group { get; set; }
        [DataMember]
        public int LevelCount { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("[");
            builder.AppendLine("[" + ForumName + "]");
            builder.AppendLine("[ForumId: " + ForumID + "]");
            builder.AppendLine("[Category: " + Category + "]");
            builder.AppendLine("[LevelCount: " + LevelCount + "]");
            builder.AppendLine("]");
            return builder.ToString();
        }
    }

    [DataContract]
    public class ForumMetadataGroup : IComparable<ForumMetadataGroup>,
        IEquatable<ForumMetadataGroup>
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Weight { get; set; }
        [DataMember]
        public string Description { get; set; }

        public ForumMetadataGroup() { }
        public ForumMetadataGroup(string name, int weight) : this()
        {
            this.Name = name;
            this.Weight = weight;

        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(this.Name) ?
                base.ToString() :
                this.Name;
        }

        public int CompareTo(ForumMetadataGroup other)
        {
            return this.Weight.CompareTo(other.Weight);
        }

        public bool Equals(ForumMetadataGroup other)
        {
            if (other == null)
                return false;

            bool same = this.Name.Equals(other.Name);
            same = same && this.Weight.Equals(other.Weight);
            return same;
        }
    }

    public enum ForumCategory
    {
        MAIN = 0,
        DISCUSSION,
        ARTS,
        COMMUNITY,
        ARCHIVES,
        OTHER
    }

    public class ForumMetadataCollection : List<ForumMetadata>
    {
        public DateTime LastUpdated { get; private set; }

        public ForumMetadataCollection(DateTime lastUpdated)
            : base()
        {
            LastUpdated = lastUpdated;
        }

        public ForumMetadataCollection() : this(DateTime.Now) { }
    }
}