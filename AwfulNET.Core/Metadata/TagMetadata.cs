using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AwfulNET
{
    [DataContract]
    public class TagMetadata
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public string TagUri { get; set; }

        public static readonly TagMetadata NoTag;
        static TagMetadata() { NoTag = new TagMetadata() { Title = "No Icon", Value = "0", TagUri = string.Empty }; }
    }

    public class FilterTagMetadata : TagMetadata
    {
        public static readonly FilterTagMetadata NoFilter;
        static FilterTagMetadata() { NoFilter = new FilterTagMetadata() { Title = "No Filter" }; }
        public string FilterUri { get; set; }
    }
}
