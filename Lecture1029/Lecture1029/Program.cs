using System;
using System.Diagnostics;
using System.IO;

namespace Lecture1029
{
    class Program
    {
        private readonly object _Foo;

        public Program()
        {
            _Foo = new object();
        }

        static void Main(string[] args)
        {
            (int, int) numbers = (1, 2);
            Print(numbers); // (1, 2)
            AddNumbers(numbers);
            Print(numbers); // (1, 2)? (3, 2)?

            Pets pet = default;

            pet = Pets.Dog;

            Print(pet);
        }

        public static void AddNumbers((int a, int b) numbers)
        {
            //a += b;
            //numbers.Item1 += numbers.Item2;

             
        }

        public static void Print(object foo) => Console.WriteLine(foo.ToString());
    }


    [Flags]
    public enum Pets
    {
        Unknown = 0,
        None = Unknown,

        FlyDog = Dog | Chicken,

        Dog = 0b_0000,
        Cat = 0b_0001,
        Bird = 0b_0010,
        Chicken = 0b_0100
    }
}
