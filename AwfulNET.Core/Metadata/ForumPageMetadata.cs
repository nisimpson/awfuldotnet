using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET
{
    public class ForumPageMetadata
    {
        public string ForumID { get; set; }
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
        public IList<ThreadMetadata> Threads { get; set; }
        public IEnumerable<FilterTagMetadata> Filters { get; set; }

        public ForumPageMetadata()
        {
            ForumID = string.Empty;
            PageNumber = -1;
            PageCount = -1;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("[ForumPageMetadata]");
            builder.AppendLine(string.Format("[ForumID: {0}]", ForumID));
            builder.AppendLine(string.Format("[PageNumber: {0}]", PageNumber));
            builder.AppendLine(string.Format("[PageCount: {0}]", PageCount));
            builder.AppendLine(string.Format("[ThreadCount: {0}]", Threads != null ? Threads.Count.ToString() : "null"));
            return builder.ToString();
        }
    }
}
