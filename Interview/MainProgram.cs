using DependencyInjectionDemo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Interview
{
    /// <summary>
    /// Main Program for console application
    /// </summary>
    static class MainProgram
    {
        static void Main(string[] args)
        {
            #region LinkedList Sample
            SampleLinkedList.SampleMethod();
            Console.Read();
            #endregion

            #region ObjectPool design Patter

            EmployeeFactory factory = new EmployeeFactory();
            Employee employee = factory.GetEmployee();
            employee.FirstName = "RudreGowda";
            Console.WriteLine(employee.FirstName);            

            Employee emplyeeTwo = factory.GetEmployee();
            emplyeeTwo.FirstName = "ByreGowda";
            Console.WriteLine(emplyeeTwo.FirstName);

            Employee emplioyeeThree = factory.GetEmployee();
            Console.WriteLine(emplioyeeThree.FirstName);

            Employee employeeFour = factory.GetEmployee();
            Console.WriteLine(employeeFour.FirstName);

            Employee employeeFive = factory.GetEmployee();
            Console.WriteLine(employeeFive.FirstName);

            Employee employeeSix = factory.GetEmployee();
            Console.WriteLine(employeeSix.FirstName);

            Employee employeeSeven = factory.GetEmployee();
            Console.WriteLine(employeeSeven.FirstName);

            Employee employeeEight = factory.GetEmployee();
            Console.WriteLine(employeeEight.FirstName);

            Console.Read();
            #endregion

            #region Find the Palindrome in given String
            Stopwatch stopWatch = new Stopwatch();
            string inputPalindrome = "1234xyzyx496569445544xyzyx1234xyzyx496569445544xyzyx1234xyzyx496569445544xyzyx2";
            Palindrome palindrome = new Palindrome();
            stopWatch.Restart();
            palindrome.FindPalindrome(inputPalindrome);
            stopWatch.Stop();
            Console.WriteLine("Total time taken for Operation in  MilliSeconds : " +stopWatch.ElapsedMilliseconds.ToString());

            string palidromeWithCount = palindrome[6];
            Console.WriteLine(palidromeWithCount);

            Console.Read();
            #endregion

            #region Constructor Chaining

            ClassOne classTHree = new ClassThree();
            Console.Read();            
            #endregion

            #region PartialClass Demo

            PrimeMinister pm = new PrimeMinister();
            pm.PrintFirstName();
            pm.PrintlastName();
            Console.Read();
            #endregion

            #region VideoEncoding Using Events Sample

            Video InputVideo = new Video();
            InputVideo.Artist = "LinkinPark";
            InputVideo.Title = "NUMB";

            VideoEncoder vidEncoder = new VideoEncoder();
            MailService mailService = new MailService();
            TextService textService = new TextService();

            vidEncoder.VideoEncoded += mailService.SendMessage;
            vidEncoder.VideoEncoded += textService.SendMessage;
            vidEncoder.EncodeVideo(InputVideo);

            //Decode Video is an Extension method
            VideoEncoder decodedVideo  = vidEncoder.DecodeVideo();

            //Factoroial is also Extension Method
            int temp = 5.Factorial();
            Console.Read();

            #endregion

            #region Inhetitence Sample

            Hashtable hashTable = new Hashtable();
            hashTable.Add("asd", "ksdajsd");

            AbstractClass ab = new DerrivedFromAbstact();
            ab.Print();
            DerrivedFromAbstact derivedAbstract = new DerrivedFromAbstact();
            derivedAbstract.Print();

            BaseClass derrivedClass =  new DerrivedClass2();
            derrivedClass.Print();
            #endregion

            #region Operator Overloading
            OperatorOverloading operator1 = new OperatorOverloading();
            OperatorOverloading operator2 = new OperatorOverloading();

            operator1.FirstName = "Narendra";
            operator2.LastName = "Modi";

            string result = operator1 + operator2;
            Console.WriteLine(result);


            #endregion

            #region ref and normal parameter for Functions

            int i = 5;
            int j = 6;
            Calculate(ref i);
            Calculate(j);
            #endregion

            #region Difference between Array , List and ArrayList
            ArrayList list = new ArrayList();
            list.Add("a");
            list.Add(1);

            List<string> listString = new List<string>();
            listString.Add("askjdbas");
            #endregion

            #region FileLogger Instantition
            ILogger fileLogger = Logger.InstanceCreation(new FileLogger());
            fileLogger.Log("ashdbaks.md ahlsdbak.,s");
            #endregion

            #region BruteForce

            BruteForce bruteForce = new BruteForce();
            bruteForce.DetectPassword();
            #endregion

            #region DeadLockDemo
            DeadLock deadLock = new DeadLock();
            deadLock.SharedResourceOne = "SharedResourceOne";
            deadLock.SharedResourceTwo = "SharedResourceTwo";
            deadLock.MainMethod();
            #endregion
            
            #region Find Duplicate in Given string
            string inputDuplicate = "TEMPasdTEMPTEMPasdTEMPTEMPasdTEMP";
            DuplicateAlphabets duplicateAlphabets = new DuplicateAlphabets(inputDuplicate);
            //string output = duplicateAlphabets.FindDuplicate(inputDuplicate);
            //Console.WriteLine(output);
            #endregion

            #region Fibonacci
            Fibonacci fibonacci = new Fibonacci();
            fibonacci.FindFibonacciTotal(13);
            #endregion
        }


        #region Static Method(s)

        static void Calculate(ref int numA)
        {
            numA *= numA;
            Console.WriteLine(numA);
        }

        static void Calculate(int numA)
        {
            Console.WriteLine(numA * numA * numA);
        }
        #endregion
    }
}
