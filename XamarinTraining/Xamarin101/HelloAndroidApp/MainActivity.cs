using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace HelloAndroidApp
{
    //[Activity(Label = "HelloAndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

            Button.Click += delegate { TextView.Text = $"{count++} clicks!"; };
        }

        private Button Button => FindViewById<Button>(Resource.Id.MyButton);
        private TextView TextView => FindViewById<TextView>(Resource.Id.ClickTextView);
    }
}

