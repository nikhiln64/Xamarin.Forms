using System;
using System.Collections.Generic;
using System.Text;

namespace Byte_Rate.Model_Classes
{
    class Constants
    {
        public static long MobileNumber = 17704033883;
        public static string Password = "password";
        public static string client_id = "L3BCP0MWUYJ5AHS4ELZFABD1AGHYWBI4KMIFWSI5Y4FL21U2";
        public static string client_secret = "BPINNHYL2EPMSQEO5WMET13EAMMXQZIX234ITP1OXDHELPNC";
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
