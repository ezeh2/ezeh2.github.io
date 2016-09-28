using Foundation;
using System;
using UIKit;
using System.Linq;
using MyAddressbook.Core;
using System.Collections.Generic;
using MyAddressbook.Core.Models;
using MyAddressbook.Core.Services;

namespace MyAddressbook.iOS
{
    public partial class AddressBookOverviewTableViewController : UITableViewController
	{
		IAddressBook _addressBook;

        public AddressBookOverviewTableViewController (IntPtr handle) : base (handle)
        {
			//_addressBook = new MyAddressbook.Core.Services.AddressBook();
			_addressBook = AddressBookFactory.Instance();

        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIBarButtonSystemItem.Add, (sender, args) =>
			{
				// button was clicked
                NavigationController.PushViewController(new PersonDetailViewController(handle:Handle), true);
				PerformSegue("NavToPersonSegue", this);
			})
		, true);
		}

		public override async void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			IEnumerable<Core.Models.Person> tableItems = (await _addressBook.GetPeople());

			TableView.Source = new IndexedTableSource(tableItems?.ToArray(), this);
			TableView.ReloadData();
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "NavToPersonSegue")
			{
				// set in Storyboard
				var navctlr = segue.DestinationViewController as PersonDetailViewController;
				if (navctlr != null)
				{
					var source = TableView.Source as IndexedTableSource;
					var rowPath = TableView.IndexPathForSelectedRow;
					var item = source.GetItem(rowPath) ?? new Person();
					navctlr.SetPerson(this, item); // to be defined on the TaskDetailViewController
				}
			}
		}
    }
}