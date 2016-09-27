using System;

using UIKit;
using Data.Core.Repository.Impl;
using System.Linq;
using Foundation;

namespace Data.iOS
{

	public class MessageTableSource : UITableViewSource
	{
		string[] TableItems;
		string CellIdentifier = "MessageCell";
		UIViewController owner;

		public MessageTableSource (string[] items, UIViewController owner)
		{
			this.owner = owner;

			TableItems = items;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return TableItems.Length;
		}

		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			UIAlertController okAlertController = UIAlertController.Create ("Row Selected", TableItems[indexPath.Row], UIAlertControllerStyle.Alert);
			okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
			owner.PresentViewController (okAlertController, true, null);
			tableView.DeselectRow (indexPath, true);
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (CellIdentifier);

			cell.TextLabel.Text = TableItems[indexPath.Row];

			return cell;
		}
	}
}
