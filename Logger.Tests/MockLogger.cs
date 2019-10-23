using System;

namespace Logger
{
    public class MockLogger :BaseLogger
    {

        public MockLogger(string className)
        {
            ClassName = className;
        }
        
        public override void Log(LogLevel logLevel, string message)
        {
            InternalMessages.Add(FormatLogEntry(logLevel, message));
        }

        System.Collections.Generic.List<string> InternalMessages { get; } = 
            new System.Collections.Generic.List<string>();
        public string[] Messages
        {
            get
            {
                return System.Linq.Enumerable.ToArray(InternalMessages);
            }
        }
    }
}
