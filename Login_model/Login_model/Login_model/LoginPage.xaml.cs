using Login_model.Model_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Login_model
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        Constants constants = new Constants();
        public LoginPage()
        {
            InitializeComponent();
            InitApp();
        }

        private void InitApp()
        {
            
            constants.SetListValues();
            foreach (var countryName in constants.SetListValues()) {
                CountryCodePicker.Items.Add(countryName.CountryName);
            }
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

           

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                MobileNumber = Convert.ToInt64(mobileNumberEntry.Text),
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        private void CountryCodePicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int choosenIndex = CountryCodePicker.SelectedIndex;
            if (choosenIndex > -1) {
                string code= constants.SetListValues()[choosenIndex].CountryCode.ToString();
                DisplayAlert(code, "Selected Value", "OK");
            } 
        }



        bool AreCredentialsCorrect(User user)
        {
            return user.MobileNumber == Constants.MobileNumber && user.Password == Constants.Password;
        }


    }
}