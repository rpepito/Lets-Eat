using Android.App;
using Android.Widget;
using Android.OS;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using static Android.Views.View;
using Android.Support.Design.Widget;
using Android.Gms.Tasks;
using Android.Content;

namespace LetsEat
{
    [Activity(Label = "LetsEat", MainLauncher = true, Icon = "@drawable/icon" )]
    public class MainActivity : Activity
    {
        public static FirebaseApp app;     //Used to get the Firebase instance of our application; Very Important Do Not Delete
        private FirebaseAuth auth;
        private FirebaseUser currentUser;
        //private FirebaseDatabase database;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Init Firebase  
            InitFirebase();

            //Adrian 03/28/2018 TODO: Remove below later after editing MainActivity.cs to work with LoginActivity.cs
            StartActivity(new Intent(this, typeof(Views.CustomerSide.MainPage)));
            Finish();
        }

        /*protected override void OnStart()
        {
            //Check if user is signed in (non-null) and update UI accordingly
            if (auth.CurrentUser != null)
            {
                currentUser = auth.CurrentUser;
                //Adrian 03/28/18 TODO: Add code/function call to update UI
            }
        }*/

        private void InitFirebase()
        {
            var options = new FirebaseOptions.Builder()
              .SetApplicationId("1:100312271278:android:3d79789aa8f833cd")
              .SetApiKey("AIzaSyAH9j_K2-wcnrmxj9hEarZaFvCh6dMsOWw")
              .SetDatabaseUrl("https://fir-database-ec02e.firebaseio.com/")
              .Build();
            if (app == null)
                app = FirebaseApp.InitializeApp(this, options);

            auth = FirebaseAuth.GetInstance(app);
            auth.AuthState += (sender, e) =>
            {
                currentUser = e?.Auth?.CurrentUser;

                if (currentUser != null)
                {

                }
                else
                {

                }
            };

        }
    }
}

