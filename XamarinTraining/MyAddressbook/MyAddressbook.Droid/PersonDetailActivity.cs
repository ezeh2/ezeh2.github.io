using System;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Text;
using MyAddressbook.Core;
using MyAddressbook.Core.Models;
using MyAddressbook.Core.Services;

namespace MyAddressbook.Droid
{
    [Activity(Label = "Person", Icon = "@drawable/icon")]
    public class PersonDetailActivity : Activity
    {
        private IAddressBook _addressBook;
        private Person _person;
        private string _lastname;
        private string _firstname;

        public PersonDetailActivity()
        {
            _addressBook = AddressBookFactory.Instance();
        }

        #region Overrides of Activity
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.PersonDetail);
            Button.Click += StorePerson;
            FirstnameText.TextChanged += FirstnameTextOnTextChanged;
            LastnameText.TextChanged += LastnameTextOnTextChanged;

            var personId = Intent.GetIntExtra("PersonId", 0);
            if (personId > 0)
            {
                Person = await _addressBook.GetPerson(personId);
            }
            else
            {
                Person = new Person();
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Button.Click -= StorePerson;
            FirstnameText.TextChanged -= FirstnameTextOnTextChanged;
            LastnameText.TextChanged -= LastnameTextOnTextChanged;
        }

        #endregion

        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                Firstname = Person.FirstName;
                Lastname = Person.LastName;
            }
        }

        public string Lastname
        {
            get { return _lastname; }
            set
            {
                if (value == _lastname) return;
                _lastname = value;
                LastnameText.Text = _lastname;
                Person.LastName = _lastname;
            }
        }

        public string Firstname
        {
            get { return _firstname; }
            set
            {
                if (value == _firstname) return;
                _firstname = value;
                FirstnameText.Text = _firstname;
                Person.FirstName = _firstname;
            }
        }

        private Button Button => FindViewById<Button>(Resource.Id.SaveButton);
        private EditText FirstnameText => FindViewById<EditText>(Resource.Id.FirstnameEditText);
        private EditText LastnameText => FindViewById<EditText>(Resource.Id.LastNameEditText);

        private void StorePerson(object sender, EventArgs e)
        {
            _addressBook.UpdatePerson(Person);
            this.Finish();
        }

        private void FirstnameTextOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            Firstname = FirstnameText.Text;
        }

        private void LastnameTextOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            Lastname = LastnameText.Text;
        }
    }
}

