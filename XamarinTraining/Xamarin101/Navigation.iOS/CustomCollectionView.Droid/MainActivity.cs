using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Widget;
using Android.OS;
using CustomCollectionView.Droid.Services;
using CustomCollectionView.Droid.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CustomCollectionView.Droid
{
    [Activity(Label = "CustomCollectionView.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Person[] _people;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var listView = FindViewById<ListView>(Resource.Id.listView);

            //const int numberOfPeople = 100;
            //_people = new PersonService().GeneratePeople(numberOfPeople).ToArray();

            //listView.Adapter = new ArrayAdapter<Person>(this, Android.Resource.Layout.SimpleExpandableListItem1, _people);
            //listView.Adapter = new PersonScreenAdapter(this, _people.Select(p => p.FullName).ToArray());

            List<string> veges = new List<string>();
            Stream seedDataStream = Assets.Open(@"VegeData.txt");
            using (StreamReader reader = new StreamReader(seedDataStream))
            {
                while (!reader.EndOfStream)
                {
                    veges.Add(reader.ReadLine());
                }
            }
            veges.Sort((x, y) => x.CompareTo(y));
            var items = veges.ToArray();
            listView.Adapter = new VegeAdapter(this, items);

            listView.ItemClick += OnItemClick;
            listView.FastScrollEnabled = true;
        }

        private void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var person = _people[e.Position];
            Toast.MakeText(this, person.ToString(), ToastLength.Short).Show();
        }
    }
}

