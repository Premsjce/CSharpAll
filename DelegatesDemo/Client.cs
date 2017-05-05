using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    class Client
    {
        protected delegate int tempFunctionPointer(string strParameter, int intParameter);
        static Func<string, int, int> tempFuncPointer;
        static Action<string, int> tempActionPointer;
        static Predicate<Employee> tempPredicatePoiner;


        static void Main(string[] args)
        {
            DelegateSample tempObject = new DelegateSample();

            tempFunctionPointer funcPointer = tempObject.FirstFunction;
            funcPointer += tempObject.SecondFunction;

            //Calling the funcion explicitly
            //funcPointer("Hello 2nd Time", 2);

            tempFuncPointer += tempObject.FirstFunction;
            int retValue = tempFuncPointer("From Func methois", 1);
            Console.WriteLine("Return value from Func method is : " + retValue);

            tempActionPointer += tempObject.ThirdFunction;
            tempActionPointer("from Acion delegate", 3);

            tempPredicatePoiner += tempObject.FourthFunction;
            Employee emp = new Employee()
            {
                Name = "Employee Awesome",
                Age = 28
            };

            tempPredicatePoiner(emp);

        }
    }
}
