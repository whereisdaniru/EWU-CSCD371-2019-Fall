using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        public string FilePath { get; } = "People.csv";

        // 1.
        public IEnumerable<string> CsvRows 
            => File.ReadAllLines(FilePath)
            .Skip(1);


        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
            => CsvRows.Select(line => line.Split(",")[6]).Distinct().OrderBy(line => line);

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => string.Join(", ", GetUniqueSortedListOfStatesGivenCsvRows());

        // 4.
        public IEnumerable<IPerson> People 
            => CsvRows.Select(line =>
            {
                string[] columns = line.Split(',');
                return new Person()
                {
                    FirstName = columns[1],
                    LastName = columns[2],
                    EmailAddress = columns[3],
                    Address = new Address
                    {
                        StreetAddress = columns[4],
                        City = columns[5],
                        State = columns[6],
                        Zip = columns[7]
                    }
                };
            })
            .OrderBy(person => person.Address.State)
            .ThenBy(person => person.Address.City)
            .ThenBy(person => person.Address.Zip);


        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) 
            => People.Where(person => filter(person.EmailAddress)).Select(name => (name.FirstName, name.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people)
        {
            return people.Select(person => person.Address.State)
                           .Distinct()
                           .Aggregate((current, next) => current + ", " + next)
                           .ToString();
        }
    }
}
