using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{


    class ShapeFactory : IAbstractFactory
    {
        public IColor CreateColorFactory(ColorType colorType)
        {
            switch (colorType)
            {
                case ColorType.Red:
                    return new Red();
                case ColorType.Green:
                    return new Green();
                default:
                    return new Blue();
            }
        }

        public IShape CreateShapeFactory(Shapetype shapeType)
        {

            switch (shapeType)
            {
                case Shapetype.Circle:
                    return new Circle();
                case Shapetype.Rectangle:
                    return new Rectangle();
                default:
                    return new Square();
            }
        }
    }
}
