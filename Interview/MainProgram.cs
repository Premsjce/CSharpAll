using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Interview
{
    /// <summary>
    /// Main Program for console application
    /// </summary>
    static class MainProgram
    {
        static void Main(string[] args)
        {

            #region DeadLockDemo
            DeadLock deadLock = new DeadLock();
            deadLock.SharedResourceOne = "SharedResourceOne";
            deadLock.SharedResourceTwo = "SharedResourceTwo";
            deadLock.MainMethod();
            #endregion

            #region Private Memer(s)
            Stopwatch stopWatch = new Stopwatch();
            #endregion

            #region Find Duplicate in Given string
            string inputDuplicate = "TEMPasdTEMPTEMPasdTEMPTEMPasdTEMP";
            DuplicateAlphabets duplicateAlphabets = new DuplicateAlphabets(inputDuplicate);
            //string output = duplicateAlphabets.FindDuplicate(inputDuplicate);
            //Console.WriteLine(output);
            #endregion

            #region Find the Palindrome in given String

            string inputPalindrome = "1234xyzyx496569445544xyzyx1234xyzyx496569445544xyzyx1234xyzyx496569445544xyzyx2";
            Palindrome palindrome = new Palindrome();

            stopWatch.Restart();
            //palindrome.FindPalindrome(inputPalindrome);
            stopWatch.Stop();
            //Console.WriteLine("Total time taken for Operation in  MilliSeconds : "
                //+stopWatch.ElapsedMilliseconds.ToString());
            #endregion

            #region Fibonacci
            Fibonacci fibonacci = new Fibonacci();
            //fibonacci.FindFibonacciTotal(13);
            #endregion
        }
    }
}
