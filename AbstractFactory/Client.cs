using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Client
    {
        static void Main(string[] args)
        {
            IAbstractFactory absFctryShape = new ShapeFactory();
            IShape shape = absFctryShape.CreateShapeFactory(Shapetype.Rectangle);


            IAbstractFactory absFctryColor = new ColorFactory();
            IColor color = absFctryColor.CreateColorFactory(ColorType.Blue);

            FactoryWorld fw = new FactoryWorld(shape, color);
            fw.GetShapeAndColor();
        }
    }
}
