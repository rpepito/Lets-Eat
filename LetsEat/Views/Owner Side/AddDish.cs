
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
using Firebase;
using Firebase.Auth;

namespace LetsEat.Views.OwnerSide
{
    [Activity(Label = "AddDish")]
    public class AddDish : Activity
    {

        Button btn_save;
        EditText ingredients, description, dish_name, price;
       

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AddDishLayout);
            // Create your application here

            FirebaseUser user = FirebaseAuth.GetInstance(MainActivity.app).CurrentUser;

            btn_save = FindViewById<Button>(Resource.Id.savebtn);
            ingredients = FindViewById<EditText>(Resource.Id.Ingredients);
            description = FindViewById<EditText>(Resource.Id.Description);
            dish_name = FindViewById<EditText>(Resource.Id.DishName);
            price = FindViewById<EditText>(Resource.Id.Price);


            btn_save.Click += delegate {
                Toast.MakeText(this, "Dish information as been saved!", ToastLength.Short).Show();
                Finish();

            };
        }

    }
}
