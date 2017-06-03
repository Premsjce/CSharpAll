using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstracFactoryDemo
{
    public class AnimalWorld
    {
        public AnimalWorld(IContinentFactory continentFactory)
        {
            herbivore = continentFactory.HerbivoreFactory();
            carnivore = continentFactory.CarnivoreFactory();
        }
        private IHerbivore herbivore;
        private ICarnivore carnivore;

        public void RunFoodChain()
        {
            carnivore.Eat(herbivore);
        }
    }
}
