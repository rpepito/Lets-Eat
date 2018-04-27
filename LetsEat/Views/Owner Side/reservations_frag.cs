
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace LetsEat.Views.OwnerSide
{
    public class reservations_frag : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.ReservationLayout, null);

            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            return view;
        }

        public static reservations_frag NewInstance()
        {
            var frag1 = new reservations_frag { Arguments = new Bundle() };
            return frag1;
        }
    }
}
