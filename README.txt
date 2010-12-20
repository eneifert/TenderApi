Before the Tests will run you need to create a TenderSettings.cs file in TenderApiTests.

Here is a sample file:

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenderApiTests
{
    public class TenderSettings
    {
        public const string Site = "my_site";
        public const string Email = "sample@gmail.com";
        public const string UserName = "user_name";
        public const string Password = "password";
        public const string ApiKey = "your_api_key";
    }
}
