using System;

using UIKit;
using Data.Core.Repository.Impl;
using System.Linq;
using System.IO;
using Data.Core.Repository;

namespace Data.iOS
{
	public partial class ViewController : UIViewController
	{
		IMessageRepository _messageRepository;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override async void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			_messageRepository = new MessageRepository();
			var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
			var libFolder = Path.Combine(docsFolder, "..", "Library");

			await _messageRepository.Init (libFolder);

			StoreMessage.TouchUpInside += (sender, e) => 
			{
				_messageRepository.WriteMessage (Message.Text);
				LoadMessages ();
			};
			LoadMessages ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		private async void LoadMessages()
		{
			var messages = await _messageRepository.ReadMessages ();
			TableView.Source = new MessageTableSource (messages.ToArray (), this);
			TableView.ReloadData ();
		}
	}

}

