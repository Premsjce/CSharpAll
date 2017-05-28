using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlbahariThreading
{
    class EventWaitHandleSample
    {
        static EventWaitHandle waitHandle = new AutoResetEvent(true);

        static EventWaitHandle _fromMain = new EventWaitHandle(false, EventResetMode.AutoReset);
        static EventWaitHandle _fromWorker = new EventWaitHandle(false, EventResetMode.AutoReset);
        static readonly object syncLock = new object();
        static string _message;

        static void Main1(string[]  args)
        {
            using (ProducerConsumerQueue q = new ProducerConsumerQueue())
            {
                q.EnqueTask("Hello");
                for (int i = 0; i < 5; i++) q.EnqueTask("Say " + i);
                q.EnqueTask("Goodbye!");
            }


            /*
            Thread workerThread = new Thread(WorkerMethod);
            workerThread.Start();

            _fromMain.WaitOne();
            lock (syncLock)
            {
                _message = "going to get changed in worker Method during call 1";
            }
            
            _fromWorker.Set();

            _fromMain.WaitOne();
            lock (syncLock)
            {
                _message = "going to get changed in worker Method during call 2";
            }
            
            _fromWorker.Set();
            _fromMain.WaitOne();
            lock (syncLock)
            {
                _message = null;
            }
            _fromWorker.Set();


            new Thread(Waiter1).Start();
            Thread.Sleep(2000);
            waitHandle.Set();

            new Thread(Waiter2).Start();
            Thread.Sleep(4000);
            waitHandle.Set();

            new Thread(Waiter3).Start();
            Thread.Sleep(6000);
            waitHandle.Set();
            waitHandle.Close(); */
        }

        static void WorkerMethod()
        {
            while(true)
            {
                _fromMain.Set();
                _fromWorker.WaitOne();
                lock(syncLock)
                {
                    if (_message == null)
                        return;
                    else
                        Console.WriteLine(_message);
                }
            }
        }

        static void Waiter1()
        {
            Console.WriteLine("Wating in Waiter 1 Method....");
            waitHandle.WaitOne();
            Console.WriteLine("Notified to Waiter 1 Method..");
        }

        static void Waiter2()
        {
            Console.WriteLine("Wating in Waiter 2 Method....");
            waitHandle.WaitOne();
            Console.WriteLine("Notified to Waiter 2 Method.");
        }

        static void Waiter3()
        {
            Console.WriteLine("Wating in Waiter 3 Method....");
            waitHandle.WaitOne();
            Console.WriteLine("Notified to Waiter 3 Method..");
        }
    }
}
