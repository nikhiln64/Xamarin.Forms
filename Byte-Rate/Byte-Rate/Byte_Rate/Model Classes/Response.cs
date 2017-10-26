using System.Collections.Generic;

namespace Byte_Rate.Model_Classes
{
    public class Response
    {
        public SuggestedFilters suggestedFilters { get; set; }
        public int suggestedRadius { get; set; }
        public string headerLocation { get; set; }
        public string headerFullLocation { get; set; }
        public string headerLocationGranularity { get; set; }

        public int totalResults { get; set; }
        public SuggestedBounds suggestedBounds { get; set; }
        public List<Groups> groups { get; set; }

    }
}