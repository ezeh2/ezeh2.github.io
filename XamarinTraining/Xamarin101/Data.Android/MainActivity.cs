using Android.App;
using Android.Widget;
using Android.OS;
using Data.Core.Repository.Impl;
using System.Linq;
using System.Threading.Tasks;
using Data.Core.Repository;

namespace Data.Droid
{
    [Activity(Label = "Data.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
		IMessageRepository _messageRepository;

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Persistency Message Repository
			//_messageRepository = new MessageRepository();
            // In memory Repository
			_messageRepository = new DummyMessageRepository();
			var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
			await _messageRepository.Init(docsFolder);

			await SetMessagesHistory ();


			Button.Click += (sender, e) => AddMessageHandler();
        }

		private Button Button => FindViewById<Button>(Resource.Id.MyButton);
		private EditText Message => FindViewById<EditText>(Resource.Id.MessageInput);
		private ListView Messages => FindViewById<ListView>(Resource.Id.Messages);

		async void AddMessageHandler ()
		{
			if (string.IsNullOrEmpty (Message.Text)) return;

			await _messageRepository.WriteMessage(Message.Text);
			await SetMessagesHistory();
		}

		private async Task SetMessagesHistory ()
		{
			var messages = await _messageRepository.ReadMessages ();
			Messages.Adapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleListItem1, messages.ToArray ());
		}
    }
}

