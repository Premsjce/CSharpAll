using Facade.Subsystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    /// <summary>
    /// The Facade Class
    /// </summary>
    class Mortgage
    {
        Bank bank = new Bank();
        Loan loan = new Loan();
        Credit credit = new Credit();
        
        public bool IsEligible(Customer cust, int amount)
        {
            bool eligible = true;

            Console.WriteLine("{0} applies for {1:C} loan\n",cust.Name, amount);

            if(!bank.HasSufficientSaving(cust,amount))
            {
                eligible = false;
            }
            else if(!loan.HasNoBadLoan(cust))
            {
                eligible = false;
            }
            else if(!credit.HasGoodCredit(cust))
            {
                eligible = false;
            }
            else
            {
                eligible =  true;
            }

            return eligible;
        }
    }
}
