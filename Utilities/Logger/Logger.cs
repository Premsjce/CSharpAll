using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionDemo
{
    /// <summary>
    /// Singleton Logger Class
    /// </summary>
    public class Logger : ILogger
    {
        public readonly static object lockObject = new object();
        private volatile static Logger _Instance;
        private ILogger loggerObject;

        private Logger(ILogger loggrType)
        {
            //Instance = GetTheInstance(loggrType);
            loggerObject = loggrType;
        }

        public static ILogger InstanceCreation(ILogger loggrType)
        {
            if (_Instance == null)
            {
                lock (lockObject)
                {
                    if (_Instance == null)
                    {
                        return new Logger(loggrType);
                    }
                }
            }
            return _Instance;
        }

        public void Log(string message)
        {
            loggerObject.Log(message);
        }
    }
}
