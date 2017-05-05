using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Subsystems
{
    class Loan
    {
        public bool HasNoBadLoan(Customer cust)
        {
            Console.WriteLine("Check loans for : {0}", cust.Name);
            return true;
        }
    }
}
