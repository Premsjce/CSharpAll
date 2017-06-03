using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibraryDemo
{
    public class HandlingExceptions
    {
        #region UnHandeled Exception(i.e Handling without Try/Catch block)
        public static void UnHandledExceptionMethod()
        {
            List<int> listIntegers = new List<int>();
            //Create the Task
            Task<List<int>> taskWithFactoryAndState = Task.Factory.StartNew((stateObj) =>
            {
                List<int> listInt = new List<int>();

                for (int i = 0; i < (int)stateObj; i++)
                {
                    listInt.Add(i);

                    if (i > 100)
                    {
                        InvalidOperationException invalidException = new InvalidOperationException("Its Invalid excepion thrown forcefully, Because stateObj is > 100");
                        invalidException.Source = "taskWithFactoryAndState";
                        throw invalidException;
                    }
                }
                return listInt;
            }, 2000);


            //Wait for the task to comlete, do not use Wait(). By doing so
            //Will cause any unhandled exception to remain unhandled
            if (!taskWithFactoryAndState.IsFaulted)
            {
                Console.WriteLine(string.Format("Managed to get {0} items", taskWithFactoryAndState.Result.Count));
            }


            //Below code is for Unhandled Excpetion
            while (!taskWithFactoryAndState.IsCompleted)
            {
                Thread.Sleep(100);

            }

            if (!taskWithFactoryAndState.IsFaulted)
            {
                listIntegers.AddRange(taskWithFactoryAndState.Result);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                AggregateException agEx = taskWithFactoryAndState.Exception;

                foreach (Exception ex in agEx.InnerExceptions)
                {
                    sb.AppendLine(String.Format("Caght Exception : {0}", ex.Message));
                }

                Console.WriteLine(sb.ToString());
            }

            //All done with Task, so now time dispose it.
            taskWithFactoryAndState.Dispose();

        }

        #endregion

        #region Handeling Exception gracefully
        public static void HandledExceptionsMethod()
        {
            List<int> listIntegers = new List<int>();
            //Create the Task
            Task<List<int>> taskWithFactoryAndState = Task.Factory.StartNew((stateObj) => 
            {
                List<int> listInt = new List<int>();

                for(int i = 0; i< (int)stateObj ; i ++)
                {
                    listInt.Add(i);

                    if(i> 100)
                    {
                        InvalidOperationException invalidException = new InvalidOperationException("Its Invalid excepion thrown forcefully, Because stateObj is > 100");
                        invalidException.Source = "taskWithFactoryAndState";
                        throw invalidException;
                    }
                }
                return listInt;
            },2000);


            try
            {
                //For handling Exceptions
                //Use one of the Trigger methods i.e Wait() to make sure AggregatorException is being observed
                taskWithFactoryAndState.Wait();

                if (!taskWithFactoryAndState.IsFaulted)
                {
                    Console.WriteLine(string.Format("Managed to get {0} items", taskWithFactoryAndState.Result.Count));
                }
            }
            catch (AggregateException agEx)
            {
                foreach(Exception ex in agEx.InnerExceptions)
                {
                    Console.WriteLine("Caught the Exception: {0}", ex.Message);
                }
            }
            finally
            {
                taskWithFactoryAndState.Dispose();
            }

        }
        #endregion

    }
}
