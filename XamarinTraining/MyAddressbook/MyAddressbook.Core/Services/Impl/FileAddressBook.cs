using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PCLStorage;
using MyAddressbook.Core.Services;
using MyAddressbook.Core.Models;

namespace MyAddressbook.Core.Services
{
	public class FileAddressBook : IAddressBook
	{
		private IEnumerable<Person> _people;
		private const string FileName = "AddressBook.json";
		private const string StorageLocation = "AddressBook";
		private object _sync = new object();

		private bool _isInitializing = false;

		#region Implementation of IAddressBook

		public event EventHandler PersonChanged;
		public async Task<IEnumerable<Person>> GetPeople()
		{
			await Init();
            var people =  JsonConvert.DeserializeObject<IEnumerable<Person>>(JsonConvert.SerializeObject(_people));
			return people;
		}

		public async Task<Person> GetPerson(int personId)
		{
			await Init();
            var foundPerson = _people.FirstOrDefault(p => p.Id == personId);

		    if (foundPerson != null)
		    {
		        foundPerson = JsonConvert.DeserializeObject<Person>(JsonConvert.SerializeObject(foundPerson));
		    }
		    return foundPerson;
		}

		public async Task UpdatePerson(Person person)
		{
			await Init();

			var foundPerson = _people.FirstOrDefault(p => p.Id == person.Id) ?? new Person();

			if (foundPerson.Id == 0)
			{
				foundPerson.Id = (_people.Last().Id + 1);
				var people = new List<Person>(_people);
				people.Add(foundPerson);
				_people = people;
			}

			foundPerson.FirstName = person.FirstName;
			foundPerson.LastName = person.LastName;
			foundPerson.Birthday = person.Birthday;

			await StorePeopleToFile();

			PersonChanged?.Invoke(this, null);
		}

		#endregion

		private async Task Init()
		{
			lock (_sync)
			{
				if (_isInitializing) return;
				_isInitializing = true;
			}

			if (_people == null)
			{
				_people = await ReadPeopleFromFile();
			}

			lock (_sync)
			{
				_isInitializing = false;
			}
		}

		private async Task StorePeopleToFile()
		{
			var folder = await NavigateToFolder(StorageLocation);
			IFile file = await folder.CreateFileAsync(FileName, CreationCollisionOption.ReplaceExisting);
			var peopleJson = JsonConvert.SerializeObject(_people);
			await file.WriteAllTextAsync(peopleJson);
		}

		private async Task<IEnumerable<Person>> ReadPeopleFromFile()
		{
			var folder = await NavigateToFolder(StorageLocation);

			if ((await folder.CheckExistsAsync(FileName)) == ExistenceCheckResult.NotFound)
			{
				await InitStorage();
			}

			IFile file = await folder.GetFileAsync(FileName);
			var jsonPeople = await file.ReadAllTextAsync();

			if (string.IsNullOrEmpty(jsonPeople)) return new List<Person>();

			var people = JsonConvert.DeserializeObject<IEnumerable<Person>>(jsonPeople);

			if (people == null)
			{
				await InitStorage();
				people = _people;
			}

			return people;
		}

		private async Task InitStorage()
		{
			_people = new[]
			{
				new Person {Id = 1, FirstName = "Harvey", LastName = "Specter", Birthday = new DateTime(1979, 4, 21)},
				new Person {Id = 2, FirstName = "Louis", LastName = "Litt", Birthday = new DateTime(1975, 8, 12)},
				new Person{Id = 3, FirstName = "Rachel", LastName = "Reese", Birthday = new DateTime(1983, 2, 1)},
				new Person{Id = 4, FirstName = "Michael", LastName = "Ross", Birthday = new DateTime(1980, 5, 10)},
			};

			await StorePeopleToFile();
		}

		private async Task<IFolder> NavigateToFolder(string targetFolder)
		{
			IFolder rootFolder = FileSystem.Current.LocalStorage;
			IFolder folder = await rootFolder.CreateFolderAsync(targetFolder,
				CreationCollisionOption.OpenIfExists);

			return folder;
		}
	}
}