using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static log4net.Appender.RollingFileAppender;

namespace AlbahariThreading
{
    class MainMethod
    {
        static void Main(string[] args)
        {
            AppDomain appDomain = AppDomain.CurrentDomain;
            appDomain.UnhandledException += AppDomain_UnhandledException;

            
            #region Exception From Different Threads

            try
            {
                Thread threadForException = new Thread(() =>
                {
                    throw new Exception(string.Format("Exception is being thrown form Different Thread : {0}", Thread.CurrentThread.Name));
                });
                threadForException.Name = "ThreadForException";
                threadForException.Start();
                threadForException.Join();

                Task taskExcption = Task.Run(() =>
                {
                    throw new Exception(string.Format("Exception is being thrown form Different Task : {0}", Thread.CurrentThread.Name));
                });


                taskExcption.Wait();
                //Sleep for some time
                Thread.Sleep(5000);
                //throw new Exception("Exception thrown from Main Thread");

            }
            catch(Exception ex)
            {
                Console.WriteLine("caught the excpetion" + ex.Message);
            }


            Console.Read();
            #endregion

            #region MultiThread

            Thread threadOne = new Thread(Go);
            threadOne.Name = "FirstThread";
            threadOne.Start();
            Thread.Sleep(1);
            Go();
            Console.Read();
            #endregion

            #region ManualResetEvent Sample

            Thread _workerThread1 = new Thread(ManualResetEventSample.HelperMethod1);
            Thread _workerThread2 = new Thread(ManualResetEventSample.HelperMethod2);
            _workerThread1.Start();
            _workerThread2.Start();

            Thread.Sleep(2000);

            #endregion

            #region SynchronozationContextSample

             SynchronozationContextSample syncSample = new SynchronozationContextSample();

             Thread thread1 = new Thread(syncSample.SomeMethod);
             Thread thread2 = new Thread(syncSample.SomeMethod);
             Thread thread3 = new Thread(syncSample.SomeMethod);
             Thread thread4 = new Thread(syncSample.SomeMethod);

             syncSample.SomeMethod();
             thread1.Start();
             thread2.Start();
             thread3.Start();
             thread4.Start();
            #endregion

        }

        private static void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Came int unhandeled excpetion with message as " + (e.ExceptionObject as Exception).Message);
        }

        static void Go()
        {
            Console.WriteLine("Printing Go on time " + DateTime.Now.ToString("hh.mm.ss.ffffff") + " from thread {0}", Thread.CurrentThread.Name);
        }

    }
}
