using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Navigation.Droid
{
    [Activity(Label = "Navigation.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button basicNavigationButton = FindViewById<Button>(Resource.Id.BasicNavigation);
            Button parameterNavigationButton = FindViewById<Button>(Resource.Id.NavigateWithParameter);
            Button tabbedUINavigationButton = FindViewById<Button>(Resource.Id.NavigateTabbedUi);

            basicNavigationButton.Click += BasicNavigationInvoked;
            parameterNavigationButton.Click += ParameterNavigationInvoked;
            tabbedUINavigationButton.Click += TabbedUiNavigationInvoked;
        }

        private void BasicNavigationInvoked(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(BasicActivity));
            StartActivity(intent);
        }

        private void ParameterNavigationInvoked(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ParameterActivity));
            intent.PutExtra("Gnabber", "The mighty parameter");
            StartActivity(intent);
        }
        private void TabbedUiNavigationInvoked(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TabbedUiActivity));
            StartActivity(intent);
        }
    }
}