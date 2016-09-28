using System;

using UIKit;

namespace HelloiOS
{
	public partial class ViewController : UIViewController
	{
		private int _clickCounter = 0;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Display the updated text
			TheButton.TouchUpInside += (sender, e) => {TheLabel.Text = $"Button has been selected {++_clickCounter} times";};
		    //TheButton.TouchUpInside += ShowAlert;
		}

	    private void ShowAlert(object sender, EventArgs e)
	    {
            //Create Alert
            var okAlertController = UIAlertController.Create("Button selected", $"Button has been selected {++_clickCounter} times", UIAlertControllerStyle.Alert);

            //Add Action
            okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

            // Present Alert
            PresentViewController(okAlertController, true, null);
        }


        public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
