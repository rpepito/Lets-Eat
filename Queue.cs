using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Firebase;
using Firebase.Database;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;


namespace LetsEat
{
    [Activity(Label = "Queue")]
    public class Queue : Activity
    {
        private const string FBURL = "https://fir-database-ec02e.firebaseio.com/";
        EditText queueText;
        EditText amountText;
        Button queuebutton;

        List<Views.OwnerSide.Queuedb> listQueue = new List<Views.OwnerSide.Queuedb>();

        string queueHolder = string.Empty;
        string errmesg = "Queue could not be made";
        string confirmmsg = "success";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.QueueLayout);

            // Create your application here

            queueText = FindViewById<EditText>(Resource.Id.QueueText);
            amountText = FindViewById<EditText>(Resource.Id.AmountText);
            queuebutton = FindViewById<Button>(Resource.Id.AddNameToQueueButton);

            queuebutton.Click += delegate {
                queueHolder = queueText.Text;
                if(!(string.IsNullOrWhiteSpace(queueHolder)))
                {
                    CreateResData();
                    Toast.MakeText(ApplicationContext, confirmmsg, ToastLength.Long).Show();
                }
                else{
                    Toast.MakeText(ApplicationContext, errmesg, ToastLength.Long).Show();
                }
            };
        }


        private async void CreateResData(){
            Views.OwnerSide.Queuedb queuedb = new Views.OwnerSide.Queuedb();
            queuedb.name = queueText.Text;
            queuedb.amount = amountText.Text;
            queuedb.uid = String.Empty;
            var firebase = new FirebaseClient(FBURL);
            var item = await firebase.Child("queues").PostAsync<Views.OwnerSide.Queuedb>(queuedb);
        }
    }
}
