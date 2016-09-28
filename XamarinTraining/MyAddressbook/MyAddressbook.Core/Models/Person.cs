using System;
namespace MyAddressbook.Core.Models
{
	public class Person
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime Birthday { get; set; }
		public string BirthdayString => Birthday.ToString("dd MMMM yyyy");
		public string FullName => $"{FirstName} {LastName}";

	    #region Overrides of Object

	    public override string ToString()
	    {
	        return FullName;
	    }

	    #endregion
	}
}
