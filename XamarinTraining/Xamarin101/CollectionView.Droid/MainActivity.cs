using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using CollectionView.Droid.Models;
using CollectionView.Droid.Services;

namespace CollectionView.Droid
{
    [Activity(Label = "CollectionView.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private IList<Person> _people;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var listView = FindViewById<ListView>(Resource.Id.listView);

            const int numberOfPeople = 100;
            _people = new PersonService().GeneratePeople(numberOfPeople);

            listView.Adapter = new ArrayAdapter<Person>(this, Android.Resource.Layout.SimpleExpandableListItem1, _people);
            listView.ItemClick += OnItemClick;
        }

        private void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var person = _people[e.Position];
            Toast.MakeText(this, person.ToString(), ToastLength.Short).Show();
        }
    }
}

