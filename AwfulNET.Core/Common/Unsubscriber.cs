using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Common
{
    internal class Unsubscriber<T> : IDisposable
    {
        private List<IObserver<T>> observers;
        private IObserver<T> observer;

        public Unsubscriber(IObserver<T> observer, List<IObserver<T>> observers)
        {
            this.observer = observer;
            this.observers = observers;
        }

        public void Dispose()
        {
            if (this.observers != null && this.observer != null)
            {
                this.observers.Remove(this.observer);
            }
        }
    }
}
