using System;
namespace SterlingePOSMerchant.Models
{
    public class Constants
    {
        public static TimeSpan MaximumConnection => new TimeSpan(0, 1, 0);

        public Constants()
        {
        }
    }

    public class MessageKeys
    {
        // Add product to basket  
        public const string AddProduct = "AddProduct";

        // Filter  
        public const string Filter = "Filter";

        // Change selected Tab programmatically  
        public const string ChangeTab = "ChangeTab";
        public const string Registeration = "Registeration";
        internal const string otp_password = "otp_password";
    }
}
