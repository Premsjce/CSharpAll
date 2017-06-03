using ICommandMVVMDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ICommandMVVMDemo.Commands
{
    public class PlusCommand : ICommand
    {
        CalculatorViewModel viewmodel;
        public PlusCommand(CalculatorViewModel viewmod)
        {
            this.viewmodel = viewmod;
        }
        public event EventHandler CanExecuteChanged =  delegate{ };

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewmodel.AddMethod();
        }
    }
}
