using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinodSession
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ICar> listOfCars = new List<ICar>();
            listOfCars.Add(new Audi());
            listOfCars.Add(new BMW());
            listOfCars.Add(new Toyota());

            Driver driver = new Driver();
            foreach(ICar car in listOfCars)
            {
                driver.Drive(car);
            }
        }
    }
}
