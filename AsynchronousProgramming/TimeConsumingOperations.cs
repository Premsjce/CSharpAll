using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    /// <summary>
    /// Time Consuming Operation class
    /// </summary>
    public class TimeConsumingOperations
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeConsumingOperations"/> class.
        /// </summary>
        public TimeConsumingOperations()
        {
            //Default Constructor   
        }

        /// <summary>
        /// Gets the factorial.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <returns></returns>
        public int GetFactorial(int num)
        {
            Thread.Sleep(1000);
            int tempFact = 1;
            if(num == 0)
            {
                return tempFact;
            }
            else
            {
                return tempFact = num * GetFactorial(num - 1);
            }            
        }

        /// <summary>
        /// Compares the Input Items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <returns></returns>
        public bool CompareItems<T>(T item1, T item2)
        {
            if(item1.Equals(item2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
