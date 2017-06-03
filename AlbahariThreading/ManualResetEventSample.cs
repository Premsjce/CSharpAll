using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlbahariThreading
{
    class ManualResetEventSample
    {
        static ManualResetEvent _waitHandle = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            Thread _workerThread1 = new Thread(HelperMethod1);
            Thread _workerThread2 = new Thread(HelperMethod2);
            _workerThread1.Start();
            _workerThread2.Start();

            Thread.Sleep(1000);
            _waitHandle.Reset();

            Thread.Sleep(2000);
            _waitHandle.Set();

        }

        static void HelperMethod1()
        {
            Console.WriteLine("In helper Methid 1.. Waiitng");
            _waitHandle.WaitOne();
            Thread.Sleep(2000);
            Console.WriteLine("In helper Methid 1.. Waiting finsihed");
            

        }

        static void HelperMethod2()
        {
            Console.WriteLine("In helper Methid 2.. Waiting");
            _waitHandle.WaitOne();
            Thread.Sleep(2000);
            Console.WriteLine("In helper Methid 2.. Waiting finsihed");
        }
    }
}
