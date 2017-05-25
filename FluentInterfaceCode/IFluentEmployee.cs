using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentInterfaceCode
{
    /// <summary>
    /// Interface which defines the Fluent Employee
    /// </summary>
    public interface IFluentEmployee
    {
        /// <summary>
        /// First name.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <returns></returns>
        IFluentEmployee FluentFirstName(string firstName);

        /// <summary>
        /// Last the name.
        /// </summary>
        /// <param name="lastName">The last name.</param>
        /// <returns></returns>
        IFluentEmployee FluentLastName(string lastName);

        /// <summary>
        /// Company name
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        IFluentEmployee FluentCompany(string company);

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        Employee FluentCreate();
    }
}
