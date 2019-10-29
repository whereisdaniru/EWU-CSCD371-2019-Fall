using System;
using System.Diagnostics;
using System.IO;

namespace Lecture1029
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentException(nameof(args), "My message here");
            }


            try
            {
                // lots of IO stuff here
                Console.WriteLine("Hello World!");
            }
            catch (IOException ex) when (ex.Message == "foo")
            {
                //Do something
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e}");
                throw;
            }
        }
    }

    public class MyException : Exception
    {
        public MyException(string message) : base(message)
        {

        }
    }
}
