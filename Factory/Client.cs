using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// <summary>
    /// Creates an instance of several derived classes => FactoryMethod Definition
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            ShapeFactory shpFctry = new ShapeFactory();
            IShape circleObject = shpFctry.GetShape(Shapetype.Circle);
            circleObject.Draw();
        }
    }
}
