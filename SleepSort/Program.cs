using System;
using System.Threading;

namespace SleepSortCSharp
{
    class SleepSort
    {
        static void Main(string[] args)
        {
            int[] _inputArray = { 100, 56, 32, 79, 1, 0, 55, 92, 55, 56 };

            foreach (int _temp in _inputArray)
            {
                Thread thread = new Thread(PrintNumber);
                thread.Start(_temp);
            }
        }

        static void PrintNumber(object num)
        {
            int number = (int)num;
            Thread.Sleep(number);
            Console.WriteLine(number);
        }
    }
}