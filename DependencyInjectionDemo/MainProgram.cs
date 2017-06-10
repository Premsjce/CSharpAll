using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DependencyInjectionDemo
{
    class MainProgram
    {

        #region No Need to create so many different logger, Use Dependecy Injection

        /*
        static EventLogger evnetLogger = new EventLogger();
        static FileLogger fileLogger = new FileLogger();
        static XMLLogger xmlLogger = new XMLLogger();
        */
        #endregion

        static Logger LoggerSample; 

        static void Main(string[] args)
        {
            //Injecting the Dependency
            ILogger logger = new XMLLogger();
            LoggerSample = Logger.InstanceCreation(logger);
            LoggerSample.Log("Entered the Main Method");
            LoggerSample.Log("Calling SomeJunkMethod()");
            SomeJuntMethod();
        }

       static void SomeJuntMethod()
        {
            LoggerSample.Log("SomeJunkMethod -- Entry");
            //Doing some simulation hat this metod is doing somehting
            Thread.Sleep(2000);
            LoggerSample.Log("SomeJunkMethod -- Exit");

        }
    }
}
