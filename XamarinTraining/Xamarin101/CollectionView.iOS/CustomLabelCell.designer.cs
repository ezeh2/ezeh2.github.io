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

namespace CollectionView.iOS
{
	[Register ("CustomLabelCell")]
	partial class CustomLabelCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel CellLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CellLabel != null) {
				CellLabel.Dispose ();
				CellLabel = null;
			}
		}
	}
}
