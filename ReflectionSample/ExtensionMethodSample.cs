using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionSample
{
    /// <summary>
    /// Extension Methoid Class for demo
    /// </summary>
    static class ExtensionMethodSample
    {
        #region Sample Extension Method to Print Number
        public static int PrintNumbers(this int inpuRange)
        {
            for(int i = 0; i< inpuRange; i++)
            {
                Console.WriteLine("Now Printing Number : {0}", i);
            }
            return inpuRange;
        }
        #endregion

        #region Class as ExtesnionMethod
        public static int MultiplyFromExtension(this CalculatorClassForExtension calc)
        {
            return calc.Number1 * calc.Number2;
        }

        public static int DivisionFromExtension(this CalculatorClassForExtension calc)
        {
            return calc.Number1 / calc.Number2;
        }

        #endregion

        #region Factorial as Extension Method

        public static int Factorial(this int num)
        {
            int tempSum = 1;
            if (num == 0)
            {
                return tempSum;
            }

            tempSum = num * Factorial(num - 1);
            Console.WriteLine("Factorial of {0} is {1}", num, tempSum);
            return tempSum;
        }
        #endregion
    }
}
