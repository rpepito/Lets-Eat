using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
<<<<<<< HEAD
using gms_Task = Android.Gms.Tasks.Task;

using Firebase.Auth;
using Firebase.Database;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;

using static Android.Views.View;

using Android.Gms.Tasks;
using LetsEat.Views.OwnerSide;
=======
using Android.Support.Design.Widget;
using Android.Gms.Tasks;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using static Android.Views.View;
using LetsEat.Views.Owner_Side;
>>>>>>> origin/Ryan-Test2

namespace LetsEat.Views.Log_In
{
    [Activity(Label = "LoginActivity")]
<<<<<<< HEAD
    public class LoginActivity : Activity, IOnClickListener, IOnCompleteListener
=======
    public class LoginActivity : Activity, IOnCompleteListener, IOnClickListener
>>>>>>> origin/Ryan-Test2
    {
        private Button btn_signIn,  btn_register;
        private EditText input_email, input_password;
        private FirebaseAuth auth;
        private RelativeLayout activity_main;
        private FirebaseDatabase database;
        private DatabaseReference user_reference;
<<<<<<< HEAD

        private const string FBURL = "https://fir-database-ec02e.firebaseio.com/";
=======
        private static string user_type = "nothing right now";
>>>>>>> origin/Ryan-Test2

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LoginLayout);
<<<<<<< HEAD

            database =  FirebaseDatabase.GetInstance(MainActivity.app);
            user_reference = database.GetReference("users");



            //Initialize Firebase
            auth = FirebaseAuth.GetInstance(MainActivity.app);

=======

            database = FirebaseDatabase.GetInstance(MainActivity.app);
            user_reference = database.GetReference("users");

            //Initialize Firebase
            auth = FirebaseAuth.GetInstance(MainActivity.app);

>>>>>>> origin/Ryan-Test2
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

        public void homepage_click(object sender, EventArgs e){
<<<<<<< HEAD

            StartActivity(typeof(Views.CustomerSide.MainPage));
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

        public async void OnComplete(gms_Task task){
            if(task.IsSuccessful){
                var firebase = new FirebaseClient(FBURL);

                var user_type = await firebase
                    .Child("users")
                    .Child(auth.CurrentUser.Uid)
                    .Child("user_type")
                    .OnceSingleAsync<String>();

                if(user_type == "owner"){
                    Toast.MakeText(this, "Login Successful", ToastLength.Long).Show();
                    StartActivity(typeof(Views.Owner_Side.OwnerPage));
                    Finish();
                }

                else if(user_type == "customer"){
                    Toast.MakeText(this, "Login Successful", ToastLength.Long).Show();
                    StartActivity(typeof(Views.CustomerSide.MainPage_Customer));
                    Finish();
                }
            }

            else
            {
                
                Toast.MakeText(this, "Login Failed", ToastLength.Long).Show();
                SetEditing(true);
=======

            StartActivity(typeof(Views.CustomerSide.MainPage));
            Finish();
        }

        public class User_ValueEventListener : Java.Lang.Object, Firebase.Database.IValueEventListener
        {

            public void OnCancelled(DatabaseError error)
            {
                throw new NotImplementedException();
            }

            public void OnDataChange(DataSnapshot snapshot)
            {
                //throw new NotImplementedException();

                //Grab Single Item from child name of the user branch

                user_type = snapshot.Child("user_type").Value.ToString();

                Console.WriteLine(user_type);

            }

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

        public void OnComplete(Task task)  //Adrian 03/28/18 TODO: Change functionality of success and failure
        {
            if (task.IsSuccessful)
            {
        
                user_reference.Child(auth.CurrentUser.Uid).AddListenerForSingleValueEvent(new User_ValueEventListener());
                Console.WriteLine(user_type);
                if (user_type == "customer")
                {
                    Toast.MakeText(this, "Login Success", ToastLength.Long).Show();
                    StartActivity(typeof(Views.CustomerSide.MainPage_Customer));
                    Finish();
                }

                if (user_type == "owner")
                {
                    Toast.MakeText(this, "Login Success", ToastLength.Long).Show();
                    StartActivity(typeof(Views.Owner_Side.OwnerPage));
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
>>>>>>> origin/Ryan-Test2
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