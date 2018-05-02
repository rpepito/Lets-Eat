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


namespace LetsEat
{
    [Activity(Label = "Queue")]
    public class QueuePageActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CustomerQueueLayout);

            EditText queueText = FindViewById<EditText>(Resource.Id.QueueText);
            Button addNameToQueueButton = FindViewById<Button>(Resource.Id.AddNameToQueueButton);


            string queueHolder = string.Empty;
            addNameToQueueButton.Click += (sender, e) =>
            {
                queueHolder = queueText.Text;
                //if text entry is not blank, put in array and then go back to queue page
                if (!(string.IsNullOrWhiteSpace(queueHolder)))
                {
                    Queue.queueNames.Add(queueHolder);
                    addNameToQueueButton.Enabled = true;
                    Toast.MakeText(this, "Successfully entered queue!", ToastLength.Long).Show();
                }

                StartActivity(typeof(Views.CustomerSide.MainPage));
                Finish();
            };
        }
    }
}
