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
    public static class UserData
    {
        public static List<User> Users { get; private set; }

        static UserData()
        {
            var temp = new List<User>();

            AddUser(temp); //number that show on the page                     
           
            Users = temp.OrderBy(i => i.Name).ToList();
        }

        static void AddUser(List<User> users)
        {
            users.Add(new User()
            {
                Name = "King and I Thai",
                Cuisine = "Thai",
                ImageUrl = "images/thai.png",
                Price = "$$"
            });

            users.Add(new User()
            {
                Name = "Twist by Pierre Gagnaire",
                Cuisine = "French",
                ImageUrl = "images/french.png",
                Price = "$$$$"
            });

            users.Add(new User()
            {
                Name = "SW Steakhouse",
                Cuisine = "Steakhouse",
                ImageUrl = "images/steak.png",
                Price = "$$$"
            });

            users.Add(new User()
            {
                Name = "Zuma Restaurant",
                Cuisine = "Japanese",
                ImageUrl = "images/japanese.png",
                Price = "$$$"
            });

            users.Add(new User()
            {
                Name = "Lago - Bellagio",
                Cuisine = "Italian",
                ImageUrl = "images/italian.png",
                Price = "$$$"
            });
        }
    }
}