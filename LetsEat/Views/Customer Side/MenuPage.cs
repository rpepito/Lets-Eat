using LetsEat.Views.Owner_Side;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Firebase;
using Firebase.Database;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;

namespace LetsEat
{
    [Activity(Label = "MenuPage")]
    public class MenuPage : Activity
    {
        //Firebase URL
        private const string FBURL = "https://fir-database-ec02e.firebaseio.com/";
        ListView menulistView;
        List<string> listDishes = new List<string>();
        //String selectedDish;


        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MenuList);
            menulistView = FindViewById<ListView>(Resource.Id.menulistViewCustomer);
            await LoadDish_Data();
            //ArrayAdapter<string> ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.DishList, listDishes);

        }

        public async Task LoadDish_Data()
        {
            var firebase = new FirebaseClient(FBURL);

            var items = await firebase
                .Child("menus")
                .Child(Intent.GetStringExtra("uid"))
                .OnceAsync<Dish>();

            foreach (var item in items)
            {
                Dish Dish_info = new Dish();
                Dish_info.Name = item.Object.Name;

                listDishes.Add(Dish_info.Name);

                Console.WriteLine(Dish_info.Name);
            };

            var ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.DishList, listDishes);
            menulistView.Adapter = ListAdapter;
        }
    }
}
