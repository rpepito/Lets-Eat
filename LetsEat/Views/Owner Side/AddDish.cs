
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
using Firebase.Auth;
using static Android.Views.View;

using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;

namespace LetsEat.Views.Owner_Side
{
    [Activity(Label = "AddDish")]
    public class AddDish : Activity, IOnClickListener
    {

        Button btn_save;
        EditText ingredients, description, dish_name, price;
        private FirebaseUser user;
        private const string FBURL = "https://fir-database-ec02e.firebaseio.com/";


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AddDishLayout);
            // Create your application here

            user = FirebaseAuth.GetInstance(MainActivity.app).CurrentUser;

            btn_save = FindViewById<Button>(Resource.Id.savebtn);
            ingredients = FindViewById<EditText>(Resource.Id.Ingredients);
            description = FindViewById<EditText>(Resource.Id.Description);
            dish_name = FindViewById<EditText>(Resource.Id.DishName);
            price = FindViewById<EditText>(Resource.Id.Price);


            btn_save.SetOnClickListener(this);


        }

        public async void OnClick(View v)
        {
            if (dish_name.Text == "" || ingredients.Text == "" || description.Text == "" || price.Text == "")
            {
                Toast.MakeText(this, "Please fill out all dish information entries", ToastLength.Long).Show();
            }
            else
            {
                Dish new_dish = new Dish();
                new_dish.Name = dish_name.Text;
                new_dish.Description = description.Text;
                new_dish.Ingredients = ingredients.Text;
                new_dish.Price = price.Text;

                var firebase = new FirebaseClient(FBURL);
                var item = await firebase
                    .Child("menus")
                    .Child(user.Uid)
                    .PostAsync<Dish>(new_dish);

                Toast.MakeText(this, "Dish has been saved", ToastLength.Long).Show();
                Finish();
            }

        }
    }

}