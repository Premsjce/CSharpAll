using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDemo
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Writing from FileLogger's Log method " + message);
        }
    }
}
