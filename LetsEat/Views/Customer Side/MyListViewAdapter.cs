using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LetsEat
{
    class MyListViewAdapter : BaseAdapter<Restaurant>
    {
        private List<Restaurant> mItems;
        private Context mContext;

        public MyListViewAdapter(Context context, List<Restaurant> items)
        {
            mItems = items;
            mContext = context;
        }
        public override int Count
        {
            get { return mItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Restaurant this[int position]
        {
            get { return mItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if(row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.listview_row, null, false);         
            }

            TextView txtName = row.FindViewById<TextView>(Resource.Id.txtName);
            txtName.Text = mItems[position].Name;

            TextView txtCuisine = row.FindViewById<TextView>(Resource.Id.txtCuisine);
            txtCuisine.Text = mItems[position].Cuisine;

            TextView txtPrice = row.FindViewById<TextView>(Resource.Id.txtPrice);
            txtPrice.Text = mItems[position].Price;

            return row;

        }
    }
}