using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AwfulNET
{
    [DataContract]
    public class PrivateMessageMetadata
    {
        public enum MessageStatus
        {
            Unknown = 0,
            New,
            Read,
            Cancelled,
            Replied,
            Forwarded
        };

        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string To { get; set; }
        [DataMember]
        public string From { get; set; }
        [DataMember]
        public string RawHtml { get; set; }
        [DataMember]
        public string PrivateMessageId { get; set; }
        [DataMember]
        public MessageStatus Status { get; set; }
        [DataMember]
        public DateTime? PostDate { get; set; }
        [DataMember]
        public string FolderId { get; set; }
        [DataMember]
        public string IconUri { get; set; }
    }

    public class PrivateMessageMetadataCollection : List<PrivateMessageMetadata>
    {
        private PrivateMessageFolderMetadata folder = new PrivateMessageFolderMetadata();

        public PrivateMessageFolderMetadata Folder
        {
            get { return folder; }
        }

        public string FolderName { get { return folder.Name; } }

        public PrivateMessageMetadataCollection() { }

        public PrivateMessageMetadataCollection(PrivateMessageFolderMetadata folder)
            : this() { this.folder = folder; }
    }
}
