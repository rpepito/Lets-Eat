
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

namespace LetsEat
{
    [Activity(Label = "MenuPage")]
    public class MenuPage : Android.Support.V4.App.Fragment

    {
        Button add_item_btn;
        ListView menulistView;
        List<string> listDishes = new List<string>();

        private FirebaseUser user;
        private const string FBURL = "https://fir-database-ec02e.firebaseio.com/";

        public async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            user = FirebaseAuth.GetInstance(MainActivity.app).CurrentUser;
            await LoadDish_Data();
            // Create your application here
        }

        public static MenuPage NewInstance()
        {
            var frag1 = new MenuPage { Arguments = new Bundle() };
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
                Dish Dish_info = new Dish();
                Dish_info.Name = item.Object.Name;

                listDishes.Add(Dish_info.Name);

                Console.WriteLine(Dish_info.Name);

            };

            var ListAdapter = new ArrayAdapter<string>(this.Activity, Resource.Layout.DishList, listDishes);
            menulistView.Adapter = ListAdapter;

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.MenuList, null);

            menulistView = view.FindViewById<ListView>(Resource.Id.menulistViewCustomer);


            menulistView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                Toast.MakeText(this.Activity, ((TextView)args.View).Text, ToastLength.Short).Show();
            };

            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            return view;


        }


    }
}
