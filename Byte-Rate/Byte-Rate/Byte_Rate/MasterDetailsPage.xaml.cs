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
	public partial class MasterDetailsPage : MasterDetailPage
    {
		public MasterDetailsPage ()
		{
			InitializeComponent ();
            Detail = new NavigationPage(new HomePage());

        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }

        private void Favourites_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FavouritesPage());
        }

        private void Trail_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TrialPage());
        }

        private void Social_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SocialPage());
        }

        private void Account_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AccountPage());
        }


        private void Logout_Button_Clicked(object sender, EventArgs e)
        {
            var loginPage = new LoginPage();
            Navigation.PushAsync(loginPage);
            NavigationPage.SetHasNavigationBar(loginPage, false);
        }

        private void Help_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HelpPage());
        }

        private void Suggestions_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SuggestionsPage());
        }
    }
}