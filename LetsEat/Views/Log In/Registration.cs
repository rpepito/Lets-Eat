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
using Firebase.Database;
using Android.Gms.Tasks;
using static Android.Views.View;

namespace LetsEat.Views.Log_In
{
    [Activity(Label = "Registration")]
    public class Registration : Activity, IOnClickListener, IOnCompleteListener
    {
        private FirebaseAuth auth;
        private FirebaseDatabase database;
        private Button btn_register;
        private EditText input_email, input_password;
        private Spinner spinner_type;
        private RelativeLayout activity_register;
        private String selected_Type;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Registration);

            //Initialize Firebase
            auth = FirebaseAuth.GetInstance(MainActivity.app);
            database = FirebaseDatabase.GetInstance(MainActivity.app);

            //Initialize layout views
            btn_register = FindViewById<Button>(Resource.Id.btn_register);
            input_email = FindViewById<EditText>(Resource.Id.register_email);
            input_password = FindViewById<EditText>(Resource.Id.register_password);
            activity_register = FindViewById<RelativeLayout>(Resource.Id.activity_register);
            SpinnerInit();
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
                FirebaseUser currentUser;

                Toast.MakeText(this, "Register Success", ToastLength.Long).Show();
                //TODO: Add function to add name to firebase database
                currentUser = auth.CurrentUser;
                Add_AdditionalUserProperties(currentUser);
                //Adrian 03/28/18 TODO: Add code/function call to update UI for new user
            }
            else
            {   
                Toast.MakeText(this, "Register Failed", ToastLength.Long).Show();
                //TODO: Error Checking of registration
            }
        }

        private void SpinnerInit()
        {
            spinner_type = FindViewById<Spinner>(Resource.Id.spinner_type);
            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.user_types, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner_type.Adapter= adapter;
            spinner_type.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(Spinner_ItemSelect);
        }

        private void Spinner_ItemSelect(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            this.selected_Type = spinner.GetItemAtPosition(e.Position).ToString().ToLower();
        }

        private void Add_AdditionalUserProperties(FirebaseUser user)
        {
            DatabaseReference mDatabase = database.GetReference("users");

            mDatabase.Child(user.Uid).Child("user_type").SetValue(selected_Type);
        }
    }
}