using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Customer
    {
        private string  _name;

        public Customer(string name)
        {
            _name = name;
        }

        //Get the Name of the Customer from the Cusomer class which was initialized during the Instance creation ;)
        public string  Name
        {
            get { return _name; }
            
        }

    }
}
