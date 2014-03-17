using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET
{
    public class ThreadPageMetadata
    {
        public string ThreadTitle { get; set; }
        public string ThreadID { get; set; }
        public int LastPage { get; set; }
        public int PageNumber { get; set; }
        public ThreadPostMetadata[] Posts { get; set; }
        public string TargetPostIndex { get; set; }
        public bool IsBookmarked { get; set; }
        public string ParentForum { get; set; }
        public string ParentForumId { get; set; }

        public string ToJSON()
        {
            string output = JsonConvert.SerializeObject(this);
            return output;
        }

        public Task<string> ToJsonAsync()
        {
            return Task.Factory.StartNew(() => JsonConvert.SerializeObject(this));
        }

        public static ThreadPageMetadata FromJSON(string json)
        {
            ThreadPageMetadata metadata = JsonConvert.DeserializeObject<ThreadPageMetadata>(json);
            return metadata;
        }

        public static Task<ThreadPageMetadata> FromJSONAsync(string json)
        {
            var metadata = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ThreadPageMetadata>(json));
            return metadata;
        }
    }
}