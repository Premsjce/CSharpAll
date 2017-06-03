using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibraryDemo
{
    class AsyncAwaitSample
    {
        static string Greetings(string name)
        {
            Thread.Sleep(3000);
            return "Hello from : " + name ;
        }
        public async static void MyMethodAsync()
        {
            
            string temp = await MyMethodAwait("Bangari");
            Console.WriteLine(temp);
            
        }

        public static Task<string> MyMethodAwait(string name)
        {
            return Task.Run<string>(() =>
           {
               Thread.Sleep(3000); //Simulating some work is being done
               return "Hello from : " + name;
               //return Greetings(name); //Just another method to call from Task. call only when more line of code is present
           });
        }
    }
}
