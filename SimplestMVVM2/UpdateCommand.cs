using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimplestMVVM2
{
    public class UpdateCommand : ICommand
    {
        ViewModel viewModel;
        public UpdateCommand(ViewModel vm)
        {
            this.viewModel = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.UpdateCmnd();
        }

        public event EventHandler CanExecuteChanged;
    }
}
