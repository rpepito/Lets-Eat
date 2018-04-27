
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;

namespace LetsEat.Views.OwnerSide
{
    public class menu_config_frag : Android.Support.V4.App.Fragment
    {

        static readonly string[] dishes = new String[] {
            "Ham & Cheese Sandwich", "Roasted Turkey Sandwich", "Chicken Sandwich", "Meatball Sandwich",
            "Coldcut Sandwich", "Pulled Pork Sandwich", "Breakfast Sandwich", "Peanut Butter & Jelly Sandwich"
        };

        ListView menulistView;
        Toolbar toolbar;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }


        public static menu_config_frag NewInstance()
        {
            var frag1 = new menu_config_frag { Arguments = new Bundle() };
            return frag1;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.MenuLayout, null);

            toolbar = view.FindViewById<Toolbar>(Resource.Id.menutoolbar);

            menulistView = view.FindViewById<ListView>(Resource.Id.menulistView);

            ((AppCompatActivity)this.Activity).SetActionBar(toolbar);
            ((AppCompatActivity)this.Activity).ActionBar.Title = "Menu Configuration";

            var ListAdapter = new ArrayAdapter<string>(this.Activity, Resource.Layout.DishList, dishes);
            menulistView.Adapter = ListAdapter;

            menulistView.TextFilterEnabled = true;
            menulistView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                Toast.MakeText(this.Activity, ((TextView)args.View).Text, ToastLength.Short).Show();
            };


            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            return view;


        }

    }
}
