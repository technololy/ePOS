using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace SterlingePOSMerchant.Services
{
    public class Helper
    {
        public Helper()
        {
        }

        internal static StringContent Stringify(dynamic values)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(values);
            Debug.WriteLine(json);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        internal static StringContent StringifyAndEncrypt(dynamic values)
        {
            string clientkey = Settings.AppSettings.key;
            string clientIV = Settings.AppSettings.iv;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(values);
            Debug.WriteLine(json);
            var hash = Settings.Encryption.EncryptAES(json, clientkey, clientIV);
            return new StringContent(hash, Encoding.UTF8, "application/json");
        }
    }
}
