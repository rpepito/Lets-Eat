using LetsEat.Models;
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

        void SignInProcedure (object sender, EventArgs e)
        {
            User user = new User(UsrName_Entry.Text, Pwd_Entry.Text);
            if (user.UserCheckInfo())
                DisplayAlert("Sign In", "Sign In Successful.", "Okay");                                         //If sign in successful, display message
            else
                DisplayAlert("Sign In", message: "Error: Empty Username and/or Password.", cancel: "Okay");     //If user enters a blank on either fields (or both) display error
        }
	}
}