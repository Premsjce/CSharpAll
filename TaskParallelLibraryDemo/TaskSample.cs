using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibraryDemo
{
    /// <summary>
    /// Sample class for Task's
    /// </summary>
    public class TaskSample
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskSample"/> class.
        /// </summary>
        public TaskSample()
        {
            //Default Constructor.
        }

        #endregion

        #region MainMethod

        /// <summary>
        /// Mains the mehtod.
        /// </summary>
        public void MainMehtod()
        {
            #region Without Using Task.Factory
            
            Task task1 = new Task(() => { DoWork(1, 500); });
            Task task2 = new Task(() => { DoWork(2, 500); });
            Task task3 = new Task(() => { DoWork(3, 500); });
            Task task4 = new Task(() => { DoWork(4, 500); });

            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();
            #endregion

            #region Using Task.Facaory
            Task taskFactory1 = Task.Factory.StartNew(() => { DoWork(5, 1000); });
            Task taskFactory2 = Task.Factory.StartNew(() => { DoWork(6, 3000); });
            Task taskFactory3 = Task.Factory.StartNew(() => { DoWork(7, 5000); });
            Task taskFactory4 = Task.Factory.StartNew(() => { DoWork(8, 2000); });
            #endregion
        }

        #endregion

        #region Static Methods

        private static void DoWork(int threadID, int sleepTimer)
        {
            Console.WriteLine("Task {0} is Beginnig",threadID);
            //Do som work, Simulate the work done by sleeping the thread
            Thread.Sleep(sleepTimer);
            Console.WriteLine("Task {0} is Completed", threadID);

        }
        #endregion
    }
}
