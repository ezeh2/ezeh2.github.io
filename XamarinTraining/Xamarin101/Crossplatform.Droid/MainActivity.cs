using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Crossplatform.Core.Services;
using Crossplatform.Droid.Services;
using Crossplatform.Core.Model;
using AndroidHUD;

namespace Crossplatform.Droid
{
    [Activity(Label = "Crossplatform.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
		AReallyGreatService _locationService;
		EditText _longitudeInput;
		EditText _latitudeInput;
		TextView _resultLabel;

		public MainActivity(){
			_locationService = new AReallyGreatService (new PositionService());
		}

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.areWeThereButton);
			_longitudeInput = FindViewById<EditText>(Resource.Id.longitudeEntry);
			_latitudeInput = FindViewById<EditText>(Resource.Id.latitudeEntry);
			_resultLabel = FindViewById<TextView>(Resource.Id.resultText);

			button.Click += ClickHandler;

			AndHUD.Shared.Show(this, maskType: MaskType.Clear);
			var currentLocation = await _locationService.GetCurrentLocation ();
			_latitudeInput.Text = currentLocation.Latitude.ToString();
			_longitudeInput.Text = currentLocation.Longitude.ToString();
			AndHUD.Shared.Dismiss();
        }

		private async void ClickHandler (object sender, EventArgs e)
		{
			AndHUD.Shared.Show(this, maskType: MaskType.Clear);
			var destinationLatitude = Convert.ToDouble(_latitudeInput.Text);
			var destinationLongitude = Convert.ToDouble(_longitudeInput.Text);

			var enteredDestination = new LocationPoint (destinationLatitude, destinationLongitude);
			var isLocationCloseEnough = await _locationService.AreWeThereYetAsync (enteredDestination);
			_resultLabel.Text = isLocationCloseEnough ? "Yay we made it." : "Sorry we still have some way to go.";
			AndHUD.Shared.Dismiss();

		}
    }
}

