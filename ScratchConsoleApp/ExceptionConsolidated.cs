using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace ScratchConsoleApp
{
    public class ExceptionConsolidated
    {
        public static void CheckException()
        {
            try
            {

                //int x, y;
                //x = 1;
                //y = 0;
                //int a = x / y;

                throw new ApplicationException();
            }
            catch(Exception ex)
            {
                
                if (ex is SEHException || ex is UnauthorizedAccessException || ex is ArgumentNullException ||
                     ex is ArgumentException || ex is PathTooLongException || ex is DirectoryNotFoundException ||
                     ex is FileNotFoundException || ex is NotSupportedException || ex is IOException ||ex is SystemException)
                {
                    Console.WriteLine("Caught exception is from the list");
                }
                else
                {
                    Console.WriteLine("Its new exception and will be rethrown");
                }
                 
            }
        }

    }
}
