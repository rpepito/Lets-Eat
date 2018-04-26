
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
using LetsEat.Views.Owner_Side;

namespace LetsEat
{
    [Activity(Label = "Queue")]
    public class Queue : ListActivity
    {
        
        public static readonly List<string> queueNames = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.QueueLayout);

            // Create your application here
            Button buttonAddToQueue, buttonRemoveFromQueue;
            
            buttonAddToQueue = FindViewById<Button>(Resource.Id.addToQueueButton);
            buttonRemoveFromQueue = FindViewById<Button>(Resource.Id.removeFromQueueButton);

            ListView  queueList = FindViewById<ListView>(Resource.Id.QueueList);
            ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.ResListItem, queueNames);
            queueList.Adapter = ListAdapter;

            buttonAddToQueue.Click += (sender, e) =>
            {
                // move owner to a page where they can put in the name for the first person in line
                Toast.MakeText(this, "Adding customer to queue..", ToastLength.Long).Show();
                StartActivity(typeof(QueuePageActivity));
            };
            // gotta connect both buttons with database or make a variable not sure yet 
            // not working yet
            buttonRemoveFromQueue.Click += (sender, e) =>
            {
                Toast.MakeText(this, "Removed customer from queue", ToastLength.Long).Show();
            };


        }

       

    }
}
