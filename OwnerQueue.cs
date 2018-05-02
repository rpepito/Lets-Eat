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
using Android.Support.Design.Widget;
using LetsEat.Views.Owner_Side;

using Firebase;
using Firebase.Database;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;

namespace LetsEat
{
    [Activity(Label = "OwnerQueue")]
    public class OwnerQueue : Activity
    {
        //Firebase URL
        private const string FBURL = "https://fir-database-ec02e.firebaseio.com/";

        // public static readonly List<string> queueNames = new List<string>();
        //ProgressBar circular_progress;
        ListView listView;
        List<Views.OwnerSide.Queuedb> listQueues = new List<Views.OwnerSide.Queuedb>();

        Views.OwnerSide.ListViewQueue adapter;

        Views.OwnerSide.Queuedb selectedQueue;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.QueueLayout);

            // Create your application here
            Button buttonRemoveFromQueue;

            //circular_progress = FindViewById<ProgressBar>(Resource.Id.circularProgress);


            //buttonAddToQueue = FindViewById<Button>(Resource.Id.addToQueueButton);
            buttonRemoveFromQueue = FindViewById<Button>(Resource.Id.removeFromQueueButton);

            listView = (ListView)FindViewById(Android.Resource.Id.List);


            listView.ItemClick += (s, e) =>
            {
                Views.OwnerSide.Queuedb queue = listQueues[e.Position];
                selectedQueue = queue;

            };

            await LoadData();


        }
        private async Task LoadData()
        {
            //circular_progress.Visibility = ViewStates.Visible;
            listView.Visibility = ViewStates.Invisible;
            var firebase = new FirebaseClient(FBURL);
            var items = await firebase
                .Child("queues")
                .OnceAsync<Views.OwnerSide.Queuedb>();
            listQueues.Clear();
            adapter = null;
            foreach (var item in items)
            {
                Views.OwnerSide.Queuedb queue = new Views.OwnerSide.Queuedb();
                queue.uid = item.Key;
                queue.name = item.Object.name;
                //queue.amount = item.Object.amount;

                listQueues.Add(queue);
            }
            adapter = new Views.OwnerSide.ListViewQueue(this, listQueues);
            adapter.NotifyDataSetChanged();
            listView.Adapter = adapter;
           // circular_progress.Visibility = ViewStates.Invisible;
            listView.Visibility = ViewStates.Visible;

        }


    }
}