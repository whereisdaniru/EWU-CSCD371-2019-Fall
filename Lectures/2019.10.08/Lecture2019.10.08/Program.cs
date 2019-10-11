using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lecture2019._10._08
{
    public static class DateTimeExtensions
    {
        public static bool IsNullOrEmpty(this string @string)
        {
            return string.IsNullOrEmpty(@string);
        }

        public static DateTime AssignmentDue(this DateTime now)
        {
            var tuesday = now.AddDays(-(int)now.DayOfWeek)
                .AddDays(2)
                .AddDays(7);
            tuesday = tuesday.Date.AddHours(12);

            return tuesday;
        }

        public static Person GetPerson(this DateTime now) => null;

        public static string GetFullName(this Person person) => "Kevin";
    }

    abstract class Program
    {
        [Flags]
        public enum AnimalTypes
        {
            Dog = 1,
            Cat = 2,
            Bird = 4,
            Duck = 8,

            FlyingDog = Dog | Duck
        }

        public static void Foo(object first, params int[] numbers)
        {

            void Swap(int first, int second)
            {
                
            }
        }

        public static void Main(string[] _)
        {
            DateTime assignmentDue = DateTime.Now.AssignmentDue();
            string fullName = DateTime.Now.GetPerson()?.GetFullName();
            Person kevin = null;
            kevin.GetFullName();

            string foo = "Kevin" + 
                "Bost" + fullName;

            Foo(null);
            Foo(null, 1);
            Foo(null, 1, 2, 3, 4, 5);
            
            string.Format("{0} {1}", 1, 2);
            
            string fullName2 = DateTimeExtensions.GetFullName(DateTimeExtensions.GetPerson(DateTime.Now));

            Console.WriteLine(assignmentDue);

            return;

            GetPerson();
            Console.WriteLine("Enter DOB (mm/dd/yy):");
            string dateString = $"{DateTime.Now:mm/dd/yy}";
            Console.WriteLine(dateString);
            dateString = $"{DateTime.Now:MM/dd/yy}";
            if (DateTime.TryParseExact(dateString, "mm/dd/yy", CultureInfo.CurrentCulture,
                DateTimeStyles.None, out DateTime parsedDate))
            {
                Console.WriteLine($"{parsedDate}");
            }

            var type = (AnimalTypes)(AnimalTypes.Cat + (int)AnimalTypes.Cat);

            var list = new List<int>
            {
                1,
                2,
                3
            };

            var cat = new Animal("")
            {
                Name = "cat"
            };

            var dog = new Animal("")
            {
                Name = "dog"
            };


            //string dateString = $"{DateTime.Now}";

        }


        static void MainOld(string[] args)
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

        /*
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
        */
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
    }

    public class Animal
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
        }
    }

    public class Person
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
