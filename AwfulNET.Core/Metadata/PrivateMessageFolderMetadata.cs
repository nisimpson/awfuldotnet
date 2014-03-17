using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AwfulNET
{
    [DataContract]
    public class PrivateMessageFolderMetadata
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string FolderId { get; set; }
        [DataMember]
        public ICollection<PrivateMessageMetadata> Messages { get; set; }
    }
}
