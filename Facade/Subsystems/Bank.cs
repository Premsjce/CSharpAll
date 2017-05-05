using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Subsystems
{
    class Bank
    {
        public bool HasSufficientSaving(Customer cus, int amount)
        {
            Console.WriteLine("Check bank account for : {0}", cus.Name);

            //pretend that there is some amount checking logic is here and it returns true
            return true;
        }
    }

}
