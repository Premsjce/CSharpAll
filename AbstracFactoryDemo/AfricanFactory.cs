using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstracFactoryDemo
{
    public class AfricanFactory : IAfricanFactory
    {
        public ICarnivore CarnivoreFactory()
        {
            return new Lion();
        }

        public IHerbivore HerbivoreFactory()
        {
            return new WildeBeast();
        }
    }
}
