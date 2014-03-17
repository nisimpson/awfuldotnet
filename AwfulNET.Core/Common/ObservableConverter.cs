using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core
{
    /// <summary>
    /// Helper class to convert Observable objects of one type to another.
    /// </summary>
    public class ObservableProxy<TSource, TElement> :
        IObservable<TElement>,
        IObserver<TSource>
    {
        private List<IObserver<TElement>> observers;
        private Func<TSource, TElement> convertToElement;

        public ObservableProxy(Func<TSource, TElement> convertFunc)
        {
            this.observers = new List<IObserver<TElement>>();
            this.convertToElement = convertFunc;
        }

        public IDisposable Subscribe(IObserver<TElement> observer)
        {
            return observer.Subscribe(observers);
        }

        public void OnCompleted()
        {
            foreach (var observer in observers)
                observer.OnCompleted();
        }

        public void OnError(Exception error)
        {
            foreach (var observer in observers)
                observer.OnError(error);
        }

        public void OnNext(TSource value)
        {
            /*
            var convert = Task<TElement>.Run(() => { return this.convertToElement(value); });
            convert.ContinueWith(task =>
                {
                    var element = task.Result;
                    foreach (var observer in observers) { observer.OnNext(element); }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            */

            var element = this.convertToElement(value);
            foreach (var observer in observers)
                observer.OnNext(element);

        }
    }
}
