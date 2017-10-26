using System;
using System.Collections.Generic;

namespace Byte_Rate.Model_Classes
{
    public class PreciseLocation
    {
        public string address { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public List<Object> labeledLatLngs { get; set; }
        public int distance { get; set; }
        public string postalCode { get; set; }
        public string cc { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string[] formattedAddress { get; set; }
    }
}