using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples
{
    /// <summary>
    /// Interface Segregaion Principle
    /// </summary>
    interface IDataBase
    {
        void Add();
    }

    interface IDataBaseRead : IDataBase
    {
        void Read();
    }

    class Enquiry : IDataBaseRead
    {
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }
    }
}
