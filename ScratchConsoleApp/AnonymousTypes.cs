using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchConsoleApp
{
    public class AnonymousTypes
    {
        public static void SampleAnonymouTypesMethod()
        {
            var anonType = new
            {
                Amount = 100,
                Price = 200,
                Message = "Hello"
            };

            Console.WriteLine("Amount is : {0}, \n Price is : {1}, \n Message is {2}",anonType.Amount, anonType.Price, anonType.Message);

        }
    }
}
