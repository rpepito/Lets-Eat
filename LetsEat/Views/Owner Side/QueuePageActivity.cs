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


namespace LetsEat.Views.Owner_Side
{
    [Activity(Label = "Queue")]
    public class QueuePageActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.QueuePage);

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
                }

                StartActivity(typeof(Queue));
            };
        }
    }
}