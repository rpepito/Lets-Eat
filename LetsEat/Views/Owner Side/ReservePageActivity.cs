
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
    [Activity(Label = "@string/reservePage")]
    public class ReservePageActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
<<<<<<< HEAD
=======
            /*
>>>>>>> origin/Ryan-Test2
            SetContentView(Resource.Layout.ReservePage);

            EditText reservationText = FindViewById<EditText>(Resource.Id.ReservationText);
            Button reserveButton = FindViewById<Button>(Resource.Id.ReservationButton);

            string reserveHolder = string.Empty;
            reserveButton.Click += (sender, e) =>
            {
                reserveHolder = reservationText.Text;
                //if text entry is not blank, record as valid item in array then move back to Reservations.cs
                if (!(string.IsNullOrWhiteSpace(reserveHolder)))
                {
                    Reservations.reserveNames.Add(reserveHolder);
                    reserveButton.Enabled = true;
                }

                StartActivity(typeof(Reservations));
            };
<<<<<<< HEAD
=======
        //*/
>>>>>>> origin/Ryan-Test2
        }
    }
}
