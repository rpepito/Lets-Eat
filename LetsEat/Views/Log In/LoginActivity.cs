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
                Toast.MakeText(this, "Login Success", ToastLength.Long).Show();
                //Adrian 03/28/18 TODO: Add code/function call to update UI
            }
            else
            {
                Toast.MakeText(this, "Login Failed", ToastLength.Long).Show();
            }
        }
    }
}