using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.IO;
using System.Collections.Generic;

namespace HelloiOS
{
	public partial class TableViewController : UITableViewController
	{
		UITableView table;

		public TableViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			table = new UITableView(View.Bounds); // defaults to Plain style
			table.AutoresizingMask = UIViewAutoresizing.All;

			// Credit for test data to 
			// http://en.wikipedia.org/wiki/List_of_culinary_vegetables
			var lines = File.ReadLines("VegeData.txt");
			List<string> veges = new List<string>();
			foreach (var l in lines) {
				veges.Add (l);
			}
			veges.Sort ((x,y) => {return x.CompareTo (y);});
			string[] tableItems = veges.ToArray();

//			TableView.Source = new TableSource(tableItems,this);
//			TableView.Source = new IndexedTableSource(tableItems,this);
			TableView.Source = new CustomCellTableSource(tableItems,this);
		}
	}
}

