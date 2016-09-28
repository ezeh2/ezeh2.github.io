
using System;

using Foundation;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using CollectionView.iOS;

namespace HelloiOS
{

	public class CustomCellTableSource : UITableViewSource
	{
		string[] TableItems;
		string CellIdentifier = "CustomLabelCell";
		TableViewController owner;

		public CustomCellTableSource (string[] items, TableViewController owner)
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
			CustomLabelCell cell = (CustomLabelCell)tableView.DequeueReusableCell (CellIdentifier);

			cell.UpdateCell(TableItems[indexPath.Row]);

			return cell;
		}
	}
}
