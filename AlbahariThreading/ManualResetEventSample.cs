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

            Thread.Sleep(2000);
            
        }

        static void HelperMethod1()
        {
            //When the Handle is reset then There will be no reciever 
            _waitHandle.Reset();

            Console.WriteLine("In helper Methid 1.. Waiitng");
            _waitHandle.WaitOne();
            Thread.Sleep(2000);
            Console.WriteLine("In helper Methid 1.. Waiting finsihed");
            

        }

        static void HelperMethod2()
        {
            Console.WriteLine("In helper Methid 2.. Waiting");
            //_waitHandle.WaitOne();
            Thread.Sleep(2000);
            //Manual reset event from only one set can trigger mulitple waithandles which are waiting for signals
            _waitHandle.Set();
            Console.WriteLine("In helper Methid 2.. Waiting finsihed");
            

        }
    }
}
