using System;

namespace WindowsFormsMVVM
{
    using System.ComponentModel;
    /// <summary>
    /// Command はボタンを押した時などに実行するロジックを保持します。
    /// CanExecute プロパティはコマンドが実行可能な時に true を、不可能な時に false を返します。
    /// Execute() メソッドは紐づけられたアクションを実行します。
    /// また簡単に作成できるように拡張メソッドを定義しています。
    /// </summary>
    public class Command : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PropertySetter PropertySetter { get; private set; }

        public Command(Action execute)
        {
            PropertySetter = new PropertySetter(this, OnPropertyChanged);
            this.execute = execute;
        }

        public Command(Action execute, bool canExecute)
            : this(execute)
        {
            CanExecute = canExecute;
        }

        public Command(Action execute, IObservable<bool> canExecute)
            : this(execute)
        {
            canExecute.Subscribe(a => CanExecute = a);
        }

        private Action execute;
        public void Execute()
        {
            if (!CanExecute) return;
            execute?.Invoke();
        }

        private bool canExecute;
        public bool CanExecute
        {
            get => canExecute;
            set => PropertySetter.Set(ref canExecute, value);
        }
    }

    public static class CommandExtension
    {
        public static Command ToCommand(this IObservable<bool> source, Action execute = null)
        {
            return new Command(execute, source);
        }
    }
}
