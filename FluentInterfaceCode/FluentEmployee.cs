#region Prem's CopyWright(c) Information
/*#
#
#
#
#
#*/
#endregion

namespace FluentInterfaceCode
{
    /// <summary>
    /// Class that implements the IFluentEmployee Interface
    /// </summary>
    /// <seealso cref="FluentInterfaceCode.IFluentEmployee" />
    public class FluentEmployee : IFluentEmployee
    {
        #region Static Member(s)
        private static Employee employee;
        private static IFluentEmployee fluent;
        #endregion

        #region IFluentEmployee Implementation
        
        /// <summary>
        /// Initializes the Employee and FluentEmployee instance.
        /// </summary>
        /// <returns></returns>
        public static IFluentEmployee Init()
        {
            employee = new Employee();
            fluent = new FluentEmployee();
            return fluent;
        }

        /// <summary>
        /// Company name
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        public IFluentEmployee FluentCompany(string company)
        {
            employee.Company = company;
            return fluent;    
        }

        /// <summary>
        /// First name.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <returns></returns>
        public IFluentEmployee FluentFirstName(string firstName)
        {
            employee.FirstName = firstName;
            return fluent;
        }

        /// <summary>
        /// Last the name.
        /// </summary>
        /// <param name="lastName">The last name.</param>
        /// <returns></returns>
        public IFluentEmployee FluentLastName(string lastName)
        {
            employee.LastName = lastName;
            return fluent;
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public Employee FluentCreate()
        {
            return employee;
        }

        #endregion
    }
}

