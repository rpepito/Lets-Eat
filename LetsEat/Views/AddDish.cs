
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

namespace LetsEat.Views.OwnerSide
{
    [Activity(Label = "AddDish")]
    public class AddDish : Activity
    {

        Button btn_save;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AddDishLayout);
            // Create your application here

            btn_save = FindViewById<Button>(Resource.Id.savebtn);

            btn_save.Click += delegate {

                Toast.MakeText(this, "Dish information as been saved!", ToastLength.Short).Show();

            };
        }

    }
}
