using System;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using LetsEat.Models;
using System.Collections.Generic;

namespace LetsEat.Views.Owner_Side
{
    public class ListViewAdapter : BaseAdapter
    {

        Activity activity;
        List<Dish> lstAccounts;
        LayoutInflater inflater;
        public ListViewAdapter(Activity activity, List<Dish> lstAccounts)
        {
            this.activity = activity;
            this.lstAccounts = lstAccounts;
        }
        public override int Count
        {
            get { return lstAccounts.Count; }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            inflater = (LayoutInflater)activity.BaseContext.GetSystemService(Context.LayoutInflaterService);
            View itemView = inflater.Inflate(Resource.Layout.ResListItem, null);
            var txtuser = itemView.FindViewById<TextView>(Resource.Id.ListDishName);

            if (lstAccounts.Count > 0)
            {
                txtuser.Text = lstAccounts[position].Name;

            }
            return itemView;
        }
    }
}
