using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using gms_Task = Android.Gms.Tasks.Task;

using Firebase.Auth;
using Firebase.Database;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;

using static Android.Views.View;

using Android.Gms.Tasks;

namespace LetsEat.Views.Log_In
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity, IOnClickListener, IOnCompleteListener
    {
        private Button btn_signIn, btn_register;
        private EditText input_email, input_password;
        private FirebaseAuth auth;
        private RelativeLayout activity_main;
        private FirebaseDatabase database;
        private DatabaseReference user_reference;

        private const string FBURL = "https://fir-database-ec02e.firebaseio.com/";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LoginLayout);

            database = FirebaseDatabase.GetInstance(MainActivity.app);
            user_reference = database.GetReference("users");



            //Initialize Firebase
            auth = FirebaseAuth.GetInstance(MainActivity.app);

            // Initialize layout views
            btn_signIn = FindViewById<Button>(Resource.Id.loginButton);
            btn_register = FindViewById<Button>(Resource.Id.registerButton);
            input_email = FindViewById<EditText>(Resource.Id.email);
            input_password = FindViewById<EditText>(Resource.Id.password);
            activity_main = FindViewById<RelativeLayout>(Resource.Id.activity_main);
            btn_register.SetOnClickListener(this);
            btn_signIn.SetOnClickListener(this);
            SetEditing(true);


            TextView homepage = FindViewById<TextView>(Resource.Id.HomePage);
            homepage.Click += homepage_click;
        }

        public void homepage_click(object sender, EventArgs e)
        {

            StartActivity(typeof(Views.Owner_Side.OwnerPage));
            Finish();
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.loginButton)
            {
                if (input_email.Text == "" || input_password.Text == "")
                {
                    Toast.MakeText(this, "Please enter your E-mail & Password", ToastLength.Long).Show();
                }
                else
                {
                    LoginUser(input_email.Text, input_password.Text);
                    SetEditing(false);
                }
            }
            else if (v.Id == Resource.Id.registerButton)
            {
                if (auth.CurrentUser != null)
                {
                    auth.SignOut();
                }
                StartActivity(new Intent(this, typeof(Registration)));
            }
        }

        private void LoginUser(string email, string password)
        {
            auth.SignInWithEmailAndPassword(email, password).AddOnCompleteListener(this);

        }

        public async void OnComplete(gms_Task task)
        {
            if (task.IsSuccessful)
            {
                var firebase = new FirebaseClient(FBURL);

                var user_type = await firebase
                    .Child("users")
                    .Child(auth.CurrentUser.Uid)
                    .Child("user_type")
                    .OnceSingleAsync<String>();

                if (user_type == "owner")
                {
                    Toast.MakeText(this, "Login Successful", ToastLength.Long).Show();
                    StartActivity(typeof(Views.Owner_Side.OwnerPage));
                    Finish();
                }

                else if (user_type == "customer")
                {
                    Toast.MakeText(this, "Login Successful", ToastLength.Long).Show();
                    StartActivity(typeof(Views.CustomerSide.MainPage_Customer));
                    Finish();
                }
            }

            else
            {

                Toast.MakeText(this, "Login Failed", ToastLength.Long).Show();
                SetEditing(true);
            }
        }

        private void SetEditing(bool enabled)
        {
            input_email.Enabled = enabled;
            input_password.Enabled = enabled;
            if (enabled)
            {
                btn_signIn.Visibility = ViewStates.Visible;
                btn_register.Visibility = ViewStates.Visible;
            }
            else
            {
                btn_signIn.Visibility = ViewStates.Gone;
                btn_register.Visibility = ViewStates.Gone;
            }
        }

    }
}