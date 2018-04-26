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
        private EditText input_email, input_password, input_name;
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
            input_name = FindViewById<EditText>(Resource.Id.register_name);
            activity_register = FindViewById<RelativeLayout>(Resource.Id.activity_register);
            SpinnerInit();
            btn_register.SetOnClickListener(this);
            SetEditing(true);
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_register)
            {
                Console.WriteLine("Register button pressed.");
                Toast.MakeText(this, "Registering new user...", ToastLength.Long).Show();
                SetEditing(false);
                RegisterUser(input_email.Text, input_password.Text);
            }
        }

        private void RegisterUser(string email, string password)
        {
            auth.CreateUserWithEmailAndPassword(email, password).AddOnCompleteListener(this, this);
        }

        public void OnComplete(Task task)   //Adrian 03/28/18 TODO: Change functionality of success and failure
        {
            FirebaseUser currentUser;

            if (task.IsSuccessful == true)
            {
                currentUser = auth.CurrentUser;
                Console.WriteLine("Created User: " + currentUser.Email);
                Add_AdditionalUserProperties(currentUser);
                Toast.MakeText(this, "Register Success", ToastLength.Long).Show();
                Finish();
            }
            else
            {
                Toast.MakeText(this, "Register Failed", ToastLength.Long).Show();
                SetEditing(true);
                //TODO: Error Checking of registration
            }
        }

        private void SpinnerInit()
        {
            spinner_type = FindViewById<Spinner>(Resource.Id.spinner_type);
            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.user_types, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner_type.Adapter = adapter;
            spinner_type.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(Spinner_ItemSelect);
        }

        private void Spinner_ItemSelect(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            this.selected_Type = spinner.GetItemAtPosition(e.Position).ToString().ToLower();
            Console.WriteLine("Current Spinner Item Selected: " + this.selected_Type);
        }

        private void Add_AdditionalUserProperties(FirebaseUser user)
        {
            DatabaseReference reference = database.GetReference("users");
            Console.WriteLine("Connected to database reference: " + reference.ToString());

            reference.Child(user.Uid).Child("user_type").SetValue(selected_Type);
            Console.WriteLine("Added user_type to database for userID: " + user.Uid);
            reference.Child(user.Uid).Child("name").SetValue(input_name.Text);
            Console.WriteLine("Added name to database for userID: " + user.Uid);
        }

        private void SetEditing(bool enabled)
        {
            input_email.Enabled = enabled;
            input_password.Enabled = enabled;
            input_name.Enabled = enabled;
            spinner_type.Enabled = enabled;
            if (enabled)
            {
                btn_register.Visibility = ViewStates.Visible;
            }
            else
            {
                btn_register.Visibility = ViewStates.Gone;
            }
        }
    }
}