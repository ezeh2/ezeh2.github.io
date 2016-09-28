using Android.App;
using Android.OS;
using Android.Widget;

namespace Navigation.Droid
{
    [Activity(Label = "Parameter Navigation", Icon = "@drawable/icon")]
    public class ParameterActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Parameter);

            var parameterTextView = FindViewById<TextView>(Resource.Id.ParameterText);

            parameterTextView.Text = Intent.GetStringExtra("Gnabber");

        }
    }
}