using System;
using System.Collections.Generic;

namespace Lecture2019._10._08
{
    abstract class Program
    {
        static void Main(string[] args)
        {
            if (GetPerson() is Person person)
            {
                int len = person.FirstName?.Length ?? 0;
                    
                string foo = len == 0 ? "empty" : len.ToString();

                Console.WriteLine($"{foo} {len}");
            }

            var parsed = double.Parse("0.0");

            List<int> list = GetFoo();
        }

        private static List<int> GetFoo() => null;

        private static object GetPerson() => new Person("Kevin", null);

        public static void Main()
        {
            double foo = 0.3;
            string bar = $"{foo}";
            bool baz = double.TryParse(bar, out double f);
            Console.WriteLine($"{baz} {f}");
            (string firstName, string lastName) tuple = GetName();

            tuple.firstName = "Bob";
            DateTime current = DateTime.Now;
            DateTime tomorrow = current.AddDays(1);
        }

        public static (string city, string state) GetName()
        {
            return ("Kevin", "Bost");
        }

        public static void CheckNull(object parameter)
        {
            if (parameter is null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }
        }

        private class Person
        {
            private readonly string _lastName;
            public string FirstName { get; }

            public string LastName => _lastName ?? "unset";

            public Person(string firstName, string lastName)
            {
                FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
                _lastName = lastName;
            }
        }
    }
}
