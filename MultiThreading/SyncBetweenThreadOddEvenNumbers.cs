using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    /// <summary>
    /// SyncBetweenThreadOddEvenNumbers Class
    /// </summary>
    public class SyncBetweenThreadOddEvenNumbers
    {
        static AutoResetEvent _autoOddNoThread = new AutoResetEvent(false);
        static AutoResetEvent _autoEvenNoThread = new AutoResetEvent(false);

        public SyncBetweenThreadOddEvenNumbers()
        {
            //Default Constructor
        }

        public void PrintNumberFromDifferentThreads()
        {
            Thread oddThread = new Thread(PrintOddNumbers);
            Thread evenThread = new Thread(PrintEvenNumbers);
            evenThread.Start();
            oddThread.Start();
            
        }

        private void PrintOddNumbers()
        {
            
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 != 0)
                {
                    _autoOddNoThread.WaitOne();
                    Console.Write("Printing : {0}\t", i);
                    _autoEvenNoThread.Set();
                    
                    
                }
            }
        }

        private void PrintEvenNumbers()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0)
                {   
                    Console.Write("Printing : {0}\t", i);
                    _autoOddNoThread.Set();
                    _autoEvenNoThread.WaitOne();

                }
            }
        }

    }
}
