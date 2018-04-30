
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

        private static Toolbar toolbar;
        private static ListView menulistView;
        private static String resturant_name;            //Global Variable for restaurant name

        private FirebaseDatabase database;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            FirebaseUser user = FirebaseAuth.GetInstance(MainActivity.app).CurrentUser;
            database = FirebaseDatabase.GetInstance(MainActivity.app);
            DatabaseReference user_reference = database.GetReference("users");
            DatabaseReference menu_reference = database.GetReference("menus");

            SetContentView(Resource.Layout.MenuLayout);
            // Create your application here

            //toolbar = FindViewById<Toolbar>(Resource.Id.menutoolbar);
            menulistView = FindViewById<ListView>(Resource.Id.menulistView);

            //setElements();

            user_reference.Child(user.Uid).AddValueEventListener(new User_ValueEventListener());

            //menu_reference.Child(user.Uid).AddChildEventListener(new Menu_ChildEventListener());
            menu_reference.Child(user.Uid).AddValueEventListener(new Menu_ValueEventListener());
            /*
            var ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.DishList, dishes);
            menulistView.Adapter = ListAdapter;

            menulistView.TextFilterEnabled = true;
            menulistView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                Toast.MakeText(Application, ((TextView)args.View).Text, ToastLength.Short).Show();
            };
            */

        }

        public void setElements(){

            SetActionBar(toolbar);
            ActionBar.Title = resturant_name;

        }

        public class User_ValueEventListener : Java.Lang.Object, Firebase.Database.IValueEventListener
        {

            public void OnCancelled(DatabaseError error)
            {
                throw new NotImplementedException();
            }

            public void OnDataChange(DataSnapshot snapshot)
            {
                //throw new NotImplementedException();

                //Grab Single Item from child name of the user branch

                resturant_name = snapshot.Child("name").Value.ToString();

                //Console.WriteLine(resturant_name);


            }

        }
      
        public class Menu_ValueEventListener : Java.Lang.Object, Firebase.Database.IValueEventListener
        {

            public void OnCancelled(DatabaseError error)
            {
                throw new NotImplementedException();
            }

            public void OnDataChange(DataSnapshot snapshot)
            {
                throw new NotImplementedException();

               
            }

        }

        /*
        public class Menu_ChildEventListener : Java.Lang.Object, Firebase.Database.IChildEventListener
        {
            public void OnCancelled(DatabaseError error)
            {
                throw new NotImplementedException();
            }

            public void OnChildAdded(DataSnapshot snapshot, string previousChildName)
            {
                throw new NotImplementedException();
            }

            public void OnChildChanged(DataSnapshot snapshot, string previousChildName)
            {
                throw new NotImplementedException();
            }

            public void OnChildMoved(DataSnapshot snapshot, string previousChildName)
            {
                throw new NotImplementedException();
            }

            public void OnChildRemoved(DataSnapshot snapshot)
            {
                throw new NotImplementedException();
            }
        }

    */

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
