using System;
using System.ComponentModel;

namespace AsynchronousProgramming
{
    class CLient
    {
        public static TimeConsumingOperations timeConsumingOperation = new TimeConsumingOperations();
        static void Main(string[] args)
        {
            BackgroundWorker _worker = new BackgroundWorker();
            _worker.DoWork += _worker_DoWork;
            _worker.RunWorkerAsync();
            Console.WriteLine(timeConsumingOperation.CompareItems<string>("Number1","Number2"));
            _worker.DoWork -= _worker_DoWork;
        }

        private static void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            timeConsumingOperation.GetFactorial(5);
        }
    }
}
