using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    /// <summary>
    /// Basic Wait Handle
    /// </summary>
    class BasicWaitHandle
    {
        private static EventWaitHandle _waitHandle = new AutoResetEvent(false);

        static void MainEventWaitHandle(string[] args)
        {
            Thread worker = new Thread(new ThreadStart(Waiter));
            worker.Start();
            Thread.Sleep(2000);
            _waitHandle.Set();

            string s = "Temp String";
            Invoke(s);
        }

        private static void Invoke(object s)
        {
            Console.WriteLine("object param invoked");
        }

        private static void Invoke<T>(params T[] par)
        {
            Console.WriteLine("Genenric mehtods invoked");
        }

        static void Waiter()
        {
            Console.WriteLine("Waiting in Waiter method called from worker thread...");
            _waitHandle.WaitOne();
            _waitHandle.Close();
            Console.WriteLine("Completed Waiting in Waiter method called from worker thread...");
        }
    }
}
