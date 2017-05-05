using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public enum Shapetype
    {
        Circle,
        Rectangle,
        Square
    }

    class ShapeFactory
    {
        public IShape GetShape(Shapetype shapeType)
        {
            switch(shapeType)
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
