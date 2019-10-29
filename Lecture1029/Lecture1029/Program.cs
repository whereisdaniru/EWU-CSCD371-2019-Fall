using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Lecture1029
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream fileStream = File.Open("Foo", FileMode.OpenOrCreate);
            var reader = new StreamReader(fileStream);
            using var writer = new StreamWriter(fileStream, leaveOpen:true);
            fileStream.Dispose();
            
            reader.Dispose();

            var hashSet = new HashSet<Person>();
            //var d = new Dictionary<int, string>();
            //d.Add(0, "");
            //d.Add(0, "Foo");
            //d[0] = "Foo";

            var kevin1 = new Person("Kevin", DateTime.Today.AddDays(-1), ssn: "123456");
            var kevin2 = new Person("Kevin", DateTime.Today.AddDays(-1), ssn: "123456");
            var kevin3 = new Person("Kevin", DateTime.Today.AddDays(-1), ssn: "123456");

            DateTime tomrrow = DateTime.Now + TimeSpan.FromDays(1);
            kevin1 = null;
            //Console.WriteLine($"Equals {kevin1.Equals(kevin2)}");
            Console.WriteLine($"== {kevin1 == kevin2}");

            hashSet.Add(kevin1);
            hashSet.Add(kevin2);
            hashSet.Add(kevin3);
            Console.WriteLine(hashSet.Count);
            //Print(kevin);
        }

        public static void Print(object foo) => Console.WriteLine(foo.ToString());
    }

    [DebuggerDisplay("{Name} {Dob}")]
    public class Person : IEquatable<Person>
    {
        public string Name { get; }

        public DateTime Dob { get; }

        private string Ssn { get; }

        public Person(string name, DateTime dob, string ssn = null)
        {
            Dob = dob;
            Ssn = ssn;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public bool Equals([AllowNull] Person other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Name == other.Name &&
                   Dob == other.Dob &&
                   Ssn == other.Ssn;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Person);
        }

        public override int GetHashCode()
        {
            return (Name, Dob, Ssn).GetHashCode();
            //int rv = Name.GetHashCode();
            //rv = rv ^ Dob.GetHashCode() * 397;
            //rv ^= Ssn?.GetHashCode() * 397 ?? 0;
            //return rv;
            //return Name.GetHashCode() + Dob.GetHashCode() + (Ssn?.GetHashCode() ?? 0);
        }
        
        public static bool operator ==(Person a, Person b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (ReferenceEquals(a, null)) return false;
            return a.Equals(b);
        }

        public static bool operator !=(Person a, Person b) => !(a == b);

        public override string ToString()
        {
            return $"{Name} {Dob:d} {Ssn?[^4..]}";
        }

    }
}
