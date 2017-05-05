using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    class DelegateSample
    {
        public int FirstFunction(string strParamenter, int intParameter)
        {
            Console.WriteLine("First Test Function");
            Console.WriteLine(strParamenter);
            return intParameter;
        }
            
        public int SecondFunction(string strParamenter, int intParameter)
        {
            Console.WriteLine("Second Test Function");
            Console.WriteLine(strParamenter);
            return intParameter;
        }

        public void ThirdFunction(string strParameter, int intParameter)
        {
            Console.WriteLine("Thirsd Test function");
            Console.WriteLine(strParameter);
        }


        public bool FourthFunction(Employee exEmp)
        {
            Console.WriteLine("Fourth Test function");
            return exEmp.Age < 27;
        }

        public  XEmployee FifthFunction(Employee emp)
        {
            return new XEmployee()
            {
                Name = emp.Name,
                Age = emp.Age,
            };
        }

        public int SixthFunction(Employee strParamter1, Employee strParameter2)
        {
            return strParamter1.Name.CompareTo(strParameter2.Name);
        }

    }
}
