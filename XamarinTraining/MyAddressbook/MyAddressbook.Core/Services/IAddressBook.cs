using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyAddressbook.Core.Models;

namespace MyAddressbook.Core
{
	public interface IAddressBook
	{
		event EventHandler PersonChanged;
		Task<IEnumerable<Person>> GetPeople();
		Task<Person> GetPerson(int personId);
		Task UpdatePerson(Person person);
	}
}
