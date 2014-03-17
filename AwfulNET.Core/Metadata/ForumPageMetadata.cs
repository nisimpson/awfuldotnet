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
    }
}
