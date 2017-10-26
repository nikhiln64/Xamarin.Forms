using System.Collections.Generic;

namespace Byte_Rate.Model_Classes
{
    public class SuggestedFilters
    {
        public string header { get; set; }
        public List<Filters> filters { get; set; }
    }
}