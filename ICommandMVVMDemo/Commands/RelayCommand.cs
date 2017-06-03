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

        #region Constructor(s)

        public RelayCommand(Action action)
        {
            this._action = action;
        }

        public RelayCommand(Action action, Func<bool> canExcetute)
        {
            this._action = action;
            this._canExecute = canExcetute;
        }

        #endregion

        #region Field(s)

        Action _action;

        Func<bool> _canExecute;
        #endregion

        #region Public Method(s)
        
        public bool CanExecute(object parameter)
        {
            if(_canExecute != null)
            {
                return _canExecute();
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            _action();
        }
        #endregion

        #region Event(s)
        
        public event EventHandler CanExecuteChanged;
        #endregion

    }
}
