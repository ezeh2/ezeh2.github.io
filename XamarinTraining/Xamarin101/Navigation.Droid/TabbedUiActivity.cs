using Android.App;
using Android.OS;
using Android.Widget;

namespace Navigation.Droid
{
    [Activity(Label = "Parameter Navigation", Icon = "@drawable/icon")]
	public class TabbedUiActivity : Activity
    {
		protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Tabbed);

			this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			AddTab ("Tab 1", Resource.Drawable.Icon, new Tab1 ());
			AddTab ("Tab 2", Resource.Drawable.Icon, new Tab2 ());

			if (savedInstanceState != null)
				this.ActionBar.SelectTab(this.ActionBar.GetTabAt(savedInstanceState.GetInt("tab")));
        }

		protected override void OnSaveInstanceState(Bundle outState)
		{
			outState.PutInt("tab", this.ActionBar.SelectedNavigationIndex);

			base.OnSaveInstanceState(outState);
		}

		void AddTab (string tabText, int iconResourceId, Fragment view)
		{
			var tab = this.ActionBar.NewTab ();            
			tab.SetText (tabText);
			tab.SetIcon (Resource.Drawable.Icon);

			// must set event handler before adding tab
			tab.TabSelected += (sender, e) =>
			{
				var fragment = this.FragmentManager.FindFragmentById(Resource.Id.FragmentContainer);
				if (fragment != null)
					e.FragmentTransaction.Remove(fragment);         
				e.FragmentTransaction.Add (Resource.Id.FragmentContainer, view);
			};
			tab.TabUnselected += (sender,  e) => {
				e.FragmentTransaction.Remove(view);
			};
			tab.TabReselected += (sender, e) => Toast.MakeText (this, $"Refresing Tab {tab.Position+1 }", ToastLength.Short).Show();

			this.ActionBar.AddTab (tab);
		}
    }
}