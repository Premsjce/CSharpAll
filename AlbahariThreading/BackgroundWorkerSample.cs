using System;
using System.ComponentModel;
using System.Threading;

namespace AlbahariThreading
{

    class BackgroundWorkerSample
    {
        static BackgroundWorker _bgWorker;

        static void MainBackGroundWorker(string[] args)
        {
            _bgWorker = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            _bgWorker.DoWork += _bgWorker_DoWork;
            _bgWorker.ProgressChanged += _bgWorker_ProgressChanged;
            _bgWorker.RunWorkerCompleted += _bgWorker_RunWorkerCompleted;


            _bgWorker.RunWorkerAsync("Hello Background worker");

            Console.WriteLine("Press Enter in next 5 second to abort the operation");
            Console.ReadLine();
            if (_bgWorker.IsBusy)
            {
                _bgWorker.CancelAsync();
            }
            Console.ReadLine();

            _bgWorker.DoWork -= _bgWorker_DoWork;
            _bgWorker.ProgressChanged -= _bgWorker_ProgressChanged;
            _bgWorker.RunWorkerCompleted -= _bgWorker_RunWorkerCompleted;
        }

        static void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("Starting the work from the Background worker, and the value passed from calling method is");
            Console.WriteLine(e.Argument);

            for (int i = 0; i <= 100; i+=20)
            {
                if (_bgWorker.CancellationPending) { e.Cancel = true;return; }
                _bgWorker.ReportProgress(i);
                Thread.Sleep(1000); //Simulate that some work is being done
            }

            //This value will get passed to Run worker completed on completion of the fuction
            e.Result = 0123;
        }

        static void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                Console.WriteLine("You cancelled!");
            else if (e.Error != null)
                Console.WriteLine("Some Exception has been thrown. \nError is  : " + e.Error.Message);
            else
                Console.WriteLine("Complete : " + e.Result);
        }


        static void _bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine("Reached {0}%", e.ProgressPercentage);
        }
    }
}