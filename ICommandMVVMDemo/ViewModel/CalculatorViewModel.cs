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

        #region Constructo(s)
        public CalculatorViewModel()
        {
            plusCommand = new PlusCommand(this);
            model = new CalculatorModel();
            firstInput = model.FirstNumber;
            secondInput = model.SecondNumber;
            output = model.OutputNumber;
        }
        #endregion

        #region Propertie(s)

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
        #endregion

        #region Field(s)
        private CalculatorModel model;
        private int firstInput;
        private int secondInput;
        private int output;
        private ICommand plusCommand;
        #endregion

        #region Private Method(s)

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
        #endregion
        
        #region Command(s)

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

        public ICommand AddSpecificCommand
        {
            get
            {
                return plusCommand;
            }
        }
        #endregion
    }
}
