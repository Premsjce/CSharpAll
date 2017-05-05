using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Subsystems
{
    class Credit
    {
        public bool HasGoodCredit(Customer cust)
        {
            Console.WriteLine("Check credit score for  : {0}", cust.Name);
            return true;
        }
    }
}
