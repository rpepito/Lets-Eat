using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LetsEat.Views.Customer_Side
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RestaurantList : ContentPage
	{
		public RestaurantList ()
		{
			InitializeComponent ();

            MainListView.ItemsSource = new List<Restaurant>
            {
                new Restaurant
                {
                    Name = "King and I Thai Restaurant", 
                    Cuisine = "Thai"
                },

                new Restaurant
                {
                    Name = "Sushi Samba Las Vegas",
                    Cuisine = "Japanese"
                },

                new Restaurant
                {
                    Name = "Rich Moonen's RM Seafood",
                    Cuisine = "Seafood"
                },

                new Restaurant
                {
                    Name = "Cheesecake Factory",
                    Cuisine = "American"
                }    

            };
		}
	}
}