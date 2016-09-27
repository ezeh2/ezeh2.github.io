using System;
using System.Drawing;
using System.Globalization;
using BigTed;
using Crossplatform.Core.Model;
using Crossplatform.Core.Services;
using Crossplatform.iOS.Services;
using Foundation;
using UIKit;

namespace Crossplatform.iOS
{
    public partial class RootViewController : UIViewController
    {
        private AReallyGreatService _locationService;

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public RootViewController(IntPtr handle) : base(handle)
        {
            _locationService = new AReallyGreatService(new PositionService());
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            AreWeThereYetButton.TouchUpInside += AreWeThereYetButtonOnTouchUpInside;

            BTProgressHUD.Show(maskType: ProgressHUD.MaskType.Gradient);
            var currentLocation = await _locationService.GetCurrentLocation();
            LatitudeTextField.Text = currentLocation.Latitude.ToString(CultureInfo.InvariantCulture);
            LongitudeTextField.Text = currentLocation.Longitude.ToString(CultureInfo.InvariantCulture);
            BTProgressHUD.Dismiss();
        }

        private async void AreWeThereYetButtonOnTouchUpInside(object sender, EventArgs eventArgs)
        {
            BTProgressHUD.Show(maskType: ProgressHUD.MaskType.Gradient);
            AreWeThereYetButton.Enabled = false;
            var destinationLatitude = Convert.ToDouble(LatitudeTextField.Text);
            var destinationLongitude = Convert.ToDouble(LongitudeTextField.Text);
            var destinationLocation = new LocationPoint(destinationLatitude, destinationLongitude);
            var isLocationCloseEnough = await _locationService.AreWeThereYetAsync(destinationLocation);

            AnswerLabel.Text = isLocationCloseEnough ? "Yay we made it." : "Sorry we still have some way to go.";
            AreWeThereYetButton.Enabled = true;
            BTProgressHUD.Dismiss();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}