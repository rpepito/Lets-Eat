
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
    [Activity(Label = "ReservePage")]
    public class ReservePage : ListActivity
    {
        //public static readonly List<string> reserveNames = new List<string>();
        //
        EditText reservationText;
        Button reserveButton;
        //ListView reserveList;
        string reserveHolder = string.Empty;
        string errMessage = "Reservation could not be made: Empty Name";
        string confirmMessage = "Reservation successful!";
        //static readonly List<string> reserveNames = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ReservePageLayout);

            var reserveNum = Intent.GetStringExtra("reserve_time");
            var reserveNames = Intent.Extras.GetStringArrayList("list_reservations") ?? new string[0];
            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, reserveNames);

            reservationText = FindViewById<EditText>(Resource.Id.ReservationText);
            reserveButton = FindViewById<Button>(Resource.Id.ReservationButton);

            //reserveList = FindViewById<ListView>(Resource.Id.ReserveList);
            //*
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, reserveNames);
            ListView listView = (ListView)FindViewById(Android.Resource.Id.List);
            listView.Adapter = adapter;
             //

            reserveButton.Click += delegate
            {
                reserveHolder = reservationText.Text;
                if (!(string.IsNullOrWhiteSpace(reserveHolder)))
                {
                    //reserveNames.Add(reserveHolder);
                    Intent returnIntent = new Intent(this, typeof(RestaurantPage));
                    returnIntent.PutExtra("list_return", reserveHolder);
                    SetResult(Result.Ok, returnIntent);
                    Toast.MakeText(ApplicationContext, confirmMessage + " Time: " + reserveNum, ToastLength.Long).Show();
                    Finish();
                }
                else {
                    Toast.MakeText(ApplicationContext, errMessage, ToastLength.Long).Show();
                }

            };
            //*/
        }
    }
}
