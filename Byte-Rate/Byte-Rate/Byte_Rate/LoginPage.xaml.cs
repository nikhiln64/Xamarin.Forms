using Byte_Rate.Model_Classes;
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
	public partial class LoginPage : ContentPage
	{
        Constants constants = new Constants();
        
        public LoginPage ()
		{
			InitializeComponent ();
            InitApp();
        }

        private void InitApp()
        {
            foreach (var countryName in constants.SetListValues())
            {
                CountryCodePicker.Items.Add(countryName.CountryName);
                CountryCodePicker.SelectedIndex = 0;
            }
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string countryCodeSelected = null;
            String mobileNumber = mobileNumberEntry.Text;
            String password = passwordEntry.Text;

            if (CountryCodePicker.SelectedIndex > -1)
            {
                countryCodeSelected = constants.SetListValues()[CountryCodePicker.SelectedIndex].CountryCode.ToString();
            }
            if (!String.IsNullOrEmpty(mobileNumber) && !String.IsNullOrEmpty(password))
            {
                var user = new User
                {

                    MobileNumber = Convert.ToInt64(countryCodeSelected + mobileNumber),
                    Password = passwordEntry.Text
                };

                var isValid = AreCredentialsCorrect(user);
                if (isValid)
                {
                    App.IsUserLoggedIn = true;
                    var masterDetailsPage = new MasterDetailsPage();
                    await Navigation.PushAsync(masterDetailsPage);
                    NavigationPage.SetHasNavigationBar(masterDetailsPage, false);
                }
                else
                {
                    loginMessageLabel.Text = "Credentials Mismatch";
                    passwordEntry.Text = string.Empty;
                }
            }
            else {
                loginMessageLabel.Text = "Enter Valid Details";
                mobileNumberEntry.BackgroundColor = Color.Red;
                passwordEntry.BackgroundColor = Color.Red;
            }
           
        }

        bool AreCredentialsCorrect(User user)
        {
            return (user.MobileNumber == Constants.MobileNumber && user.Password == Constants.Password);
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }

        private void ForgetPwd_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgetPasswordPage());
        }

        private void Register_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void On_Eye_Button_Clicked(object sender, EventArgs e)
        {
            
            if (eyeButton.Image.File.Equals("eye.png"))
            {
                passwordEntry.IsPassword = false;
                eyeButton.Image.File = "eyeclose.png";
            }
            else {
                passwordEntry.IsPassword = true;
                eyeButton.Image.File = "eye.png";
            }
            
        }
    }
}