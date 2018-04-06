
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
using LetsEat.Views.OwnerSide;

namespace LetsEat
{
    [Activity(Label = "Menu")]
    public class Menu : Activity
    {
        static readonly string[] dishes = new String[] {
            "Ham & Cheese Sandwich", "Roasted Turkey Sandwich", "Chicken Sandwich", "Meatball Sandwich",
            "Coldcut Sandwich", "Pulled Pork Sandwich", "Breakfast Sandwich", "Peanut Butter & Jelly Sandwich"
        };



        Toolbar toolbar;
        ListView menulistView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MenuLayout);
            // Create your application here


            toolbar = FindViewById<Toolbar>(Resource.Id.menutoolbar);
            menulistView = FindViewById<ListView>(Resource.Id.menulistView);

            SetActionBar(toolbar);
            ActionBar.Title = "Resturant Name";


            var ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.DishList, dishes);
            menulistView.Adapter = ListAdapter;

            menulistView.TextFilterEnabled = true;
            menulistView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                Toast.MakeText(Application, ((TextView)args.View).Text, ToastLength.Short).Show();
            };


        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.dishes, menu);

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            if (item.ItemId == Resource.Id.action_add){
                StartActivity(typeof(AddDish));
            }

            return base.OnOptionsItemSelected(item);
        }


    }
}
