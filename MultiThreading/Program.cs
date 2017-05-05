using System;
using System.ComponentModel;
using System.Threading;

namespace MultiThreading
{
    class Program
    {
        public static Thread pvtThread = new Thread(()=> 
        {
            Console.WriteLine("Public Static threa from Main Method");
            Thread.Sleep(3000);
        });
        static BackgroundWorker _bgWorker = new BackgroundWorker()
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };

        static void NMain(string[] args)
        {
            NewClass nc = new NewClass();
            NewClass.Method2();

            Thread.CurrentThread.Name = "Main Thread";

            Console.WriteLine("Current thread name is {0}", Thread.CurrentThread.Name);
            Console.WriteLine("Main Thread Started");

            Thread thread = new Thread(() =>
                {
                    try
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Console.WriteLine("Executing ThreadOne");
                            Thread.Sleep(1000);

                        }
                    }
                    catch (ThreadAbortException x)
                    {
                        Console.WriteLine("Thread Abort excepion caught with messsage : {0}", x.Message);
                    }
                });
            thread.Start();
            thread.Join();
            Thread.Sleep(3000);
            thread.Abort();


            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Executing Main Thread");
                Thread.Sleep(3000);
            }

            Console.WriteLine("Main Thread Completed");
            Console.ReadLine();
        }
    }

    public class NewClass
    {
        public static void Method2()
        {
            Console.WriteLine("In Class B methd2");
            Thread.Sleep(9000);
            Program.pvtThread.Start();
        }
    }
}
