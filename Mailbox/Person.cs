using System;
using System.Diagnostics.CodeAnalysis;

namespace Mailbox
{
    public struct Person : IEquatable<Person> 
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }

        public Person(String firstName, String lastName)
        {
            if(firstName is null || lastName is null)
            {
                throw new ArgumentNullException();
            }
            
            FirstName = firstName;
            LastName = lastName;
        }

        public bool Equals([AllowNull]Person other)
        {
            if(LastName == other.LastName && FirstName == other.FirstName)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }
            return Equals((Person)obj);
        }

        public override int GetHashCode()
        {
            return (FirstName, LastName).GetHashCode();
            
        }

        public static bool operator ==(Person a, Person b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Person a, Person b)
        {
            return !a.Equals(b);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

}