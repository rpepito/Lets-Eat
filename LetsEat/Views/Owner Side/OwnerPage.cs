using LetsEat.Models;
using LetsEat.Views;

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
using Android.Support.Design.Widget;
using Android.Gms.Tasks;
using static Android.Views.View;
using LetsEat.Views.OwnerSide;

namespace LetsEat.Views.Owner_Side
{
    [Activity(Label = "OwnerPage")]
    public class OwnerPage : Activity, IOnClickListener
    {
        private Button btn_Menu, btn_Table, btn_Queue, btn_Reservation;
        private RelativeLayout activity_main;
        //Toolbar toolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.OwnerPage);

            btn_Menu = FindViewById<Button>(Resource.Id.Menubutton);
            btn_Table = FindViewById<Button>(Resource.Id.Tablebutton);
            btn_Queue = FindViewById<Button>(Resource.Id.Queuebutton);
            btn_Reservation = FindViewById<Button>(Resource.Id.Reservationbutton);
            activity_main = FindViewById<RelativeLayout>(Resource.Id.activity_main);
            //toolbar = FindViewById<Toolbar>(Resource.Id.menutoolbar);


            //SetActionBar(toolbar);
            //ActionBar.Title = "Resturant Name";

            btn_Menu.SetOnClickListener(this);
            btn_Queue.SetOnClickListener(this);
            btn_Table.SetOnClickListener(this);
            btn_Reservation.SetOnClickListener(this);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.Menubutton)
            {
                StartActivity(typeof(Menu));
            }

            else if(v.Id == Resource.Id.Tablebutton)
            {
                StartActivity(typeof(TableList));
            }

            else if (v.Id == Resource.Id.Queuebutton)
            {
                StartActivity(typeof(Queue));
            }

            else if (v.Id == Resource.Id.Reservationbutton)
            {
                StartActivity(typeof(Reservations));
            }
        }

    }
}
