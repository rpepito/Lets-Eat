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
using Firebase;
using Firebase.Auth;
using static Android.Views.View;

namespace LetsEat.Views.Log_In
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity, IOnCompleteListener, IOnClickListener
    {
        private Button btn_signIn,  btn_register;
        private EditText input_email, input_password;
        private FirebaseAuth auth;
        private RelativeLayout activity_main;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LoginLayout);

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
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.loginButton)
            {
                LoginUser(input_email.Text, input_password.Text);
            }
            else if (v.Id == Resource.Id.registerButton)
            {
                StartActivity(new Intent(this, typeof(Registration)));
                Finish();
            }
        }
        /*private void SignIn_Click(object sender, System.EventArgs e)
        {
            // Find the edit text boxes defined in LoginLayout, turn into strings
            // EditText usrName = FindViewById<EditText>(Resource.Id.userName);
            // EditText pwd = FindViewById<EditText>(Resource.Id.password);

            //            String UsrName_Entry = usrName.Text;
            //            String Pwd_Entry = pwd.Text;

            // Pass values to User class, check info if correct
            // using UserCheckInfo
            //           User user = new User(UsrName_Entry, Pwd_Entry);\
            // test
            Toast.MakeText(this, "You clicked Login", ToastLength.Short).Show();

        }*/
        private void LoginUser(string email, string password)
        {
            auth.SignInWithEmailAndPassword(email, password).AddOnCompleteListener(this);
        }

        public void OnComplete(Task task)  //Adrian 03/28/18 TODO: Change functionality of success and failure
        {
            if (task.IsSuccessful)
            {
                Snackbar.Make(activity_main, "Login Success", Snackbar.LengthShort).Show();
            }
            else
            {
                Snackbar.Make(activity_main, "Login Failed ", Snackbar.LengthShort).Show();
            }
        }
    }
}