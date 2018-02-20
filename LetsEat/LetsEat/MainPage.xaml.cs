//Pull the current class/files from the root
using LetsEat.Models;
using LetsEat.Views;
using LetsEat.Views.Customer_Side;

//Default stuff
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LetsEat
{
	public partial class MainPage : MasterDetailPage
	{
        // Creates nav menu objects of List type from MasterPageItem 
        public List<MasterPageItem> NavMenu { get; set; }

		public MainPage()
		{
			InitializeComponent();

            //Initialize the object based from the class
            NavMenu = new List<MasterPageItem>();

            //Variables that hold each nav menu items
            var page1 = new MasterPageItem() { Title = "Home", TargetType = typeof(RestaurantList) };
            var page2 = new MasterPageItem() { Title = "Login/Register", TargetType = typeof(Login) };

            //Add menu items to nav menu
            NavMenu.Add(page1);
            NavMenu.Add(page2);

            //Set the list to be ItemSource for the list view in the xaml file
            NavDrawer.ItemsSource = NavMenu;

            //Initial navigation (home page)
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(RestaurantList)));

            //Binding stuff
            this.BindingContext = new
            {
                Header = "",
                Footer = "Welcome to Let's Eat!"
            };
        }
        private void SelectedMenuItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }

}
