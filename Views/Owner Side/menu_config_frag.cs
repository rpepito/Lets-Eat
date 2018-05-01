
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;

using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;

namespace LetsEat.Views.OwnerSide
{
    public class menu_config_frag : Android.Support.V4.App.Fragment
    {

        ListView menulistView;
        Toolbar toolbar;
        List<Owner_Side.Dish> listDishes = new List<Owner_Side.Dish>();
        FirebaseUser user;
        private static String restaurant_name;
        private const string FBURL = "https://fir-database-ec02e.firebaseio.com/";

        public override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

            user = FirebaseAuth.GetInstance(MainActivity.app).CurrentUser;
            await LoadUser_Data();

        }

        public static menu_config_frag NewInstance()
        {
            var frag1 = new menu_config_frag { Arguments = new Bundle() };
            return frag1;
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
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.MenuLayout, null);

            toolbar = view.FindViewById<Toolbar>(Resource.Id.menutoolbar);

            menulistView = view.FindViewById<ListView>(Resource.Id.menulistView);

            ((AppCompatActivity)this.Activity).SetActionBar(toolbar);
            ((AppCompatActivity)this.Activity).ActionBar.Title = restaurant_name;

            //var ListAdapter = new ArrayAdapter<string>(this.Activity, Resource.Layout.DishList, );
            //menulistView.Adapter = ListAdapter;

            //menulistView.TextFilterEnabled = true;
            //menulistView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            //{
            //    Toast.MakeText(this.Activity, ((TextView)args.View).Text, ToastLength.Short).Show();
            //};

            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            return view;


        }

    }
}
