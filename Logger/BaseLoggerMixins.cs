using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger logger, string message, params object[] args)
        {
            LogLevel logLevel = LogLevel.Error;

            if(logger is null)
            {
                throw new ArgumentNullException("Logger is null");
            }
            else
            {
                logger.Log(logLevel, string.Format(message, args));
            }
        }

        public static void Warning(this BaseLogger logger, string message, params object[] args)
        {
            LogLevel logLevel = LogLevel.Warning;

            if(logger is null)
            {
                throw new ArgumentNullException("Logger is null");
            }
            else
            {
                logger.Log(logLevel, string.Format(message, args));
            }
        }

        public static void Information(this BaseLogger logger, string message, params object[] args)
        {
            LogLevel logLevel = LogLevel.Information;

            if(logger is null)
            {
                throw new ArgumentNullException("Logger is null");
            }
            else
            {
                logger.Log(logLevel, string.Format(message, args));
            }
        }

        public static void Debug(this BaseLogger logger, string message, params object[] args)
        {
            LogLevel logLevel = LogLevel.Debug;

            if(logger is null)
            {
                throw new ArgumentNullException("Logger is null");
            }
            else
            {
                logger.Log(logLevel, string.Format(message, args));
            }
        }
    }
}
