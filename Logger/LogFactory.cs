namespace Logger
{
    public class LogFactory
    {
        private string LogFile { get; set; }

        public void ConfigureFileLogger(string logFile)
        {
            LogFile = logFile;
        }

        public ILogger CreateLogger(string className)
        {
            if (!string.IsNullOrWhiteSpace(LogFile))
            {
                return new FileLogger(LogFile)
                {
                    ClassName = className
                };
            }

            throw new System.InvalidOperationException("Log file name not specified.");
        }
    }
}
