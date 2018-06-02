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
    [Activity(Label = "AddTable")]
    public class AddTable : Activity, IOnClickListener
    {
        Button save_btn;
        EditText tableNumber, currentOccupants, currentBill, maxCapacity;
        private FirebaseUser user;
        private const string FBURL = "https://fir-database-ec02e.firebaseio.com/";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AddTableLayout);
           

            user = FirebaseAuth.GetInstance(MainActivity.app).CurrentUser;

            save_btn = FindViewById<Button>(Resource.Id.savebtn);
            tableNumber = FindViewById<EditText>(Resource.Id.TableNumber);
            currentOccupants = FindViewById<EditText>(Resource.Id.currNum);
            currentBill = FindViewById<EditText>(Resource.Id.currBill);
            maxCapacity = FindViewById<EditText>(Resource.Id.maxCapacity);


            save_btn.SetOnClickListener(this);
        }

        public async void OnClick(View v)
        {
            if (tableNumber.Text == "" || currentOccupants.Text == "" || maxCapacity.Text == "")
            {
                Toast.MakeText(this, "Please fill out all table information entries", ToastLength.Long).Show();
            }
            else
            {
                TableListClass new_table = new TableListClass();
                new_table.TableNumber = tableNumber.Text;
                new_table.CurrentOccupants = currentOccupants.Text;
                new_table.CurrentBill = currentBill.Text;
                new_table.MaxCapacity = maxCapacity.Text;

                var firebase = new FirebaseClient(FBURL);
                var item = await firebase
                    .Child("table_lists")
                    .Child(user.Uid)
                    .PostAsync<TableListClass>(new_table);

                Toast.MakeText(this, "Table has been saved", ToastLength.Long).Show();
                Finish();
            }

        }
    }
}