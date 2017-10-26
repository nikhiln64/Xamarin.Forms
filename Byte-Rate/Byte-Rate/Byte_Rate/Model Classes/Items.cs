using System.Collections.Generic;

namespace Byte_Rate.Model_Classes
{
    public class Items
    {
        public Reasons reasons { get; set; }
        public Venue venue { get; set; }
        public List<Tips> tips { get; set; }
        public string referralId { get; set; }
    }
}