using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class FactoryWorld
    {
        IShape _shape;
        IColor _color;

        public FactoryWorld(IShape shape, IColor color)
        {
            _shape = shape;
            _color = color;
        }

        public void GetShapeAndColor()
        {
            _shape.Draw();
            _color.Fill();
        }
    }
}
