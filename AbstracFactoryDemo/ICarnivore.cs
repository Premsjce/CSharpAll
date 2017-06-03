using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstracFactoryDemo
{
    public interface ICarnivore
    {
        void Eat(IHerbivore heribore);
    }
}
