using System;

namespace LectureNotes
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Person contact = new Employee
        //    {
        //        EmployeeId = "1",
        //        FirstName = "Inigo",
        //        LastName = "Montoya"
        //        //MiddleName = "Ykmf"
        //    };

        //    Person person = (Contact)"Princess Buttercup None 2";

        //    PrintPerson(person);
        //    PrintEmployee((Employee)person);

        //    var contact2 = person as Contact;
        //    if (contact2 != null)
        //    {
        //        PrintContact(contact2);
        //    }
        //}

        static void PrintContact(Contact contact)
        {
            Console.WriteLine(contact.FullName());
        }
        static void PrintPerson(Person person)
        {
            Console.WriteLine(person.FullName());
        }

        static void PrintEmployee(Employee employee)
        {
            Console.WriteLine(employee.FullName());
        }
    }

    public static class Extensions
    {
        public static string FullName(this Person person)
        {
            return $"{person.LastName}, {person.FirstName}";
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public static explicit operator Person(string name)
        //{
        //    var person = new Person();
        //    var splitName = name.Split(' ');

        //    person.FirstName = splitName[0];
        //    person.LastName = splitName[1];

        //    return person;
        //}

        public virtual string FullName()
        {
            return $"{FirstName} {LastName}";
        }
    }

    public class Employee : Person
    {
        public string EmployeeId { get; set; }

        public override sealed string FullName()
        {
            return $"{EmployeeId} - {FirstName} {LastName}";
        }
    }

    public class Contact : Employee
    {
        public string MiddleName { get; set; }

        public virtual new string FullName()
        {
            return $"{LastName}, {FirstName} {MiddleName}";
        }

        public static explicit operator Contact(string name)
        {
            var person = new Contact();
            var splitName = name.Split(' ');

            person.FirstName = splitName[0];
            person.LastName = splitName[1];
            person.MiddleName = splitName[2];
            person.EmployeeId = splitName[3];

            return person;
        }
    }
}
