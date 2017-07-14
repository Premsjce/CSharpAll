using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Threading;
using ZZScratchConsoleApp;

namespace ScratchConsoleApp
{

    /// <summary>
    /// Main class which has an Entry point for this Console Application
    /// </summary>
    public class Program
    {

        #region Main Method

        static void Main()
        {
            #region Scratch
            string start = @"C:\Users\310225812\Desktop\ToDelete\MasterLink\x_paper_kit_v1.2.2\__MACOSX";
            string result = @"C:\Users\310225812\Desktop\ToDelete\MasterLink\x_paper_kit_v1.2.2\__MACOSX.zip";
            string extractpath = @"C:\Users\310225812\Desktop\ToDelete\MasterLink\x_paper_kit_v1.2.2\__MACOSXExtracted";
            ZipFile.CreateFromDirectory(start, result);
            #endregion

            #region Decimal Degree Converter
            LattitudeToDecimalDegrees decimalConverter = new LattitudeToDecimalDegrees();
            Console.WriteLine(decimalConverter.ConvertDMSToDecimal("75:30:16", 6));
            #endregion

            #region Checking collections and Generics
            IList<int> list = new List<int>();
            list.Add(100);

            List<string> listString = new List<string>(6);
            listString.Add("1");

            #endregion

            #region LINQ sample
            LINQSample.SampleMethod2();
            #endregion

            #region Countdown waitHandle

            new Thread(SaySomething).Start("I am thread 1");
            new Thread(SaySomething).Start("I am thread 2");
            new Thread(SaySomething).Start("I am thread 3");

            _countdown.Wait();   // Blocks until Signal has been called 3 times
            Console.WriteLine("All threads have finished speaking!");
            #endregion

            #region TrapWater Example

            TrapWater tp = new TrapWater();
            Console.WriteLine("Trappedwater count is :" + tp.Trap(new int[] { 12, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1, 3, 12 }));

            #endregion

            #region Consolidate Excpetion Handling

            ExceptionConsolidated.CheckException();
            #endregion

            #region Anonymous Method            
            AnonymousTypes.SampleAnonymouTypesMethod();
            #endregion

            #region Program Class Instance Creation
            Program p = new Program();
            p.SamplePublicMethod1();
            #endregion



        }
        #endregion

        #region Static Method

        static void SaySomething(object thing)
        {

            Thread.Sleep(1000);
            Console.WriteLine(thing);
            _countdown.Signal();
        }

        #endregion

        #region Public Methods

        public void SamplePublicMethod1()
        {
            SamplePublicMethod2();
        }

        public void SamplePublicMethod2()
        {
            //do nohting
            //SamplePublicMethod2();
        }

        #endregion

        #region Static Members
        static CountdownEvent _countdown = new CountdownEvent(3);
        #endregion
    }
}
