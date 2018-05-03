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

using LetsEat.Views.Owner_Side;

namespace LetsEat
{  
    public class Reservation
    {
        //public Dish[] order_dishes { get; set; }
        public string uid { get; set; }
        public string name { get; set; }
        public string time { get; set; }
        public string date { get; set; }
        public string amount { get; set; }    
    }
}
