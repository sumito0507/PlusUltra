using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WindowsFormMVVM2.Command
{
    class SampleButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action _commandAction;
        private readonly Func<bool> _canExecuteCommandAction;

        public SampleButtonCommand(Action commandAction, Func<bool> canExecuteCommandAction = null)
        {
            _commandAction = commandAction;
            _canExecuteCommandAction = canExecuteCommandAction;
        }

        public bool CanExecute(object parameter) => _canExecuteCommandAction?.Invoke() ?? true;
        public void Execute(object parameter) => _commandAction.Invoke();
        public void NotifyCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
