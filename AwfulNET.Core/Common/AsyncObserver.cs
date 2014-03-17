using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Common
{
    public class RelayObserver<T> : IObserver<T>
    {
        private Action<T> next;
        private Action<Exception> error;
        private Action completed;

        internal RelayObserver(Action<T> next, 
            Action<Exception> error = null, 
            Action completed = null)
        {
            this.next = next;
            this.error = error;
            this.completed = completed;
        }

        public void OnCompleted()
        {
            if (this.completed != null)
                this.completed();
        }

        public void OnError(Exception error)
        {
            if (this.error != null)
                this.error(error);
            else
                throw error;
        }

        public void OnNext(T value)
        {
            this.next(value);
        }
    }
}
