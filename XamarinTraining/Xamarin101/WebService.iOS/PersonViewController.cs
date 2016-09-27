using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using WebService.Core.Models;
using BigTed;
using WebService.Core.Services.People;

namespace WebService.iOS
{
	partial class PersonViewController : UIViewController
	{
		IPersonService _personService;

		public PersonViewController (IntPtr handle) : base (handle)
		{
			_personService = Application.PersonService;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			CreatePerson.TouchUpInside += CreatePerson_TouchUpInside;
		}

		private async void CreatePerson_TouchUpInside (object sender, EventArgs e)
		{
			BTProgressHUD.Show ();

			var person = new Person (Firstname.Text, Lastname.Text);
			await _personService.StorePerson (person);
			NavigationController.PopViewController (true);

			BTProgressHUD.Dismiss ();
		}
	}
}
