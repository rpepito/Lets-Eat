
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

using System.Threading.Tasks;
using LetsEat.Views.OwnerSide;

using Firebase.Auth;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using System;

namespace LetsEat.Views.Owner_Side
{
    [Activity(Label = "OwnerPage", Theme = "@style/Theme.DesignDemo")]
    public class OwnerPage : AppCompatActivity
    {
        //private Button btn_Menu, btn_Table, btn_Queue, btn_Reservation;
        //private RelativeLayout activity_main;
        //DrawerLayout drawerLayout;
        //NavigationView navigationView_user;
        BottomNavigationView bottom_navigationView;
        //DrawerLayout drawerLayout;
        //NavigationView navigationView_user;


        private FirebaseUser user;
        private const string FBURL = "https://fir-database-ec02e.firebaseio.com/";
        private string restaurant_name = null;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.OwnerPage);

            user = FirebaseAuth.GetInstance(MainActivity.app).CurrentUser;


            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            if(toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(false);
                SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.hamburger_drawer);
                SupportActionBar.SetDisplayShowTitleEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(false);
            }

            bottom_navigationView = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
            bottom_navigationView.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            await LoadUser_Data();

            LoadFragment(Resource.Id.bottom_menu_config);

            //drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout_owner);

            //setupUser_Nav();
            /*
            btn_Menu.SetOnClickListener(this);
            btn_Queue.SetOnClickListener(this);
            btn_Table.SetOnClickListener(this);
            btn_Reservation.SetOnClickListener(this);
            */
        }

        public async Task LoadUser_Data()
        {
            var firebase = new FirebaseClient(FBURL);

            var user_name = await firebase
                .Child("users")
                .Child(user.Uid)
                .Child("name")
                .OnceSingleAsync<String>();

            restaurant_name = user_name;

            SupportActionBar.Title = restaurant_name;

        }
        /*
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
        */

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }
        /*
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
*/
        void LoadFragment(int id)
        {
            Android.Support.V4.App.Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.bottom_menu_config:
                    fragment = menu_config_frag.NewInstance();
                    break;
                case Resource.Id.bottom_queue:
                    fragment = queue_frag.NewInstance();
                    break;
                case Resource.Id.bottom_tablelist:
                    fragment = table_list_frag.NewInstance();
                    break;
                case Resource.Id.bottom_reservations:
                    fragment = reservations_frag.NewInstance();
                    break;
            }

            if (fragment == null)
                return;

            SupportFragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                .Commit();
        }

        /*
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
        */
    }
}
