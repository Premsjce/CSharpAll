using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchConsoleApp
{
    class PyramidUpDown
    {
        static void EntryFunction()
        {
            runagain: Console.WriteLine("Enter the Number of Levels");
            int level;
            bool resul = int.TryParse(Console.ReadLine(), out level);

            if (!resul)
            {
                Console.WriteLine("Enter valid integer ");
                goto runagain;
            }
            else
            {
                //pyramid Bottom Up
                for (int i = (level * 2); i >= 0; i -= 2)
                {
                    for (int j = i; j < ((level * 2) - 1); j++)
                    {
                        Console.Write("* ");
                    }
                    Console.WriteLine();
                    for (int k = 0; k < i - 1; k++)
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();

                //Pyramid Top Down
                for (int i = 0; i < (level * 2); i += 2)
                {
                    for (int j = i; j < ((level * 2) - 1); j++)
                    {
                        Console.Write(" *");
                    }
                    Console.WriteLine();
                    for (int k = 0; k <= i; k++)
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();


            }
        }

    }
}
