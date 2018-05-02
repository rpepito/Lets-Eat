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
    public class reservations_frag : Android.Support.V4.App.Fragment
    {
        //Firebase URL
        private const string FBURL = "https://fir-database-ec02e.firebaseio.com/";

        ListView listView;
        //List<string> reservations = new String[] { "Eric", "Test" };
        Views.CustomerSide.ListViewAdapter adapter;
        List<Reservation> listReservations = new List<Reservation>();
        //Reservation selectedReservation;

        Button dequeue_btn;
        FirebaseUser user;

        public override async void OnCreate(Bundle savedInstanceState) //async
        {
            base.OnCreate(savedInstanceState);

            user = FirebaseAuth.GetInstance(MainActivity.app).CurrentUser;

            // Create your fragment here     
            await LoadData();


        }

        public static reservations_frag NewInstance()
        {
            var frag1 = new reservations_frag { Arguments = new Bundle() };
            return frag1;
        }
        //*
        private async Task LoadData()
        {
            //circular_progress.Visibility = ViewStates.Visible;
            // if (listView != null)
            // {
            Console.WriteLine("Loading database...");
            //listView.Visibility = ViewStates.Invisible;
            var firebase = new FirebaseClient(FBURL);
            //*
            var items = await firebase
                .Child("reservations")
                .Child(user.Uid)
                .OnceAsync<Reservation>();
            //listReservations.Clear();

            adapter = null;
            foreach (var item in items)
            {
                Console.WriteLine("Loading items...");
                Console.WriteLine(item.Object.name);
                Reservation reservation = new Reservation();
                reservation.uid = item.Key;
                reservation.name = item.Object.name;
                reservation.time = item.Object.time;
                //reservation.email = item.Object.email;  
                listReservations.Add(reservation);
            }

            Console.WriteLine("Updating adapter...");
            adapter = new Views.CustomerSide.ListViewAdapter(this, listReservations);
            adapter.NotifyDataSetChanged();
            listView.Adapter = adapter;
            listView.TextFilterEnabled = true;

            //circular_progress.Visibility = ViewStates.Invisible;
            //listView.Visibility = ViewStates.Visible;
            // }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.ReservePage, null);

            dequeue_btn = view.FindViewById<Button>(Resource.Id.remove_reservation_button);

            dequeue_btn.Click += delegate {
                Toast.MakeText(this.Activity, "Remove Reservation", ToastLength.Short).Show();
            };
            /*
            Reservation newReservation = new Reservation();
            newReservation.name = "Eric";
            newReservation.time = "9:00 AM";
            listReservations.Add(newReservation);
            */

            listView = (ListView)view.FindViewById(Android.Resource.Id.List);
            adapter = new Views.CustomerSide.ListViewAdapter(this, listReservations);
            adapter.NotifyDataSetChanged();
            listView.Adapter = adapter;
            listView.TextFilterEnabled = true;

            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            return view;
        }


        //*/
    }
}