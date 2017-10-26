using System;
using System.Collections.Generic;
using System.Text;

namespace Byte_Rate.Model_Classes
{
    public class User
    {
        public string id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string gender { get; set; }

        public Photo photo { get; set; }

        public long MobileNumber { get; set; }

        public string Password { get; set; }

    }
}
