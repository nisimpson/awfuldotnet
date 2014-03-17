
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Rest
{
    public interface IThreadForm : ICreateHttpRequestBuilder
    {
        string Message { get; set; }
        bool ParseUrls { get; set; }
        bool BookmarkThread { get; set; }
    }

    internal abstract class ThreadForm : IThreadForm
    {
        public string Message { get; set; }
        public bool ParseUrls { get; set; }
        public bool BookmarkThread { get; set; }

        public abstract IHttpRequestBuilder CreateHttpRequestBuilder();
    }

    public abstract class ThreadFormResponse
    {
        public bool Success { get; private set; }
        public IThreadForm Form { get; private set; }
        public ThreadFormResponse(IThreadForm form, bool success)
        {
            this.Form = form;
            this.Success = success;
        }

        public abstract Task<ThreadPageMetadata> LoadRedirectPageAsync();
    }
}
