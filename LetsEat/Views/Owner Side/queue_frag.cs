using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Content;

using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;


namespace LetsEat.Views.OwnerSide
{
    public class queue_frag : Android.Support.V4.App.Fragment
    {
        private const string FBURL = "https://fir-database-ec02e.firebaseio.com/";
      

        // List<Views.OwnerSide.Queuedb> listQueue = new List<Views.OwnerSide.Queuedb>();

        ListView listView;

        Views.CustomerSide.QueueListViewAdapter adapter;
        List<Queuedb> listQueue = new List<Queuedb>();



        FirebaseUser user;

        public override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

            user = FirebaseAuth.GetInstance(MainActivity.app).CurrentUser;

            await LoadData();
        }

        public static queue_frag NewInstance()
        {
            var frag2 = new queue_frag { Arguments = new Bundle() };
            return frag2;
        }

        private async Task LoadData()
        {
            Console.WriteLine("Loading database...");
            var firebase = new FirebaseClient(FBURL);
            
            var items = await firebase
                .Child("queues")
                .Child(user.Uid)
                .OnceAsync<Queuedb>();
            
            adapter = null;

            
            foreach (var item in items)
            {
                Console.WriteLine("Loading items...");                  // ERROR SOMEWHERE IN THIS FUNCTION 5/2
                Console.WriteLine(item.Object.name);
                Queuedb queuedb = new Queuedb();            // FUNCTION + LINES = ERROR??? NULLEXCEPTION CRASH ERROR DUNNO FIX
                Console.WriteLine("Check1");
                queuedb.uid = item.Key;
                Console.WriteLine("Check2");
                queuedb.name = item.Object.name;
                Console.WriteLine("Check3");
                listQueue.Add(queuedb);
                Console.WriteLine("Check4");

            }
            
            

            Console.WriteLine("Updating adapter...");
            adapter = new Views.CustomerSide.QueueListViewAdapter(this, listQueue);
            adapter.NotifyDataSetChanged();
            listView.Adapter = adapter;
            listView.TextFilterEnabled = true;
           
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.OwnerQueueLayout, null);
            Button manualAddtoQueueBtn = view.FindViewById<Button>(Resource.Id.manualAddToQueueButton);
            Button removeFromQueueBtn = view.FindViewById<Button>(Resource.Id.removeFromQueueButton);

           // var queueIntent = new Intent(this, typeof(QueuePage));

            removeFromQueueBtn.Click += delegate {
               Toast.MakeText(this.Activity, "Removing from queue", ToastLength.Short).Show();
            };

            manualAddtoQueueBtn.Click += delegate
            {
                Toast.MakeText(this.Activity, "Navigating to queue page...", ToastLength.Short).Show();
                //StartActivity(queueIntent);
            };
                listView = (ListView)view.FindViewById(Android.Resource.Id.List);
            adapter = new CustomerSide.QueueListViewAdapter(this, listQueue);
            adapter.NotifyDataSetChanged();
            listView.Adapter = adapter;
            listView.TextFilterEnabled = true;

            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            return view;
        }
        
    }
    
}
