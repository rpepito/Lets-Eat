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
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

using Android.Gms.Tasks;
using static Android.Views.View;
using LetsEat.Views.OwnerSide;

namespace LetsEat.Views.Owner_Side
{
    [Activity(Label = "OwnerPage", Theme = "@style/Theme.DesignDemo")]
    public class OwnerPage : AppCompatActivity, IOnClickListener
    {
        private Button btn_Menu, btn_Table, btn_Queue, btn_Reservation;
        private RelativeLayout activity_main;
        DrawerLayout drawerLayout;
        NavigationView navigationView_user;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.OwnerPage);


            btn_Menu = FindViewById<Button>(Resource.Id.Menubutton);
            btn_Table = FindViewById<Button>(Resource.Id.Tablebutton);
            btn_Queue = FindViewById<Button>(Resource.Id.Queuebutton);
            btn_Reservation = FindViewById<Button>(Resource.Id.Reservationbutton);
            activity_main = FindViewById<RelativeLayout>(Resource.Id.activity_main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.hamburger_drawer);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(true);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout_owner);

            setupUser_Nav();

            btn_Menu.SetOnClickListener(this);
            btn_Queue.SetOnClickListener(this);
            btn_Table.SetOnClickListener(this);
            btn_Reservation.SetOnClickListener(this);
        }

        public void setupUser_Nav()
        {

            navigationView_user = FindViewById<NavigationView>(Resource.Id.nav_view_owner);

            navigationView_user.NavigationItemSelected += (sender, e) => {

                e.MenuItem.SetChecked(true);

                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.action_logout:
                        StartActivity(typeof(Views.CustomerSide.MainPage));
                        Finish();
                        Toast.MakeText(this, "Successfully Logged Out", ToastLength.Long).Show();

                        break;

                    case Resource.Id.action_home:
                        StartActivity(typeof(Views.CustomerSide.MainPage_Owner));
                        Finish();
                        break;

                    case Resource.Id.action_ownerpage:
                        StartActivity(typeof(Views.Owner_Side.OwnerPage));
                        Finish();
                        break;

                    default:
                        break;
                }
                drawerLayout.CloseDrawers();
            };

        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {

                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer((int)GravityFlags.Left);

                    return true;

            }
            return base.OnOptionsItemSelected(item);
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
