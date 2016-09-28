using System;
using Newtonsoft.Json;

namespace WebService.Core.Models
{
    public class Person
    {
        private readonly string _firstName;
        private readonly string _lastName;

        public Person(string firstName, string lastName)
        {
            if (firstName == null) throw new ArgumentNullException(nameof(firstName));
            if (lastName == null) throw new ArgumentNullException(nameof(lastName));
            _firstName = firstName;
            _lastName = lastName;
        }

        public string FirstName { get { return _firstName; } }
        public string LastName { get { return _lastName; } }
        [JsonIgnore]
        public string FullName { get { return $"{_firstName} {_lastName}"; } }

        public override string ToString()
        {
            return FullName;
        }
    }

}
