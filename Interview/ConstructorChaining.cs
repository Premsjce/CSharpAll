using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class ClassOne
    {
        public ClassOne(): this(999)
        {
            Console.WriteLine("Class one constructor");
        }

        public ClassOne(int intOne) : this("Passed from base class constructor", intOne)
        {
            Console.WriteLine("Class one constructor with intOne number" + intOne);
        }

        public ClassOne(string overloaded, int num)
        {
            Console.WriteLine("Class one constructor with intOne number" + num + "and message as " + overloaded );
        }
    }


    public class ClassTwo : ClassOne
    {
        public ClassTwo() : base()
        {
            Console.WriteLine("Class two constructor");
        }
    }

    public class ClassThree : ClassTwo
    {
        public ClassThree() : base()
        {
            Console.WriteLine("Class three constructor");
        }
    }

}
