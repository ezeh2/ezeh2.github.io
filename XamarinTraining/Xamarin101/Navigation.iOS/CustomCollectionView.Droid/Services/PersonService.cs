using System;
using System.Collections.Generic;
using System.Linq;
using CustomCollectionView.Droid.Models;
using CustomCollectionView.Droid.Utils;

namespace CustomCollectionView.Droid.Services
{
    internal class PersonService
    {
        public IList<Person> GeneratePeople(int count)
        {
            var personParameters = new List<Tuple<string,string, DateTime>>(count);

            for (int i = 0; i < count; ++i)
            {
                var firstName = NameGenerator.GenRandomFirstName();
                var lastName = NameGenerator.GenRandomLastName();
                var birthday = RandomDay();
                personParameters.Add(new Tuple<string, string, DateTime>(firstName, lastName, birthday));
            }

            return personParameters.Select(p => new Person(p.Item1, p.Item2, p.Item3)).ToList();
        }

        private DateTime RandomDay()
        {
            DateTime start = new DateTime(1950, 1, 1);
            Random gen = new Random();

            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}