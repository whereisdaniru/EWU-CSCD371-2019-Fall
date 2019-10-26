using Logger;
using System;

namespace SampleApp
{
    public static class Program
    {
        public static ILogger? Logger { get; set; }

        static public void Main()
        {
            string loggerblah;
            if (Logger is object)
            {
                loggerblah = Logger.ToString()!;
            }
            object? thing = Logger;
            string a = "Inigo";
            string b = $"{a}Montoya";
            a = $"{a}Montoya";


            Logger ??= new FileLogger($"{nameof(SampleApp)}.log");
            Logger?.Log(LogLevel.Information, "This is a test of ...");
            Logger?.Log(LogLevel.Information, "This is a test of ...");
            Console.WriteLine("Hello World!");
        }
    }
}
