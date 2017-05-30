using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventTogether
{

    /// <summary>
    /// Sample delegate to hold methods with return Void and takes int  as input parameters
    /// </summary>
    /// <param name="intInput">The int input.</param>    
    public delegate void FirstDelegate(int intInput);


    /// <summary>
    /// Delegate Sample Class
    /// </summary>
    public class DelegateSample
    {        

        /// <summary>
        /// Sample delegate to hold methods with return Void and takes int and String as inputs parameters
        /// </summary>
        /// <param name="intInput">The temp1.</param>
        /// <param name="stringInput">The temp2.</param>
        public delegate void SecondDelegate(int intInput, string stringInput);

        public DelegateSample()
        {
            //default Construstor
            
        }


        private static void VoidMethodInt(int intInput)
        {
            //Do nothing
        }

        private void VoidMethodIntString(int tempInt, string tempString)
        {
            //Do nothing
        }
    }
}
