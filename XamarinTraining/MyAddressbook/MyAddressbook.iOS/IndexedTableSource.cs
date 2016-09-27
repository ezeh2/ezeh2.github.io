using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using MyAddressbook.Core.Models;

namespace MyAddressbook.iOS
{

	public class IndexedTableSource : UITableViewSource
	{
		string CellIdentifier = "GnabberCell";
		UITableViewController owner;

		Dictionary<string, List<Person>> indexedTableItems;

		string[] keys;

		public IndexedTableSource(Person[] people, UITableViewController owner)
		{
			this.owner = owner;

			indexedTableItems = new Dictionary<string, List<Person>>();
			foreach (var person in people)
			{
				if (indexedTableItems.ContainsKey(person.FullName[0].ToString()))
				{
					indexedTableItems[person.FullName[0].ToString()].Add(person);
				}
				else {
					indexedTableItems.Add(person.FullName[0].ToString(), new List<Person> { person });
				}
			}
			keys = indexedTableItems.Keys.ToArray();
		}

		internal Person GetItem(NSIndexPath indexPath)
		{
			if (indexPath == null) return null;
			return indexedTableItems[keys[indexPath.Section]][indexPath.Row];
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return indexedTableItems[keys[section]].Count;
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return keys.Length;
		}

		public override String[] SectionIndexTitles(UITableView tableView)
		{
			return indexedTableItems.Keys.ToArray();
		}

		//public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		//{
			
		//	UIAlertController okAlertController = UIAlertController.Create("Row Selected", indexedTableItems[keys[indexPath.Section]][indexPath.Row].FullName, UIAlertControllerStyle.Alert);
		//	okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
		//	owner.PresentViewController(okAlertController, true, null);
		//	tableView.DeselectRow(indexPath, true);
		//}

		public override string TitleForHeader(UITableView tableView, nint section)
		{
			return keys[section];
		}

		//public override string TitleForFooter(UITableView tableView, nint section)
		//{
		//	return indexedTableItems[keys[section]].Count + " items";
		//}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);

			cell.TextLabel.Text = indexedTableItems[keys[indexPath.Section]][indexPath.Row].FullName;

			return cell;
		}

}
}