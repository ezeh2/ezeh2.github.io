namespace MyAddressbook.Core.Services
{
	public static class AddressBookFactory
	{
		static IAddressBook _instance;

		public static IAddressBook Instance()
		{
			return _instance ?? (_instance = new FileAddressBook());
		}
	}
}
