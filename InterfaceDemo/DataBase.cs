using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    public class DataBase : IDataBase
    {
        public void CustomMthod()
        {
            //does nothing
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Connect(string connectionString)
        {
            throw new NotImplementedException();
        }

        public object GetData()
        {
            throw new NotImplementedException();
        }

        public void SendData(object data)
        {
            throw new NotImplementedException();
        }
    }
}
