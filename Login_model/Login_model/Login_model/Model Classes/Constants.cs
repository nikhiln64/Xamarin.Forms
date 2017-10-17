using System;
using System.Collections.Generic;
using System.Text;

namespace Login_model.Model_Classes
{
    public class Constants
    {
        public static long MobileNumber = 7704033883;
        public static string Password = "password";

        List<CountryCodes> countryCodeList;

        public List<CountryCodes> SetListValues()
        {
            countryCodeList = new List<CountryCodes>
            {
                new CountryCodes { CountryName = "United States", CountryCode = 1 },
                new CountryCodes { CountryName = "India", CountryCode = 91 },
                new CountryCodes { CountryName = "Canada", CountryCode = 88 },
                new CountryCodes { CountryName = "Germany", CountryCode = 18 }
            };
            return countryCodeList;
        }

    }
}
