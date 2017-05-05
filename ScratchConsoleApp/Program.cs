using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ScratchConsoleApp
{

    class Program
    {
        static CountdownEvent _countdown = new CountdownEvent(3);

        static void Main()
        {
            
            //new Thread(SaySomething).Start("I am thread 1");
            //new Thread(SaySomething).Start("I am thread 2");
            //new Thread(SaySomething).Start("I am thread 3");

            //_countdown.Wait();   // Blocks until Signal has been called 3 times
            //Console.WriteLine("All threads have finished speaking!");

            TrapWater tp = new TrapWater();
            Console.WriteLine("Trappedwater count is :" + tp.Trap(new int[] { 12, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1, 3, 12 }));
        }

        static void SaySomething(object thing)
        {

            Thread.Sleep(1000);
            Console.WriteLine(thing);
            _countdown.Signal();
        }



    }
}
