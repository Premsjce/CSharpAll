using System;
using System.Threading;

namespace AlbahariThreading
{
    class Chapter1
    {
        static bool done;
        static readonly object syncLock = new object();
        static void Main(string[] args)
        {

            Thread thrd = new Thread(Go);
            thrd.Start();
            
            Go();
            Console.WriteLine((ThreadState.WaitSleepJoin == Thread.CurrentThread.ThreadState) ? "TRUE" : "FALSE");
        }

        static void Go()
        {
            lock (syncLock)
            {

                Thread.Sleep(1000);
                int val1 = 1, val2 = 1;

                if (val2 != 0)
                {
                    int result = val1 / val2;
                    val2 = 0;
                }
            }
        }
    }

}
