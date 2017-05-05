using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Red : IColor
    {
        public void Fill()
        {
            Console.WriteLine("Red Color");
        }
    }
}
