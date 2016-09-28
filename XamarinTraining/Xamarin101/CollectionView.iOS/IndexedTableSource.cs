
using System;

using Foundation;
using UIKit;
using System.Collections.Generic;
using System.Linq;

namespace HelloiOS
{
	public class IndexedTableSource : UITableViewSource
	{
		string CellIdentifier = "GnabberCell";
		TableViewController owner;

		Dictionary<string, List<string>> indexedTableItems;

		string[] keys;

		public IndexedTableSource (string[] items, TableViewController owner)
		{
			this.owner = owner;

			indexedTableItems = new Dictionary<string, List<string>> ();
			foreach (var t in items) {
				if (indexedTableItems.ContainsKey (t [0].ToString ())) {
					indexedTableItems [t [0].ToString ()].Add (t);
				} else {
					indexedTableItems.Add (t [0].ToString (), new List<string> () { t });
				}
			}
			keys = indexedTableItems.Keys.ToArray ();
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return indexedTableItems [keys [section]].Count;
		}


		public override nint NumberOfSections (UITableView tableView)
		{
			return keys.Length;
		}

		public override String[] SectionIndexTitles (UITableView tableView)
		{
			return indexedTableItems.Keys.ToArray ();
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			UIAlertController okAlertController = UIAlertController.Create ("Row Selected", indexedTableItems [keys [indexPath.Section]] [indexPath.Row], UIAlertControllerStyle.Alert);
			okAlertController.AddAction (UIAlertAction.Create ("OK", UIAlertActionStyle.Default, null));
			owner.PresentViewController (okAlertController, true, null);
			tableView.DeselectRow (indexPath, true);
		}

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return keys[section];
        }
        public override string TitleForFooter(UITableView tableView, nint section)
        {
            return indexedTableItems[keys[section]].Count + " items";
        }

        public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (CellIdentifier);
			if (cell == null) { 
				cell = new UITableViewCell (UITableViewCellStyle.Default, CellIdentifier); 
			}

			cell.TextLabel.Text = indexedTableItems [keys [indexPath.Section]] [indexPath.Row];

			return cell;
		}
	}
}

