using System;
using System.Drawing;

using Foundation;
using UIKit;
using WebService.Core.Services.People;
using WebService.Core.Services.People.Impl;
using WebService.Core.Handlers.Http.Impl;
using BigTed;

namespace WebService.iOS
{

	public class PeopleTableSource : UITableViewSource
	{
		string[] TableItems;
		string CellIdentifier = "PersonCell";
		UIViewController owner;

		public PeopleTableSource (string[] items, UIViewController owner)
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