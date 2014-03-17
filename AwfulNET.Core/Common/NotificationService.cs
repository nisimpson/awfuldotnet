using AwfulNET.Core.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Common
{
    public interface INotification<T>
    {
        string ID { get; }
        object State { get; }
        object Sender { get; }
        T Value { get; }
    }

    public class BasicNotification<T> : INotification<T>
    {
        public string ID { get; private set; }
        public object State { get; private set; }
        public object Sender { get; private set; }
        public T Value { get; private set; }
        
        public BasicNotification(object state, object sender, T value)
        {
            this.ID = Guid.NewGuid().ToString();
            this.State = state;
            this.Sender = sender;
            this.Value = value;
        }
    }
    

    public class NotificationService
    {
        public static NotificationService Default {get; private set; }
        static NotificationService() { Default = new NotificationService(); }

        private Dictionary<Type, object> observables = new Dictionary<Type, object>();
        
        internal IDisposable Register<T> (IObserver<INotification<T>> observer)
        {
            var t = typeof(T);
            if (!observables.ContainsKey(t))
                observables.Add(t, new NotificationCarrier<T>());

            return (observables[t] as NotificationCarrier<T>).Subscribe(observer);
        }

        public IDisposable Register<T> (Action<INotification<T>> onNext)
        {
            return Register(new RelayObserver<INotification<T>>(onNext));
        }

        public void Notify<T>(object sender, T value, object state = null)
        {
            var t = typeof(T);
            if (observables.ContainsKey(t))
                (observables[t] as NotificationCarrier<T>).Notify(sender, state, value);
        }
    }

    internal class NotificationCarrier<T> : IObservable<INotification<T>>
    {
        private List<IObserver<INotification<T>>> observers = new List<IObserver<INotification<T>>>();

        public IDisposable Subscribe(IObserver<INotification<T>> observer)
        {
            this.observers.Add(observer);
            return new Unsubscriber<INotification<T>>(observer, observers);
        }

        public void Notify(object sender, object state, T value)
        {
            var notification = new BasicNotification<T>(state, sender, value);
            foreach (var observer in observers)
                observer.OnNext(notification);
        }
    }
}
