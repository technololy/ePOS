using System;
namespace SterlingePOSMerchant.Settings
{
    public class AppSettings
    {
        public static string iv;
        public static string key;
        public const string ClientId = "mobile-integrator@paythru.ng";
        public const string BaseURL = "http://41.206.23.138:8484/paythru-qr-service/api/";

        public static dynamic AccessToken { get; internal set; }

        public AppSettings()
        {
        }
    }
}
