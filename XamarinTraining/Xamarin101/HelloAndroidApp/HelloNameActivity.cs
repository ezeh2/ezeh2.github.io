using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace HelloAndroidApp
{
    [Activity(Label = "HelloNameApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class HelloNameActivity:Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.NameAlert);

            Button.Click += ShowAlertDialog;
        }

        private Button Button => FindViewById<Button>(Resource.Id.PopupButton);
        private EditText PersonName => FindViewById<EditText>(Resource.Id.PersonName);

        private void ShowAlertDialog(object sender, EventArgs e)
        {
            var alertDialog = new AlertDialog.Builder(this);
            alertDialog.SetTitle(Resource.String.HelloPopupTitle);
            alertDialog.SetMessage($"Hello {PersonName.Text}");
            alertDialog.SetPositiveButton(Resource.String.PopupAffirmativeButton, (o, args) => {});
            alertDialog.Show();
        }
    }
}