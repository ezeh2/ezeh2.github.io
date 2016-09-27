using System.Collections.Generic;
using System.Linq;
using CollectionView.Droid.Models;
using CollectionView.Droid.Utils;

namespace CollectionView.Droid.Services
{
    internal class PersonService
    {
        public IList<Person> GeneratePeople(int count)
        {
            var firstNames = new List<string>(count);
            var lastNames = new List<string>(count);

            for (int i = 0; i < count; ++i)
            {
                firstNames.Add(NameGenerator.GenRandomFirstName());
                lastNames.Add(NameGenerator.GenRandomLastName());
            }

            return firstNames.Zip(lastNames, (firstName, lastName) => new Person(firstName, lastName)).ToList();
        }
    }
}