using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlbahariThreading
{
    class CountDownEventSample
    {
        static CountdownEvent vount = new CountdownEvent(5);
        static void MainA(string[] args)
        {
            Thread thread1 = new Thread(Method1);
            Thread thread2 = new Thread(Method2);
            Thread thread3 = new Thread(Method3);
            Thread thread4 = new Thread(Method4);
            Thread thread5 = new Thread(Method5);

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();

            //CountDownEvent allows you to wait from multiple threads. 
            //once you get the intialaizd count signal then the function continues
            //to execute the next line

            //wait till 5 count down event signals are recieved
            vount.Wait();
            Console.WriteLine("Printing form the main method");
        }

        private static void Method1()
        {
            Console.WriteLine("Im in method1");
            Thread.Sleep(2000);
            vount.Signal();

        }
        private static void Method2()
        {
            Console.WriteLine("Im in method2");
            Thread.Sleep(2000);
            vount.Signal();

        }
        private static void Method3()
        {
            Console.WriteLine("Im in method3");
            Thread.Sleep(2000);
            vount.Signal();

        }
        private static void Method4()
        {
            Console.WriteLine("Im in method4");
            Thread.Sleep(2000);
            vount.Signal();

        }
        private static void Method5()
        {
            Console.WriteLine("Im in method5");
            Thread.Sleep(2000);
            vount.Signal();

        }

    }
}
