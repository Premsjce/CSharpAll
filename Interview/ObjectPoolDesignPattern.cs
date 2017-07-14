using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{

    /// <summary>
    /// Object polling for Employee Factory
    /// </summary>
    public class EmployeeFactory
    {
        #region Static Fields

        private static int _poolMaxSize = 2;

        private static Queue<Employee> objPoolGeneric = new Queue<Employee>(_poolMaxSize);

        private static Queue objPoll = new Queue(_poolMaxSize);


        #endregion

        public Employee GetEmployee()
        {
            Employee oEmployee;

            if(objPoll.Count > 0)
            {
                return RetrieveEmployee();
            }
            else
            {
                return GetNewEmployee();
            }
        }

        private Employee GetNewEmployee()
        {
            Employee employee = new Employee();
            objPoll.Enqueue(employee);
            return employee;
        }

        private Employee RetrieveEmployee()
        {
            Employee employee;
            if(objPoll.Count > 0)
            {
                employee = (Employee)objPoll.Dequeue();
                Employee.couter--;
                return employee;
            }
            else
            {
                employee = new Employee();
                objPoll.Enqueue(employee);
                return employee;
                
            }
        }
    }

    #region Employee Class
    
    public class Employee
    {
        public static int couter = 0;
        public Employee()
        {
            ++couter;
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

    }
    #endregion
}

