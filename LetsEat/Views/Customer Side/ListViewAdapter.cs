using System;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using LetsEat.Models;
using System.Collections.Generic;

namespace LetsEat.Views.CustomerSide
{
    public class ListViewAdapter : BaseAdapter
    {

        //Activity activity;
        Android.Support.V4.App.Fragment fragment;
        List<Reservation> lstAccounts;
        LayoutInflater inflater;
        public ListViewAdapter(Android.Support.V4.App.Fragment fragment, List<Reservation> lstAccounts)
        {
            this.fragment = fragment;
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
            //inflater = (LayoutInflater)fragment.getActivity().GetSystemService(Context.LayoutInflaterService);
            //inflater = getActivity().getLayoutInflater();
            inflater = Application.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
            View itemView = inflater.Inflate(Resource.Layout.ResListItem, null);

            var txtuser = itemView.FindViewById<TextView>(Resource.Id.ListName);
            var txttime = itemView.FindViewById<TextView>(Resource.Id.ListTime);
            var txtdate = itemView.FindViewById<TextView>(Resource.Id.ListDate);

            if (lstAccounts.Count > 0)
            {
                txtuser.Text = lstAccounts[position].name;
                txttime.Text = lstAccounts[position].time;
                txtdate.Text = lstAccounts[position].date;
            }
            return itemView;
        }
    }
}