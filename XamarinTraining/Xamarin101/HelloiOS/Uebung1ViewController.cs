using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace HelloiOS
{
	partial class Uebung1ViewController : UIViewController
	{
		public Uebung1ViewController (IntPtr handle) : base (handle)
		{
			
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			TheHelloButton.TouchUpInside += (sender, e) => ShowAlert();
		}

		void ShowAlert ()
		{
			var okAlertController = UIAlertController.Create ("Hello there", $"Hi {this.Name.Text}", UIAlertControllerStyle.Alert);
			okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null)); 

			PresentViewController (okAlertController, true, null);
			
		}
	}
}
