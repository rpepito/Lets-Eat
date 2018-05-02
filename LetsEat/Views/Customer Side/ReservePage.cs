
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
using Firebase.Database;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;

namespace LetsEat
{
    [Activity(Label = "ReservePage")]
    public class ReservePage : Activity //ListActivity
    {
        //Firebase URL
        private const string FBURL = "https://fir-database-ec02e.firebaseio.com/";

        EditText reservationText;
        EditText amountText;
        Button reserveButton;
        ProgressBar circular_progress;
       // ListView listView;
        List<Reservation> listReservations = new List<Reservation>();
        //ArrayAdapter<string> adapter;
       // Views.CustomerSide.ListViewAdapter adapter;
       // Reservation selectedReservation;
        //ListView reserveList;
        string reserveHolder = string.Empty;
        string errMessage = "Reservation could not be made: Empty Name";
        string confirmMessage = "Reservation successful!";
        //static readonly List<string> reserveNames = new List<string>();
        string restaurant_uid;

        protected override void OnCreate(Bundle savedInstanceState) //async
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ReservePageLayout);

            restaurant_uid = Intent.GetStringExtra("restaurant_uid");
            var reserveNum = Intent.GetStringExtra("reserve_time");
            var reserveNames = Intent.Extras.GetStringArrayList("list_reservations") ?? new string[0];
           // this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, reserveNames);

            reservationText = FindViewById<EditText>(Resource.Id.ReservationText);
            amountText = FindViewById<EditText>(Resource.Id.AmountText);
            reserveButton = FindViewById<Button>(Resource.Id.ReservationButton);
            circular_progress = FindViewById<ProgressBar>(Resource.Id.circularProgress);

            //*
            //adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, reserveNames);
           // listView = (ListView)FindViewById(Android.Resource.Id.List);
            //listView.Adapter = adapter;
            //
            reserveButton.Click += delegate
            {
                reserveHolder = reservationText.Text;
                if (!(string.IsNullOrWhiteSpace(reserveHolder)))
                {
                    //Intent returnIntent = new Intent(this, typeof(RestaurantPage));
                    //returnIntent.PutExtra("list_return", reserveHolder);
                    //SetResult(Result.Ok, returnIntent);
                    CreateResData();
                    Toast.MakeText(ApplicationContext, confirmMessage + " Time: " + reserveNum, ToastLength.Long).Show();
                    Finish();
                }
                else
                {
                    Toast.MakeText(ApplicationContext, errMessage, ToastLength.Long).Show();
                }

            };
            /*
            listView.ItemClick += (s, e) =>
            {
                Reservation reservation = listReservations[e.Position];
                selectedReservation = reservation;
                reservationText.Text = reservation.name;
                //input_email.Text = account.email;
            };

            //await LoadData();


            //*/
        }
        /*
        private async Task LoadData()
        {
            circular_progress.Visibility = ViewStates.Visible;  
            listView.Visibility = ViewStates.Invisible;  
            var firebase = new FirebaseClient(FBURL);  
            var items = await firebase  
                .Child("reservations")  
                .OnceAsync<Reservation>();  
            listReservations.Clear();  
            adapter = null;  
            foreach (var item in items)  
            {  
                Reservation reservation = new Reservation();  
                reservation.uid = item.Key;  
                reservation.name = item.Object.name;  
                //reservation.email = item.Object.email;  
                listReservations.Add(reservation);  
            }  
            adapter = new Views.CustomerSide.ListViewAdapter(this, listReservations);  
            adapter.NotifyDataSetChanged();  
            listView.Adapter = adapter;  
            circular_progress.Visibility = ViewStates.Invisible;  
            listView.Visibility = ViewStates.Visible;  
        
        }
        /*
        private async void UpdateResData(string name) {
            var firebase = new FirebaseClient(FBURL);
            await firebase.Child("reservations").PutAsync(name);
            await LoadData();
        }
        //*/
        private async void CreateResData() {
            Reservation reservation = new Reservation();
            reservation.name = reservationText.Text;
            reservation.time = Intent.GetStringExtra("reserve_time");
            reservation.amount = amountText.Text;
            reservation.uid = String.Empty;
            var firebase = new FirebaseClient(FBURL);
            var item = await firebase.Child("reservations")
                                     .Child(restaurant_uid)
                                     .PostAsync<Reservation>(reservation);

            //await LoadData();
        }
    }
}
