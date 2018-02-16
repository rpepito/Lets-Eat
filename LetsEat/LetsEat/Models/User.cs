using System;
using System.Collections.Generic;
using System.Text;

namespace LetsEat.Models
{
    public class User
    {
        // Variables that will hold the user's information
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        // Empty constructor for user class
        public User() { }

        // Function
        public User(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }
    }
}
