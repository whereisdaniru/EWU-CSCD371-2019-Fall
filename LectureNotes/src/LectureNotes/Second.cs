using System;
using System.Collections.Generic;
using System.Text;

namespace LectureNotes
{
    public class Second
    {
        public static void Main()
        {
            Animal dog = new Dog() { IsDebarked = true };
            Animal cat = new Cat();

            dog.Speak();
            cat.Speak();

            //if (dog is Dog d)
            //{
            //    d.Bark();
            //}
            //if (cat is Cat c)
            //{
            //    c.Meow();
            //}
        }
    }


    static class ExtensionAnimal
    {
        public static void Speak(this Animal animal)
        {
            switch (animal)
            {
                case Dog d when !d.IsDebarked:
                    d.Bark();
                    break;
                case Dog d when d.IsDebarked:
                    Console.WriteLine("Can't speak");
                    break;
                case Cat c:
                    c.Meow();
                    break;
                case Animal a:
                    break;
            }
        }
    }
    public class Animal
    {
    }

    public class Dog : Animal
    {
        public bool IsDebarked { get; set; }
        public void Bark()
        {
            Console.WriteLine("Woof");
        }
    }
    public class Cat : Animal
    {
        public void Meow()
        {
            Console.WriteLine("Meow");
        }
    }

    public class Duck : Animal
    {
        public void Quack()
        {
            Console.WriteLine("Quack");
        }
    }
}
