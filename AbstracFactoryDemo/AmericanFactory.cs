using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstracFactoryDemo
{
    public class AmericanFactory : IAmericanFactory
    {
        public ICarnivore CarnivoreFactory()
        {
            return new Wolf();
        }

        public IHerbivore HerbivoreFactory()
        {
            return new Bison();
        }
    }
}
