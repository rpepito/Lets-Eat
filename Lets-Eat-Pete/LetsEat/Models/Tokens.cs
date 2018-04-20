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
    public class Tokens
    {
        // Variable descriptions
        // -id: used by the database for information storage identification
        // -accessToken: Will contain the access token received from the server
        // -errDescription: Will hold any error messages received from server
        // -expiration: Contains token expiration
        public int id { get; set;  }
        public string accessToken { get; set; }
        public string errDescription { get; set; }
        public DateTime expiration { get; set; }

        // Empty constructor for the Token Class
        public Tokens() { }
    }
}