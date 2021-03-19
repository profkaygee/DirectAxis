using System;
using System.IO;

namespace CustomLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger("testlogger.log", Logger.Level.Info);

            logger.Debug("Debug Message Test");
            logger.Info("Info Message Test");
            logger.Error("Error Message Test");

            logger.Info("Demo of Logger Starting");

            for (int i = 0; i < 5; i++)
            {
                logger.Info("i = {0}", i);
            }

            logger.Info("Demo of logger complete.");
        }
    }

    public class Logger
    {
        public string logFilePath;
        public Logger.Level logLevel;

        public Logger(string logPath, Logger.Level level)
        {
            logFilePath = logPath;
            logLevel = level;

            using (var writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine("Logger Initialised");
                writer.Close();
            }
        }

        ~Logger()
        {
            using (var writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine("Logger Destroyed");
                writer.Close();
            }
        }

        internal void Debug(string message)
        {
            if (logLevel != Level.Debug)
                return;

            using (var writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")} DBG {message}");
                writer.Close();
            }
        }

        internal void Debug(string message, object value)
        {
            if (logLevel != Level.Debug)
                return;

            using (var writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")} DBG {string.Format(message, value)}");
                writer.Close();
            }
        }

        internal void Error(string message)
        {
            if (logLevel != Level.Debug && logLevel != Level.Info && logLevel != Level.Error)
                return;

            using (var writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")} ERR {message}");
                writer.Close();
            }
        }

        internal void Error(string message, object value)
        {
            if (logLevel != Level.Debug && logLevel != Level.Info && logLevel != Level.Error)
                return;

            using (var writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")} ERR {string.Format(message, value)}");
                writer.Close();
            }
        }

        internal void Info(string message)
        {
            if (logLevel == Level.Info || logLevel == Level.Debug)
            {
                using (var writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")} INF {message}");
                    writer.Close();
                }
            }
        }

        internal void Info(string message, object value)
        {
            if (logLevel == Level.Info || logLevel == Level.Debug)
            {
                using (var writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")} INF {string.Format(message, value)}");
                    writer.Close();
                }
            }
        }

        public enum Level
        {
            Debug = 0,
            Info = 1,
            Error = 2
        }
    }


}
