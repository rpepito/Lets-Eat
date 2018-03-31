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
        private Button btn_register;//, btn_customer, btn_owner;
        private EditText input_email, input_password;
        //private Switch switch_type;
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

            //Initialize layout views
            btn_register = FindViewById<Button>(Resource.Id.btn_register);
            //btn_customer = FindViewById<ToggleButton>(Resource.Id.btn_customer);
            //btn_owner = FindViewById<ToggleButton>(Resource.Id.btn_owner);
            //switch_type = FindViewById<Switch>(Resource.Id.switch_type);
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
            /*else if (v.Id == Resource.Id.btn_customer)
            {
                //btn_owner.Selected = false;
            }
            else if (v.Id == Resource.Id.btn_owner)
            {
                //btn_customer.Selected = false;
            }*/
        }

        private void RegisterUser(string email, string password)
        {
            auth.CreateUserWithEmailAndPassword(email, password).AddOnCompleteListener(this, this);
        }

        public void OnComplete(Task task)   //Adrian 03/28/18 TODO: Change functionality of success and failure
        {
            if (task.IsSuccessful == true)
            {
                Toast.MakeText(this, "Register Success", ToastLength.Long).Show();
                //Adrian 03/28/18 TODO: Add code/function call to update UI for new user
            }
            else
            {   
                Toast.MakeText(this, "Register Failed", ToastLength.Long).Show();
            }
        }

        private void SpinnerInit()
        {
            spinner_type = FindViewById<Spinner>(Resource.Id.spinner_type);
            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.user_types, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner_type.Adapter= adapter;
            spinner_type.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelect);
        }

        private void spinner_ItemSelect(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            this.selected_Type = (String)spinner.GetItemAtPosition(e.Position);
        }
    }
}