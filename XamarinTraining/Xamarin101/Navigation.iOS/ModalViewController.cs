using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Navigation.iOS
{
	partial class ModalViewController : UIViewController
	{
		public ModalViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			BackButton.TouchUpInside += (sender, e) => DismissViewController(true, null);
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();


		}
	}
}
