using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlbahariThreading
{
    [Synchronization]
    class SynchronozationContextSample : ContextBoundObject
    {
        public void SomeMethod()
        {
            Console.WriteLine("Stating on Method... and Sleepting for a While");
            Thread.Sleep(1000);
            Console.WriteLine("Ending the Method.");
        }
    }
}
