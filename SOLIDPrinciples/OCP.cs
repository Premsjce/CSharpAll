using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples
{
    class Employee
    {
        
        private int employeeType;

        public int EmployeeType
        {
            get { return employeeType; }
            set { employeeType = value; }
        }

        public virtual double getDiscount(double totalSale)
        {
            return totalSale;
        }

        
        //Recursive funcion to find Facorial of a Number
        

    }

    class SilverEmployee  : Employee
    {
        public override double getDiscount(double totalSales)
        {
            return totalSales - 50;
        }
    }

    class GoldEmployee : Employee
    {
        public override double getDiscount(double totalSales)
        {
            return totalSales - 100;
        }
    }
}
