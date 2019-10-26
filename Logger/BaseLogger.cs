using System;

namespace Logger
{
    public abstract class BaseLogger : ILogger
    {
        public string? ClassName { get; set; }

        public abstract void Log(LogLevel logLevel, string message);

        public virtual string FormatLogEntry(LogLevel logLevel, string message)
        {
            return $"{DateTime.Now:G} {ClassName??"<ClassName>"} {logLevel}: {message}{Environment.NewLine}";
        }
    }
}
