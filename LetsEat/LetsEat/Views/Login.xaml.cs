using LetsEat.Models;
using LetsEat.Views;
using LetsEat.Views.Owner_Side;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LetsEat.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

        private void SignInProcedure (object sender, EventArgs e)
        {
            User user = new User(UsrName_Entry.Text, Pwd_Entry.Text);
            if (user.UserCheckInfo())
                if (UsrName_Entry.Text.Equals("owner") && Pwd_Entry.Text.Equals("owner123"))
                    OwnerPageTransfer();                                                                            //if the textbox has the hardcoded values, call the owner page!
                else
                    DisplayAlert("Sign In", "Sign In Successful.", "Okay");                                         //If sign in successful, display message
            else
                DisplayAlert("Sign In", message: "Error: Empty or Invalid Username and/or Password.", cancel: "Okay");     //If user enters a blank on either fields (or both) display error
        }

        private async void RegisterProcedure(object sender, EventArgs e) => await Navigation.PushAsync(new Registration());
        private async void OwnerPageTransfer() => await Navigation.PushAsync(new OwnerPage());

    }
}