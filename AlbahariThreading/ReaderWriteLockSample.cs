using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AlbahariThreading
{
    class ReaderWriteLockSample
    {
        static ReaderWriterLockSlim readWriteLock = new ReaderWriterLockSlim();
        static List<int> items = new List<int>();
        static Random random = new Random();


        static void Main(string [] args)
        {
            Thread thread1 = new Thread(Read);
            Thread thread2 = new Thread(Read);
            Thread thread3 = new Thread(Read);
            Thread thread4 = new Thread(Write);
            Thread thread5 = new Thread(Write);

            thread1.Start("Read-A");
            thread2.Start("Read-B");
            thread3.Start("Read-C");

            thread4.Start("Write-D");
            thread5.Start("Write-E");
        }


        static void Read(object threaID)
        {
            while(true)
            {
                readWriteLock.EnterReadLock();
                foreach(int temp in items)
                {
                    Console.WriteLine("Reading from Thraed : {0}, Value is : {1}",threaID, temp);
                    Thread.Sleep(5000);
                }
                readWriteLock.ExitReadLock();
            }

        }

        static void Write(object threadID)
        {
            while(true)
            {
                int num = GetRandomNumber(100);
                readWriteLock.EnterWriteLock();
                items.Add(num);
                readWriteLock.ExitWriteLock();
                Console.WriteLine("Thread : {0} added number : {1}", threadID, num);
                Thread.Sleep(1000);

            }
        }

        static int GetRandomNumber(int max)
        {
            lock(random)
            {
                return random.Next(max);
            }
        }
    }
}
