using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyAddressbook.Core.Models;
using Newtonsoft.Json;

namespace MyAddressbook.Core.Services
{
	public class AddressBook : IAddressBook
	{
		private readonly Person[] _people;

		public AddressBook()
		{
			_people = new[]
			{
				new Person {Id = 1, FirstName = "Harvey", LastName = "Specter", Birthday = new DateTime(1979, 4, 21)},
				new Person {Id = 2, FirstName = "Louis", LastName = "Litt", Birthday = new DateTime(1975, 8, 12)},
				new Person {Id = 3, FirstName = "Rachel", LastName = "Reese", Birthday = new DateTime(1983, 2, 1)},
				new Person {Id = 4, FirstName = "Michael", LastName = "Ross", Birthday = new DateTime(1980, 5, 10)},
			};
		}

		#region Implementation of IAddressBook

		public event EventHandler PersonChanged;

		public Task<IEnumerable<Person>> GetPeople()
		{
            var people =  JsonConvert.DeserializeObject<IEnumerable<Person>>(JsonConvert.SerializeObject(_people));
			return Task.FromResult(people);
		}

		public Task<Person> GetPerson(int personId)
		{
			var foundPerson = _people.FirstOrDefault(p => p.Id == personId);
		    if (foundPerson != null)
		    {
		        foundPerson = JsonConvert.DeserializeObject<Person>(JsonConvert.SerializeObject(foundPerson));
		    }
			return Task.FromResult(foundPerson);
		}

		public async Task UpdatePerson(Person person)
		{
			var foundPerson = _people.FirstOrDefault(p => p.Id == person.Id);
			if (foundPerson == null) throw new ArgumentException($"Could not find a person with Id {person.Id}");

			foundPerson.FirstName = person.FirstName;
			foundPerson.LastName = person.LastName;
			foundPerson.Birthday = person.Birthday;

			PersonChanged?.Invoke(this, null);

			await Task.FromResult(string.Empty);
		}

		#endregion
	}
}
