using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICommandMVVMDemo.Model
{
    public class CalculatorModel
    {
        #region Constructor(s)
        
        public CalculatorModel()
        {
            //Default values
            FirstNumber = 15;
            SecondNumber = 20;
            OutputNumber = 0;
        }
        #endregion

        #region Propertie(s)
        
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public int OutputNumber { get; set; }

        #endregion

        #region Unwanted Public Method(s), Can delete if you want
        
        public int Add(int first, int second)
        {
            return first + second;
        }

        public int Sub(int first, int second)
        {
            return first - second;
        }

        public int Multiply(int first, int second)
        {
            return first * second;
        }

        public int Divide(int first, int second)
        {
            return first / second;
        }
        #endregion
    }
}
