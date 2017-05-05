using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Client
    {
        static void Main(string[] args)
        {
            Customer cust = new Customer("NotMe");

            Mortgage mortgage = new Mortgage();
           bool eligible  = mortgage.IsEligible(cust, 1000);

            Console.WriteLine("\n" + cust.Name + "has been " + (eligible? "Approved" : "Rejected"));
        }
    }
}
