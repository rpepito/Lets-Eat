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
                    Name = "King and I Thai Restaurant" 
                },

                new Restaurant
                {
                    Name = "Pizza Hut"
                },

                new Restaurant
                {
                    Name = "Soho Sushi Burrito"
                },

                new Restaurant
                {
                    Name = "Panda Express"
                }    

            };
		}
	}
}