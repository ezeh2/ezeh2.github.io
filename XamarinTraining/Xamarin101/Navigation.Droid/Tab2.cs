using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Navigation.Droid
{

	class Tab2:Fragment
	{
		View _view;

		public override Android.Views.View OnCreateView (Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);
			_view = inflater.Inflate (Resource.Layout.FragmentTab, null);

			TabText.Text = "Welcome To Tab 2";
			return _view;
		}

		TextView TabText => _view.FindViewById<TextView> (Resource.Id.FragmentText);
	}
}