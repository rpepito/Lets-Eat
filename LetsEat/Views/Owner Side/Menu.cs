
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
using Firebase;
using Firebase.Auth;
using Firebase.Database;

using Java.Util;

namespace LetsEat
{
    [Activity(Label = "Menu")]
    public class Menu : Activity
    {
        static readonly string[] dishes = new String[] {
            "Ham & Cheese Sandwich", "Roasted Turkey Sandwich", "Chicken Sandwich", "Meatball Sandwich",
            "Coldcut Sandwich", "Pulled Pork Sandwich", "Breakfast Sandwich", "Peanut Butter & Jelly Sandwich"
        };


        String resturant_name = "Resturant Name";
        Toolbar toolbar;
        ListView menulistView;

  

        private FirebaseDatabase database;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MenuLayout);
            // Create your application here

            FirebaseUser user = FirebaseAuth.GetInstance(MainActivity.app).CurrentUser;
            database = FirebaseDatabase.GetInstance(MainActivity.app);
            DatabaseReference reference = database.GetReference("users");

            reference.Child(user.Uid).AddListenerForSingleValueEvent(new MyValueEventListener());

            toolbar = FindViewById<Toolbar>(Resource.Id.menutoolbar);
            menulistView = FindViewById<ListView>(Resource.Id.menulistView);

            SetActionBar(toolbar);
            ActionBar.Title = resturant_name;

            var ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.DishList, dishes);
            menulistView.Adapter = ListAdapter;

            menulistView.TextFilterEnabled = true;
            menulistView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                Toast.MakeText(Application, ((TextView)args.View).Text, ToastLength.Short).Show();
            };


        }

        public class MyValueEventListener : Java.Lang.Object, Firebase.Database.IValueEventListener
        {

            public void OnCancelled(DatabaseError error)
            {
                throw new NotImplementedException();
            }

            public void OnDataChange(DataSnapshot snapshot)
            {
                //throw new NotImplementedException();

                var resturant_info = snapshot.Children;

                foreach (DataSnapshot datasnapshot in resturant_info.ToEnumerable())
                {
                    //if (datasnapshot.GetValue(true) == null) continue;

                    //string info = datasnapshot.Child("name").GetValue(true).ToString();
                    //Console.WriteLine(info);

                }

            }

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
