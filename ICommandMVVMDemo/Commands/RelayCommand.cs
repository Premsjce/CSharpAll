using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ICommandMVVMDemo.Commands
{
    public class RelayCommand : ICommand
    {
        Action _action;

        public RelayCommand(Action action)
        {
            this._action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged;
    }
}
