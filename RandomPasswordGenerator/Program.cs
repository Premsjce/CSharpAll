using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Factorial of 5 is {0}", Factorial(5));
            Console.WriteLine(PasswordGenerator.GetPassword(10));
        }


        public static int Factorial(int _number)
        {
            if (_number == 0)
                return 1;
            else
                return (_number * Factorial(_number-1));
        }
    }


}
