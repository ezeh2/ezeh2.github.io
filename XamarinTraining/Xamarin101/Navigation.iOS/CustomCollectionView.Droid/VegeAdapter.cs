using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace CustomCollectionView.Droid
{
    public class VegeAdapter : BaseAdapter<string>, ISectionIndexer
    {
        string[] items;
        Activity context;
        private Dictionary<string, int> alphaIndex;
        private string[] sections;
        private Object[] sectionsObjects;

        public VegeAdapter(Activity context, string[] items) : base()
        {
            this.context = context;
            this.items = items;
            this.alphaIndex = new Dictionary<string, int>();
            for(int i = 0; i < items.Length; ++i)
            {
                var key = items[i][0].ToString();
                if(!alphaIndex.ContainsKey(key)) alphaIndex.Add(key, i);
            }

            this.sections = new string[alphaIndex.Keys.Count];
            // convert letters list to string[]
            this.alphaIndex.Keys.CopyTo(sections, 0);

            this.sectionsObjects = new Java.Lang.Object[sections.Length];
            for (int i = 0; i < sections.Length; ++i)
            {
                sectionsObjects[i] = new Java.Lang.String(sections[i]);
            }
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override string this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Length; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
			if (view == null) { // otherwise create a new one
//                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
				view = context.LayoutInflater.Inflate (Resource.Layout.CustomRow, null);
			}

//			view.FindViewById<TextView>(Android.Resource.Id.Text1 ).Text = items[position];
			view.FindViewById<TextView>(Resource.Id.CustomText).Text = items[position];
            return view;
        }

        public int GetPositionForSection(int sectionIndex)
        {
            return alphaIndex[sections[sectionIndex]];
        }

        public int GetSectionForPosition(int position)
        {
            int prevSection = 0;
            for (int i = 0; i < sections.Length; i++)
            {
                if (GetPositionForSection(i) > position)
                {
                    break;
                }
                prevSection = i;
            }
            return prevSection;
        }

        public Java.Lang.Object[] GetSections()
        {
            return sectionsObjects;
        }
    }
}