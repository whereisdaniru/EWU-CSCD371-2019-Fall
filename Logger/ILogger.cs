namespace Logger
{
    public interface ILogger
    {
        string ClassName { get; }
        void Log(LogLevel logLevel, string message);
    }
}
