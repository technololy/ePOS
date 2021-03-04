using System;
using SterlingePOSMerchant.Models;

namespace SterlingePOSMerchant.Services
{
    public class DataWareHouse
    {
        public DataWareHouse()
        {
        }

        public static APIService APIServices { get; set; }
        public static CreateMerchant LoggedInMerchantData { get; set; }
        public static string UserNameDuringOnboarding { get; set; }
        public static string PassWordDuringOnboarding { get; set; }
        public static CreateMerchant ErrorLoggingInData { get; set; }
    }
}
