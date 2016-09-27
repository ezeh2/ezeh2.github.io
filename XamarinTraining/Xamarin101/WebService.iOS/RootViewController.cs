using System;
using System.Drawing;
using Foundation;
using UIKit;
using BigTed;
using System.Collections.Generic;
using System.Linq;
using WebService.Core.Services.People;

namespace WebService.iOS
{
    public partial class RootViewController : UIViewController
    {
		IPersonService _personService;

        public RootViewController(IntPtr handle) : base(handle)
        {
			_personService = Application.PersonService;
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
			People.SectionHeaderHeight = 0;
			People.SectionFooterHeight = 0;
        }

		async void InitAsync ()
		{
			BTProgressHUD.Show();

			IEnumerable<WebService.Core.Models.Person> people = await _personService.GetPeople ();
			People.Source = new PeopleTableSource (people.Select (p => p.FullName).ToArray (), this);
			People.ReloadData ();

			BTProgressHUD.Dismiss ();
		}

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
			InitAsync();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }

}