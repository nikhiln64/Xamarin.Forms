using System;
using System.Collections.Generic;
using System.Text;

namespace Byte_Rate.Model_Classes
{
    class Constants
    {
        public static long MobileNumber = 17704033883;
        public static string Password = "password";

        List<CountryCodes> countryCodeList;
        
        public List<CountryCodes> SetListValues()
        {
            countryCodeList = new List<CountryCodes>
            {
                new CountryCodes { CountryName = "United States", CountryCode = 1 },
                new CountryCodes { CountryName = "India", CountryCode = 91 }
            };
            return countryCodeList;
        }
    }
}
