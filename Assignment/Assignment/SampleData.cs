using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows => File.ReadLines("People.csv").Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
            => CsvRows.Select(row => row.Split(",")[6]).OrderBy(State => State).Distinct();

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => String.Join(",", GetUniqueSortedListOfStatesGivenCsvRows().ToArray());

        // 4.
        public IEnumerable<IPerson> People 
            => CsvRows.Select(item => item.Split(",")).OrderBy(item => item[6]).ThenBy(item => item[5])
            .ThenBy(item => item[7]).Select(person => new Person(person[1], person[2], new Address(person[4], 
            person[5], person[6], person[7]), person[3]));

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => People.Where(person => person.EmailAddress.Equals(filter)).Select(person => (person.FirstName, person.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => String.Join(",", people.Select(State => State.Address.State));
    }
}
