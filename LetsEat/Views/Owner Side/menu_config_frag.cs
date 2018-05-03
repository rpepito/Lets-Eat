
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using LetsEat.Views.Owner_Side;

namespace LetsEat.Views.OwnerSide
{
    public class menu_config_frag : Android.Support.V4.App.Fragment
    {

        Button add_item_btn;
        ListView menulistView;
        List<string> listDishes = new List<string>();

        private FirebaseUser user;
        private const string FBURL = "https://fir-database-ec02e.firebaseio.com/";

        public override async void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            //Console.WriteLine("OnCreate");
            // Create your fragment here


            user = FirebaseAuth.GetInstance(MainActivity.app).CurrentUser;
            await LoadDish_Data();

        }

        public static menu_config_frag NewInstance()
        {
            var frag1 = new menu_config_frag { Arguments = new Bundle() };
            return frag1;
        }

        public async Task LoadDish_Data()
        {
            
            var firebase = new FirebaseClient(FBURL);

            var items = await firebase
                .Child("menus")
                .Child(user.Uid)
                .OnceAsync<Dish>();
            
            foreach (var item in items)
            {
                Console.WriteLine(item.Key);
                Dish Dish_info = new Dish();
                Dish_info.Name = item.Object.Name;

                Console.WriteLine(Dish_info.Name);

            };

            var ListAdapter = new ArrayAdapter<string>(this.Activity, Resource.Layout.DishList, listDishes);
            menulistView.Adapter = ListAdapter;

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.MenuLayout, null);

            add_item_btn = view.FindViewById<Button>(Resource.Id.add_item_button);

            menulistView = view.FindViewById<ListView>(Resource.Id.menulistView);

            add_item_btn.Click += delegate {
                Intent myIntent = new Intent();
        
                myIntent = new Intent(this.Activity, typeof(AddDish));

                StartActivity(myIntent);

            };

            menulistView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                Toast.MakeText(this.Activity, ((TextView)args.View).Text, ToastLength.Short).Show();
            };

            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            return view;


        }
    }
}
