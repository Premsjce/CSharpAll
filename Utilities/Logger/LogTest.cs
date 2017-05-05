using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Utilities.Logger
{
    class LogTest
    {
        static readonly ILog logger = LogManager.GetLogger(typeof(LogTest));

        static void DoNothing(string [] args)
        {
            BasicConfigurator.Configure();

            logger.Debug("Debug log");
            logger.Error("Error log");
            logger.Fatal("Fatal log");
            logger.Info("Info log");
            logger.Warn("Warning log");

        }

    }
}
