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

namespace HelloiOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton TheButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TheLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (TheButton != null) {
				TheButton.Dispose ();
				TheButton = null;
			}
			if (TheLabel != null) {
				TheLabel.Dispose ();
				TheLabel = null;
			}
		}
	}
}
