using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples
{
    /// <summary>
    /// Single Responsibilty Principle
    /// </summary>
    interface ILogger
    {
        void Log(Exception ex);
    }
   

    class Logger : ILogger
    {
        public void Log(Exception ex)
        {
            //Update the file with Exception details
        }
    }


    interface ICustomer
    {
        void Add();
    }
    class Customer : ICustomer
    {
        
        public void Add()
        {
            //Customer Add function logic 
        }
    }

    class CustomerMaintence
    {
        readonly ILogger logger;
        readonly ICustomer cusomer;

        public CustomerMaintence(ILogger _logger, ICustomer _customer)
        {
            logger = _logger;
            cusomer = _customer;
        }

        public void Add()
        {
            try
            {
                cusomer.Add();
            }
            catch(Exception ex)
            {
                //Log the exception to anywhere you want
                logger.Log(ex);
            }
        }

    }
}
