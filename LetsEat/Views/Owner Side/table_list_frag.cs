
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using LetsEat.Views.Owner_Side;
using Firebase.Auth;
using Firebase.Xamarin.Database;
using System.Threading.Tasks;
using Firebase.Xamarin.Database.Query;

namespace LetsEat.Views.OwnerSide
{
    public class table_list_frag : Android.Support.V4.App.Fragment
    {
        Button add_table_btn;
        ListView tablelistView;
        List<string> tableList = new List<string>();
        private FirebaseUser user;
        private const string FBURL = "https://fir-database-ec02e.firebaseio.com/";

        public override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Start data pull, get current user
            user = FirebaseAuth.GetInstance(MainActivity.app).CurrentUser;
            await LoadTableList_Data();
        }

        public static table_list_frag NewInstance()
        {
            var frag3 = new table_list_frag { Arguments = new Bundle() };
            return frag3;
        }


        public async Task LoadTableList_Data()
        {

            var firebase = new FirebaseClient(FBURL);

            var tables = await firebase
                .Child("table_lists")
                .Child(user.Uid)
                .OnceAsync<TableListClass>();

            foreach (var table in tables)
            {
                TableListClass Table_Info = new TableListClass();
                Table_Info.TableNumber = "Table " + table.Object.TableNumber;

                tableList.Add(Table_Info.TableNumber);

                Console.WriteLine(Table_Info.TableNumber);

            };

            var ListAdapter = new ArrayAdapter<string>(this.Activity, Resource.Layout.TableList, tableList);
            tablelistView.Adapter = ListAdapter;

        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.TableLayout, null);

            add_table_btn = view.FindViewById<Button>(Resource.Id.add_table_button);

            tablelistView = view.FindViewById<ListView>(Resource.Id.tablelistView);

            add_table_btn.Click += delegate {
                Intent myIntent = new Intent();

                myIntent = new Intent(this.Activity, typeof(AddTable));

                StartActivity(myIntent);

            };

            tablelistView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                Toast.MakeText(this.Activity, ((TextView)args.View).Text, ToastLength.Short).Show();
            };

            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            return view;
        }
    }
}
