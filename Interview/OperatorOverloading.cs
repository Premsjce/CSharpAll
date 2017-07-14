using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class OperatorOverloading
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static string operator+(OperatorOverloading op1 , OperatorOverloading op2)
        {
            OperatorOverloading result = new OperatorOverloading();

            result.FirstName = op1.FirstName;
            result.LastName = op2.LastName;
            return result.FirstName + result.LastName;

        }
    }
}
