using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    /// <summary>
    /// Class that has the Fibonnacci related functions
    /// </summary>
    public class Fibonacci
    {
        #region Constructor(s)
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Fibonacci"/> class.
        /// </summary>
        public Fibonacci()
        {
            //Default Constructor
        }
        #endregion

        #region Public Method(s)
        public void FindFibonacciTotal(int numberUpto)
        {
            //Initial Condition
            int initial = 0;
            int nextNum = 1;
            for (int i = 2; i < numberUpto; i++)
            {
                nextNum = nextNum + initial;
                initial = nextNum- initial;
            }

            Console.WriteLine("Fibonacci value is : "+ nextNum );
        }
        #endregion

    }
}
