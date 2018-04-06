using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using static Android.Views.View;

namespace LetsEat
{
    [Activity(Label = "LetsEat", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public static FirebaseApp app;
        FirebaseAuth auth;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.Main);

            //Init Firebase  
            InitFirebaseAuth();

            //Adrian 03/28/2018 TODO: Remove below later after editing MainActivity.cs to work with LoginActivity.cs
            StartActivity(typeof(Views.Owner_Side.OwnerPage));    
        }

        private void InitFirebaseAuth()
        {
            var options = new FirebaseOptions.Builder()
              .SetApplicationId("1:100312271278:android:3d79789aa8f833cd")
              .SetApiKey("AIzaSyAH9j_K2-wcnrmxj9hEarZaFvCh6dMsOWw")
              .Build();
            if (app == null)
                app = FirebaseApp.InitializeApp(this, options);
            auth = FirebaseAuth.GetInstance(app);
        }
    }
}

