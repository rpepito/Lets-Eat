
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
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

using Firebase;
using Firebase.Auth;
using Firebase.Database;

namespace LetsEat.Views.CustomerSide
{
    [Activity(Label = "MainPage", Theme = "@style/Theme.DesignDemo")]
    public class MainPage_Customer : AppCompatActivity
    {
        ListView myList;
        DrawerLayout drawerLayout;
        NavigationView navigationView_user;
        FirebaseAuth auth;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainPageLayout_Customer);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.hamburger_drawer);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(true);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout_customer);

            auth = FirebaseAuth.GetInstance(MainActivity.app);


            setupUser_Nav();

            myList = FindViewById<ListView>(Resource.Id.listView);

            myList.Adapter = new MyCustomListAdapter(UserData.Users);

            myList.ItemClick += MyList_ItemClick;


            // Create your application here
        }

        public void setupUser_Nav()
        {

            navigationView_user = FindViewById<NavigationView>(Resource.Id.nav_view_customer);

            navigationView_user.NavigationItemSelected += (sender, e) => {

                e.MenuItem.SetChecked(true);

                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.action_logout:
                        auth.SignOut();
                        StartActivity(typeof(Views.CustomerSide.MainPage));
                        Finish();
                        Toast.MakeText(this, "Successfully Logged Out", ToastLength.Long).Show();

                        break;

                    case Resource.Id.action_home:
                        StartActivity(typeof(Views.CustomerSide.MainPage_Customer));
                        Finish();
                        break;

                    case Resource.Id.action_reservations:
                        Toast.MakeText(this, "Go To Reservation Page", ToastLength.Long).Show();
                        break;

                    default:
                        break;
                }
                drawerLayout.CloseDrawers();
            };

        }


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


        private void MyList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            if (e.Position == 0)
            {
                Intent intent = new Intent(this, typeof(RestaurantPage));
                intent.PutExtra("Name", "Aloha Kitchen");
                intent.PutExtra("Cuisine", "Hawaiian");
                intent.PutExtra("Photo", "images/hawaiian.png");
                StartActivity(intent);
            }

            if (e.Position == 1)
            {
                Intent intent = new Intent(this, typeof(RestaurantPage));
                intent.PutExtra("Name", "Lago - Bellagio");
                intent.PutExtra("Cuisine", "Italian");
                intent.PutExtra("Photo", "images/italian.png");
                StartActivity(intent);
            }

            if (e.Position == 2)
            {
                Intent intent = new Intent(this, typeof(RestaurantPage));
                intent.PutExtra("Name", "Lemongrass - Aria");
                intent.PutExtra("Cuisine", "Thai & Chinese");
                intent.PutExtra("Photo", "images/thai.png");
                StartActivity(intent);
            }

            if (e.Position == 3)
            {
                Intent intent = new Intent(this, typeof(RestaurantPage));
                intent.PutExtra("Name", "Olive Garden");
                intent.PutExtra("Cuisine", "Italian");
                intent.PutExtra("Photo", "images/italian2.png");
                StartActivity(intent);
            }

            if (e.Position == 4)
            {
                Intent intent = new Intent(this, typeof(RestaurantPage));
                intent.PutExtra("Name", "Pho Thanh Huong");
                intent.PutExtra("Cuisine", "Vietnamese");
                intent.PutExtra("Photo", "images/vietnamese.png");
                StartActivity(intent);
            }

            if (e.Position == 5)
            {
                Intent intent = new Intent(this, typeof(RestaurantPage));
                intent.PutExtra("Name", "Roberto's Taco Shop");
                intent.PutExtra("Cuisine", "Mexican");
                intent.PutExtra("Photo", "images/mexican.png");
                StartActivity(intent);
            }

            if (e.Position == 6)
            {
                Intent intent = new Intent(this, typeof(RestaurantPage));
                intent.PutExtra("Name", "SW Steakhouse");
                intent.PutExtra("Cuisine", "Steak");
                intent.PutExtra("Photo", "images/steak.png");
                StartActivity(intent);
            }

            if (e.Position == 7)
            {
                Intent intent = new Intent(this, typeof(RestaurantPage));
                intent.PutExtra("Name", "Sweet Poke");
                intent.PutExtra("Cuisine", "Sushi");
                intent.PutExtra("Photo", "images/sushi.png");
                StartActivity(intent);
            }

            if (e.Position == 8)
            {
                Intent intent = new Intent(this, typeof(RestaurantPage));
                intent.PutExtra("Name", "Twist by Pierre Gagnaire");
                intent.PutExtra("Cuisine", "French");
                intent.PutExtra("Photo", "images/french.png");
                StartActivity(intent);
            }

            if (e.Position == 9)
            {
                Intent intent = new Intent(this, typeof(RestaurantPage));
                intent.PutExtra("Name", "Zuma Restaurant");
                intent.PutExtra("Cuisine", "Japanese");
                intent.PutExtra("Photo", "images/japanese.png");
                StartActivity(intent);
            }
        }
    }
}
