
using System;

using Foundation;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using CollectionView.iOS;

namespace HelloiOS
{
	public class TableSource : UITableViewSource
	{
		string[] TableItems;
		string CellIdentifier = "GnabberCell";
		TableViewController owner;

		public TableSource (string[] items, TableViewController owner)
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
			if (cell == null)
			{ 
				cell = new UITableViewCell (UITableViewCellStyle.Default, CellIdentifier);
			}

			cell.TextLabel.Text = TableItems[indexPath.Row];

			return cell;
		}
	}
}
