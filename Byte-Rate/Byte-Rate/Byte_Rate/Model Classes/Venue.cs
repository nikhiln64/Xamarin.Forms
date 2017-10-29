using System.Collections.Generic;

namespace Byte_Rate.Model_Classes
{
    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public Contact contact { get; set; }
        public PreciseLocation location { get; set; }
        public List<Categories> categories { get; set; }
        public bool verified { get; set; }
        public Stats stats { get; set; }
        public Price price { get; set; }
        public double rating { get; set; }
        public string ratingColor { get; set; }
        public int ratingSignals { get; set; }
        public bool allowMenuUrlEdit { get; set; }
        public BeenHere beenHere { get; set; }
        public Hours hours { get; set; }
        public Photos photos { get; set; }
        public HearNow hereNow { get; set; }
    }
}