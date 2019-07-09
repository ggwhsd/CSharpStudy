using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleLogger;
using SimpleLogger.Logging.Handlers;

namespace MarketRiskUI
{
    class LoggerTest
    {
        public static void TestLogOne()
        {
            var currentDate = DateTime.Now;
            var guid = Guid.NewGuid();
            string filename = string.Format("Log_{0:0000}{1:00}{2:00}-{3:00}{4:00}_{5}.log",
               currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, guid);

            Logger.LoggerHandlerManager
               .AddHandler(new ConsoleLoggerHandler())
               .AddHandler(new FileLoggerHandler(filename, "./kk"))
               .AddHandler(new DebugConsoleLoggerHandler());
            Logger.Log("test");

            Logger.Log(Logger.Level.Fine, "Explicit define level");

            //Logger.DefaultLevel = Logger.Level.Severe;
            Logger.Log(Logger.Level.Info, "AfterSetDefaultLevel" + Logger.DefaultLevel);
            Logger.DefaultLevel = Logger.Level.Info;
            Logger.Log(Logger.Level.Severe, "AfterSetDefaultLevel"+ Logger.DefaultLevel);

            try
            {
                // Simulation of exceptions
                throw new Exception();
            }
            catch (Exception exception)
            {
                //只有debug目前是有开关控制是否输出debug日志，其他level的都无法控制，只能输出。
                Logger.Log(exception);
                Logger.Log<LoggerTest>(exception);


                Logger.Debug.Log("Debug log");
                Logger.Debug.Log<LoggerTest>("Debug log");

                Logger.DebugOff();
                Logger.Debug.Log("Not-logged message");

                Logger.DebugOn();
                Logger.Debug.Log("I'am back!");

            }
        }
    }
}
