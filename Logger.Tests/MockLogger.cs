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
            
        }

        public  string[] Messages()
        {
            return null;
        }
    }
}
