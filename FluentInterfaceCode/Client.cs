using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentInterfaceCode
{
    /// <summary>
    /// CLient that user the FLuentCode interface
    /// </summary>
    public static class Client
    {
        //Entry method for this application
        static void Main(string[] args)
        {
            //Writing the fluent interpretation of the Employee Constructor in following way. 
            var emp = FluentEmployee.Init()
                        .FluentFirstName("Jhon")
                        .FluentLastName("Wick")
                        .FluentCompany("dhoom taka dhoon")
                        .FluentCreate();
            Console.WriteLine("Employee Details are as Follows\n"+
                "First Name\t:\t{0},\n"+
                "Last Name\t:\t{1},\n" +
                "Company Name\t:\t{2}\n",emp.FirstName, emp.LastName,emp.Company);        
        }
    }
}
