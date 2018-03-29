using Android.App;
using Android.Widget;
using Android.OS;
using static Android.Views.View;
using Android.Content;
using System.Collections.Generic;

namespace LetsEat
{
    [Activity(Label = "LetsEat", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private List<Restaurant> mItems;
        private ListView mListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mListView = FindViewById<ListView>(Resource.Id.myListView);

            mItems = new List<Restaurant>();
            mItems.Add(new Restaurant() { Name = "King and I Thai Restaurant", Cuisine = "Thai", Price = "$$" });
            mItems.Add(new Restaurant() { Name = "Hot and Juicy Seafood", Cuisine = "Seafood", Price = "$$$" });
            mItems.Add(new Restaurant() { Name = "I Love Sushi", Cuisine = "Japanese", Price = "$$$" });

            MyListViewAdapter adapter = new MyListViewAdapter(this, mItems);
            mListView.Adapter = adapter;
        }
    }
}

