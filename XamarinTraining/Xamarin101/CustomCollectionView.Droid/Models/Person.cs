using System;

namespace CustomCollectionView.Droid.Models
{
    public class Person
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private DateTime _birthday;

        public Person(string firstName, string lastName)
        {
            if (firstName == null) throw new ArgumentNullException(nameof(firstName));
            if (lastName == null) throw new ArgumentNullException(nameof(lastName));
            _firstName = firstName;
            _lastName = lastName;
        }

        public Person(string firstName, string lastName, DateTime birthday) : this(firstName, lastName)
        {
            _birthday = birthday;
        }

        public string FirstName { get {return _firstName;} }
        public string LastName { get {return _lastName;} }
        public string FullName { get { return $"{_firstName} {_lastName}"; } }

        public DateTime BirthDay { get {return _birthday;} }

        public override string ToString()
        {
            return FullName;
        }
    }
}