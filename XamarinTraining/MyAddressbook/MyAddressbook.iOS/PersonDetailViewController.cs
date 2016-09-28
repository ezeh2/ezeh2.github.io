using Foundation;
using System;
using UIKit;
using MyAddressbook.Core.Models;
using MyAddressbook.Core.Services;
using System.Threading.Tasks;
using MyAddressbook.Core;

namespace MyAddressbook.iOS
{
    public partial class PersonDetailViewController : UIViewController
    {
		private string _firstname;
		private string _lastname;
		private IAddressBook _addressBook;
		private object _sync = new object();
		private bool _isStoring = false;


        public PersonDetailViewController (IntPtr handle) : base (handle)
        {
			_addressBook = AddressBookFactory.Instance();
        }
		Person person;

		public Person Person
		{
			get
			{
				return person;
			}

			set
			{
				person = value;
				Firstname = person.FirstName;
				Lastname = person.LastName;
			}
		}

		public string Firstname
		{
			get
			{
				return _firstname;
			}

			set
			{
				_firstname = value;
				if(FirstnameTextfield != null) FirstnameTextfield.Text = value;
				Person.FirstName = value;
				EnableSaveIfNeeded();
			}
		}

		public string Lastname
		{
			get
			{
				return _lastname;
			}

			set
			{
				_lastname = value;
				if(LastnameTextField != null) LastnameTextField.Text = value;
				Person.LastName = value;
				EnableSaveIfNeeded();
			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.NavigationItem.SetLeftBarButtonItem(
				new UIBarButtonItem(UIBarButtonSystemItem.Cancel, (sender, args) =>
			{
				// button was clicke
				NavigationController.PopViewController(true);
				//DismissViewController(animated: true, completionHandler: () => { });
			})
		, true);

			LastnameTextField.EditingChanged += (sender, e) => Lastname = LastnameTextField.Text;
			FirstnameTextfield.EditingChanged += (sender, e) => Firstname = FirstnameTextfield.Text;
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			FirstnameTextfield.Text = Firstname;
			LastnameTextField.Text = Lastname;
			EnableSaveIfNeeded();
		}

		internal void SetPerson(AddressBookOverviewTableViewController addressBookOverviewTableViewController, Person person)
		{
			if (person == null)
				throw new ArgumentNullException(nameof(person));
			Person = person;
			Firstname = person.FirstName;
			Lastname = person.LastName;
		}

		private async Task HandleStoring()
		{
			lock(_sync)
			{
				if (_isStoring) return;
				_isStoring = true;
			}

			await _addressBook.UpdatePerson(Person);

			NavigationController.PopViewController(true);

			_isStoring = false;
		}

		void EnableSaveIfNeeded()
		{
			if (SaveButton == null) return;
			if (string.IsNullOrEmpty(_firstname) || string.IsNullOrEmpty(_lastname))
			{
				SaveButton.Enabled = false;
				SaveButton.BackgroundColor = UIColor.LightGray;
				SaveButton.TouchUpInside -= async (sender, e) => await HandleStoring();
			}
			else
			{
				SaveButton.Enabled = true;
				SaveButton.BackgroundColor = UIColor.Green;
				SaveButton.TouchUpInside += async (sender, e) => await HandleStoring();
			}
		}
	}
}