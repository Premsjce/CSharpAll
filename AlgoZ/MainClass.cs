using System;
using System.Threading;

namespace AlgoZ
{
    class MainClass
    {
        static void Main(string[] args)
        {
            int[] inputsArray1 = { 9, 7, 23, 5, 4, 23, 1, 1, 0 };
            int[] inputsArray2 = { 9, 7, 23, 5, 4, 23, 1, 1, 0 };
            int[] inputsArray3 = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

            //int[] outputArray =  BubbleSort.Sort(inputsArray2);
            int[] outputArray = SelectionSort.Sort(inputsArray3);

            Console.WriteLine();
            Console.WriteLine("Sorted Array");
            for (int i = 0; i < outputArray.Length; i++)
            {
                Console.Write(" " + outputArray[i]);
            }
            Console.WriteLine();
        }
    }
}
