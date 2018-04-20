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

namespace LetsEat.Views.Log_In
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        private Button signIn;
        private  Button register;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            // Initialize button from layout
            signIn = FindViewById<Button>(Resource.Id.loginButton);
            register = FindViewById<Button>(Resource.Id.registerButton);

            signIn.Click += SignIn_Click;

            

     
        }

        private void SignIn_Click(object sender, System.EventArgs e)
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

        }
    }
}