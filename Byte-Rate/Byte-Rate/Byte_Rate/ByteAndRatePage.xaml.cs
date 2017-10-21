using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Byte_Rate
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ByteAndRatePage : ContentPage
	{
		public ByteAndRatePage ()
		{
			InitializeComponent ();
		}

        private void FacebookSignUpButton_Clicked(object sender, EventArgs e)
        {

        }

        private void GoogleSignUpButton_Clicked(object sender, EventArgs e)
        {

        }

        private void PhoneSignUpButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void SkipButton_Clicked(object sender, EventArgs e)
        {
            var masterDetailsPage = new MasterDetailsPage();
            Navigation.PushAsync(masterDetailsPage);
            NavigationPage.SetHasNavigationBar(masterDetailsPage, false);
        }
    }
}