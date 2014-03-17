using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET
{
    public static class JsonHelper
    {

        public static Task<string> SerializeObjectAsync(object value)
        {
            return Task.Factory.StartNew(() => JsonConvert.SerializeObject(value));
        }

        public static dynamic Parse(string json)
        {
            return JObject.Parse(json);
        }
    }
}
