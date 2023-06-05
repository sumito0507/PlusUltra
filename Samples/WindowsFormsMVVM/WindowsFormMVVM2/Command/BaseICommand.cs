using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WindowsFormMVVM2.Command
{
    public class BaseICommand : ICommand
    {
        public delegate void DelegateAction();
        private DelegateAction _delegateAction;

        public event EventHandler CanExecuteChanged;

        public BaseICommand(Action action)
        {
            _delegateAction = new DelegateAction(action);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _delegateAction();
        }
    }
}
