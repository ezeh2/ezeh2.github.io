using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyAddressbook.Core;
using MyAddressbook.Core.Models;
using MyAddressbook.Core.Services;

namespace MyAddressbook.Droid
{
    [Activity(Label = "My Addressbook", MainLauncher = true, Icon = "@drawable/icon")]
    public class PeopleOverviewActivity : Activity
    {
        private readonly IAddressBook _addressBook;
        private List<Person> _people;

        public PeopleOverviewActivity()
        {
            _addressBook = AddressBookFactory.Instance();
        }

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.PeopleOverview);

            People.ItemClick += OnItemClick;
        }

        #region Overrides of Activity

        protected override async void OnResume()
        {
            base.OnResume();
            _people = (await _addressBook.GetPeople()).ToList();
            People.Adapter = new ArrayAdapter<Person>(this, Android.Resource.Layout.SimpleExpandableListItem1, _people);
        }

        #endregion

        public ListView People => FindViewById<ListView>(Resource.Id.PeopleListView);

        private void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var person = _people[e.Position];
            var intent = new Intent(this, typeof(PersonDetailActivity));
            intent.PutExtra("PersonId", person.Id);
            StartActivity(intent);
        }
    }
}