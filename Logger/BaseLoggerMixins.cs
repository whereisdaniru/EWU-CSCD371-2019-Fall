using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(BaseLogger logger, string message, params object[] args)
        {
            LogLevel logLevel = LogLevel.Error;

            if(logger is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                logger.Log(logLevel, message);
            }
        }

        public static void Warning(BaseLogger logger, string message, params object[] args)
        {
            LogLevel logLevel = LogLevel.Warning;

            if(logger is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                logger.Log(logLevel, message);
            }
        }

        public static void Information(BaseLogger logger, string message, params object[] args)
        {
            LogLevel logLevel = LogLevel.Information;

            if(logger is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                logger.Log(logLevel, message);
            }
        }

        public static void Debug(BaseLogger logger, string message, params object[] args)
        {
            LogLevel logLevel = LogLevel.Debug;

            if(logger is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                logger.Log(logLevel, message);
            }
        }
    }
}
