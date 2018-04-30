
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
<<<<<<< HEAD
=======
using System.Threading.Tasks;
>>>>>>> origin/Ryan-Test2

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

<<<<<<< HEAD
=======
using Firebase;
using Firebase.Database;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;

>>>>>>> origin/Ryan-Test2
namespace LetsEat
{
    [Activity(Label = "Reservations")]
    public class Reservations : ListActivity
    {
<<<<<<< HEAD
        public static readonly List<string> reserveNames = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ReservationLayout);
            // Create your application here

            ListView reserveList = FindViewById<ListView>(Resource.Id.ReserveList);
            ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.ResListItem, reserveNames);
            reserveList.Adapter = ListAdapter;

            //Button pressed to move to Page with Registration
            Button reservePageButton = FindViewById<Button>(Resource.Id.ReservePageButton);
            reservePageButton.Click += (sender, e) =>
            {
                StartActivity(typeof(ReservePageActivity));
            };
        }
=======
        //Firebase URL
        private const string FBURL = "https://fir-database-ec02e.firebaseio.com/";

        //EditText reservationText;
        //Button reserveButton;
        ProgressBar circular_progress;
        ListView listView;
        List<Reservation> listReservations = new List<Reservation>();
        //ArrayAdapter<string> adapter;
        Views.CustomerSide.ListViewAdapter adapter;
        Reservation selectedReservation;
        //ListView reserveList;
        //static readonly List<string> reserveNames = new List<string>();

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ReservePage);

            //var reserveNum = Intent.GetStringExtra("reserve_time");
            //var reserveNames = Intent.Extras.GetStringArrayList("list_reservations") ?? new string[0];
            //this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, reserveNames);

            //reservationText = FindViewById<EditText>(Resource.Id.ReservationText);
            //reserveButton = FindViewById<Button>(Resource.Id.ReservationButton);
            circular_progress = FindViewById<ProgressBar>(Resource.Id.circularProgress);

            //*
            //adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, reserveNames);
            listView = (ListView)FindViewById(Android.Resource.Id.List);
            //listView.Adapter = adapter;

            listView.ItemClick += (s, e) =>
            {
                Reservation reservation = listReservations[e.Position];
                //selectedReservation = reservation;
                //reservationText.Text = reservation.name;
                //input_email.Text = account.email;
                //var listView = sender as ListView;
                //Android.Widget.Toast.MakeText(this, reservation.name + "/n" + reservation.time, Android.Widget.ToastLength.Short).Show();
                
            };

            await LoadData();
            //*/
        }

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
        private async void DeleteUser(string uid)  
        {  
            var firebase = new FirebaseClient(FirebaseURL);  
            await firebase.Child("users").Child(uid).DeleteAsync();  
            await LoadData();  
        }  
        private async void CreateResData()
        {
            Reservation reservation = new Reservation();
            reservation.name = reservationText.Text;
            reservation.time = Intent.GetStringExtra("reserve_time");
            reservation.amount = 1;
            reservation.uid = String.Empty;
            var firebase = new FirebaseClient(FBURL);
            var item = await firebase.Child("reservations").PostAsync<Reservation>(reservation);

            await LoadData();
        }
        //*/
>>>>>>> origin/Ryan-Test2
    }
}
