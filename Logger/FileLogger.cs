using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string filePath;

        public FileLogger(string filePath)
        {
            this.filePath = filePath;

            if(!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }

        public override void Log(LogLevel logLevel, string message)
        {
            string logData = $"{DateTime.Now} {className} {logLevel} {message}";

            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(logData);
            }
        }
    }
}
