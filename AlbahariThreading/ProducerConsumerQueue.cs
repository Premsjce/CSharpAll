using System;
using System.Collections.Generic;
using System.Threading;

namespace AlbahariThreading
{
    class ProducerConsumerQueue : IDisposable
    {
        EventWaitHandle _wh = new AutoResetEvent(false);
        Thread _workerThread;
        readonly object syncLock = new object();
        Queue<string> _tasks = new Queue<string>();

        public ProducerConsumerQueue()
        {
            _workerThread = new Thread(Work);
            _workerThread.Start();
        }


        public void EnqueTask(string task)
        {
            lock(syncLock)
            {
                _tasks.Enqueue(task);
                _wh.Set();
            }
        }

        void Work()
        {
            while(true)
            {
                string task = null;
                lock(syncLock)
                {
                    if(_tasks. Count > 0)
                    {
                        //Load the task from the  Queue
                        task = _tasks.Dequeue();

                        //Say good bye when the task is null and Exit out of loop
                        if (task == null)
                            return;
                    }
                    if(task != null)
                    {
                        Console.WriteLine("Performing task : " + task);
                        Thread.Sleep(2000); //Simulate the work done
                    }
                    else
                    {
                        //No tasks are available, wait for the signal
                        //Console.WriteLine("No tasks are available, wait for the signal");
                        _wh.WaitOne();
                        //Console.WriteLine("notified from Enqueue mehtod that a Task iS ready for executing");
                    }
                }
            }
        }
        public void Dispose()
        {
            EnqueTask(null);
            _workerThread.Join();
            _wh.Close();
        }
    }
}
