using System;
using System.Collections.Generic;
using System.Text;

namespace Login_model.Model_Classes
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }

        public long MobileNumber { get; set; }

        public string Password { get; set; }

        public DateTime TimeStamp { get; set; }

    }
}
