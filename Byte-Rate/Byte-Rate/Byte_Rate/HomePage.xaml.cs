using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Byte_Rate
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
    {
        public HomePage ()
		{
			InitializeComponent ();
            Init();
        }

        private void Init()
        {
            Task.Run(async () => {
                 await GetCurrentLocationAsync();
            });
        }

        

        private async Task GetCurrentLocationAsync()
        {
            MyMap.Pins.Clear();
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 1;
            TimeSpan ts = new TimeSpan((Int32)10000);
            var position = await locator.GetPositionAsync(timeout: ts);
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
            var pin = new Pin()
            {
                Position = new Position(position.Latitude, position.Longitude),
                Label = "You"
            };
            MyMap.Pins.Add(pin);
        }

        private void Restaurent_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RestaurentPage());
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }

        private void Search_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RestaurentPage());
        }

        private async void getCurrentLocation_Clicked(object sender, EventArgs e)
        {
            await GetCurrentLocationAsync();
        }
    }
}