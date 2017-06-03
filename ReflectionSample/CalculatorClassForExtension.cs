using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionSample
{
    /// <summary>
    /// CalculatorClass to b used for Extension
    /// </summary>
    public class CalculatorClassForExtension
    {
        #region Constructor(s)
        public CalculatorClassForExtension()
        {
            //Default Constructor
        }
        #endregion

        #region Field(s)
        private int number1;
        private int number2;
        #endregion

        #region Propertie(s)

        public int Number1
        {
            get { return number1; }
            set { number1 = value; }
        }

        public int Number2
        {
            get { return number2; }
            set { number2 = value; }
        }

        #endregion

        #region Public Method(s)

        public int Add()
        {
            return number1+number2;
        }

        public int Minus()
        {
            return number1 - number2;
        }

        #endregion
    }

}
