using Newtonsoft.Json;
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
            var kevin1 = new Person("Kevin", DateTime.Today.AddDays(-1), ssn: "123456");
            var kevin2 = new Person("Joe", DateTime.Today.AddDays(-2), ssn: "456789");
            var kevin3 = new Person("Kenny", DateTime.Today.AddDays(-1), ssn: "98756");

            var coolPeople = new[] { kevin1, kevin2, kevin3 };

            string jsonData = JsonConvert.SerializeObject(coolPeople);
            
            
            using var ms = new MemoryStream();
            using var writer = new StreamWriter(ms, leaveOpen:true);
            writer.WriteLine(jsonData);
            writer.Flush();

            ms.Position = 0;

            List<Person> people = LoadPeople(ms);
        }

        private static List<Person> LoadPeople(Stream stream)
        {
            using var reader = new StreamReader(stream, leaveOpen:true);
            string jsonData = reader.ReadToEnd();

            List<Person> people = JsonConvert.DeserializeObject<List<Person>>(jsonData);
            return people;
        }

        public static void Print(object foo) => Console.WriteLine(foo.ToString());
    }

    public class Garbage : IDisposable
    {
        private IDisposable DisposableMember { get; }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    DisposableMember?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~Garbage()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion

    }

    [DebuggerDisplay("{Name} {Dob}")]
    public class Person : IEquatable<Person>
    {
        public string Name { get; }

        public DateTime Dob { get; }

        private string Ssn { get; }

        public Person(string name, DateTime dateOfBirth, string ssn = null)
        {
            Dob = dateOfBirth;
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
