
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
    [Activity(Label = "Reservations")]
    public class Reservations : ListActivity
    {
        public static readonly List<string> reserveNames = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ReservePageLayout);
            // Create your application here
            /*

            ListView reserveList = FindViewById<ListView>(Resource.Id.ReserveList);
            ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.ResListItem, reserveNames);
            reserveList.Adapter = ListAdapter;

            //Button pressed to move to Page with Registration
            Button reservePageButton = FindViewById<Button>(Resource.Id.ReservePageButton);
            reservePageButton.Click += (sender, e) =>
            {
                StartActivity(typeof(ReservePageActivity));
            };
            //*/
        }
    }
}
