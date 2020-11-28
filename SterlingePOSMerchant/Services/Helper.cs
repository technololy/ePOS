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
    }
}
