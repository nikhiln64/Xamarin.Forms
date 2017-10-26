using System.Collections.Generic;

namespace Byte_Rate.Model_Classes
{
    public class Groups
    {
        public string type { get; set; }
        public string name { get; set; }
        public List<Items> items { get; set; }
    }
}