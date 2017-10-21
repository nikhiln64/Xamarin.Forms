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
	public partial class ForgetPasswordPage : ContentPage
    {
		public ForgetPasswordPage ()
		{
			InitializeComponent ();
		}

        private void Verify_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ResetPasswordPage());
        }
    }
}