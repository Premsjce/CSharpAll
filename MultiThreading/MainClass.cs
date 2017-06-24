using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    /// <summary>
    /// Main Entry call for this Program
    /// </summary>
    static class MainClass
    {
        static AutoResetEvent oddThread = new AutoResetEvent(false);
        static AutoResetEvent evenThread = new AutoResetEvent(false);

        static void Main(string[] args)
        {

            #region BackgroudWroker Demo
            BacgroundWorkerDemo bgDemo = new BacgroundWorkerDemo();
            bgDemo.TakesCareOfTimeConsumingWork();
            
            #endregion
            
            #region  Using Conventional Threads

            SyncBetweenThreadOddEvenNumbers oddEvenThread = new SyncBetweenThreadOddEvenNumbers();
            oddEvenThread.PrintNumberFromDifferentThreads();
            #endregion

            #region Using TaskFactory

            Task oddTask = Task.Factory.StartNew(() =>
           {
               for (int i = 0; i < 100; i++)
               {
                   if (i % 2 != 0)
                   {
                       oddThread.WaitOne();
                       Console.Write(i + "\t");
                       evenThread.Set();
                       
                   }
               }
           });


            Task evenTask = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write(i + "\t");
                        oddThread.Set();
                        evenThread.WaitOne();
                    }
                }
            });

            Task.WaitAny(oddTask, evenTask);
            Console.WriteLine("\nPress any Key to Continue");
            Console.Read();
            #endregion
            
        }
    }
}
