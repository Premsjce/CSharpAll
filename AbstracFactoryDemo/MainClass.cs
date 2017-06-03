using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstracFactoryDemo
{
    class MainClass
    {
        static void Main(string[] args)
        {
            IContinentFactory americanFactory = new AmericanFactory();
            AnimalWorld animalAmericanWorld = new AnimalWorld(americanFactory);
            animalAmericanWorld.RunFoodChain();

            IContinentFactory afrcianFacory = new AfricanFactory();
            AnimalWorld animalAfricanWorld = new AnimalWorld(afrcianFacory);
            animalAfricanWorld.RunFoodChain();
        }
    }
}
