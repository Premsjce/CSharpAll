using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples
{
    /// <summary>
    /// Liskov Substitution Principle
    /// </summary>
    class LSP
    {
    }

    class Parent
    {
        public virtual void Add()
        {
            //Some logic to Add
        }
    }

    class FirstChild : Parent
    {
        public override void Add()
        {
            //Some other logicx
        }
    }
}
