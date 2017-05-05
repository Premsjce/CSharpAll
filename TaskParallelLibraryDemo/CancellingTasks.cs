using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibraryDemo
{
    public class CancellingTasks
    {
        public static void CancellingSingleTask()
        {
            //Creating the cancellation token
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            //Creating the Cancellation token
            CancellationToken token = tokenSource.Token;

            //Create and start the task
            Task<List<int>> taskWithFactoryAndState = Task.Factory.StartNew((stateObj) =>
            {
                List<int> listInt = new List<int>();
                for (int i = 0; i < (int)stateObj; i++)
                {
                    listInt.Add(i);
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine("taskWithFactoryAndState, Creating Item : {0}", i);
                }
                return listInt;
            }, 2000, token);

            //Write out the cancellation detail of the task
            Console.WriteLine("Task Cancelled .. ? : {0}", taskWithFactoryAndState.IsCanceled);

            //Cancel the token source
            tokenSource.Cancel();

            if (!taskWithFactoryAndState.IsCanceled && !taskWithFactoryAndState.IsFaulted)
            {
                try
                {
                    if (!taskWithFactoryAndState.IsFaulted)
                    {
                        Console.WriteLine("Managed to get {0} items.", taskWithFactoryAndState.Result.Count);
                    }
                }
                catch (AggregateException aggEx)
                {
                    foreach (Exception ex in aggEx.InnerExceptions)
                    {
                        Console.WriteLine("Caught {0} Exception", ex.Message);
                    }
                }
                finally
                {
                    taskWithFactoryAndState.Dispose();
                }
            }
            else
            {
                Console.WriteLine("Task Cancelled .. ? : {0}", taskWithFactoryAndState.IsCanceled);
            }

        }

        public static void CancellingOneOfSeveralTasks()
        {
            CancellationTokenSource tokenSource1 = new CancellationTokenSource();
            CancellationToken token1 = tokenSource1.Token;

            Task<List<int>> taskWithFactoryAndState1 = Task.Factory.StartNew((stateObj) =>
            {
                List<int> listInt = new List<int>();

                for (int i = 0; i < (int)stateObj; i++)
                {
                    listInt.Add(i);
                    token1.ThrowIfCancellationRequested();
                    Console.WriteLine("taskWithFactoryAndState1 : Creating Item of {0}", i);
                }
                return listInt;
            }, 2000, token1);

            CancellationTokenSource tokenSource2 = new CancellationTokenSource();
            CancellationToken token2 = tokenSource2.Token;

            Task<List<int>> taskWithFactoryAndState2 = Task.Factory.StartNew((stateObj) =>
            {
                List<int> listInt = new List<int>();

                for (int i = 0; i < (int)stateObj; i++)
                {
                    listInt.Add(i);
                    token2.ThrowIfCancellationRequested();
                    Console.WriteLine("taskWithFactoryAndState2 : Creating Item of {0}", i);
                }
                return listInt;
            }, 15, token2);


            //Cancel the first Token
            tokenSource1.Cancel();

            //Observing the taskWithFactoryAndState1
            try
            {
                Console.WriteLine("taskWithFactoryAndState1  Cancelled ? {0}", taskWithFactoryAndState1.IsCanceled);

                //We didn't calculate the Tokensource1, So Print the result here.
                Console.WriteLine("taskWithFactoryAndState1  results count ? {0}", taskWithFactoryAndState1.Result.Count);

                Console.WriteLine("taskWithFactoryAndState1  Cancelled ? {0}", taskWithFactoryAndState1.IsCanceled);

            }
            catch (AggregateException agEx)
            {
                PrintException(taskWithFactoryAndState1, agEx, "taskWithFactoryAndState1");
            }
            finally
            {
                taskWithFactoryAndState1.Dispose();
            }


            //Cancel the Second Token
            //tokenSource2.Cancel();

            //Observing the taskWithFactoryAndState2
            try
            {
                Console.WriteLine("taskWithFactoryAndState2  Cancelled ? {0}", taskWithFactoryAndState2.IsCanceled);

                //We didn't calculate the Tokensource1, So Print the result here.
                Console.WriteLine("taskWithFactoryAndState2  results count ? {0}", taskWithFactoryAndState2.Result.Count);

                Console.WriteLine("taskWithFactoryAndState2  Cancelled ? {0}", taskWithFactoryAndState2.IsCanceled);

            }
            catch (AggregateException agEx)
            {
                PrintException(taskWithFactoryAndState2, agEx, "taskWithFactoryAndState2");
            }
            finally
            {
                taskWithFactoryAndState2.Dispose();
            }

        }

        #region Helper Methods

        private static void PrintException(Task task, AggregateException aggEx, string taskName)
        {
            foreach (Exception ex in aggEx.InnerExceptions)
            {
                Console.WriteLine(string.Format("{0} caugh excepion in {1}", taskName, ex.Message));
            }
            Console.WriteLine(string.Format("{0} Cancelled task ? ", taskName, task.IsCanceled));
        }
        #endregion
    }
}
