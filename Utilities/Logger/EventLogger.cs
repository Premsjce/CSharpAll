using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDemo
{
    public class EventLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Writing from EventLogger's Log method " + message);
        }
    }
}
