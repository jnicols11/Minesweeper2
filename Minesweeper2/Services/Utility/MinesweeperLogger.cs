using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper2.Services.Utility
{
    public class MinesweeperLogger
    {
        private static MinesweeperLogger instance; // Singleton Design Pattern
        private static Logger logger; // static variable to hold a single instance of NLogger

        // default constructor
        private MinesweeperLogger()
        {

        }
        public static MinesweeperLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new MinesweeperLogger();
            }
            return instance;
        }
        public void Debug(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myAppLoggerRules").Debug(message);
            }
            else
            {
                GetLogger("myAppLoggerRules").Debug(message, arg);
            }
        }

        public void Error(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myAppLoggerRules").Error(message);
            }
            else
            {
                GetLogger("myAppLoggerRules").Error(message, arg);
            }
        }

        public void Info(String message, String arg = null)
        {
            if (arg == null)
            {
                GetLogger("myAppLoggerRules").Info(message);
            }
            else
            {
                GetLogger("myAppLoggerRules").Info(message, arg);
            }
        }

        public void Warning(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myAppLoggerRules").Warn(message);
            }
            else
            {
                GetLogger("myAppLoggerRules").Warn(message, arg);
            }
        }
        private Logger GetLogger(string theLogger)
        {
            if (MinesweeperLogger.logger == null)
            {
                MinesweeperLogger.logger = LogManager.GetLogger(theLogger);
            }
            return MinesweeperLogger.logger;
        }
    }
}