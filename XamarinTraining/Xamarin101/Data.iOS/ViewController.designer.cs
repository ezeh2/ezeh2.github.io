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

namespace Data.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField Message { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton StoreMessage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView TableView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (Message != null) {
				Message.Dispose ();
				Message = null;
			}
			if (StoreMessage != null) {
				StoreMessage.Dispose ();
				StoreMessage = null;
			}
			if (TableView != null) {
				TableView.Dispose ();
				TableView = null;
			}
		}
	}
}
