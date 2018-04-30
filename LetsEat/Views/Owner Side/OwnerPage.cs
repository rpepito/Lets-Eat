<<<<<<< HEAD
﻿
=======
﻿using LetsEat.Models;
using LetsEat.Views;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

>>>>>>> origin/Ryan-Test2
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

<<<<<<< HEAD
using System.Threading.Tasks;
using LetsEat.Views.OwnerSide;

using Firebase.Auth;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using System;

namespace LetsEat.Views.Owner_Side
{
    [Activity(Label = "OwnerPage", Theme = "@style/Theme.DesignDemo")]
    public class OwnerPage : AppCompatActivity
    {
        //private Button btn_Menu, btn_Table, btn_Queue, btn_Reservation;
        //private RelativeLayout activity_main;
        //DrawerLayout drawerLayout;
        //NavigationView navigationView_user;
        BottomNavigationView bottom_navigationView;
        //DrawerLayout drawerLayout;
        //NavigationView navigationView_user;


        private FirebaseUser user;
        private const string FBURL = "https://fir-database-ec02e.firebaseio.com/";
        private string restaurant_name = null;

        protected override async void OnCreate(Bundle savedInstanceState)
=======
using Android.Gms.Tasks;
using static Android.Views.View;
using LetsEat.Views.OwnerSide;

namespace LetsEat.Views.Owner_Side
{
    [Activity(Label = "OwnerPage", Theme = "@style/Theme.DesignDemo")]
    public class OwnerPage : AppCompatActivity, IOnClickListener
    {
        private Button btn_Menu, btn_Table, btn_Queue, btn_Reservation;
        private RelativeLayout activity_main;
        DrawerLayout drawerLayout;
        NavigationView navigationView_user;

        protected override void OnCreate(Bundle savedInstanceState)
>>>>>>> origin/Ryan-Test2
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.OwnerPage);

<<<<<<< HEAD
            user = FirebaseAuth.GetInstance(MainActivity.app).CurrentUser;


            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            if(toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.hamburger_drawer);
                SupportActionBar.SetDisplayShowTitleEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
            }

            bottom_navigationView = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            bottom_navigationView.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            await LoadUser_Data();

            LoadFragment(Resource.Id.bottom_menu_config);

            //drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout_owner);

            //setupUser_Nav();
            /*
=======

            btn_Menu = FindViewById<Button>(Resource.Id.Menubutton);
            btn_Table = FindViewById<Button>(Resource.Id.Tablebutton);
            btn_Queue = FindViewById<Button>(Resource.Id.Queuebutton);
            btn_Reservation = FindViewById<Button>(Resource.Id.Reservationbutton);
            activity_main = FindViewById<RelativeLayout>(Resource.Id.activity_main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.hamburger_drawer);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(true);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout_owner);

            setupUser_Nav();

>>>>>>> origin/Ryan-Test2
            btn_Menu.SetOnClickListener(this);
            btn_Queue.SetOnClickListener(this);
            btn_Table.SetOnClickListener(this);
            btn_Reservation.SetOnClickListener(this);
<<<<<<< HEAD
            */
        }

        public async Task LoadUser_Data()
        {
            var firebase = new FirebaseClient(FBURL);

            var user_name = await firebase
                .Child("users")
                .Child(user.Uid)
                .Child("name")
                .OnceSingleAsync<String>();

            restaurant_name = user_name;

            SupportActionBar.Title = restaurant_name;

        }
        /*
=======
        }

>>>>>>> origin/Ryan-Test2
        public void setupUser_Nav()
        {

            navigationView_user = FindViewById<NavigationView>(Resource.Id.nav_view_owner);

            navigationView_user.NavigationItemSelected += (sender, e) => {

                e.MenuItem.SetChecked(true);

                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.action_logout:
                        StartActivity(typeof(Views.CustomerSide.MainPage));
                        Finish();
                        Toast.MakeText(this, "Successfully Logged Out", ToastLength.Long).Show();

                        break;

                    case Resource.Id.action_home:
                        StartActivity(typeof(Views.CustomerSide.MainPage_Owner));
                        Finish();
                        break;

                    case Resource.Id.action_ownerpage:
                        StartActivity(typeof(Views.Owner_Side.OwnerPage));
                        Finish();
                        break;

                    default:
                        break;
                }
                drawerLayout.CloseDrawers();
            };

        }
<<<<<<< HEAD
        */

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }
        /*
=======


>>>>>>> origin/Ryan-Test2
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {

                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer((int)GravityFlags.Left);

                    return true;

            }
            return base.OnOptionsItemSelected(item);
        }
<<<<<<< HEAD
*/
        void LoadFragment(int id)
        {
            Android.Support.V4.App.Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.bottom_menu_config:
                    fragment = menu_config_frag.NewInstance();
                    break;
                case Resource.Id.bottom_queue:
                    fragment = queue_frag.NewInstance();
                    break;
                case Resource.Id.bottom_tablelist:
                    fragment = table_list_frag.NewInstance();
                    break;
                case Resource.Id.bottom_reservations:
                    fragment = reservations_frag.NewInstance();
                    break;
            }

            if (fragment == null)
                return;

            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();
        }

        /*
=======

>>>>>>> origin/Ryan-Test2
        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.Menubutton)
            {
                StartActivity(typeof(Menu));
            }

            else if(v.Id == Resource.Id.Tablebutton)
            {
                StartActivity(typeof(TableList));
            }

            else if (v.Id == Resource.Id.Queuebutton)
            {
                StartActivity(typeof(Queue));
            }

            else if (v.Id == Resource.Id.Reservationbutton)
            {
                StartActivity(typeof(Reservations));
            }
        }
<<<<<<< HEAD
        */
=======

>>>>>>> origin/Ryan-Test2
    }
}
