using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using SterlingePOSMerchant.Models;

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

        internal static StringContent StringifyAndEncrypt(dynamic values, bool useHardcodedJson = false)
        {
            string clientkey = Settings.AppSettings.key;
            string clientIV = Settings.AppSettings.iv;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(values);
            //  if (useHardcodedJson)
            //     json = "{\"fullName\":\"ololade GUO ahmed GUO oyebanji GUO\",\"firstName\":\"ololade GUO\",\"middleName\":\"ahmed GUO\",\"lastName\":\"oyebanji GUO\",\"emailAddress\":\"loladekingGUO@gmail.com\",\"phoneNumberPri\":\"+2341810832\",\"phoneNumberSec\":\"+2341810832\",\"address1\":\"chris okafor\",\"address2\":\"chris okafor\",\"timestamp\":\"1612648768\",\"multiStore\":false,\"userRole\":\"07\",\"userName\":\"loladeking GUO\",\"code\":\"0000000009\"}";


            Debug.WriteLine("json before hash is " + json);
            var hash = Settings.Encryption.EncryptAES(json, clientkey, clientIV);
            Debug.WriteLine("hash is " + hash);
            Debug.WriteLine("hardcoded json hash is " + hash);


            return new StringContent(hash, Encoding.UTF8, "application/json");
        }

        public static List<BankInfo> GetbankInfo()
        {
            List<BankInfo> bankInfo = new List<BankInfo>()
            {
                new BankInfo{BankName="STERLING BANK",BankCode="000001"},
                new BankInfo{BankName="KEYSTONE BANK",BankCode="000002"},
                new BankInfo{BankName="FCMB",BankCode="000003"},
                new BankInfo{BankName="UNITED BANK OF AFRICA",BankCode="000004"},
                new BankInfo{BankName="ACCESS BANK PLC(DIAMOND",BankCode="000005"},
                new BankInfo{BankName="JAIZ BANK",BankCode="000006"},
                new BankInfo{BankName="FIDELITY BANK",BankCode="000007"},
                new BankInfo{BankName="POLARIS BANK",BankCode="000008"},
                new BankInfo{BankName="CITI BANK",BankCode="000009"},
                new BankInfo{BankName="ECO BANK",BankCode="000010"},
                new BankInfo{BankName="UNITY BANK",BankCode="000011"},
                new BankInfo{BankName="STANBICITC BANK",BankCode="000012"},
                new BankInfo{BankName="GTB BANK PLC",BankCode="000013"},
                new BankInfo{BankName="Access",BankCode="000014"},
                new BankInfo{BankName="ZENITH BANK",BankCode="000015"},
                new BankInfo{BankName="FIRST BANK OF NIGERIA",BankCode="000016"},
                new BankInfo{BankName="WEMA BANK",BankCode="000017"},
                new BankInfo{BankName="UNION BANK",BankCode="000018"},
                new BankInfo{BankName="ENTERPRISE BANK",BankCode="000019"},
                new BankInfo{BankName="HERITAGE",BankCode="000020"},
                new BankInfo{BankName="STANDARD CHARTERED",BankCode="000021"},
                new BankInfo{BankName="SUNTRUST BANK",BankCode="000022"},
                new BankInfo{BankName="PROVIDUS BANK",BankCode="000023"},
                new BankInfo{BankName="TITAN TRUST BANK",BankCode="000025"},
                new BankInfo{BankName="TAJ BANK ",BankCode="000026"},
                new BankInfo{BankName="GLOBUS BANK ",BankCode="000027"},
            };

            return bankInfo;
        }
    }
}
