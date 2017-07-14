using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    public interface IDataBase
    {
        void Connect(string connectionString);

        void Close();

        object GetData();

        void SendData(object data);


    }
}
