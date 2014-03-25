
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;

namespace AwfulNET.Core.Rest
{
    public interface IPrivateMessageRequest :
        ICreateHttpRequestBuilder
    {
        TagMetadata SelectedTag { get; set; }
        string PrivateMessageId { get; }
        string To { get; set; }
        string Subject { get; set; }
        string FormKey { get; }
        string FormCookie { get; }
        bool IsForward { get; }
        string Body { get; set; }
        List<TagMetadata> TagOptions { get; set; }
    }

    [DataContract]
    public class PrivateMessageRequest : IPrivateMessageRequest
    {
        [DataMember]
        public string PrivateMessageId { get; set; }
        [DataMember]
        public TagMetadata SelectedTag { get; set; }
        [DataMember]
        public string FormKey { get; set; }
        [DataMember]
        public string FormCookie { get; set; }
        [DataMember]
        public bool IsForward { get; set; }
        [DataMember]
        public string To { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string Body { get; set; }
        [DataMember]
        public List<TagMetadata> TagOptions { get; set; }

        public PrivateMessageRequest()
        {
            PrivateMessageId = string.Empty;
            To = string.Empty;
            Subject = string.Empty;
            Body = string.Empty;
        }

        private const string SEND_MESSAGE_ACTION_VALUE = "dosend";
        private const string SEND_MESSAGE_SUBMIT_VALUE = "Send Message";

        public System.Net.Http.IHttpRequestBuilder CreateHttpRequestBuilder()
        {
            IPrivateMessageRequest request = this;
            HttpPostRequestBuilder endpoint = new HttpPostRequestBuilder("private.php");
            endpoint.AddParameter("prevmessageid", request.PrivateMessageId);
            endpoint.AddParameter("action", SEND_MESSAGE_ACTION_VALUE);
            endpoint.AddParameter("forward", request.IsForward ? "yes" : string.Empty);
            endpoint.AddParameter("touser", request.To);
            endpoint.AddParameter("title", request.Subject);

            if (request.SelectedTag != null)
                endpoint.AddParameter("iconid", request.SelectedTag.Value);

            endpoint.AddParameter("message", request.Body);
            endpoint.AddParameter("parseurl", "yes");
            endpoint.AddParameter("savecopy", "yes");
            endpoint.AddParameter("submit", SEND_MESSAGE_SUBMIT_VALUE);
            return endpoint;
        }
    }
}
