using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    interface IAbstractFactory
    {
        IShape CreateShapeFactory(Shapetype shapeType);
        IColor CreateColorFactory(ColorType colorType);
    }
}
