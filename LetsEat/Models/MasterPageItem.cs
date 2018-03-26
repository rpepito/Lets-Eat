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

namespace LetsEat.Models
{
    public class MasterPageItem
    {
        // Sets title of master page item
        public string Title { get; set; }

        // Sets target to be pulled for use for master detail item
        public Type TargetType { get; set; }
    }
}