using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Interview
{
    
    public class DeadLock
    {
        public string SharedResourceOne { get; set; }
        public string SharedResourceTwo { get; set; }

        public void MainMethod()
        {
            Console.WriteLine("Entering the DeadLock main method");
            Console.WriteLine("Press Enter key to begin the deadlock situation");
            Console.ReadLine();
           
            Thread threadOne = new Thread(ThreadOneMethod);
            threadOne.Start();

            Thread threadTwo = new Thread(ThreadTwoMethod);
            threadTwo.Start();
        }
        
        public void ThreadOneMethod()
        {
            lock(syncLockOne)
            {
                Thread.Sleep(100);
                Console.WriteLine("ThreadOne: locked resource " + SharedResourceOne);
                lock (syncLockTwo)
                {
                    Console.WriteLine("Thread 2: locked resource " + SharedResourceTwo);
                }

            }
        }

        public void ThreadTwoMethod()
        {
            lock (syncLockTwo)
            {
                Thread.Sleep(100);
                Console.WriteLine("ThreadTwo: locked resource " + SharedResourceTwo);
                lock (syncLockOne)
                {
                    Console.WriteLine("Thread 1: locked resource " + SharedResourceOne);
                }

            }
        }

        private static object syncLockOne = new object();
        private static object syncLockTwo = new object();

    }
   
}
