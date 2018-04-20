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
    class User
    {
        // Variables that will hold the user's information
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        // Empty constructor for user class
        public User() { }

        // Function that stores User info
        public User(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }

        // Function that checks if user info is entered correctly
        public bool UserCheckInfo()
        {
            if (!this.UserName.Equals("") && !this.Password.Equals("") && (this.Password.Length >= 8))
                return true;
            else
                return false;
        }
    }
}