
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



namespace LetsEat.Views.CustomerSide
{
    [Activity(Label = "MainPage")]
    public class MainPage : Activity
    {
        ListView myList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainPageLayout);

            myList = FindViewById<ListView>(Resource.Id.listView);

            myList.Adapter = new MyCustomListAdapter(UserData.Users);

            myList.ItemClick += MyList_ItemClick;


            // Create your application here
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
