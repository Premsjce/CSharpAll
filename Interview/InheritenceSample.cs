using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class BaseClass
    {
        public virtual void Print()
        {
            Console.WriteLine("In Print method of " + this.GetType().Name);
        }
    }

    public class DerrivedClass : BaseClass
    {
        public override void Print()
        {
            Console.WriteLine("In Print method of " + this.GetType().Name);
        }
    }

    public class DerrivedClass2 : DerrivedClass
    {
        public void Print()
        {
            Console.WriteLine("In Print method of " + this.GetType().Name);
        }
    }


    public abstract class AbstractClass
    {
        public abstract void Print();
    }

    public class DerrivedFromAbstact : AbstractClass
    {
        public override void Print()
        {
            Console.WriteLine("printing from Derrived from abstract method in class :" + this.GetType().Name);
        }
    }
}
