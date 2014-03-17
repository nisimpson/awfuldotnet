using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Feeds
{
    [DataContract]
    public abstract class CommonFeed<T> : IObservable<T>
    {
        private List<IObserver<T>> observers;
        public ObservableStatus Status
        {
            get;
            protected set;
        }

        public enum ObservableStatus { Error, Next, Complete };

        public CommonFeed() 
        { 
            observers = new List<IObserver<T>>();
            Status = ObservableStatus.Next;
        }

        /// <summary>
        /// Retrieves additional content from the feed, if available.
        /// </summary>
        /// <returns></returns>
        public virtual async Task PullAsync()
        {
            await PullAsync(false);
        }

        /// <summary>
        /// Refreshes content from the feed.
        /// </summary>
        /// <returns></returns>
        public virtual async Task UpdateAsync()
        {
            await PullAsync(true);
        }

        private async Task PullAsync(bool refresh)
        {
            try
            {
                var content = await GetContentAsync(refresh);
                if (content == null) { SendComplete(); }
                else { SendNext(content); }
            }
            catch (Exception ex)
            {
                SendError(ex);
            }
        }

        protected void SendError(Exception ex)
        {
            this.Status = ObservableStatus.Error;
            foreach (var observer in this.observers)
                observer.OnError(ex);
        }

        protected void SendComplete()
        {
            this.Status = ObservableStatus.Complete;
            foreach (var observer in this.observers)
                observer.OnCompleted();
        }

        protected void SendNext(T next)
        {
            this.Status = ObservableStatus.Next;
            foreach (var observer in this.observers)
                observer.OnNext(next);
        }

        protected abstract Task<T> GetContentAsync(bool refresh);

        public IDisposable Subscribe(IObserver<T> observer)
        {
            return observer.Subscribe(observers);
        }
    }
}
