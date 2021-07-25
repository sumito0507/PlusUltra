using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsMVVM
{
    using System.ComponentModel;
    using System.Reactive.Linq;
    public class ViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PropertySetter PropertySetter { get; private set; }
        #endregion

        private int counter;
        public int Counter
        {
            get => counter;
            set => PropertySetter.Set(ref counter, value);
        }

        public Command UpCommand { get; private set; }
        public Command DownCommand { get; private set; }

        public ViewModel()
        {
            PropertySetter = new PropertySetter(this, OnPropertyChanged);
            var observeCounter = PropertySetter.ObserveChanged(nameof(Counter));
            UpCommand = observeCounter.Select(_ => Counter < 10).ToCommand(() => Counter++);
            DownCommand = observeCounter.Select(_ => Counter > 0).ToCommand(() => Counter--);
        }
    }
}
