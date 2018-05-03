
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
    [Activity(Label = "QueuePage")]
    public class QueuePage : Activity //ListActivity
    {
        //Firebase URL
        private const string FBURL = "https://fir-database-ec02e.firebaseio.com/";

        EditText queueText;
        EditText amountText;
        Button queuebutton;

        //ProgressBar circular_progress;


        List<Queuedb> listQueue = new List<Queuedb>();

        string queueHolder = string.Empty;
        string errorMessage = "Could not queue.";
        string confirmMsg = "Success!";
      
         string restaurant_uid;      

        protected override void OnCreate(Bundle savedInstanceState) //async
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CustomerQueueLayout);

            restaurant_uid = Intent.GetStringExtra("uid_restaurant1");
           
            var queueNames = Intent.Extras.GetStringArrayList("list_queue") ?? new string[0];

            queueText = FindViewById<EditText>(Resource.Id.QueueText);
            amountText = FindViewById<EditText>(Resource.Id.AmountText);
            queuebutton = FindViewById<Button>(Resource.Id.AddNameToQueueButton);

           // circular_progress = FindViewById<ProgressBar>(Resource.Id.circularProgress);


            queuebutton.Click += delegate {
                queueHolder = queueText.Text;
                if (!(string.IsNullOrWhiteSpace(queueHolder)))
                {
                    CreateResData();
                    Toast.MakeText(ApplicationContext, confirmMsg, ToastLength.Long).Show();
                    Finish();
                }
                else
                {
                    Toast.MakeText(ApplicationContext, errorMessage, ToastLength.Long).Show();
                }
              

            };
           
        }

        private async void CreateResData()
        {
            Queuedb queuedb = new Queuedb();
            queuedb.name = queueText.Text;
            queuedb.amount = amountText.Text;
            queuedb.uid = String.Empty;
            var firebase = new FirebaseClient(FBURL);
            var item = await firebase.Child("queues")
                                                      .Child(restaurant_uid)  
                                                      .PostAsync<Queuedb>(queuedb);
                                                        
        }
    }
}
