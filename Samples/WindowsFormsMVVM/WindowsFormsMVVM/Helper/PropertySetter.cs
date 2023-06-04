using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsMVVM
{
    using System.ComponentModel;
    using System.Reactive.Linq;
    using System.Runtime.CompilerServices;
    /// <summary>
    /// INotifyPropertyChanged を簡単に実装するためのクラス
    /// </summary>
    public class PropertySetter
    {
        public PropertySetter(INotifyPropertyChanged owner, Action<string> OnPropertyChanged = null, Action<string> OnPropertyChanging = null)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            PropertyChangedHandler = OnPropertyChanged;
            PropertyChangingHandler = OnPropertyChanging;
        }

        protected INotifyPropertyChanged Owner { get; private set; }

        protected Action<string> PropertyChangedHandler;
        protected Action<string> PropertyChangingHandler;

        public bool Set<T>(ref T backStore, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(backStore, value)) return false;
            PropertyChangingHandler?.Invoke(propertyName);
            backStore = value;
            PropertyChangedHandler?.Invoke(propertyName);
            return true;
        }

        private IObservable<string> observeChanged;
        public IObservable<string> ObserveChanged()
        {
            if (observeChanged == null)
            {
                observeChanged = Observable
                    .FromEvent<PropertyChangedEventHandler, string>(
                        h => (sender, args) => h(args.PropertyName),
                        h => Owner.PropertyChanged += h,
                        h => Owner.PropertyChanged -= h
                    );
            }
            return observeChanged;
        }

        private IObservable<string> observeChanging;
        public IObservable<string> ObserveChanging()
        {
            if (observeChanging == null)
            {
                var owner = Owner as INotifyPropertyChanging;
                if (owner == null)
                {
                    observeChanging = Observable.Empty<string>();
                }
                else
                {
                    observeChanging = Observable
                        .FromEvent<PropertyChangingEventHandler, string>(
                            h => (sender, args) => h(args.PropertyName),
                            h => owner.PropertyChanging += h,
                            h => owner.PropertyChanging -= h
                        );
                }
            }
            return observeChanging;
        }

        public IObservable<string> ObserveChanged(string propertyName)
        {
            return Observable
                .Return(propertyName)
                .Merge(ObserveChanged())
                .Where(a => a == propertyName);
        }

        public IObservable<string> ObserveChanging(string propertyName)
        {
            return Observable
                .Return(propertyName)
                .Merge(ObserveChanging())
                .Where(a => a == propertyName);
        }
    }
}
