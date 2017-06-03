using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibraryDemo
{
    /// <summary>
    /// Main class
    /// </summary>
    class MainClass
    {
        static void Main(string[] args)
        {
            #region Starter StarterMethod 
            //Day1 Class 1
            //Starter.StarterMethod();
            #endregion

            #region DifferentWaysToCreateTasks
            //Day1 Class 2
            //DifferentWaysToCreateTasks.DifferentWaysToCreateTasksMethod();
            #endregion

            #region HandlingExceptions

            //Day2 Class 1 
            //HandlingExceptions.UnHandledExceptionMethod();
            //HandlingExceptions.HandledExceptionsMethod();
            //CancellingTasks.CancellingSingleTask();
            //CancellingTasks.CancellingOneOfSeveralTasks();
            #endregion

            #region AsyncAwaitSample
            //AsyncAwaitSample.MyMethodAsync();
            #endregion

            #region Task Sample
            TaskSample taskSample = new TaskSample();
            taskSample.MainMehtod();
            #endregion

            #region Exiting the code

            Console.WriteLine("Thats it buddy. You're up now");
            Console.ReadLine();
            #endregion
        }

       
    }
}
