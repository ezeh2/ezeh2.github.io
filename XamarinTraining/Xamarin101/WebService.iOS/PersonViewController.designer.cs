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

namespace WebService.iOS
{
	[Register ("PersonViewController")]
	partial class PersonViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton CreatePerson { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField Firstname { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField Lastname { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CreatePerson != null) {
				CreatePerson.Dispose ();
				CreatePerson = null;
			}
			if (Firstname != null) {
				Firstname.Dispose ();
				Firstname = null;
			}
			if (Lastname != null) {
				Lastname.Dispose ();
				Lastname = null;
			}
		}
	}
}
