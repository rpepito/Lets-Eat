
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

        TextView _dateDisplay;
        Button _dateSelectButton;

        protected override void OnCreate(Bundle savedInstanceState) //async
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ReservePageLayout);
             
            _dateDisplay = FindViewById <TextView> (Resource.Id.date_display);  
            _dateSelectButton = FindViewById <Button> (Resource.Id.date_select_button);  
            _dateSelectButton.Click += DateSelect_OnClick; 

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
            //reservation.order_dishes = null;
            reservation.uid = String.Empty;
            var firebase = new FirebaseClient(FBURL);
            var item = await firebase.Child("reservations")
                                     .Child(restaurant_uid)
                                     .PostAsync<Reservation>(reservation);

            //await LoadData();
        }

        void DateSelect_OnClick(object sender, EventArgs eventArgs) 
        {
            /*
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time) 

            {  
              _dateDisplay.Text = time.ToLongDateString();  
            }); 

            frag.Show(FragmentManager, DatePickerFragment.TAG);  

            Console.WriteLine("Wow");
            */
        } 

    }

    public class DatePickerFragment: DialogFragment,  
    DatePickerDialog.IOnDateSetListener {  
          
        public static readonly string TAG = "X:" + typeof(DatePickerFragment).Name.ToUpper();  
         
        Action <DateTime> _dateSelectedHandler = delegate {};  
        public static DatePickerFragment NewInstance(Action < DateTime > onDateSelected) {  
            DatePickerFragment frag = new DatePickerFragment();  
            frag._dateSelectedHandler = onDateSelected;  
            return frag;  
        }  
        public override Dialog OnCreateDialog(Bundle savedInstanceState) {  
            DateTime currently = DateTime.Now;  
            DatePickerDialog dialog = new DatePickerDialog(Activity, this, currently.Year, currently.Month, currently.Day);  
            return dialog;  
        }  
        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {  
            
            DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);  
             
            _dateSelectedHandler(selectedDate);  
        }  
    } 
}