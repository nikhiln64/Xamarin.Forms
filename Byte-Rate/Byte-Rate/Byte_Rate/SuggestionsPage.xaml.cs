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
	public partial class SuggestionsPage : ContentPage
	{
		public SuggestionsPage ()
		{
			InitializeComponent ();
		}


        private void Suggestion_Submit_Button_Clicked(object sender, EventArgs e)
        {
            var masterDetailsPage = new MasterDetailsPage();
            Navigation.PushAsync(masterDetailsPage);
            NavigationPage.SetHasNavigationBar(masterDetailsPage, false);
        }
    }
}