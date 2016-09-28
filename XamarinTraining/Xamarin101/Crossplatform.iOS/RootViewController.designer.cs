// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Crossplatform.iOS
{
	[Register ("RootViewController")]
	partial class RootViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel AnswerLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton AreWeThereYetButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField LatitudeTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField LongitudeTextField { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (AnswerLabel != null) {
				AnswerLabel.Dispose ();
				AnswerLabel = null;
			}
			if (AreWeThereYetButton != null) {
				AreWeThereYetButton.Dispose ();
				AreWeThereYetButton = null;
			}
			if (LatitudeTextField != null) {
				LatitudeTextField.Dispose ();
				LatitudeTextField = null;
			}
			if (LongitudeTextField != null) {
				LongitudeTextField.Dispose ();
				LongitudeTextField = null;
			}
		}
	}
}
