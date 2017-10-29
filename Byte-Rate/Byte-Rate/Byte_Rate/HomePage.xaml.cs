using Byte_Rate.Model_Classes;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator.Abstractions;
using Newtonsoft.Json;
using System.Net.Http;

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
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
            var pin = new Pin()
            {
                Position = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude),
                Label = "You"
            };
            MyMap.Pins.Add(pin);
            NearByRestaurents placesApiQueryResponse = await GetNeraByRestaurentsAsync(position);
            List<Pin> pins = GetPins(placesApiQueryResponse);
            foreach (Pin eachPin in pins) {
                MyMap.Pins.Add(eachPin);
            }
        }

        private List<Pin> GetPins(NearByRestaurents placesApiQueryResponse)
        {
            List<Pin> pins = new List<Pin>();
            foreach (Groups groups in placesApiQueryResponse.response.groups){
                foreach (Items item in groups.items) {
                    var pin = new Pin()
                    {
                        Position = new Xamarin.Forms.Maps.Position(item.venue.location.lat, item.venue.location.lng),
                        Label = item.venue.name
                    };
                    pin.Clicked += (object sender, EventArgs e) =>
                    {
                        restaurentButton.IsVisible = true;
                        string isOpen = "Closed";
                        if (item.venue.hours != null)
                        {
                            if (item.venue.hours.isOpen)
                            {
                                isOpen = "Open";
                            }
                        }
                        else {
                            isOpen = "Timings TBD";
                        }
                        restaurentButton.FontAttributes = FontAttributes.Bold;
                        restaurentButton.Font = Font.SystemFontOfSize(NamedSize.Large);
                        restaurentButton.Text = item.venue.name + "\n Rating: " +item.venue.rating +"\n"+isOpen;
                    };
                    pins.Add(pin);
                }
            }
            return pins;
        }

        private async Task<NearByRestaurents> GetNeraByRestaurentsAsync(Plugin.Geolocator.Abstractions.Position position)
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://api.foursquare.com/v2/venues/explore?ll=" + position.Latitude + "," +position.Longitude + "&client_id="+Constants.client_id +"&client_secret="+Constants.client_secret + "&v=20171025&section=food,drinks,coffee&limit=10");
            var result = JsonConvert.DeserializeObject<NearByRestaurents>(response);
            return result;
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