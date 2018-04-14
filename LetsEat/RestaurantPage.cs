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

namespace LetsEat    
{
    [Activity(Label = "Resturant's Info")]
    public class RestaurantPage : Activity
    {
        TextView mName;
        TextView mCuisine;
        ImageView mPhoto;
 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RestaurantPage_Layout);
            mName = FindViewById<TextView>(Resource.Id.nameTextView);
            mCuisine = FindViewById<TextView>(Resource.Id.cuisineTextView);
            mPhoto = FindViewById<ImageView>(Resource.Id.photoImageView);

            mName.Text = Intent.GetStringExtra("Name");
            mCuisine.Text = Intent.GetStringExtra("Cuisine");
            
   




        }
    }
}