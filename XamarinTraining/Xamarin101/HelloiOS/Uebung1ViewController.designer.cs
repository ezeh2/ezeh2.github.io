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
	[Register ("Uebung1ViewController")]
	partial class Uebung1ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField Name { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton TheHelloButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (Name != null) {
				Name.Dispose ();
				Name = null;
			}
			if (TheHelloButton != null) {
				TheHelloButton.Dispose ();
				TheHelloButton = null;
			}
		}
	}
}
