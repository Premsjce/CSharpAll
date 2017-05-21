using ICommandMVVMDemo.Commands;
using ICommandMVVMDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ICommandMVVMDemo.ViewModel
{
    public class CalculatorViewModel : BaseViewModel
    {
        CalculatorModel model;


        public CalculatorViewModel()
        {
            plusCommand = new PlusCommand(this);
            model = new CalculatorModel();
            firstInput = model.FirstNumber;
            secondInput = model.SecondNumber;
            output = model.OutputNumber;
        }

        private int firstInput;    
        public int FirstInput
        {
            get
            {
                return firstInput;
            }
            set
            {
                firstInput = value;
                OnPropertychanged("FirstInput");
            }
        }

        private int secondInput;

        public int SecondInput
        {
            get
            {
                return secondInput;
            }
            set
            {
                secondInput = value;
                OnPropertychanged("SecondInput");
            }
        }

        private int output;
        

        public int Output
        {
            get
            {
                return output;
            }
            set
            {
                output = value;
                OnPropertychanged("Output");
            }
        }

        public void AddMethod()
        {
            Output = firstInput + secondInput;
        }
        public void SubMethod()
        {
            Output = firstInput - secondInput;
        }
        public void MulMethod()
        {
            Output = firstInput * secondInput;
        }
        public void DivMethod()
        {
            Output = firstInput / secondInput;
        }


        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(AddMethod);
            }
        }

        public ICommand SubCommand
        {
            get
            {
                return new RelayCommand(SubMethod);
            }
        }

        public ICommand MulCommand
        {
            get
            {
                return new RelayCommand(MulMethod);
            }
        }

        public ICommand DivCommand
        {
            get
            {
                return new RelayCommand(DivMethod);
            }
        }

        private ICommand plusCommand;

        public ICommand AddSpecificCommand
        {
            get
            {
                return plusCommand;
            }
        }
    }
}
