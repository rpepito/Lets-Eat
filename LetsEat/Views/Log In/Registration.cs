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
using Firebase.Auth;
using Android.Gms.Tasks;
using static Android.Views.View;

namespace LetsEat.Views.Log_In
{
    [Activity(Label = "Registration")]
    public class Registration : Activity, IOnClickListener, IOnCompleteListener 
    {
        FirebaseAuth auth;
        private Button btn_register;
        private EditText input_email, input_password;
        private RelativeLayout activity_register;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Registration);

            //Initialize Firebase
            auth = FirebaseAuth.GetInstance(MainActivity.app);

            //Initialize layout views
            btn_register = FindViewById<Button>(Resource.Id.btn_register);
            input_email = FindViewById<EditText>(Resource.Id.register_email);
            input_password = FindViewById<EditText>(Resource.Id.register_password);
            activity_register = FindViewById<RelativeLayout>(Resource.Id.activity_register);
            btn_register.SetOnClickListener(this);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_register)
            {
                RegisterUser(input_email.Text, input_password.Text);
            }
        }

        private void RegisterUser(string email, string password)
        {
            auth.CreateUserWithEmailAndPassword(email, password).AddOnCompleteListener(this, this);
        }
        
        public void OnComplete(Task task)   //Adrian 03/28/18 TODO: Change functionality of success and failure
        {
            if (task.IsSuccessful == true)
            {
                Snackbar.Make(activity_register, "Registration Successful", Snackbar.LengthLong).Show();
            }
            else
            {
                Snackbar.Make(activity_register, "Registration Failed ", Snackbar.LengthLong).Show();
            }
        }
    }
}