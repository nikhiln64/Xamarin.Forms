using Byte_Rate.Model_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Byte_Rate
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
        Constants constants = new Constants();
        public RegisterPage ()
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

        private void On_Eye_Button_Clicked(object sender, EventArgs e)
        {

            if (eyeButton.Image.File.Equals("eye.png"))
            {
                passwordEntry.IsPassword = false;
                eyeButton.Image.File = "eyeclose.png";
            }
            else
            {
                passwordEntry.IsPassword = true;
                eyeButton.Image.File = "eye.png";
            }

        }

        private void Signup_Button_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(firstNameEntry.Text) && !String.IsNullOrEmpty(lastNameEntry.Text) && !String.IsNullOrEmpty(emailAddressEntry.Text) && !String.IsNullOrEmpty(mobileNumberEntry.Text) && 
                !String.IsNullOrEmpty(passwordEntry.Text) && !String.IsNullOrEmpty(retypePasswordEntry.Text)) {
                if (passwordEntry.Text.Equals(retypePasswordEntry.Text))
                {
                    var emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
                        if (Regex.IsMatch(emailAddressEntry.Text, emailRegex))
                        {
                            var masterDetailsPage = new MasterDetailsPage();
                            Navigation.PushAsync(masterDetailsPage);
                            NavigationPage.SetHasNavigationBar(masterDetailsPage, false);
                        }
                        else
                        {
                            errorLabel.Text = "Invalid Email Address";
                        }
                   
                }
                else
                {
                    passwordEntry.TextColor = Color.Red;
                    retypePasswordEntry.TextColor = Color.Red;
                    errorLabel.Text = "Password Doesn't Match";
                }
            }
            else
            {
                errorLabel.Text = "Missed Something";
            }

        }

        private void On_Retype_Eye_Button_Clicked(object sender, EventArgs e)
        {
            if (retypeEyeButton.Image.File.Equals("eye.png"))
            {
                retypePasswordEntry.IsPassword = false;
                retypeEyeButton.Image.File = "eyeclose.png";
            }
            else
            {
                retypePasswordEntry.IsPassword = true;
                retypeEyeButton.Image.File = "eye.png";
            }
        }

        private void SkipSignUpButton_Clicked(object sender, EventArgs e)
        {
            var masterDetailsPage = new MasterDetailsPage();
            Navigation.PushAsync(masterDetailsPage);
            NavigationPage.SetHasNavigationBar(masterDetailsPage, false);
        }
    }
}