using Xamarin.Forms.Maps;

namespace Byte_Rate.CustomRenderer
{
    public class CustomPin : Pin
    {
        public string name { get; set; }
        public double rating { get; set; }
        public string available { get; set; }
    }
}