using System;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using LetsEat.Models;
using System.Collections.Generic;

namespace LetsEat.Views.OwnerSide
{
    public class QueueListViewAdapter : BaseAdapter
    {

        //Activity activity;
        Android.Support.V4.App.Fragment fragment;
        List<Queuedb> queueListAccounts;
        LayoutInflater inflater;
        public QueueListViewAdapter(Android.Support.V4.App.Fragment fragment, List<Queuedb> queueListAccounts)
        {
            this.fragment = fragment;
            this.queueListAccounts = queueListAccounts;
        }
        public override int Count
        {
            get { return queueListAccounts.Count; }
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
            View itemView = inflater.Inflate(Resource.Layout.QueueListItem, null);

            var userText = itemView.FindViewById<TextView>(Resource.Id.QueueListName);
            

            if (queueListAccounts.Count > 0)
            {
                userText.Text = queueListAccounts[position].name;
                
            }
            return itemView;
        }
    }
}