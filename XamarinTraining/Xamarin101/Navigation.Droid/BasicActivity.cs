using Android.App;
using Android.OS;

namespace Navigation.Droid
{
    [Activity(Label = "Parameter Navigation", Icon = "@drawable/icon")]
    public class BasicActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Basic);
        }
    }
}